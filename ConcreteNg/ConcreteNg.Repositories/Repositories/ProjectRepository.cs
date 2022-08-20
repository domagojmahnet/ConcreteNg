using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Repositories.TableRequestHelpers;
using ConcreteNg.Repositories.TableRequestHelpers.ConcreteFilterSort;
using ConcreteNg.Shared;
using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly DataContext dataContext;
        public ProjectRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
        }

        public User GetProjectBuyer(int projectId)
        {
            var project = dataContext.Projects.Include(x => x.Users).FirstOrDefault(x => x.ProjectId == projectId);
            if (project.Users != null)
            {
                return project.Users.FirstOrDefault(x => x.UserType == UserTypeEnum.Buyer);
            }
            return null;
        }

        public int AssignBuyer(int userId, int projectId)
        {
            var user = dataContext.Users.Find(userId);
            var project = dataContext.Projects.Include(x => x.Users).FirstOrDefault(x => x.ProjectId == projectId);
            if (project.Users == null)
            {
                project.Users = new List<User>() { user };
            }
            else
            {
                project.Users.Add(user);
            }
            return dataContext.SaveChanges();
        }

        public User GetManager(int projectId)
        {
            var project = dataContext.Projects.Include(x => x.Users).FirstOrDefault(x => x.ProjectId == projectId);
            if (project.Users != null)
            {
                return project.Users.FirstOrDefault(x => x.UserType == UserTypeEnum.Manager);
            }
            return null;
        }

        public int CreateOrUpdateProject(Project project, int managerId, int employerId)
        {
            Employer employer = dataContext.Employers.Find(employerId);
            var manager = dataContext.Users.Find(managerId);
            var projectToAddUpdate = new Project();

            if (project.ProjectId == -1)
            {
                projectToAddUpdate = new Project(employer, project.Name, project.ExpectedStartDate, project.ExpectedEndDate, project.ExpectedCost, Shared.Enums.ProjectStatusEnum.ToDo, 0);
                projectToAddUpdate.Users = new List<User>() { manager };
                dataContext.Projects.Add(projectToAddUpdate);
            }
            else
            {
                projectToAddUpdate = dataContext.Projects.Include(x => x.Users).FirstOrDefault(x => x.ProjectId == project.ProjectId);
                projectToAddUpdate.Name = project.Name;
                projectToAddUpdate.ExpectedCost = project.ExpectedCost;
                projectToAddUpdate.ExpectedEndDate = project.ExpectedEndDate;
                projectToAddUpdate.ExpectedStartDate = project.ExpectedStartDate;
                if (projectToAddUpdate.Users != null)
                {
                    projectToAddUpdate.Users = projectToAddUpdate.Users.Where(x => x.UserType != UserTypeEnum.Manager).ToList();
                    projectToAddUpdate.Users.Add(manager);
                }
                else
                {
                    projectToAddUpdate.Users = new List<User>() { manager };
                }
                dataContext.Projects.Update(projectToAddUpdate);
            }
            return dataContext.SaveChanges();
        }
    }
}
