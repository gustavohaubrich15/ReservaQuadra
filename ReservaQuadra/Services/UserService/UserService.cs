using System.Text.RegularExpressions;
using ReservaQuadra.DTO;
using ReservaQuadra.Exceptions;
using ReservaQuadra.Repositories.UserRepository;
using ReservaQuadra.Services.GenericService;
using ReservaQuadra.Validator.UserValidator;
using ReservaQuadra.Domain;

namespace ReservaQuadra.Services.UserService
{
    public class UserService : GenericService<UserService>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;

        public UserService(
            ILogger<UserService> logger,
            IConfiguration configuration,
            IUserRepository userRepository,
            IUserValidator userValidator)
            : base(logger, configuration)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<ResponseModelDTO<UserDTO>> CreateUser(UserDTO dto)
        {
            await _userValidator.ValidateUserDTO(dto);
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };
            await _userRepository.CreateAsync(user);
            dto.Id = user.Id;
            ResponseModelDTO<UserDTO> response = new ResponseModelDTO<UserDTO>();
            response.Data = dto;
            return response;
        }

        public async Task<ResponseModelDTO<UserDTO>> GetUserByPhone(string phone)
        {
            _userValidator.ValidatePhone(phone);
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Phone == phone);
            if (user == null)
            {
                throw new BusinessException(BusinessExceptionMessage.UserNotFound(phone));
            }
            ResponseModelDTO<UserDTO> response = new ResponseModelDTO<UserDTO>();
            UserDTO userDTO = new UserDTO

            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone
            };
            response.Data = userDTO;
            return response;
        }

    }
}
