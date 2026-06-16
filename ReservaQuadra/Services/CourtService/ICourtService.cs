using ReservaQuadra.DTO;

namespace ReservaQuadra.Services.CourtService
{
    public interface ICourtService
    {
        ResponseModelDTO<IEnumerable<CourtDTO>> GetAllCourts();

        Task<ResponseModelDTO<List<CourtAvailabilityDTO>>> GetAvailabilityCourt(DateOnly date);
    }
}
