using ConcreteNg.Data;
using ConcreteNg.Repositories.Repositories;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Services
{
    public class UserService : IUserService
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

        public User GetUserByUsernameAndPassword(LoginModel loginModel)
        {
            return unitOfWork.userRepository.GetByUsernameAndPassword(loginModel);
        }
    }
}
