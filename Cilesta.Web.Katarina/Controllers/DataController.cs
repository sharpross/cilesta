namespace Cilesta.Web.Katarina.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cilesta.Data.Models;

    public class DataController<T> : ListController<T> where T : class, IEntity
    {
        
    }
}
