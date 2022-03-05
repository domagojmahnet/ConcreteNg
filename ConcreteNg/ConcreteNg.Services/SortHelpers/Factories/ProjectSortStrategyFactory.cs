using ConcreteNg.Services.Interfaces;
using ConcreteNg.Services.SortHelpers.ProjectSortStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.SortHelpers.Factories
{
    public static class ProjectSortStrategyFactory
    {
        private static Dictionary<string, IProjectSortStrategy> strategyRepository;

        static ProjectSortStrategyFactory()
        {
            strategyRepository = new Dictionary<string, IProjectSortStrategy>();
            strategyRepository.Add("name", new ProjectSortByName());
            strategyRepository.Add("budget", new ProjectSortByBudget());
        }

        public static IProjectSortStrategy GetStrategy(string key)
        {
            return strategyRepository[key];
        }
    }
}
