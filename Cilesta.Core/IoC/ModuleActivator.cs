namespace Cilesta.Core.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Castle.Windsor;

    public class ModuleActivator
    {
        private const string MethodNameComponents = "InitComponents";
        private const string MethodNameValidate = "Validate";

        private IEnumerable<Assembly> Assembly { get; set; }

        private IWindsorContainer Container { get; set; }
        
        public void RegisterComponents(IWindsorContainer container)
        {
            this.Container = container;

            this.Assembly = this.GetAllAssembly();

            this.InitComponents();
        }

        private void InitComponents()
        {
            foreach (var assembly in this.Assembly)
            {
                var modules = assembly.GetTypes().Where(x => x.Name == "Module");

                foreach (var module in modules)
                {
                    this.InitMethod(module, MethodNameValidate);
                    this.InitMethod(module, MethodNameComponents);
                }
            }
        }

        private void InitMethod(Type module, string method)
        {
            var instance = Activator.CreateInstance(module);
            var methodInitComponents = module.GetMethod(method);

            switch (method)
            {
                case MethodNameValidate:
                    methodInitComponents.Invoke(instance, new object[] { });
                    break;
                case MethodNameComponents:
                default:
                    methodInitComponents.Invoke(instance, new object[] { this.Container });
                    break;
            }
            
        }

        private List<Assembly> GetAllAssembly()
        {
            var modules = new List<Assembly>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var types = assembly.GetTypes()
                    .Where(x => x.Name == "Module");

                foreach (var module in types)
                {
                    var exist = module.GetMethods()
                        .Any(x => x.Name == MethodNameComponents);

                    if (exist)
                    {
                        modules.Add(assembly);
                    }
                }
            }

            return modules;
        }
    }
}
