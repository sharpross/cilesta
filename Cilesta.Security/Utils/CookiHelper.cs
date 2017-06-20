using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cilesta.Security.Utils
{
    public class CookiHelper
    {
        public static void SetCookie(HttpResponse response)
        {
            HttpCookie cookie = new HttpCookie(Security.Constants.CookieName);
            cookie["Module"] = "katarina";
            cookie["App"] = "cilesta";
            cookie.Expires = DateTime.Now.AddDays(1);

            response.Cookies.Add(cookie);
        }

        public static void RemoveCookie(HttpResponse response)
        {
            response.Cookies.Remove(Security.Constants.CookieName);
        }
    }
}
