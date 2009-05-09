using System;
using System.Web;

namespace Sufors.Helpers
{
    public static class SiteNavigationHelper
    {
        private const string HomeUrl = "~/Default.aspx";
        public static void NavigateToHome()
        {
            HttpContext.Current.Response.Redirect(HomeUrl);
        }

        public static void NavigateToReturnPage()
        {
            var returnUrl = HttpContext.Current.Session["_returnUrl"] as string;
            if(String.IsNullOrEmpty(returnUrl))
                NavigateToHome();

            HttpContext.Current.Response.Redirect(returnUrl);
        }
    }
}