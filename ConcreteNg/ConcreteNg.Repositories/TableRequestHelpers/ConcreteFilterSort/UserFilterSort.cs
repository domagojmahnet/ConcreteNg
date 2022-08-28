using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.TableRequestHelpers.ConcreteFilterSort
{
    public class UserFilterSort : FilterTemplate<User>, IFilterTemplate<User>
    {
        public override IQueryable<User> ApplyFilters(IQueryable<User> query, BaseFilter filter)
        {
            switch ((UserFilterEnum)filter.ColumnName)
            {
                case UserFilterEnum.FirstName:
                    query = query.Where(x => x.FirstName.Contains(filter.FilterQuery));
                    break;
                case UserFilterEnum.LastName:
                    query = query.Where(x => x.LastName.Contains(filter.FilterQuery));
                    break;
                case UserFilterEnum.Username:
                    query = query.Where(x => x.Username.Contains(filter.FilterQuery));
                    break;
                case UserFilterEnum.HireDateStart:
                    var dateFrom = DateTimeOffset.Parse(filter.FilterQuery).UtcDateTime;
                    query = query.Where(x => x.HireDate >= dateFrom);
                    break;
                case UserFilterEnum.HireDateEnd:
                    var dateTo = DateTimeOffset.Parse(filter.FilterQuery).UtcDateTime.AddDays(1);
                    query = query.Where(x => x.HireDate <= dateTo);
                    break;
                case UserFilterEnum.UserType:
                    query = query.Where(x => x.UserType.ToString().Contains(filter.FilterQuery));
                    break;
                case UserFilterEnum.Phone:
                    query = query.Where(x => x.Phone.ToString().Contains(filter.FilterQuery));
                    break;
                default:
                    break;
            }
            return query;
        }

        public override object GetSortingColumn(User x, string orderBy)
        {
            switch (orderBy)
            {
                case "firstName":
                    return x.FirstName;
                case "LastName":
                    return x.LastName;
                case "username":
                    return x.Username;
                case "hireDate":
                    return x.HireDate;
                case "userType":
                    return x.UserType;
                case "phone":
                    return x.Phone;
                default:
                    return x.FirstName;
            }
        }
    }
}
