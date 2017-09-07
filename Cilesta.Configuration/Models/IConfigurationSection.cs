using System.Collections.ObjectModel;

namespace Cilesta.Configuration.Models
{
    /// <summary>
    /// Элемент секции
    /// </summary>
    public interface IConfigurationSection
    {
        /// <summary>
        /// Ключ секции
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// Получить параметр по ключу параметра
        /// </summary>
        /// <param name="key">Ключ параметра</param>
        /// <returns></returns>
        string this[string key] { get; }
    }
}
