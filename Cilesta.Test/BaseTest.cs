namespace Cilesta.Test
{
    using Castle.Windsor;

    public class BaseTest
    {
        protected static IWindsorContainer Container { get; set; }

        public BaseTest()
        {
            var activator = new Activator();
            activator.Init();

            Container = activator.Container;
        }
    }
}
