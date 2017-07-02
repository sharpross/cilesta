namespace Cilesta.Security.Katarina.Models
{
    using System;
    using Cilesta.Security.Models;

    public class AuthResult : IAuthResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string Login { get; set; }

        public string UserID { get; set; }

        public AuthResult()
        {
            this.Success = false;
            this.Message = string.Empty;
            this.Login = string.Empty;
            this.UserID = string.Empty;
        }
    }
}
