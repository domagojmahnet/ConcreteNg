using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        User GetProjectBuyer(int projectId);
        int AssignBuyer(int userId, int projectId);
        User GetManager(int projectId);
        int CreateOrUpdateProject(Project project, int managerId, int employerId);
    }
}
