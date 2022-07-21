using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.TableRequestHelpers
{
    public interface IFilterTemplate<T> where T : class
    {
        IQueryable<T> ApplyFilters(IQueryable<T> query, BaseFilter filter);
        object GetSortingColumn(T x, string orderBy);
        List<T> GetData(IQueryable<T> query, TableRequest tableRequest);
    }
}
