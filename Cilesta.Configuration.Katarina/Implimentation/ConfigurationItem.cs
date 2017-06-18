namespace Cilesta.Configuration.Katarina.Implimentation
{
    using Cilesta.Configuration.Models;

    public class ConfigurationItem : IConfigurationItem
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
