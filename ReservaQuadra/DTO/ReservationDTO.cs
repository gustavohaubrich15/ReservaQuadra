using ReservaQuadra.Domain;
using ReservaQuadra.Enumeration;

namespace ReservaQuadra.DTO
{
    public class ReservationDTO
    {
        public long Id { get; set; }

        public Court Court { get; set; }

        public long IdUser { get; set; }

        public UserDTO? User { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
