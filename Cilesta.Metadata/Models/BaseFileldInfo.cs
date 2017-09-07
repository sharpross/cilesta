namespace Cilesta.Metadata.Models
{
    /// <summary>
    /// Информация о поле
    /// </summary>
    public class BaseFileldInfo
    {
        /// <summary>
        /// Код поля
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Наименование поля
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тип поля
        /// </summary>
        public FieldType Type { get; set; }

        /*/// <summary>
        /// Объязателен к заполнению
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Максимальная длина поля
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// Минимальная длина поля
        /// </summary>
        public int MinLength { get; set; }*/

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseFileldInfo()
        {
            this.Code = string.Empty;
            this.Title = string.Empty;
            this.Type = FieldType.String;
        }
    }
}
