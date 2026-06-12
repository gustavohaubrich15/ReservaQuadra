namespace ReservaQuadra.Exceptions
{
    public static class BusinessExceptionMessage
    {

        #region User Messages

        public const string UserNameRequired = "Nome é obrigatório.";

        public const string UserNameInvalid = "Informe nome e sobrenome.";

        public const string UserEmailRequired = "Email é obrigatório.";
        public static string UserNotValidEmail(string email) => $"O email '{email}' não é válido.";

        public static string UserNotFound(string phone) => $"Usuário com número '{phone}' não foi encontrado.";

        public static string UserNotValidPhone(string phone) => $"Usuário com número '{phone}' inválido. Deve ter 11 dígitos o número de telefone";

        public const string UserEmailAlreadyCreated = "Email já utilizado por outro usuário.";

        public const string UserPhoneAlreadyCreated = "Telefone já utilizado por outro usuário.";

        public const string UserNotCreated = "Usuário não criado no sistema. Por favor cadastre primeiro seu número para reservar uma quadra.";

        #endregion



        #region Reservation Messages

        public static string ReservationCourtInvalid(int enumLength) => $"Quadra inválida. O número da quadra deve estar entre 1 e {enumLength}";

        public static string ReservationDailyLimitReached(int limit) => $"Limite diário de reserva atingido. Você já reservou {limit} vezes. Reserve em outra data ou cancele alguma data já reservada";

        public const string ReservationTimeConflict = "Já existe uma reserva para a quadra no horário informado.";

        #endregion

    }
}
