using ConcreteNg.Services.Interfaces;
using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConcreteNg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [AuthorizeRoles(UserTypeEnum.All)]
        [HttpGet]
        public async Task<ActionResult<User>> GetUser()
        {
            //get current user example
            return Ok(userService.GetUser(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }

        [AuthorizeRoles(UserTypeEnum.Administrator)]
        [HttpPost]
        [Route("users")]
        public async Task<ActionResult<TableResponse>> GetEmployedUsers([FromBody] TableRequest tableRequest)
        {
            var items = userService.GetEmployedUsers(tableRequest);
            return Ok(items);
        }

        [AuthorizeRoles(UserTypeEnum.Administrator)]
        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<User>> AddEditUser([FromBody] User user)
        {
            var result = userService.AddEditUser(user);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Username already exists!");
            }
        }

        [AuthorizeRoles(UserTypeEnum.Administrator)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (userService.DeleteUser(id) >= 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
