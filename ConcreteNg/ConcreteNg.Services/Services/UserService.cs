using ConcreteNg.Data;
using ConcreteNg.Repositories;
using ConcreteNg.Repositories.Repositories;
using ConcreteNg.Repositories.TableRequestHelpers;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Enums;
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

        public User AddEditUser(User user)
        {
            bool error = false;
            if(user.UserId == -1)
            {
                if (unitOfWork.userRepository.FindAll().Any(x => x.Username == user.Username))
                {
                    error = true;
                }
                else
                {
                    Employer employer = unitOfWork.employerRepository.Read(int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value));
                    user = new User(user.FirstName, user.LastName, user.Username, user.Password, user.Phone, DateTime.UtcNow, user.UserType, employer, true);
                    unitOfWork.userRepository.Create(user);
                }
            }
            else
            {
                var userToUpdate = unitOfWork.userRepository.Read(user.UserId);
                if(userToUpdate.Username != user.Username)
                {
                    if(unitOfWork.userRepository.FindAll().Any(x => x.Username == user.Username))
                    {
                        error = true;
                    }
                    else
                    {
                        userToUpdate.FirstName = user.FirstName;
                        userToUpdate.LastName = user.LastName;
                        userToUpdate.Username = user.Username;
                        userToUpdate.Password = user.Password;
                        userToUpdate.Phone = user.Phone;
                        userToUpdate.HireDate = user.HireDate;
                        userToUpdate.UserType = user.UserType;
                        user = userToUpdate;
                        unitOfWork.userRepository.Update(user);
                    }
                }
            }
            if(!error)
            {
                if(unitOfWork.Complete() > 0)
                {
                    return user;
                }
            }
            return null;
        }

        public int DeleteUser(int id)
        {
            var userToDelete = unitOfWork.userRepository.Read(id);
            unitOfWork.userRepository.Delete(userToDelete);
            return unitOfWork.Complete();
        }

        public TableResponse GetEmployedUsers(TableRequest tableRequest)
        {
            TableResponse tableResponse = new TableResponse();

            var query = unitOfWork.userRepository.FindAll().Where(x => x.Employer.EmployerId == int.Parse(httpContextAccessor.HttpContext.User.FindFirst("EmployerID").Value) && x.UserType != UserTypeEnum.Buyer);
            tableResponse.TotalRows = query.Count();

            IFilterTemplate<User> filterTemplate = FilterFactory<User>.CreateSortingObject();
            tableResponse.Data = filterTemplate.GetData(query, tableRequest);

            return tableResponse;
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
