namespace Cilesta.Security.Katarina.Models
{
    using Cilesta.Security.Models;

    public class AuthResult : IAuthResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public AuthResult()
        {
            this.Success = false;
            this.Message = string.Empty;
        }
    }
}
