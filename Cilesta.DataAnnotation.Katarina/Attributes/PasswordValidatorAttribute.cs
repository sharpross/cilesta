namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System.Collections.Generic;
    using Cilesta.DataAnnotation.Interfaces;

    public class PasswordValidatorAttribute : IModelValidationAttribute
    {
        private const string Error_EmptyPassword = "";
        private const string Error_LowLenght = "";

        private const string RegexSymbols = "[a-z A-Z а-яА-Я ёЁ 0-9]";

        public List<IFieldValidationInfo> Proccess()
        {
            return new List<IFieldValidationInfo>();
        }
    }
}
