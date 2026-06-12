using ReservaQuadra.DTO;

namespace ReservaQuadra.Validator.ReservationValidator
{
    public interface IReservationValidator
    {
        Task ValidateReservationDTO(ReservationDTO reservationDTO);
    }
}
