using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Repositories.SortHelpers.ProjectSortStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.SortHelpers.Factories
{
    public static class ProjectSortStrategyFactory
    {
        public static IProjectSortStrategy GetStrategy(string key)
        {
            switch (key)
            {
                case "name":
                    return new ProjectSortByName();
                case "expectedCost":
                    return new ProjectSortByBudget();
                case "projectStatus":
                    return new ProjectSortByStatus();
                default:
                    return new ProjectSortByName();
            }
        }
    }
}
