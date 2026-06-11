namespace ReservaQuadra.Exceptions
{
    public static class BusinessExceptionMessage
    {

        #region User Messages
        public static string UserNotValidEmail(string email) => $"O email '{email}' não é válido.";

        public static string UserNotFound(string phone) => $"Usuário com número '{phone}' não foi encontrado.";

        public static string UserNotValidPhone(string phone) => $"Usuário com número '{phone}' inválido. Deve ter 11 dígitos o número de telefone";

        #endregion
    }
}
