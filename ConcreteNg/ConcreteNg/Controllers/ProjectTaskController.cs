using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteNg.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService projectTaskService;

        public ProjectTaskController(IProjectTaskService _projectTaskService)
        {
            projectTaskService = _projectTaskService;
        }

        [HttpGet]
        [Route("{projectId}")]
        public async Task<ActionResult<IEnumerable<ProjectTask>>> GetProjectTasks(int projectId)
        {
            var projects = projectTaskService.GetProjectTasks(projectId);
            return Ok(projects);
        }

        [HttpPost]
        [Route("updateItem")]
        public async Task<ActionResult> UpdateProjectItem([FromBody] ProjectTaskItem projectTaskItem)
        {
            if (projectTaskService.UpdateTaskItem(projectTaskItem))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("deleteItem")]
        public async Task<ActionResult> DeleteProjectItem([FromBody] ProjectTaskItem projectTaskItem)
        {
            if (projectTaskService.DeleteTaskItem(projectTaskItem))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
