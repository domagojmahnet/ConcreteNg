using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Repositories.TableRequestHelpers;
using ConcreteNg.Shared;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    public class PricingListItemRepository : GenericRepository<PricingListItem>, IPricingListRepository
    {
        private readonly DataContext dataContext;
        public PricingListItemRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
        }

        public IEnumerable<PricingListItem> GetEmployersPricingListItems(int employerID)
        {
            return dataContext.PricingListItems.Where(x => x.Employer.EmployerId == employerID);
        }

        public TableResponse GetEmployersPricingListItemsTable(TableRequest tableRequest, int employerID)
        {
            TableResponse tableResponse = new TableResponse();

            var query = dataContext.PricingListItems.Where(x => x.Employer.EmployerId == employerID);
            tableResponse.TotalRows = query.Count();

            IFilterTemplate<PricingListItem> filterTemplate = FilterFactory<PricingListItem>.CreateSortingObject();
            tableResponse.Data = filterTemplate.GetData(query, tableRequest);

            return tableResponse;
        }
    }
}
