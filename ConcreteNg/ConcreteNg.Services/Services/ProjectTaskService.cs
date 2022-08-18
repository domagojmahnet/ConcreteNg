using ConcreteNg.Data;
using ConcreteNg.Repositories;
using ConcreteNg.Repositories.Repositories;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectTaskService(IHttpContextAccessor _httpContextAccessor, IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            httpContextAccessor = _httpContextAccessor;
        }

        public IEnumerable<ProjectTask> GetProjectTasks(int projectId)
        {
            return unitOfWork.projectTaskRepository.GetProjectTasks(projectId);
        }

        public bool UpdateTaskItem(ProjectTaskItem projectTaskItem)
        {
            unitOfWork.projectTaskItemRepository.Update(projectTaskItem);
            var updated = unitOfWork.Complete();
            return updated > 0;
        }

        public bool DeleteTaskItem(ProjectTaskItem projectTaskItem)
        {
            unitOfWork.projectTaskItemRepository.Delete(projectTaskItem);
            var updated = unitOfWork.Complete();
            return updated > 0;
        }

        public ProjectTask CreateOrUpdateProjectTask(ProjectTask projectTask, int projectId)
        {
            ProjectTask task = new ProjectTask();
            if (projectTask.ProjectTaskId == -1)
            {
                var project = unitOfWork.projectRepository.Read(projectId);
                task.ProjectTaskName = projectTask.ProjectTaskName;
                task.ProjectTaskItems = null;
                task.Project = project;
                unitOfWork.projectTaskRepository.Create(task);
            }
            else
            {
                task = unitOfWork.projectTaskRepository.Read(projectTask.ProjectTaskId);
                task.ProjectTaskName = projectTask.ProjectTaskName;
                unitOfWork.projectTaskRepository.Update(task);
            }

            if(unitOfWork.Complete() == 1 )
            {
                return task;
            }
            throw new Exception();
        }

        public int DeleteProjectTask(int id)
        {
            var task = unitOfWork.projectTaskRepository.Read(id);
            var itemsToDelete = unitOfWork.projectTaskItemRepository.FindAll().Where(x => x.ProjectTask.ProjectTaskId == id).ToList();
            foreach(var item in itemsToDelete)
            {
                var expenses = unitOfWork.expenseRepository.FindAll().Where(x => x.ProjectTaskItem.ProjectTaskItemId == item.ProjectTaskItemId);
                foreach (var expense in expenses)
                {
                    unitOfWork.expenseRepository.Delete(expense);
                }
                unitOfWork.projectTaskItemRepository.Delete(item);
            }
            unitOfWork.projectTaskRepository.Delete(task);
            return unitOfWork.Complete();
        }

        public ProjectTaskItem CreateOrUpdateProjectTaskItem(ProjectTaskItem projectTaskItem, int taskId)
        {
            ProjectTaskItem item = new ProjectTaskItem();
            if (projectTaskItem.ProjectTaskItemId == -1)
            {
                item.ProjectTask = unitOfWork.projectTaskRepository.Read(taskId);
                item.PricingListItem = projectTaskItem.PricingListItem;
                item.TaskItemStatus = Shared.Enums.ProjectStatusEnum.ToDo;
                item.PricingListItem = unitOfWork.pricingListRepository.Read(projectTaskItem.PricingListItem.PricingListItemId);
                unitOfWork.projectTaskItemRepository.Create(item);
            }
            else
            {
                item = unitOfWork.projectTaskItemRepository.Read(projectTaskItem.ProjectTaskItemId);
                item.PricingListItem = unitOfWork.pricingListRepository.Read(projectTaskItem.PricingListItem.PricingListItemId);
                item.StartTime = projectTaskItem.StartTime;
                item.FinishTime = projectTaskItem.FinishTime;
                unitOfWork.projectTaskItemRepository.Update(item);
            }

            if (unitOfWork.Complete() == 1)
            {
                return item;
            }
            throw new Exception();
        }

        public int DeleteProjectTaskItem(int id)
        {
            var itemToDelete = unitOfWork.projectTaskItemRepository.Read(id);
            var expenses = unitOfWork.expenseRepository.FindAll().Where(x => x.ProjectTaskItem.ProjectTaskItemId == id);
            foreach (var expense in expenses)
            {
                unitOfWork.expenseRepository.Delete(expense);
            }
            unitOfWork.projectTaskItemRepository.Delete(itemToDelete);
            return unitOfWork.Complete();
        }

        public Expense AddExpense(Expense expense, int taskItemId, int? pricingListItemId, int? partnerId)
        {
            var item = unitOfWork.projectTaskItemRepository.Read(taskItemId);

            if(expense.ExpenseType == Shared.Enums.ExpenseTypeEnum.Standard)
            {
                var cost = unitOfWork.pricingListRepository.Read(pricingListItemId).Price;
                expense.TotalCost = (float)(cost * expense.Quantity);
            }

            var expenseToAdd = new ExpenseBuilder((float)expense.TotalCost, expense.ExpenseType);

            if(expense.ExpenseType == Shared.Enums.ExpenseTypeEnum.Partner)
            {
                var partner = unitOfWork.partnerRepository.Read(partnerId);
                expenseToAdd.SetPartner(partner);
            }

            if(expense.ExpenseType == Shared.Enums.ExpenseTypeEnum.Standard)
            {
                expenseToAdd.SetQuantity((float)expense.Quantity);
            }

            var result = expenseToAdd.Build();
            result.ProjectTaskItem = item;
            unitOfWork.expenseRepository.Create(result);
            if (unitOfWork.Complete() == 1)
            {
                return result;
            }
            throw new Exception();
        }
    }
}
