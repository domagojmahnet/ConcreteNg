using ConcreteNg.Data;
using ConcreteNg.Repositories;
using ConcreteNg.Repositories.Repositories;
using ConcreteNg.Repositories.TableRequestHelpers;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using ConcreteNg.Shared.Models.GraphModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectService(IHttpContextAccessor _httpContextAccessor, IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            httpContextAccessor = _httpContextAccessor;
        }

        public IEnumerable<Project> GetActiveProjects()
        {
            var query = unitOfWork.projectRepository.FindAll().Where(p => (p.ProjectStatus == ProjectStatusEnum.InProgress || p.ProjectStatus == ProjectStatusEnum.ToDo) && p.Employer.EmployerId == int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
            if ((UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value) != UserTypeEnum.Administrator)
            {
                int userId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                query = query.Where(x => x.Users.Any(u => u.UserId == userId));
            }
            var projects = query.ToList();
            foreach(var project in projects)
            {
                project.CurrentCost = (float)unitOfWork.expenseRepository.FindAll().Where(x => x.ProjectTaskItem.ProjectTask.Project.ProjectId == project.ProjectId).Select(x => x.TotalCost).Sum();
            }
            return projects;
        }

        public TableResponse GetProjects(TableRequest tableRequest)
        {
            TableResponse tableResponse = new TableResponse();

            var query = unitOfWork.projectRepository.FindAll().Where(p => p.Employer.EmployerId == int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
            if ((UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value) != UserTypeEnum.Administrator)
            {
                int userId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                query = query.Where(x => x.Users.Any(u => u.UserId == userId));
            }
            tableResponse.TotalRows = query.Count();

            IFilterTemplate<Project> filterTemplate = FilterFactory<Project>.CreateSortingObject();
            tableResponse.Data = filterTemplate.GetData(query, tableRequest);

            return tableResponse;
        }

        public Project GetProject(int id)
        {
            var project = unitOfWork.projectRepository.Read(id);
            project.CurrentCost = (float)unitOfWork.expenseRepository.FindAll().Where(x => x.ProjectTaskItem.ProjectTask.Project.ProjectId == id).Select(x => x.TotalCost).Sum();
            return project;
        }

        public TableResponse GetDiaryItems(TableRequest tableRequest, int projectId)
        {
            TableResponse tableResponse = new TableResponse();

            var query = unitOfWork.diaryRepository.FindAll().Where(x => x.Project.ProjectId == projectId);
            tableResponse.TotalRows = query.Count();

            IFilterTemplate<DiaryItem> filterTemplate = FilterFactory<DiaryItem>.CreateSortingObject();
            tableResponse.Data = filterTemplate.GetData(query, tableRequest);

            return tableResponse;
        }

        public DiaryItem AddDiaryItem(DiaryItem diaryItem, int projectId)
        {
            var project = unitOfWork.projectRepository.Read(projectId);
            diaryItem = new DiaryItem(DateTime.UtcNow, diaryItem.Description, project);

            unitOfWork.diaryRepository.Create(diaryItem);
            if (unitOfWork.Complete() == 1)
            {
                return diaryItem;
            }
            throw new Exception();
        }

        public int AddProject(Project project, int managerId)
        {
            Employer employer = unitOfWork.employerRepository.Read(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
            var projectToAdd = new Project(employer, project.Name, project.ExpectedStartDate, project.ExpectedEndDate, project.ExpectedCost, Shared.Enums.ProjectStatusEnum.ToDo, 0);
            var manager = unitOfWork.userRepository.Read(managerId);
            projectToAdd.Users = new List<User>() { manager};
            unitOfWork.projectRepository.Create(projectToAdd);
            return unitOfWork.Complete();
        }

        public IEnumerable<User> GetEligibleManagers()
        {
            int id = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            User user = unitOfWork.userRepository.FindAll().FirstOrDefault(x => x.UserId == id);
            if (user.UserType == UserTypeEnum.Administrator)
            {
                List<User> users = unitOfWork.userRepository.FindAll().Where(x => x.Employer.EmployerId == int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value) && x.UserType == UserTypeEnum.Manager).ToList();
                foreach (User fetchedUser in users)
                {
                    fetchedUser.Password = null;
                }
                return users;
            }
            user.Password = null;
            return new List<User>() { user };
        }

        public IEnumerable<CostOverview> GetCostOverview(int projectId)
        {
            List<CostOverview> costOverviews = new List<CostOverview>();

            var taskItems = unitOfWork.expenseRepository.FindAll().Where(x => x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId).Select(x => x.ProjectTaskItem.PricingListItem).Distinct().ToList();

            foreach (PricingListItem item in taskItems)
            {
                List<PartnerCost> partnerCosts = new List<PartnerCost>();

                var totalLabourCost = unitOfWork.expenseRepository.FindAll().Where(x =>
                    x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId
                    && x.ProjectTaskItem.PricingListItem.PricingListItemId == item.PricingListItemId
                    && x.ExpenseType == ExpenseTypeEnum.Standard).Select(x => x.TotalCost).Sum();

                var totalLabourQuantity = unitOfWork.expenseRepository.FindAll().Where(x =>
                    x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId
                    && x.ProjectTaskItem.PricingListItem.PricingListItemId == item.PricingListItemId
                    && x.ExpenseType == ExpenseTypeEnum.Standard).Select(x => x.Quantity).Sum();

                var totalMaterialCost = unitOfWork.expenseRepository.FindAll().Where(x =>
                    x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId
                    && x.ProjectTaskItem.PricingListItem.PricingListItemId == item.PricingListItemId
                    && x.ExpenseType == ExpenseTypeEnum.Material).Select(x => x.TotalCost).Sum();

                var partners = unitOfWork.expenseRepository.FindAll().Where(x => x.ProjectTaskItem.PricingListItem.PricingListItemId == item.PricingListItemId && x.Partner != null).Select(x => x.Partner).Distinct().ToList();
                float totalCost = (float)(totalLabourCost + totalMaterialCost);
                foreach (Partner partner in partners)
                {
                    var totalPartnerCost = unitOfWork.expenseRepository.FindAll().Where(x =>
                        x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId
                        && x.ProjectTaskItem.PricingListItem.PricingListItemId == item.PricingListItemId
                        && x.ExpenseType == ExpenseTypeEnum.Partner && x.Partner.PartnerId == partner.PartnerId).Select(x => x.TotalCost).Sum();
                    totalCost = totalCost + (float)totalPartnerCost;
                    partnerCosts.Add(new PartnerCost(partner.Name, (float)totalPartnerCost));
                }
                costOverviews.Add(new CostOverview(item.PricingListItemName, (float)totalMaterialCost, (float)totalLabourCost, (float)totalLabourQuantity, item.UnitOfMeasurement, partnerCosts, totalCost));
            }
            return costOverviews;
        }

        public User GetProjectBuyer(int projectId)
        {
            return unitOfWork.projectRepository.GetProjectBuyer(projectId);
        }

        public int AssignBuyer(int userId, int projectId)
        {
            return unitOfWork.projectRepository.AssignBuyer(userId, projectId);
        }

        public GraphData GetGraphData(int projectId)
        {
            var taskCompletions = unitOfWork.projectTaskRepository.GetTaskCompletions(projectId);

            var expenses = unitOfWork.expenseRepository.FindAll().Where(x => x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId);
            var labourExpenses = (float)expenses.Where(x => x.ExpenseType == ExpenseTypeEnum.Standard).Select(x => x.TotalCost).Sum();
            var materialExpenses = (float)expenses.Where(x => x.ExpenseType == ExpenseTypeEnum.Material).Select(x => x.TotalCost).Sum();
            var partnerExpenses = (float)expenses.Where(x => x.ExpenseType == ExpenseTypeEnum.Partner).Select(x => x.TotalCost).Sum();
            List<PieGrid> gaugeData = new List<PieGrid>() { new PieGrid("Labour", labourExpenses), new PieGrid("Material", materialExpenses), new PieGrid("Partners", partnerExpenses), };


            return new GraphData(taskCompletions, gaugeData);
        }
    }
}
