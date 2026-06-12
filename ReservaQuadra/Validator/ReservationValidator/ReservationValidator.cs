using System.Threading.Tasks;
using ReservaQuadra.DTO;
using ReservaQuadra.Enumeration;
using ReservaQuadra.Exceptions;
using ReservaQuadra.Repositories.ReservationRepository;
using ReservaQuadra.Repositories.UserRepository;

namespace ReservaQuadra.Validator.ReservationValidator
{
    public class ReservationValidator : IReservationValidator
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUserRepository _userRepository;
        private const int MAX_DAILY_RESERVATION_PER_USER = 2;

        public ReservationValidator(IReservationRepository reservationRepository, IUserRepository userRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
        }

        public async Task ValidateReservationDTO(ReservationDTO reservationDTO)
        {
            ValidateUser(reservationDTO);
            await ValidateCourt(reservationDTO);
        }

        private void ValidateUser(ReservationDTO reservationDTO)
        {
            var user = _userRepository.GetByIdAsync(reservationDTO.IdUser).Result;

            if (user == null)
            {
                throw new BusinessException(BusinessExceptionMessage.UserNotCreated);
            }
        }

        private async Task ValidateCourt(ReservationDTO reservationDTO)
        {
            if (reservationDTO.Court is < (Enumeration.Court)1 or > (Enumeration.Court)3)
            {
                throw new BusinessException(BusinessExceptionMessage.ReservationCourtInvalid(((int)Enum.GetValues<Court>().Max())));
            }

            bool hasReachedDailyReservationLimit = await _reservationRepository.CountAsync(x =>
                    x.IdUser == reservationDTO.IdUser &&
                    x.Date == reservationDTO.Date) > 2;

            if (hasReachedDailyReservationLimit)
            {
                throw new BusinessException(BusinessExceptionMessage.ReservationDailyLimitReached(MAX_DAILY_RESERVATION_PER_USER));
            }

        }
    }
}
