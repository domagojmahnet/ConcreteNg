using ConcreteNg.Services.Interfaces;
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
        private IAuthService authService;

        public AuthController(IAuthService _authService) 
        {
            authService = _authService;
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
            return Ok(JsonSerializer.Serialize(authService.LogInUser(loginModel)));
        }
    }
}
