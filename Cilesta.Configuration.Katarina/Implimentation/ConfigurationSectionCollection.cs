namespace Cilesta.Configuration.Katarina.Implimentation
{
    using System;
    using Cilesta.Configuration.Models;
    using System.Collections.ObjectModel;

    public class ConfigurationSectionCollection : Collection<ConfigurationSection>, IConfigurationSectionCollection
    {
        public string Key { get; set; }

        public IConfigurationItem this[string key]
        {
            get
            {
                foreach (var section in this)
                {
                    if (section.Key == key)
                    {
                        var aa = 0;
                        //return section.Parametres;
                    }
                }

                return null;
            }
        }
    }
}