namespace Cilesta.Configuration.Katarina.Implimentation
{
    using Cilesta.Configuration.Models;
    using System.Collections.ObjectModel;

    public class ConfigurationItemCollection : Collection<ConfigurationItem>, IConfigurationItemCollection
    {
        public string Key { get; set; }

        public IConfigurationItem this[string key]
        {
            get
            {
                foreach (var item in this)
                {
                    if (item.Key == key)
                    {
                        return item as IConfigurationItem;
                    }
                }

                return null;
            }
        }
    }
}
