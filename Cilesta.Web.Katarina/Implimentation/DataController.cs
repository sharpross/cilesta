namespace Cilesta.Web.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cilesta.Data.Models;

    public class DataController<T> : CilestaController where <T> : class, IEntity
    {
        public IDomainService<T> Service { get; set; }


    }
}
