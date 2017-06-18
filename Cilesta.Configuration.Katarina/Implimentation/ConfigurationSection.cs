namespace Cilesta.Configuration.Katarina.Implimentation
{
    using Cilesta.Configuration.Models;

    public class ConfigurationSection : IConfigurationSection
    {
        public ConfigurationItemCollection Parametres { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string this[string key]
        {
            get
            {
                foreach (var item in this.Parametres)
                {
                    if (item.Key == key)
                    {
                        return item.Value;
                    }
                }

                return null;
            }
        }
    }
}
