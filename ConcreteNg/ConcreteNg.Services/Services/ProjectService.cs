using ConcreteNg.Data;
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
        private readonly UnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectService(DataContext dataContext, IHttpContextAccessor _httpContextAccessor)
        {
            unitOfWork = new UnitOfWork(dataContext);
            httpContextAccessor = _httpContextAccessor;
        }

        public IEnumerable<Project> GetActiveProjects()
        {
            return unitOfWork.projectRepository.GetActiveProjects(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }

        public IEnumerable<Project> GetProjects()
        {
            return unitOfWork.projectRepository.GetProjects(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
        }

        public Project GetProject(int id)
        {
            return unitOfWork.projectRepository.Read(id);
        }
    }
}
