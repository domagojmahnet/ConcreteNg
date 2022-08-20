using ConcreteNg.Shared.Models;
using ConcreteNg.Shared.Models.GraphModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<Project> GetActiveProjects();
        Project GetProject(int id);
        TableResponse GetProjects(TableRequest tableRequest);
        TableResponse GetDiaryItems(TableRequest tableRequest, int projectId);
        DiaryItem AddDiaryItem(DiaryItem diaryItem, int projectId);
        int CreateOrUpdateProject(Project project, int managerId);
        IEnumerable<User> GetEligibleManagers();
        IEnumerable<CostOverview> GetCostOverview(int projectId);
        User GetProjectBuyer (int projectId);
        int AssignBuyer(int userId, int projectId);
        GraphData GetGraphData(int projectId);
        int UpdateProjectStatus(int status, int projectId);
        User GetManager(int projectId);
    }
}
