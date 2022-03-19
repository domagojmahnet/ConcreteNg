using ConcreteNg.Data;
using ConcreteNg.Repositories.Repositories;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly UnitOfWork unitOfWork;

        public ProjectTaskService(DataContext dataContext)
        {
            unitOfWork = new UnitOfWork(dataContext);
        }
        public IEnumerable<ProjectTask> GetProjectTasks(int projectId)
        {
            return unitOfWork.projectTaskRepository.GetProjectTasks(projectId);
        }

        public bool UpdateTaskItem(ProjectTaskItem projectTaskItem)
        {
            return unitOfWork.projectTaskRepository.UpdateProjectTaskItem(projectTaskItem);
        }

        public bool DeleteTaskItem(ProjectTaskItem projectTaskItem)
        {
            return unitOfWork.projectTaskRepository.DeleteProjectTaskItem(projectTaskItem);
        }
    }
}
