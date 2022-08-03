using ConcreteNg.Data;
using ConcreteNg.Repositories;
using ConcreteNg.Repositories.Repositories;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IUnitOfWork _unitOfWork, IHttpContextAccessor _httpContextAccessor)
        {
            unitOfWork = _unitOfWork;
            httpContextAccessor = _httpContextAccessor;
        }

        public int AddEditUser(User user)
        {
            if(user.UserId == -1)
            {
                Employer employer = unitOfWork.employerRepository.Read(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
                unitOfWork.userRepository.Create(new User(
                    user.FirstName, user.LastName, user.Username, user.Password, user.Phone, user.HireDate, user.DepartureDate, user.UserType, employer)
                );
            }
            else
            {
                var userToUpdate = unitOfWork.userRepository.Read(user.UserId);
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Username = user.Username;
                userToUpdate.Password = user.Password;
                userToUpdate.Phone = user.Phone;
                userToUpdate.HireDate = user.HireDate;
                userToUpdate.DepartureDate = user.DepartureDate;
                userToUpdate.UserType = user.UserType;
                unitOfWork.userRepository.Update(userToUpdate);
            }
            return unitOfWork.Complete();
        }

        public TableResponse GetEmployedUsers(TableRequest tableRequest)
        {
            return unitOfWork.userRepository.GetEmployedUsers(tableRequest, int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
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
