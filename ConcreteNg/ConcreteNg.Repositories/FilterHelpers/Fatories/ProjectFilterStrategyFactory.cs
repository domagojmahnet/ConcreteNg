using ConcreteNg.Repositories.FilterHelpers.ProjectFilterStrategy;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Shared.Enums;

namespace ConcreteNg.Repositories.FilterHelpers.Fatories
{
    public static class ProjectFilterStrategyFactory
    {
        public static IProjectFilterStrategy GetStrategy(ProjectFilterColumnsEnum column)
        {
            switch (column)
            {
                case ProjectFilterColumnsEnum.NameFilter:
                    return new ProjectFilterByName();
                case ProjectFilterColumnsEnum.ExpectedCostFilter:
                    return new ProjectFilterByBudget();
                case ProjectFilterColumnsEnum.ProjectStatusFilter:
                    return new ProjectFilterByStatus();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
