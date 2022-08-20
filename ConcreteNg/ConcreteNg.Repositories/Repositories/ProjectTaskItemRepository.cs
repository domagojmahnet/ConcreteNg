using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    public class ProjectTaskItemRepository : GenericRepository<ProjectTaskItem>, IProjectTaskItemRepository
    {
        private readonly DataContext dataContext;

        public ProjectTaskItemRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
        }
    }
}
