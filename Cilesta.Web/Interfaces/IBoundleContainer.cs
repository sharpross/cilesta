namespace Cilesta.Web.Interfaces
{
    using System.Web.Optimization;
    using Castle.Windsor;

    public interface IBoundleContainer
    {
        IWindsorContainer Container { get; set; }

        void Init(BundleCollection bundles);
    }
}