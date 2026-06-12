using Microsoft.AspNetCore.Mvc;
using ReservaQuadra.DTO;
using ReservaQuadra.Services.ReservationService;

namespace ReservaQuadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModelDTO<ReservationDTO>>> CreateReservation([FromBody] ReservationDTO dto)
        {
            var response = await _reservationService.CreateReservation(dto);
            return Created("", response);
        }
    }
}
