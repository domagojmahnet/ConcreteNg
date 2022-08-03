using ConcreteNg.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsernameAndPassword(LoginModel loginModel);
        TableResponse GetEmployedUsers(TableRequest tableRequest, int employerId);
    }
}
