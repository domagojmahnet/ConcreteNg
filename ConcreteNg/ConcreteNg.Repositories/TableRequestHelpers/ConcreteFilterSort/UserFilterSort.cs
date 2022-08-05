using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.TableRequestHelpers.ConcreteFilterSort
{
    internal class UserFilterSort : FilterTemplate<User>, IFilterTemplate<User>
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
                case UserFilterEnum.HireDate:
                    query = query.Where(x => x.HireDate.ToString().Contains(filter.FilterQuery));
                    break;
                case UserFilterEnum.UserType:
                    query = query.Where(x => x.UserType.ToString().Contains(filter.FilterQuery));
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
                default:
                    return x.FirstName;
            }
        }
    }
}
