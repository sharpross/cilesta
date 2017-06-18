namespace Cilesta.Utils.Common
{
    using System;

    public static class WebUtils
    {
        public static string GetControllerName(Type controller)
        {
            var name = controller.Name.ToLowerInvariant();
            name = name.Substring(0, name.Length - "controller".Length);

            return name;
        }
    }
}
