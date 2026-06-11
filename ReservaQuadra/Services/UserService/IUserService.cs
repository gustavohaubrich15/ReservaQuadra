using ReservaQuadra.DTO;

namespace ReservaQuadra.Services.UserService
{
    public interface IUserService
    {
        Task CreateUser(UserDTO dto);
        Task<ResponseModelDTO<UserDTO>> GetUserByPhone(string phone);
    }
}
