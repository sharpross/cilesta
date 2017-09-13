namespace Cilesta.DataAnnotation.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Итерфейс атрибута валидации поля
    /// </summary>
    public interface IModelValidationAttribute
    {
        /// <summary>
        /// Проверить поле на ошибки    
        /// </summary>
        /// <returns>Список ошибок по полю</returns>
        List<IFieldValidationInfo> Proccess(object value, string fieldCode);
    }
}
