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
    internal class ProjectTaskItemRepository : GenericRepository<ProjectTaskItem>, IProjectTaskItemRepository
    {
        private readonly DataContext dataContext;

        public ProjectTaskItemRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
        }

        public void DeleteProjectTaskItems(int taskId)
        {
            var itemsToDelete = dataContext.ProjectTaskItems.Where(x => x.ProjectTask.ProjectTaskId == taskId);
            dataContext.RemoveRange(itemsToDelete);
        }
    }
}
