namespace Cilesta.DataAnnotation.Interfaces
{
    /// <summary>
    /// Интерфейс валидатора модели
    /// </summary>
    public interface IValidationModel
    {
        IValidationResult Validate();
    }
}
