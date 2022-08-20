using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using ConcreteNg.Shared.Models.GraphModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ConcreteNg.Controllers
{
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
        [Route("project/{managerId}")]
        public async Task<ActionResult<DiaryItem>> CreateOrUpdateProject([FromBody] Project project, int managerId)
        {
            var result = projectService.CreateOrUpdateProject(project, managerId);
            return Ok(result);
        }

        [HttpGet]
        [Route("managers")]
        public async Task<ActionResult<DiaryItem>> GetEligibleManagers()
        {
            var result = projectService.GetEligibleManagers();
            return Ok(result);
        }

        [HttpGet]
        [Route("costOverview/{projectId}")]
        public async Task<ActionResult<CostOverview>> GetCostOverview(int projectId)
        {
            var result = projectService.GetCostOverview(projectId);
            return Ok(result);
        }

        [HttpGet]
        [Route("projectBuyer/{projectId}")]
        public async Task<ActionResult<User>> GetProjectBuyer(int projectId)
        {
            var result = projectService.GetProjectBuyer(projectId);
            return Ok(result);
        }

        [HttpGet]
        [Route("assignBuyer/{userId}/{projectId}")]
        public async Task<ActionResult> AssignBuyer(int userId, int projectId)
        {
            var result = projectService.AssignBuyer(userId, projectId);
            return Ok(result);
        }

        [HttpGet]
        [Route("graphData/{projectId}")]
        public async Task<ActionResult<GraphData>> GetGraphData(int projectId)
        {
            var result = projectService.GetGraphData(projectId);
            return Ok(result);
        }

        [HttpPost]
        [Route("updateStatus/{projectId}")]
        public async Task<ActionResult> UpdateProjectStatus([FromBody] int projectStatus, int projectId)
        {
            var result = projectService.UpdateProjectStatus(projectStatus, projectId);
            return Ok(result);
        }

        [HttpGet]
        [Route("manager/{projectId}")]
        public async Task<ActionResult<GraphData>> GetManager(int projectId)
        {
            var result = projectService.GetManager(projectId);
            return Ok(result);
        }

    }
}
