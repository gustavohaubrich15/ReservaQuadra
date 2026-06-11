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

        #endregion
    }
}
