namespace Cilesta.DataAnnotation.Interfaces
{
    /// <summary>
    /// Интерфейс валидатора модели
    /// </summary>
    public interface IValidationModel
    {
        /// <summary>
        /// Проверить можель 
        /// </summary>
        /// <returns></returns>
        IValidationResult Validate();
    }
}
