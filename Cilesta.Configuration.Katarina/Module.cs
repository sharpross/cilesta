namespace Cilesta.Configuration.Katarina
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Configuration.Katarina.Implimentation;
    using Cilesta.Core;

    public class Module : IModule
    {
        public string Code => "Cilesta.Configuration.Katarina";

        public string[] Depends => new string[1];

        public void InitComponents(IWindsorContainer container)
        {
            
        }

        public void Validate()
        {
            
        }
    }
}
