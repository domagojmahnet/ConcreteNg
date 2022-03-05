using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.SortHelpers.ProjectSortStrategy
{
    public class ProjectSortByName : IProjectSortStrategy
    {
        public object Sort(Project project)
        {
            return project.Name;
        }
    }
}
