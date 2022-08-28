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
        public IProjectTaskItemRepository projectTaskItemRepository { get; }
        public IPricingListRepository pricingListRepository { get; }
        public IEmployerRepository employerRepository { get; }
        public IExpenseRepository expenseRepository { get; }
        public IPartnerRepository partnerRepository { get; }
        public IDiaryRepository diaryRepository { get; }
        public IFileRepository fileRepository { get; }

        public UnitOfWork(
            DataContext dbContext, 
            IUserRepository _userRepository, 
            IProjectRepository _projectRepository, 
            IProjectTaskRepository _projectTaskRepository,
            IProjectTaskItemRepository _projectTaskItemRepository,
            IPricingListRepository _pricingListRepository,
            IEmployerRepository _employerRepository,
            IExpenseRepository _expenseRepository,
            IPartnerRepository _partnerRepository,
            IDiaryRepository _diaryRepository,
            IFileRepository _fileRepository)
        {
            dataContext = dbContext;
            userRepository = _userRepository;
            projectRepository = _projectRepository;
            projectTaskRepository = _projectTaskRepository;
            projectTaskItemRepository = _projectTaskItemRepository;
            pricingListRepository = _pricingListRepository;
            employerRepository = _employerRepository;
            expenseRepository = _expenseRepository;
            partnerRepository = _partnerRepository;
            diaryRepository = _diaryRepository;
            fileRepository = _fileRepository;
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
