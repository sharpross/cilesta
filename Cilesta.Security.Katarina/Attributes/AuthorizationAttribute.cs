namespace Cilesta.Security.Katarina.Attributes
{
    using System;

    /// <summary>
    /// Атрибут помечающий что контроллер/метод должны выполняться только автризованным пользователем
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizationAttribute : Attribute
    {
    }
}