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
        bool UpdateTaskItem(ProjectTaskItem projectTaskItem);
        bool DeleteTaskItem(ProjectTaskItem projectTaskItem);
    }
}
