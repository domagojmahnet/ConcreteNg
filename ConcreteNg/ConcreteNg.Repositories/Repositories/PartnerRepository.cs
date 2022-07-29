using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    internal class PartnerRepository : GenericRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
