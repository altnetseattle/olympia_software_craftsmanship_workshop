using System;
using System.Web;

namespace Sufors.Helpers
{
    /// <summary>
    /// TODO: Figure out what this class should be doing.
    /// </summary>
    public static class SiteNavigationHelper
    {
        private const string HomeUrl = "~/Default.aspx";

        /// <summary>
        /// TODO: Decouple from HttpContext so this can be made testable.
        /// </summary>
        public static void NavigateToHome()
        {
            HttpContext.Current.Response.Redirect(HomeUrl);
        }

        /// <summary>
        /// TODO: Decouple from HttpContext so this is testable.
        /// </summary>
        public static void NavigateToReturnPage()
        {
            var returnUrl = HttpContext.Current.Session["_returnUrl"] as string;
            if(String.IsNullOrEmpty(returnUrl))
                NavigateToHome();

            HttpContext.Current.Response.Redirect(returnUrl);
        }
    }
}