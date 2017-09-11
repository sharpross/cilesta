namespace Cilesta.Metadata.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Описание структуры сущности
    /// </summary>
    public interface IMetadata
    {
        /// <summary>
        /// Список полей сущности
        /// </summary>
        IList<IFieldInfo> Fields { get; set; }

        /// <summary>
        /// Код сущности
        /// </summary>
        string Code { get; set; }
    }
}
