using ConcreteNg.Repositories.TableRequestHelpers.ConcreteFilterSort;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.TableRequestHelpers
{
    public static class FilterFactory<T> where T : class
    {
        public static IFilterTemplate<T> CreateSortingObject()
        {
            string dataSourceName = typeof(T).Name;

            switch (dataSourceName)
            {
                case nameof(Project):
                    return (IFilterTemplate<T>) new ProjectFilterSort();
                    break;
                case nameof(PricingListItem):
                    return (IFilterTemplate<T>) new PricingListItemFilterSort();
                case nameof(DiaryItem):
                    return (IFilterTemplate<T>)new DiaryItemFilterSort();
                case nameof(Partner):
                    return (IFilterTemplate<T>)new PartnerFilterSort();
                case nameof(User):
                    return (IFilterTemplate<T>)new UserFilterSort();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
