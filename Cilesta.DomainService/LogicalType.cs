namespace Cilesta.Domain
{
    public enum LogicalType
    {
        /// <summary>
        /// Равенство ( = )
        /// </summary>
        Eq,
        
        /// <summary>
        /// Не ровняется ( != )
        /// </summary>
        NotEq,

        /// <summary>
        /// Больше ( > )
        /// </summary>
        Gt,

        /// <summary>
        /// Больше или равно ( >= )
        /// </summary>
        Ge,

        /// <summary>
        /// Меньше ( < )
        /// </summary>
        Lt,

        /// <summary>
        /// Меньше или равно ( <= )
        /// </summary>
        Le,

        /// <summary>
        /// Похоже
        /// </summary>
        Like,

        /// <summary>
        /// Не похоже
        /// </summary>
        NotLike,

        /// <summary>
        /// Присутствует в перечислении
        /// </summary>
        In,

        /// <summary>
        /// Null
        /// </summary>
        Null,

        /// <summary>
        /// Не Null
        /// </summary>
        NotNull
    }
}