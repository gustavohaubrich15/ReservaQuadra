using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using ReservaQuadra.DTO;
using ReservaQuadra.Services.CourtService;
using ReservaQuadra.Services.UserService;

namespace ReservaQuadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Court")]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService _courtService;

        public CourtController(ICourtService courtService)
        {
            _courtService = courtService;
        }

        [HttpGet("GetAll")]
        public  ActionResult<ResponseModelDTO<CourtDTO>> GetAll()
        {
            var courts = _courtService.GetAllCourts();
            return Ok(courts);
        }

        [HttpGet("GetAvailability/{date}")]
        public async Task<ActionResult<ResponseModelDTO<UserDTO>>> GetAvailability(DateOnly date)
        {
            var response = await _courtService.GetAvailabilityCourt(date);
            return Ok(response);
        }

    }
}
