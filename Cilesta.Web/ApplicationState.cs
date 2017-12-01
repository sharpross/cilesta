namespace Cilesta.Web
{
    /// <summary>
    /// Состояние приложения
    /// </summary>
    public enum ApplicationState
    {
        /// <summary>
        /// Инициализация приложения
        /// </summary>
        Initialize,
        
        /// <summary>
        /// Требуется обслуживание
        /// </summary>
        Maintenance,
        
        /// <summary>
        /// Ошибка инициализация приложения
        /// </summary>
        Error,
        
        /// <summary>
        /// Приложение запущено
        /// </summary>
        Started
    }
}