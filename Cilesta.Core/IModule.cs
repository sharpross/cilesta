namespace Cilesta.Core
{
    using Castle.Windsor;

    public interface IModule
    {
        /// <summary>
        /// Код модуля
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Зависимость от модулей
        /// </summary>
        string[] Depends { get; }

        /// <summary>
        /// Инициализация модуля
        /// </summary>
        void InitComponents(IWindsorContainer container);

        /// <summary>
        /// Проверить на требования проведения миграции
        /// </summary>
        void Validate();
    }
}
