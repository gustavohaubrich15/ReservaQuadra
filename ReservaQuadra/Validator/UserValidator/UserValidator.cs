using System.Text.RegularExpressions;
using ReservaQuadra.Exceptions;

namespace ReservaQuadra.Validator.UserValidator
{
    public class UserValidator: IUserValidator
    {
        public void ValidatePhone(string phone)
        {
            string phoneNumber = OnlyNumbers(phone.Trim());
            
            if(phoneNumber.Length != 11)
            {
                throw new BusinessException(BusinessExceptionMessage.UserNotValidPhone(phone));
            }
        }


        private string OnlyNumbers(string value)
        {
            return Regex.Replace(value ?? "", @"\D", "");
        }
    }
}
