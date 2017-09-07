namespace Cilesta.Configuration.Models
{
    using System.Collections;

    public interface IConfigurationSectionCollection : ICollection
    {
        /// <summary>
        /// Получить список параметров по ключу секции
        /// </summary>
        /// <param name="key">Ключ секции</param>
        /// <returns></returns>
        IConfigurationItem this[string key] { get;  }
    }
}
