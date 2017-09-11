namespace Cilesta.DataAnnotation.Interfaces
{
    using System.Collections.Generic;

    public interface IModelValidationAttribute
    {
        List<IFieldValidationInfo> Proccess();
    }
}
