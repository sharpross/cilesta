namespace Cilesta.Web.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Castle.Windsor;
    using Cilesta.Logging.Interfaces;

    public class ModuleActivator
    {
        private const string MethodNameComponents = "InitComponents";
        private const string MethodNameValidate = "Validate";

        private IEnumerable<Assembly> Assembly { get; set; }

        private IWindsorContainer Container { get; set; }

        private ILogger Log { get; set; }

        public void RegisterComponents(IWindsorContainer container)
        {
            this.Container = container;
            this.Log = this.Container.Resolve<ILogger>();

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
                    try
                    {
                        this.InitMethod(module, MethodNameValidate);
                        this.InitMethod(module, MethodNameComponents);
                    }
                    catch (Exception ex)
                    {
                        this.Log.Error(ex);
                    }
                }
            }
        }

        private void InitMethod(Type module, string method)
        {
            var instance = Activator.CreateInstance(module);
            var methodInitComponents = module.GetMethod(method);
            var propertyValue = module.GetProperty("Code");

            if (propertyValue != null)
            {
                var moduleName = propertyValue.GetValue(instance);

                this.Log.Message("Init module: " + moduleName + "(" + method + ")");
            }

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
