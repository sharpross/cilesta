namespace Cilesta.Data.Models
{
    using System;

    /// <summary>
    /// Базовая сущность
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Дата создания объекта
        /// </summary>
        DateTimeOffset DateCreated { get; set; }
    }
}
