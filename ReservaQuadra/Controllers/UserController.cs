using Microsoft.AspNetCore.Mvc;
using ReservaQuadra.DTO;
using ReservaQuadra.Services.UserService;

namespace ReservaQuadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserByPhone/{phone}")]
        public async Task<ActionResult<ResponseModelDTO<UserDTO>>> GetUserByPhone(string phone)
        {
            var user = await _userService.GetUserByPhone(phone);
            return Ok(user);
        }
    }
}
