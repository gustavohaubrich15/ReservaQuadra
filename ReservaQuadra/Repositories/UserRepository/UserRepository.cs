using ReservaQuadra.Context;
using ReservaQuadra.Domain;
using ReservaQuadra.Repositories.RepositoryBase;

namespace ReservaQuadra.Repositories.UserRepository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ReservaQuadraContext context) : base(context)
        {
        }
    }
}
