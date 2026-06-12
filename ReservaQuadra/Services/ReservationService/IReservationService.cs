using ReservaQuadra.DTO;

namespace ReservaQuadra.Services.ReservationService
{
    public interface IReservationService
    {
        Task<ResponseModelDTO<ReservationDTO>> CreateReservation(ReservationDTO dto);
    }
}
