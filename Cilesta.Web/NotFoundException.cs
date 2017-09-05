namespace Cilesta.Web
{
    using System;

    /// <summary>
    /// Ошибка возникающая когда запрашиваемый ресурс не найден
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base("Запрашиваемый ресур не найден")
        { 
        }

        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
