namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;

    public class BaseAttribute : Attribute
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// Заголовое поля
        /// </summary>
        public string Caption { get; set; }
    }
}