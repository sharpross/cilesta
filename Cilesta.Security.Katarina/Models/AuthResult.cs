namespace Cilesta.Security.Katarina.Models
{
    using Security.Models;

    public class AuthResult : IAuthResult
    {
        public AuthResult()
        {
            Success = false;
            Message = string.Empty;
            Login = string.Empty;
            UserID = string.Empty;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public string Login { get; set; }

        public string UserID { get; set; }
    }
}