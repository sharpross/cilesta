namespace Cilesta.Security
{
    public enum AccessType
    {
        /// <summary>
        /// Доступ запрещён
        /// </summary>
        None = 0,

        /// <summary>
        /// Полный доступ
        /// </summary>
        All = 1,

        /// <summary>
        /// Читать данные
        /// </summary>
        Read = 2,

        /// <summary>
        /// Писать
        /// </summary>
        Write = 3,

        /// <summary>
        /// Удалять
        /// </summary>
        Delete = 4
    }
}
