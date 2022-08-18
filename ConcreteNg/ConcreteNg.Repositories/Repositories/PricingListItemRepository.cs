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
    }
}
