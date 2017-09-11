namespace Cilesta.DataAnnotation.Interfaces
{
    /// <summary>
    /// Информация по ошибкам поля
    /// </summary>
    public interface IFieldValidationInfo
    {
        /// <summary>
        /// Код поля
        /// </summary>
        string FieldCode { get; }

        /// <summary>
        /// Уровень ошибкки
        /// </summary>
        ErrorLevel Level { get; }

        /// <summary>
        /// Текст ошибки
        /// </summary>
        string Message { get; }
    }
}
