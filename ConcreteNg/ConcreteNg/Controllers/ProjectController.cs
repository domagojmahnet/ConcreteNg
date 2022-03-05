using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ConcreteNg.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService _projectService)
        {
            projectService = _projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetActiveProjects()
        {
            var projects = projectService.GetActiveProjects();
            return Ok(projects);
        }

        [HttpGet]
        [Route("allProjects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = projectService.GetProjects();
            return Ok(projects);
        }

        [HttpGet]
        [Route("{projectId}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProject(int projectId)
        {
            var projects = projectService.GetProject(projectId);
            return Ok(projects);
        }


    }
}
