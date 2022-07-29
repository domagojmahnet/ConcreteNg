using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    public class ProjectTaskRepository : GenericRepository<ProjectTask>, IProjectTaskRepository
    {
        private readonly DataContext dataContext;
        public ProjectTaskRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
        }

        public List<ProjectTask> GetProjectTasks(int projectId)
        {
            return dataContext.ProjectTasks.Include(p => p.ProjectTaskItems).ThenInclude(item => item.PricingListItem).Where(p => p.Project.ProjectId == projectId).ToList();
        }

        public bool UpdateProjectTaskItem(ProjectTaskItem projectTaskItem)
        {
            dataContext.ProjectTaskItems.Update(projectTaskItem);
            var updated = dataContext.SaveChanges();
            return updated > 0;
        }

        public bool  DeleteProjectTaskItem(ProjectTaskItem projectTaskItem)
        {
            dataContext.ProjectTaskItems.Remove(projectTaskItem);
            var updated = dataContext.SaveChanges();
            return updated > 0;
        }
    }
}
