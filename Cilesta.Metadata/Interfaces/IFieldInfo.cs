namespace Cilesta.Metadata.Interfaces
{
    public interface IFieldInfo
    {
        /// <summary>
        /// Код поля
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Наименование поля
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Тип поля
        /// </summary>
        FieldType Type { get; set; }
    }
}
