namespace Cilesta.Configuration.Models
{
    /// <summary>
    /// Элемент кофигурации
    /// </summary>
    public interface IConfigurationItem
    {
        /// <summary>
        /// Ключ параметра
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Значение параметра
        /// </summary>
        string Value { get; set; }
    }
}
