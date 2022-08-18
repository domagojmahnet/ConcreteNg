using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Repositories.TableRequestHelpers;
using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext dataContext;
        public UserRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
        }

        public User GetByUsernameAndPassword(LoginModel loginModel)
        {
            return dataContext.Users.Include(x => x.Employer).FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);
        }
    }
}
