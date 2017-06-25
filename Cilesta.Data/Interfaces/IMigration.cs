namespace Cilesta.Data.Interfaces
{
    using Castle.Windsor;

    public interface IMigration
    {
        string Code { get; }

        IWindsorContainer Container { get; set; }

        void Migrate();

        bool Need();
    }
}
