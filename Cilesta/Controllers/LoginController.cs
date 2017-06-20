namespace Cilesta.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Web.Katarina.Implimentation;

    public class LoginController : CilestaController
    {
        public IAuthService AuthService { get; set; }

        public string Login(LoginModel model)
        {
            var result = this.AuthService.Login(model);

            if (result.Success)
            {
                result.Message = Security.Constants.MessageLoginSuccess;
            }

            return string.Empty;
        }
    }
}