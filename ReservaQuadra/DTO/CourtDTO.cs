using ReservaQuadra.Enumeration;

namespace ReservaQuadra.DTO
{
    public class CourtDTO
    {
        public Court Court { get; set; }

        public string Description => Court.GetDisplayName();

    }
}
