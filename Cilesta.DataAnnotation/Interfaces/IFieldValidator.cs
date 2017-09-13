namespace Cilesta.DataAnnotation.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Интерфейс валидатора значения
    /// </summary>
    public interface IFieldValidator
    {
        List<IFieldValidationInfo> Validate(IValidatorConfig config);
    }
}
