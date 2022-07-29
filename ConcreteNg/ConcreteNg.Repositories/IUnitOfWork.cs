using ConcreteNg.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository projectRepository { get; }
        IProjectTaskRepository projectTaskRepository { get; }
        IProjectTaskItemRepository projectTaskItemRepository { get; }
        IUserRepository userRepository { get; }
        IPricingListRepository pricingListRepository { get; }
        IEmployerRepository employerRepository { get; }
        IExpenseRepository expenseRepository { get; }
        IPartnerRepository partnerRepository { get; }
        int Complete();
    }
    
}
