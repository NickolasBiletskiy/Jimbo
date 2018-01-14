using System.Collections.Generic;

namespace Jimbo
{
    public class ResponseMessages
    {
        public static Dictionary<ResponseCodes, string> MessageDictionary = new Dictionary<ResponseCodes, string>
        {
            {ResponseCodes.LOGIN_SUCCESFULL, "Login succesfull"},
            {ResponseCodes.USER_NOT_REGISTERED, "There is no such user"},
            {ResponseCodes.INTERNAL_ERROR, "Something wrong on server"},
        };
    }
}