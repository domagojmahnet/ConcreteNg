using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Interfaces
{
    public interface IProjectTaskRepository : IRepository<ProjectTask>
    {
        List<ProjectTask> GetProjectTasks(int projectId);
    }
}
