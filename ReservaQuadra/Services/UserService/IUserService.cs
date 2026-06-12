using ReservaQuadra.DTO;

namespace ReservaQuadra.Services.UserService
{
    public interface IUserService
    {
        Task<ResponseModelDTO<UserDTO>> CreateUser(UserDTO dto);
        Task<ResponseModelDTO<UserDTO>> GetUserByPhone(string phone);
    }
}
