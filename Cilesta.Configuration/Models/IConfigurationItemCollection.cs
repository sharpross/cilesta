using System.Collections;

namespace Cilesta.Configuration.Models
{
    /// <summary>
    /// Колелкция парметров
    /// </summary>
    public interface IConfigurationItemCollection : ICollection
    {
        /// <summary>
        /// Получить значение парметра
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IConfigurationItem this[string key] { get; }
    }
}
