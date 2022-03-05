using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody]LoginModel loginModel)
        {
            string token = authService.LogInUser(loginModel);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            return Ok(JsonSerializer.Serialize(token));
        }
    }
}
