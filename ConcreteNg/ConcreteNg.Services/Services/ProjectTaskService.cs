using ConcreteNg.Data;
using ConcreteNg.Repositories;
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
        private readonly IUnitOfWork unitOfWork;

        public ProjectTaskService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
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
