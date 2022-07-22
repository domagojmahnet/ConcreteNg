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

        public int CreateOrUpdateProjectTask(ProjectTask projectTask)
        {
            /*if (projectTask.ProjectTaskId == -1)
            {
                Employer employer = unitOfWork.employerRepository.Read(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
                unitOfWork.pricingListRepository.Create(new PricingListItem(item.PricingListItemName, item.UnitOfMeasurement, item.Price, employer));
            }
            else
            {
                var pricingListItem = unitOfWork.pricingListRepository.Read(item.PricingListItemId);
                pricingListItem.Price = item.Price;
                pricingListItem.UnitOfMeasurement = item.UnitOfMeasurement;
                pricingListItem.PricingListItemName = item.PricingListItemName;
                unitOfWork.pricingListRepository.Update(pricingListItem);
            }*/
            return unitOfWork.Complete();
        }
    }
}
