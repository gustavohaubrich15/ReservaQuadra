using ReservaQuadra.DTO;
using ReservaQuadra.Enumeration;
using ReservaQuadra.Repositories.ReservationRepository;
using ReservaQuadra.Repositories.UserRepository;
using ReservaQuadra.Services.GenericService;
using ReservaQuadra.Services.UserService;

namespace ReservaQuadra.Services.CourtService
{
    public class CourtService : GenericService<CourtService>, ICourtService
    {
        private readonly IReservationRepository _reservationRepository;

        public CourtService(
            ILogger<CourtService> logger,
            IConfiguration configuration,
            IReservationRepository reservationRepository)
            : base(logger, configuration)
        {
            _reservationRepository = reservationRepository;
        }


        public ResponseModelDTO<IEnumerable<CourtDTO>> GetAllCourts()
        {
            var courts = Enum.GetValues<Court>()
                 .Select(c => new CourtDTO
                 {
                     Court = c
                 });

            return new ResponseModelDTO<IEnumerable<CourtDTO>>
            {
                Data = courts
            };
        }

        public async Task<ResponseModelDTO<List<CourtAvailabilityDTO>>> GetAvailabilityCourt(DateOnly date)
        {
            var reservations = await _reservationRepository.FindAsync(x => x.Date == date);
                            

            var dto = new List<CourtAvailabilityDTO>();

            TimeOnly currentTime = new(8, 0);
            TimeOnly endTime = new(22, 0);

            while (currentTime < endTime)
            {
                foreach (Court court in Enum.GetValues<Court>())
                {
                    bool isReserved = reservations.Any(x =>
                        x.Court == court &&
                        currentTime >= x.StartTime &&
                        currentTime < x.EndTime);

                    dto.Add(new CourtAvailabilityDTO
                    {
                        StartTime = currentTime,
                        Court = court,
                        IsAvailable = !isReserved
                    });
                }

                currentTime = currentTime.AddMinutes(30);
            }

            ResponseModelDTO<List<CourtAvailabilityDTO>> response = new ResponseModelDTO<List<CourtAvailabilityDTO>>();
            response.Data = dto;
            return response;
        }

    }
}
