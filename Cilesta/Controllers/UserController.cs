using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cilesta.Security.Katarina.Entities;
using Cilesta.Web.Katarina.Controllers;
using Cilesta.Web.Katarina.Implimentation;
using NHibernate.Criterion;

namespace Cilesta.Controllers
{
    public class UserController : DataController<User>
    {
        public JsonNetResult Abc()
        {
            var data = this.Service.GetAll();
            
            return JsonNetResult.Success(data);
        }
    }
}