using System.Numerics;
using System.Text.RegularExpressions;
using ReservaQuadra.DTO;
using ReservaQuadra.Exceptions;
using ReservaQuadra.Repositories.UserRepository;

namespace ReservaQuadra.Validator.UserValidator
{
    public class UserValidator: IUserValidator
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ValidateUserDTO(UserDTO userDTO)
        {
            ValidateName(userDTO.Name);
            ValidateEmail(userDTO.Email);
            ValidatePhone(userDTO.Phone);
            await ValidateUserDoesNotExist(userDTO);
        }

        public void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessException(BusinessExceptionMessage.UserNameRequired);
            }

            var parts = name.Trim().Split(' ');

            if (parts.Length < 2)
            {
                throw new BusinessException(BusinessExceptionMessage.UserNameInvalid);
            }
        }

        public void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessException("Email é obrigatório.");
            }

            var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, emailRegex))
            {
                throw new BusinessException(BusinessExceptionMessage.UserNotValidEmail(email));
            }
        }

        public void ValidatePhone(string phone)
        {
            string phoneNumber = OnlyNumbers(phone.Trim());

            if (phoneNumber.Length != 11)
            {
                throw new BusinessException(BusinessExceptionMessage.UserNotValidPhone(phone));
            }
        }

        public async Task ValidateUserDoesNotExist(UserDTO userDTO)
        {
            var existsEmail = await _userRepository.FindAsync(x => x.Email == userDTO.Email);

            if (existsEmail.Any())
            {
                throw new BusinessException(BusinessExceptionMessage.UserEmailAlreadyCreated);
            }

            var existsPhone = await _userRepository.FindAsync(x => x.Email == userDTO.Email);

            if (existsPhone.Any())
            {
                throw new BusinessException(BusinessExceptionMessage.UserEmailAlreadyCreated);
            }
        }

        private string OnlyNumbers(string value)
        {
            return Regex.Replace(value ?? "", @"\D", "");
        }
    }
}
