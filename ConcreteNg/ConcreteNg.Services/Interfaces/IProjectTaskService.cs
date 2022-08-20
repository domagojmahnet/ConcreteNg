using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Interfaces
{
    public interface IProjectTaskService
    {
        IEnumerable<ProjectTask> GetProjectTasks(int projectId);
        int DeleteProjectTask(int id);
        bool UpdateTaskItem(ProjectTaskItem projectTaskItem, int projectId);
        bool DeleteTaskItem(ProjectTaskItem projectTaskItem);
        ProjectTask CreateOrUpdateProjectTask(ProjectTask projectTask, int projectId);
        ProjectTaskItem CreateOrUpdateProjectTaskItem(ProjectTaskItem projectTaskItem, int taskId);
        int DeleteProjectTaskItem(int id);
        Expense AddExpense(Expense expense, int taskItemId, int? pricingListItemId, int? partnerId);
    }
}
