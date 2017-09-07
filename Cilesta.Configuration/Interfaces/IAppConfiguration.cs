namespace Cilesta.Configuration.Interfaces
{
    using Cilesta.Configuration.Models;

    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    public interface IAppConfiguration
    {
        /// <summary>
        /// Доступ к секции конфигурации
        /// </summary>
        /// <param name="key">Ключ секции</param>
        /// <returns>Элемент параметра</returns>
        IConfigurationSection this[string key] { get; }

        /// <summary>
        /// Установить значение из приложения по ключу секции и имени параметра
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <param name="newValue"></param>
        void SetParameterValue(string key, string parameter, string newValue);
    }
}
