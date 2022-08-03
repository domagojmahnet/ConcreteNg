using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.TableRequestHelpers.ConcreteFilterSort
{
    public class PartnerFilterSort : FilterTemplate<Partner>, IFilterTemplate<Partner>
    {
        public override IQueryable<Partner> ApplyFilters(IQueryable<Partner> query, BaseFilter filter)
        {
            switch ((PartnerFilterEnum)filter.ColumnName)
            {
                case PartnerFilterEnum.Name:
                    query = query.Where(x => x.Name.Contains(filter.FilterQuery));
                    break;
                case PartnerFilterEnum.ContactNumber:
                    query = query.Where(x => x.ContactNumber.Contains(filter.FilterQuery));
                    break;
                case PartnerFilterEnum.ContactPerson:
                    query = query.Where(x => x.ContactPerson.Contains(filter.FilterQuery));
                    break;
                case PartnerFilterEnum.Address:
                    query = query.Where(x => x.Address.Contains(filter.FilterQuery));
                    break;
                default:
                    break;
            }
            return query;
        }

        public override object GetSortingColumn(Partner x, string orderBy)
        {
            switch (orderBy)
            {
                case "name":
                    return x.Name;
                case "contactNumber":
                    return x.ContactNumber;
                case "contactPerson":
                    return x.ContactPerson;
                case "address":
                    return x.Address;
                default:
                    return x.Name;
            }
        }
    }
}
