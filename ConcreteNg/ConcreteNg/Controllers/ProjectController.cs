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

        [HttpPost]
        [Route("allProjects")]
        public async Task<ActionResult<TableResponse>> GetProjects([FromBody] TableRequest tableRequest)
        {
            var projects = projectService.GetProjects(tableRequest);
            return Ok(projects);
        }

        [HttpGet]
        [Route("{projectId}")]
        public async Task<ActionResult<Project>> GetProject(int projectId)
        {
            var projects = projectService.GetProject(projectId);
            return Ok(projects);
        }

        [HttpPost]
        [Route("diaryItems/{projectId}")]
        public async Task<ActionResult<TableResponse>> GetDiaryItemsTable([FromBody] TableRequest tableRequest, int projectId)
        {
            var result = projectService.GetDiaryItems(tableRequest, projectId);
            return Ok(result);
        }

        [HttpPost]
        [Route("diaryItem/{projectId}")]
        public async Task<ActionResult<DiaryItem>> AddDiaryItem([FromBody] DiaryItem diary, int projectId)
        {
            var result = projectService.AddDiaryItem(diary, projectId);
            return Ok(result);
        }

        [HttpPost]
        [Route("project")]
        public async Task<ActionResult<DiaryItem>> AddProject([FromBody] Project project)
        {
            var result = projectService.AddProject(project);
            return Ok(result);
        }

        [HttpGet]
        [Route("managers")]
        public async Task<ActionResult<DiaryItem>> GetEligibleManagers()
        {
            var result = projectService.GetEligibleManagers();
            return Ok(result);
        }
    }
}
