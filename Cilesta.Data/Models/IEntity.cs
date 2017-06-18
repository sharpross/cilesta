namespace Cilesta.Data.Models
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        ulong Id { get; set; }
    }
}
