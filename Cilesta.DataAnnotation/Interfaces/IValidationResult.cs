namespace Cilesta.DataAnnotation.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Результат валидации модели
    /// </summary>
    public interface IValidationResult
    {
        /// <summary>
        /// Флаг, что модель валидна.
        /// Модель счетается валидной, если не содержит критичных ошибок.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Результат валидации
        /// </summary>
        List<IFieldValidationInfo> Results { get; }
    }
}
