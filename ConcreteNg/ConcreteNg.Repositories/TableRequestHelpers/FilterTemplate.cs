using ConcreteNg.Shared;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.TableRequestHelpers
{
    public abstract class FilterTemplate<T> : IFilterTemplate<T> where T : class
    {
        public abstract IQueryable<T> ApplyFilters(IQueryable<T> query, BaseFilter filter);
        public abstract object GetSortingColumn(T x, string orderBy);

        public List<T> GetData(IQueryable<T> query, TableRequest tableRequest)
        {
            foreach (var filter in tableRequest.Filters.Where(x => !string.IsNullOrEmpty(x.FilterQuery)))
            {
                query = ApplyFilters(query, filter);
            }

            return query
                .SortBy(tableRequest.IsAscending, x => GetSortingColumn(x, tableRequest.OrderBy))
                .Skip(tableRequest.PageSize * tableRequest.CurrentPage)
                .Take(tableRequest.PageSize)
                .ToList();
        }
    }
}
