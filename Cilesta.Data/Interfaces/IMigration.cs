namespace Cilesta.Data.Interfaces
{
    using Castle.Windsor;

    public interface IMigration
    {
        IWindsorContainer Container { get; set; }

        void Migrate();
    }
}
