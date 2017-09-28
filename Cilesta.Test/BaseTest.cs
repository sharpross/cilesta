namespace Cilesta.Test
{
    using Castle.Windsor;

    public abstract class BaseTest
    {
        protected static IWindsorContainer Container { get; set; }
        
        public BaseTest()
        {
            var activator = new Activator();
            activator.Init();

            Container = activator.Container;

            AfterInit();
        }

        protected abstract void AfterInit();
    }
}
