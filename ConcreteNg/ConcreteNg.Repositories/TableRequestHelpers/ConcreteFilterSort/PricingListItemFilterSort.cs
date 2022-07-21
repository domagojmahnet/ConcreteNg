using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.TableRequestHelpers.ConcreteFilterSort
{
    public class PricingListItemFilterSort : FilterTemplate<PricingListItem>, IFilterTemplate<PricingListItem>
    {
        public override IQueryable<PricingListItem> ApplyFilters(IQueryable<PricingListItem> query, BaseFilter filter)
        {
            switch ((PricingListFilterColumnsEnum)filter.ColumnName)
            {
                case PricingListFilterColumnsEnum.PricingListItemName:
                    query = query.Where(x => x.PricingListItemName.Contains(filter.FilterQuery));
                    break;
                case PricingListFilterColumnsEnum.UnitOfMeasurement:
                    query = query.Where(x => x.UnitOfMeasurement.Contains(filter.FilterQuery));
                    break;
                case PricingListFilterColumnsEnum.Price:
                    query = query.Where(x => x.Price.ToString().Contains(filter.FilterQuery));
                    break;
                default:
                    break;
            }
            return query;
        }

        public override object GetSortingColumn(PricingListItem pricingListItem, string orderBy)
        {
            switch (orderBy)
            {
                case "pricingListItemName":
                    return pricingListItem.PricingListItemName;
                case "unitOfMeasurement":
                    return pricingListItem.UnitOfMeasurement;
                case "price":
                    return pricingListItem.Price;
                default:
                    return pricingListItem.PricingListItemName;
            }
        }
    }
}
