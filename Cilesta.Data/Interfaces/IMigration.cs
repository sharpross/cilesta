namespace Cilesta.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMigration
    {
        //IWindsorContainer Container { get; set; }

        void Migrate();
    }
}
