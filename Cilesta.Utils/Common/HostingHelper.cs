namespace Cilesta.Utils.Common
{
    using System.Web.Hosting;

    public static class HostingHelper
    {
        public static string GetAppDirectory()
        {
            return HostingEnvironment.ApplicationPhysicalPath;
        }
    }
}
