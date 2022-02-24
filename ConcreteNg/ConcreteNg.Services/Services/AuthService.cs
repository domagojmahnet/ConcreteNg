﻿using ConcreteNg.Services.Interfaces;
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

        public AuthService(IConfiguration iConfiguration, IUserService iUserService)
        {
            configuration = iConfiguration;
            userService = iUserService;
        }

        public string LogInUser(LoginModel loginModel)
        {
            User user = userService.GetUserByUsernameAndPassword(loginModel);
            if(user == null)
            {
                return "Invalid username or password";
            }
            return CreateToken(user);
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
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
