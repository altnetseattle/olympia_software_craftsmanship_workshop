using System;
using System.Web;

namespace Sufors.Helpers
{
    /// <summary>
    /// TODO: What is the purpose of this class?
    /// </summary>
    public static class CitizenHelper
    {
        private const string DetailUrl = "~/CitizenDetail.aspx?id={0}";
        private const string NewUrl = "~/CitizenEdit.aspx?id=New";
        private const string EditUrl = "~/CitizenEdit.aspx?id={0}";

        /// <summary>
        /// TODO: Directly bound to HttpContext and completely untestable.
        /// </summary>
        /// <param name="id"></param>
        public static void NavigateToCitizenDetail(int id)
        {
            HttpContext.Current.Response.Redirect(string.Format(DetailUrl,id));
        }

        /// <summary>
        /// TODO: Directly bound to HttpContext and completely untestable.
        /// </summary>
        public static void NaviateToNewCitizen()
        {
            HttpContext.Current.Response.Redirect(NewUrl);
        }

        /// <summary>
        /// TODO: Directly bound to HttpContext and completely untestable.
        /// </summary>
        /// <param name="id"></param>
        public static void NaviateToEditCitizen(int id)
        {
            HttpContext.Current.Response.Redirect(string.Format(EditUrl,id));
        }
    }
}