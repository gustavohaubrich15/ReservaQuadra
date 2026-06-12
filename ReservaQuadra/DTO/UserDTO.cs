namespace ReservaQuadra.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string PhoneFormat => Phone.Length == 11
        ? $"({Phone[..2]}) {Phone.Substring(2, 5)}-{Phone.Substring(7, 4)}"
        : Phone;
    }
}
