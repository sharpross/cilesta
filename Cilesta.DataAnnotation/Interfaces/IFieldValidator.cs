namespace Cilesta.DataAnnotation.Interfaces
{
    /// <summary>
    /// Интерфейс валидатора значения
    /// </summary>
    public interface IFieldValidator
    {
        void Validate(object value);
    }
}
