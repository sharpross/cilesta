namespace Cilesta.Security.Utils
{
    using System;
    using System.Web;

    public static class CookiHelper
    { 
        public static void SetCookie(HttpResponseBase response, string login)
        {
            HttpCookie cookie = new HttpCookie(Constants.CookieName);
            cookie["module"] = "cilesta";
            cookie.Expires = DateTime.Now.AddDays(1);

            response.Cookies.Add(cookie);
        }

        public static void RemoveCookie(HttpResponseBase response)
        {
            response.Cookies.Remove(Constants.CookieName);
        }
    }
}
