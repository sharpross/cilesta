using System.Collections.ObjectModel;

namespace Cilesta.Configuration.Models
{
    public interface IConfigurationSection
    {
        string Key { get; set; }

        string this[string key] { get; }
    }
}
