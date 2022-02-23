using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Repositories
{
    public sealed class UnitOfWork : IDisposable
    {
        private readonly DataContext dataContext;
        public readonly IUserRepository userRepository;

        public UnitOfWork(DataContext dbContext)
        {
            dataContext = dbContext;
            userRepository = new UserRepository(dataContext);
        }

        public bool Save()
        {
            bool isSuccess = dataContext.SaveChanges() > 0;
            return isSuccess;
        }

        public void Dispose()
        {
            if (dataContext == null) return;
            dataContext.Dispose();
        }
    }
}
