using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReservaQuadra.Enumeration;

namespace ReservaQuadra.Domain
{
    public class Reservation
    {
        [Key]
        public long Id { get; set; }

        public Court Court { get; set; }

        public long IdUser { get; set; }

        [ForeignKey(nameof(IdUser))]
        public required User User { get; set; } 

        public DateOnly Date { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

    }
}
