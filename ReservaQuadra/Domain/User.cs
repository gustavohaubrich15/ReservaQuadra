using System.ComponentModel.DataAnnotations;

namespace ReservaQuadra.Domain
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public ICollection<Reservation> Reservations { get; set; }
        = new List<Reservation>();
    }
}
