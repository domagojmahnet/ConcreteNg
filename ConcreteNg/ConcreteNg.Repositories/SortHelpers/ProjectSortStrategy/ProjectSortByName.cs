using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.SortHelpers.ProjectSortStrategy
{
    public class ProjectSortByName : IProjectSortStrategy
    {
        public object Sort(Project project)
        {
            return project.Name;
        }
    }
}
