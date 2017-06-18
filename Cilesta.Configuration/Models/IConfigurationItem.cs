namespace Cilesta.Configuration.Models
{
    public interface IConfigurationItem
    {
        string Key { get; set; }

        string Value { get; set; }
    }
}
