using ConcreteNg.Data;
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
    public class ProjectService : IProjectService
    {
        private readonly UnitOfWork unitOfWork;

        public ProjectService(DataContext dataContext)
        {
            unitOfWork = new UnitOfWork(dataContext);
        }
        public IEnumerable<Project> GetActiveProjects()
        {
            return unitOfWork.projectRepository.GetActiveProjects();
        }

        public Project GetProject(int id)
        {
            return unitOfWork.projectRepository.Read(id);
        }
    }
}
