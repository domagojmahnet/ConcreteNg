using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace ConcreteNg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private IConfiguration configuration;

        public AuthController(IConfiguration iconfiguration) 
        {
            configuration = iconfiguration;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get1()
        {
            User request = new User();
            return Ok(request);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody]LoginModel loginModel)
        {
            //serialize string to json
            return Ok(JsonSerializer.Serialize(CreateToken(loginModel)));
        }

        private string CreateToken(LoginModel loginModel)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Username)
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
