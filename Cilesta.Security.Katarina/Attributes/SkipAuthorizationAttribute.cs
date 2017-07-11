namespace Cilesta.Security.Katarina.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SkipAuthorizationAttribute : Attribute
    {
        
    }
}
