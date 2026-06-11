using System.ComponentModel.DataAnnotations;

namespace ReservaQuadra.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
