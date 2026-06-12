using ReservaQuadra.Context;
using ReservaQuadra.Domain;
using ReservaQuadra.Repositories.RepositoryBase;
using ReservaQuadra.Repositories.UserRepository;

namespace ReservaQuadra.Repositories.ReservationRepository
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(ReservaQuadraContext context) : base(context)
        {
        }
    }
}
