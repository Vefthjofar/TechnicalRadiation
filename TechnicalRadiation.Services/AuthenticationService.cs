namespace TechnicalRadiation.Services
{
    public class AuthenticationService
    {
        private string validToken = "token";
        public bool isValidToken(string token)
        {
            if(token == validToken)
            {
                return true;
            }
            return false;
        }
    }
}