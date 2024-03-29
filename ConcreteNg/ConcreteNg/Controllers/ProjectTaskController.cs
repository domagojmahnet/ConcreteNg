﻿using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteNg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService projectTaskService;

        public ProjectTaskController(IProjectTaskService _projectTaskService)
        {
            projectTaskService = _projectTaskService;
        }

        [AuthorizeRoles(UserTypeEnum.All)]
        [HttpGet]
        [Route("{projectId}")]
        public async Task<ActionResult<IEnumerable<ProjectTask>>> GetProjectTasks(int projectId)
        {
            var projects = projectTaskService.GetProjectTasks(projectId);
            return Ok(projects);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpPost]
        [Route("projectTask/{projectId}")]
        public async Task<ActionResult<ProjectTask>> CreateOrUpdateProjectTask([FromBody] ProjectTask projectTask, int projectId)
        {
            var result = projectTaskService.CreateOrUpdateProjectTask(projectTask, projectId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpPost]
        [Route("updateItem/{projectId}")]
        public async Task<ActionResult> UpdateProjectItem([FromBody] ProjectTaskItem projectTaskItem, int projectId)
        {
            if (projectTaskService.UpdateTaskItem(projectTaskItem, projectId))
            {
                return Ok();
            }
            return BadRequest();
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpDelete]
        [Route("deleteTask/{id}")]
        public async Task<ActionResult> DeleteProjectTask(int id)
        {
            if (projectTaskService.DeleteProjectTask(id) >= 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpDelete]
        [Route("deleteTaskItem/{id}")]
        public async Task<ActionResult> DeleteProjectTaskItem(int id)
        {
            if (projectTaskService.DeleteProjectTaskItem(id) >= 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpPost]
        [Route("projectTaskItem/{taskId}")]
        public async Task<ActionResult<ProjectTask>> CreateOrUpdateProjectTaskItem([FromBody] ProjectTaskItem projectTaskItem, int taskId)
        {
            var result = projectTaskService.CreateOrUpdateProjectTaskItem(projectTaskItem, taskId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpPost]
        [Route("expense/{taskItemId}/{pricingListItemId}/{partnerId?}")]
        public async Task<ActionResult<Expense>> AddExpense(Expense expense, int taskItemId, int pricingListItemId, int? partnerId = null)
        {
            var result = projectTaskService.AddExpense(expense, taskItemId, pricingListItemId, partnerId);
            return Ok(result);
        }
    }
}
