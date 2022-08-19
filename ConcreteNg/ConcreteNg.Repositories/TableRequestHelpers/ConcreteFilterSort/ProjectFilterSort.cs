using ConcreteNg.Shared;
using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.TableRequestHelpers.ConcreteFilterSort
{
    public class ProjectFilterSort : FilterTemplate<Project>, IFilterTemplate<Project>
    {
        public override IQueryable<Project> ApplyFilters(IQueryable<Project> query, BaseFilter filter)
        {
            switch ((ProjectFilterColumnsEnum)filter.ColumnName)
            {
                case ProjectFilterColumnsEnum.NameFilter:
                    query = query.Where(x => x.Name.Contains(filter.FilterQuery));
                    break;
                case ProjectFilterColumnsEnum.ProjectStatusFilter:
                    var eligibleEnums = Enum.GetValues(typeof(ProjectStatusEnum)).Cast<ProjectStatusEnum>().Where(e => e.ToString().ToLower().Contains(filter.FilterQuery.Replace(" ", string.Empty).ToLower())).ToList();
                    query = query.Where(p => eligibleEnums.Contains(p.ProjectStatus));
                    break;
                case ProjectFilterColumnsEnum.ExpectedCostFilter:
                    query = query.Where(p => p.ExpectedCost.ToString().Contains(filter.FilterQuery));
                    break;
                case ProjectFilterColumnsEnum.ExpectedEndDateFilterStart:
                    var dateFrom = DateTimeOffset.Parse(filter.FilterQuery).UtcDateTime;
                    query = query.Where(x => x.ExpectedEndDate >= dateFrom);
                    break;
                case ProjectFilterColumnsEnum.ExpectedEndDateFilterEnd:
                    var dateTo = DateTimeOffset.Parse(filter.FilterQuery).UtcDateTime.AddDays(1);
                    query = query.Where(x => x.ExpectedEndDate <= dateTo);
                    break;
                default:
                    break;
            }
            return query;
        }

        public override object GetSortingColumn(Project project, string orderBy)
        {
            switch (orderBy)
            {
                case "name":
                    return project.Name;
                case "expectedCost":
                    return project.ExpectedCost;
                case "projectStatus":
                    return project.ProjectStatus;
                default:
                    return project.Name;
            }
        }
    }
}
