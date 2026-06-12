using Microsoft.AspNetCore.Mvc;
using ReservaQuadra.Domain;
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

        [HttpPost]
        public async Task<ActionResult<ResponseModelDTO<UserDTO>>> CreateUser([FromBody] UserDTO dto)
        {
            var response = await _userService.CreateUser(dto);
            return Created("", response);
        }

        [HttpGet("GetUserByPhone/{phone}")]
        public async Task<ActionResult<ResponseModelDTO<UserDTO>>> GetUserByPhone(string phone)
        {
            var user = await _userService.GetUserByPhone(phone);
            return Ok(user);
        }
    }
}
