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
