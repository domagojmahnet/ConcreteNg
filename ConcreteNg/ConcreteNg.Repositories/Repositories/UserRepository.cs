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
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
