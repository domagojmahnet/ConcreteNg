using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.TableRequestHelpers.ConcreteFilterSort
{
    public class DiaryItemFilterSort : FilterTemplate<DiaryItem>, IFilterTemplate<DiaryItem>
    {
        public override IQueryable<DiaryItem> ApplyFilters(IQueryable<DiaryItem> query, BaseFilter filter)
        {
            switch ((DiaryFilterColumnsEnum)filter.ColumnName)
            {
                case DiaryFilterColumnsEnum.Description:
                    query = query.Where(x => x.Description.Contains(filter.FilterQuery));
                    break;
                case DiaryFilterColumnsEnum.DateTime:
                    query = query.Where(x => x.DateTime.ToString().Contains(filter.FilterQuery));
                    break;
                default:
                    break;
            }
            return query;
        }

        public override object GetSortingColumn(DiaryItem x, string orderBy)
        {
            switch (orderBy)
            {
                case "description":
                    return x.Description;
                default:
                    return x.DateTime;
            }
        }
    }
}
