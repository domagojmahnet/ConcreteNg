using ConcreteNg.Data;
using ConcreteNg.Repositories;
using ConcreteNg.Repositories.Repositories;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
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
            return unitOfWork.projectRepository.GetActiveProjects(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }

        public TableResponse GetProjects(TableRequest tableRequest)
        {
            return unitOfWork.projectRepository.GetProjects(tableRequest, int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }

        public Project GetProject(int id)
        {
            return unitOfWork.projectRepository.Read(id);
        }

        public TableResponse GetDiaryItems(TableRequest tableRequest, int projectId)
        {
            return unitOfWork.diaryRepository.GetProjectDiaryItems(tableRequest, projectId);
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

        public int AddProject(Project project)
        {
            if (project.ProjectId == -1)
            {
                Employer employer = unitOfWork.employerRepository.Read(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
                unitOfWork.projectRepository.Create(new Project(employer, project.Name, project.ExpectedStartDate, project.ExpectedEndDate, project.ExpectedCost, Shared.Enums.ProjectStatusEnum.ToDo, 0));
            }
            return unitOfWork.Complete();
        }

        public IEnumerable<User> GetEligibleManagers()
        {
            return unitOfWork.userRepository.getEligibleManagers(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value), int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
        }
    }
}
