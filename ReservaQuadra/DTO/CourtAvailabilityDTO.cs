using ReservaQuadra.Enumeration;

namespace ReservaQuadra.DTO
{
    public class CourtAvailabilityDTO
    {
        public TimeOnly StartTime { get; set; }

        public Court Court { get; set; }

        public bool IsAvailable { get; set; }
    }
}
