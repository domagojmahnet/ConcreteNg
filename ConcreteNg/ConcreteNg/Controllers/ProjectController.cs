using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using ConcreteNg.Shared.Models.GraphModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ConcreteNg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        private readonly IFileService fileService;

        public ProjectController(IProjectService _projectService, IFileService _fileService)
        {
            projectService = _projectService;
            fileService = _fileService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetActiveProjects()
        {
            var projects = projectService.GetActiveProjects();
            return Ok(projects);
        }

        [AuthorizeRoles(UserTypeEnum.All)]
        [HttpPost]
        [Route("allProjects")]
        public async Task<ActionResult<TableResponse>> GetProjects([FromBody] TableRequest tableRequest)
        {
            var projects = projectService.GetProjects(tableRequest);
            return Ok(projects);
        }

        [AuthorizeRoles(UserTypeEnum.All)]
        [HttpGet]
        [Route("{projectId}")]
        public async Task<ActionResult<Project>> GetProject(int projectId)
        {
            var projects = projectService.GetProject(projectId);
            return Ok(projects);
        }

        [AuthorizeRoles(UserTypeEnum.All)]
        [HttpPost]
        [Route("diaryItems/{projectId}")]
        public async Task<ActionResult<TableResponse>> GetDiaryItemsTable([FromBody] TableRequest tableRequest, int projectId)
        {
            var result = projectService.GetDiaryItems(tableRequest, projectId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpPost]
        [Route("diaryItem/{projectId}")]
        public async Task<ActionResult<DiaryItem>> AddDiaryItem([FromBody] DiaryItem diary, int projectId)
        {
            var result = projectService.AddDiaryItem(diary, projectId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.Administrator)]
        [HttpPost]
        [Route("project/{managerId}")]
        public async Task<ActionResult<DiaryItem>> CreateOrUpdateProject([FromBody] Project project, int managerId)
        {
            var result = projectService.CreateOrUpdateProject(project, managerId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpGet]
        [Route("managers")]
        public async Task<ActionResult<DiaryItem>> GetEligibleManagers()
        {
            var result = projectService.GetEligibleManagers();
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.All)]
        [HttpGet]
        [Route("costOverview/{projectId}")]
        public async Task<ActionResult<CostOverview>> GetCostOverview(int projectId)
        {
            var result = projectService.GetCostOverview(projectId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.All)]
        [HttpGet]
        [Route("projectBuyer/{projectId}")]
        public async Task<ActionResult<User>> GetProjectBuyer(int projectId)
        {
            var result = projectService.GetProjectBuyer(projectId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpGet]
        [Route("assignBuyer/{userId}/{projectId}")]
        public async Task<ActionResult> AssignBuyer(int userId, int projectId)
        {
            var result = projectService.AssignBuyer(userId, projectId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.All)]
        [HttpGet]
        [Route("graphData/{projectId}")]
        public async Task<ActionResult<GraphData>> GetGraphData(int projectId)
        {
            var result = projectService.GetGraphData(projectId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpPost]
        [Route("updateStatus/{projectId}")]
        public async Task<ActionResult> UpdateProjectStatus([FromBody] int projectStatus, int projectId)
        {
            var result = projectService.UpdateProjectStatus(projectStatus, projectId);
            return Ok(result);
        }

        [AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpGet]
        [Route("manager/{projectId}")]
        public async Task<ActionResult<GraphData>> GetManager(int projectId)
        {
            var result = projectService.GetManager(projectId);
            return Ok(result);
        }

        //[AuthorizeRoles(UserTypeEnum.ManagerAndAdmin)]
        [HttpPost]
        [Route("upload/{projectId}")]
        public async Task<ActionResult> UploadFiles(int projectId)
        {
            var files = HttpContext.Request.Form.Files.ToList();
            var result = fileService.UploadFiles(files, projectId);
            if(result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("files/{projectId}")]
        public async Task<IActionResult> GetFiles(int projectId)
        {
            var result = fileService.GetFiles(projectId);
            return Ok(result);
        }

        [HttpGet]
        [Route("download/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var file = fileService.DownloadFile(id);
            if(file != null)
            {
                var bytes = await System.IO.File.ReadAllBytesAsync(file.FilePath);
                Response.Headers.Add("Content-Disposition", "attachment");
                return File(bytes, "text/plain", file.FileName);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
