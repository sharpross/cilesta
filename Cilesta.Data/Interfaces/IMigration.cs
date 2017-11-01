namespace Cilesta.Data.Interfaces
{
    using Castle.Windsor;

    public interface IMigration
    {
        string Code { get; }

        string Description { get; }

        string[] Depends { get; }

        IWindsorContainer Container { get; set; }

        void Migrate();

        bool Need();
    }
}