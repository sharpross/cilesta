namespace Cilesta.Metadata.Interfaces
{
    using System.Collections.Generic;
    using Cilesta.Metadata.Models;

    /// <summary>
    /// Описание структуры сущности
    /// </summary>
    public interface IMetadata
    {
        /// <summary>
        /// Список полей сущности
        /// </summary>
        IList<BaseFileldInfo> Fields { get; set; }

        /// <summary>
        /// Код сущности
        /// </summary>
        string Code { get; set; }
    }
}
