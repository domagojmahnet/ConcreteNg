using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Repositories.TableRequestHelpers;
using ConcreteNg.Repositories.TableRequestHelpers.ConcreteFilterSort;
using ConcreteNg.Shared;
using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly DataContext dataContext;
        public ProjectRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
        }

        public List<Project> GetActiveProjects(int employerID)
        {
            return dataContext.Projects.Where(p => p.ProjectStatus == ProjectStatusEnum.InProgress && p.Employer.EmployerId == employerID).ToList();
        }

        public IEnumerable<CostOverview> GetCostOverview(int projectId)
        {
            List<CostOverview> costOverviews = new List<CostOverview>();

            var taskItems = dataContext.Expenses.Where(x => x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId).Select(x => x.ProjectTaskItem.PricingListItem).Distinct().ToList();
            
            foreach(PricingListItem item in taskItems)
            {
                List<PartnerCost> partnerCosts = new List<PartnerCost>();

                var totalLabourCost = dataContext.Expenses.Where(x => 
                    x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId 
                    && x.ProjectTaskItem.PricingListItem.PricingListItemId == item.PricingListItemId 
                    && x.ExpenseType == ExpenseTypeEnum.Standard).Select(x => x.TotalCost).Sum();

                var totalLabourQuantity = dataContext.Expenses.Where(x =>
                    x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId
                    && x.ProjectTaskItem.PricingListItem.PricingListItemId == item.PricingListItemId
                    && x.ExpenseType == ExpenseTypeEnum.Standard).Select(x => x.Quantity).Sum();

                var totalMaterialCost = dataContext.Expenses.Where(x =>
                    x.ProjectTaskItem.ProjectTask.Project.ProjectId == projectId
                    && x.ProjectTaskItem.PricingListItem.PricingListItemId == item.PricingListItemId
                    && x.ExpenseType == ExpenseTypeEnum.Material).Select(x => x.TotalCost).Sum();

                var partners = dataContext.Expenses.Where(x => x.ProjectTaskItem.PricingListItem.PricingListItemId == item.PricingListItemId && x.Partner != null).Select(x => x.Partner).Distinct().ToList();
                float totalCost = (float)(totalLabourCost + totalMaterialCost);
                foreach(Partner partner in partners)
                {
                    var totalPartnerCost = dataContext.Expenses.Where(x =>
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

        public TableResponse GetProjects(TableRequest tableRequest, int employerID)
        {
            TableResponse tableResponse = new TableResponse();

            var query = dataContext.Projects.Where(p => p.Employer.EmployerId == employerID);
            tableResponse.TotalRows = query.Count();

            IFilterTemplate<Project> filterTemplate = FilterFactory<Project>.CreateSortingObject();
            tableResponse.Data = filterTemplate.GetData(query, tableRequest);

            return tableResponse;
        }
    }
}
