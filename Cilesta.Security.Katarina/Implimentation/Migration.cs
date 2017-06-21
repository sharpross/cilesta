namespace Cilesta.Security.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Castle.Windsor;
    using Cilesta.Data.Interfaces;
    using Cilesta.Security.Interfaces;

    public class Migration : IMigration
    {
        public IWindsorContainer Container { get; set; }

        public Interfaces.IUserService UserService { get; set; }

        public void Migrate()
        {
            
        }
    }
}
