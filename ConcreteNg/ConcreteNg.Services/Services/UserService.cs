using ConcreteNg.Data;
using ConcreteNg.Repositories.Repositories;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;

        public UserService(DataContext dataContext)
        {
            unitOfWork = new UnitOfWork(dataContext);
        }

        public User GetUser(int id)
        {
            return unitOfWork.userRepository.Read(id);
        }
    }
}
