namespace Cilesta.Security.Utils
{
    using System;
    using System.Web;

    public static class CookiHelper
    { 
        public static void SetCookie(HttpResponseBase response, string login, string userId)
        {
            HttpCookie cookie = new HttpCookie(Constants.CookieName);
            cookie["module"] = "cilesta";

            cookie.Values[Constants.CookieUserName] = login;
            cookie.Values[Constants.CookieUserId] = userId;

            cookie.Expires = DateTime.Now.AddDays(1);

            response.Cookies.Add(cookie);
        }

        public static void RemoveCookie(HttpResponseBase response)
        {
            var cookie = response.Cookies.Get(Constants.CookieName);

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                response.Cookies.Add(cookie);
            }
        }
    }
}
