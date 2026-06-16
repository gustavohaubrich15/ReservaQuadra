using ReservaQuadra.Domain;
using ReservaQuadra.DTO;
using ReservaQuadra.Repositories.ReservationRepository;
using ReservaQuadra.Services.GenericService;
using ReservaQuadra.Validator.ReservationValidator;

namespace ReservaQuadra.Services.ReservationService
{
    public class ReservationService : GenericService<ReservationService>, IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationValidator _reservationValidator;

        public ReservationService(
            ILogger<ReservationService> logger,
            IConfiguration configuration,
            IReservationRepository reservationRepository,
            IReservationValidator reservationValidator)
            : base(logger, configuration)
        {
            _reservationRepository = reservationRepository;
            _reservationValidator = reservationValidator;
        }

        public async Task<ResponseModelDTO<ReservationDTO>> CreateReservation(ReservationDTO dto)
        {
            _logger.LogInformation("Validar reserva");
            await _reservationValidator.ValidateReservationDTO(dto);
            _logger.LogInformation("Criando reservação para o usuário {Name} com email {Email} e telefone {Phone}", dto.User.Name, dto.User.Email, dto.User.Phone);
            var reservation = new Reservation
            {
                Court = dto.Court,
                IdUser = dto.IdUser,
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };
            await _reservationRepository.CreateAsync(reservation);
            dto.Id = reservation.Id;
            ResponseModelDTO<ReservationDTO> response = new ResponseModelDTO<ReservationDTO>();
            response.Data = dto;
            return response;
        }


    }
}
