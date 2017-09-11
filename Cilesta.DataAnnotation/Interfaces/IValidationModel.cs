namespace Cilesta.DataAnnotation.Interfaces
{
    /// <summary>
    /// Интерфейс валидатора модели
    /// </summary>
    public interface IValidationModel
    {
        /// <summary>
        /// Проверить модель 
        /// </summary>
        /// <returns>Результат валидации</returns>
        IValidationResult Validate();
    }
}
