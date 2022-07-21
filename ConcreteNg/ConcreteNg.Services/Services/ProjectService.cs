using ConcreteNg.Data;
using ConcreteNg.Repositories;
using ConcreteNg.Repositories.Repositories;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectService(IHttpContextAccessor _httpContextAccessor, IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            httpContextAccessor = _httpContextAccessor;
        }

        public IEnumerable<Project> GetActiveProjects()
        {
            return unitOfWork.projectRepository.GetActiveProjects(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }

        public TableResponse GetProjects(TableRequest tableRequest)
        {
            return unitOfWork.projectRepository.GetProjects(tableRequest, int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }

        public Project GetProject(int id)
        {
            return unitOfWork.projectRepository.Read(id);
        }
    }
}
