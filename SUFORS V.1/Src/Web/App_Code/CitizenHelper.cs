using System;
using System.Web;

namespace Sufors.Helpers
{
    public static class CitizenHelper
    {
        private const string DetailUrl = "~/CitizenDetail.aspx?id={0}";
        private const string NewUrl = "~/CitizenEdit.aspx?id=New";
        private const string EditUrl = "~/CitizenEdit.aspx?id={0}";

        public static void NavigateToCitizenDetail(int id)
        {
            HttpContext.Current.Response.Redirect(string.Format(DetailUrl,id));
        }

        public static void NaviateToNewCitizen()
        {
            HttpContext.Current.Response.Redirect(NewUrl);
        }

        public static void NaviateToEditCitizen(int id)
        {
            HttpContext.Current.Response.Redirect(string.Format(EditUrl,id));
        }
    }
}