using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Repositories.SortHelpers.Factories;
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

        public List<Project> GetProjects(int employerID)
        {
            Func<Project, Object> orderByFunction = project => ProjectSortStrategyFactory.GetStrategy("budget").Sort(project);

            return dataContext.Projects.Where(p => p.Employer.EmployerId == employerID).SortBy(SortDirectionEnum.Descending, orderByFunction).ToList();
        }
    }
}
