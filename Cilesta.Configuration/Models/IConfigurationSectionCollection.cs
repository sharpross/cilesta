namespace Cilesta.Configuration.Models
{
    using System.Collections;

    public interface IConfigurationSectionCollection : ICollection
    {
        IConfigurationItem this[string key] { get;  }
    }
}
