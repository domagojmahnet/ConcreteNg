using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Services.Services
{
    public class AuthService : IAuthService
    {
        private IConfiguration configuration;
        private readonly IUserService userService;

        public AuthService(IConfiguration _configuration, IUserService _userService)
        {
            configuration = _configuration;
            userService = _userService;
        }

        public string LogInUser(LoginModel loginModel)
        {
            User user = userService.GetUserByUsernameAndPassword(loginModel);
            if(user == null)
            {
                return string.Empty;
            }
            return CreateToken(user);
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new Claim(type: "EmployerID", value: user.Employer.EmployerId.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value)
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        
    }
}
