using ConcreteNg.Shared.Enums;
using Microsoft.AspNetCore.Authorization;

namespace ConcreteNg
{
    public class AuthorizeRoles : Attribute
    {
        public string Role { get; set; }
        public AuthorizeRoles(UserTypeEnum allowedRole)
        {
            Role = Enum.GetName(typeof(UserTypeEnum), allowedRole);
        }
    }
}
