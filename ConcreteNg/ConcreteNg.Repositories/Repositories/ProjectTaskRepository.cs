using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Shared.Models;
using ConcreteNg.Shared.Models.GraphModels;
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

        public IEnumerable<TaskCompletion> GetTaskCompletions(int projectId)
        {
            var tasks = dataContext.ProjectTasks.Include(p => p.ProjectTaskItems).Where(x => x.Project.ProjectId == projectId);
            List<TaskCompletion> taskCompletions = new List<TaskCompletion>();

            foreach (var task in tasks)
            {
                var totalTaskItems = task.ProjectTaskItems.Count();
                if(totalTaskItems == 0)
                {
                    totalTaskItems = 1;
                }
                var completedTaskItems = task.ProjectTaskItems.Where(x => x.TaskItemStatus == Shared.Enums.ProjectStatusEnum.Completed).Count();
                taskCompletions.Add(new TaskCompletion(totalTaskItems, new List<PieGrid>() { new PieGrid(task.ProjectTaskName, completedTaskItems) }));
            }
            return taskCompletions;
        }
    }
}
