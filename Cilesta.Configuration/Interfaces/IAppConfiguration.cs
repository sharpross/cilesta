namespace Cilesta.Configuration.Interfaces
{
    using Cilesta.Configuration.Models;

    public interface IAppConfiguration
    {
        IConfigurationSection this[string key] { get; }
    }
}
