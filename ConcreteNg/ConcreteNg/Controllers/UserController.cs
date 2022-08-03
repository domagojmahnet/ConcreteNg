using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConcreteNg.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser()
        {
            //get current user example
            return Ok(userService.GetUser(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [HttpPost]
        [Route("users")]
        public async Task<ActionResult<TableResponse>> GetEmployedUsers([FromBody] TableRequest tableRequest)
        {
            var items = userService.GetEmployedUsers(tableRequest);
            return Ok(items);
        }

        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<int>> AddEditUser([FromBody] User user)
        {
            var result = userService.AddEditUser(user);
            return Ok(result);
        }
    }
}
