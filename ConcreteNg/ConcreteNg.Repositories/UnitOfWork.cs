using ConcreteNg.Data;
using ConcreteNg.Repositories.Interfaces;
using ConcreteNg.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;
        public IUserRepository userRepository { get; }
        public IProjectRepository projectRepository { get; }
        public IProjectTaskRepository projectTaskRepository { get; }
        public IPricingListRepository pricingListRepository { get; }

        public UnitOfWork(
            DataContext dbContext, 
            IUserRepository _userRepository, 
            IProjectRepository _projectRepository, 
            IProjectTaskRepository _projectTaskRepository, 
            IPricingListRepository _pricingListRepository)
        {
            dataContext = dbContext;
            userRepository = _userRepository;
            projectRepository = _projectRepository;
            projectTaskRepository = _projectTaskRepository;
            pricingListRepository = _pricingListRepository;
        }

        public void Dispose()
        {
            if (dataContext == null) return;
            dataContext.Dispose();
        }

        public int Complete()
        {
            return dataContext.SaveChanges();
        }
    }
}
