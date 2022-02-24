using ConcreteNg.Data;
using ConcreteNg.Services.Interfaces;
using ConcreteNg.Services.Services;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteNg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService iUserService)
        {
            userService = iUserService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return Ok(userService.GetUser(id));
        }
    }
}
