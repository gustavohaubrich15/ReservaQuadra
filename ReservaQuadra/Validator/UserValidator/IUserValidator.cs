using ReservaQuadra.DTO;

namespace ReservaQuadra.Validator.UserValidator
{
    public interface IUserValidator
    {
        Task  ValidateUserDTO(UserDTO userDTO);
        void ValidatePhone(string phone);

        void ValidateName(string name);

        void ValidateEmail(string email);

        Task ValidateUserDoesNotExist(UserDTO userDTO);
    }
}
