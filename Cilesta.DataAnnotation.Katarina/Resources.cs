namespace Cilesta.DataAnnotation.Katarina
{
    public static class Resources
    {
        #region Cammon 

        public static string Error_Empty_Field = "Поле {0} не может быть пустым.";

        #endregion
        
        #region Password 

        public static string Error_Pswd_Lenght = "Минимальная длина пароля {0} символов.";
        public static string Error_Pswd_UpperLowCase = "Пароль должен содержать символы верхнего и нижнего регистра.";
        public static string Error_Pswd_Numbers = "Пароль должен содержать числа от 0 до 9.";
        
        #endregion
        
        #region Range 

        public static string Error_Range_Min = "Поле {0} не может быть меньше {1}.";
        public static string Error_Range_Max = "Поле {0} не может быть больше {1}.";

        #endregion
        
        #region String 

        public static string Error_String_Min = "Минимальная длина {0} символов.";
        public static string Error_String_Max = "Максимальная длина {0} символов.";

        #endregion
    }
}