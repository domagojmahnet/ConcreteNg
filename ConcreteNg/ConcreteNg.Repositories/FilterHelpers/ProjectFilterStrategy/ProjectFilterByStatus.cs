using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;

namespace ConcreteNg.Repositories.FilterHelpers.ProjectFilterStrategy
{
    public class ProjectFilterByStatus : IProjectFilterStrategy
    {

        public IQueryable<Project> Filter(IQueryable<Project> query, string filterQuery)
        {
            var eligibleEnums = Enum.GetValues(typeof(ProjectStatusEnum)).Cast<ProjectStatusEnum>().Where(e => e.ToString().ToLower().Contains(filterQuery.Replace(" ", string.Empty).ToLower())).ToList();
            return query.Where(p => eligibleEnums.Contains(p.ProjectStatus));
        }
    }
}
