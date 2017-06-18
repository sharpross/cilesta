using System.Collections;

namespace Cilesta.Configuration.Models
{
    public interface IConfigurationItemCollection : ICollection
    {
        IConfigurationItem this[string key] { get; }
    }
}
