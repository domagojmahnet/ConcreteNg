using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
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

        public List<Project> GetActiveProjects()
        {
            return dataContext.Projects.Where(p => p.ProjectStatus == ProjectStatusEnum.InProgress).ToList();
        }
    }
}
