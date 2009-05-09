using System;
using System.Web;

namespace Sufors.Helpers
{
    public static class CitizenHelper
    {
        private const string DetailUrl = "~/CitizenDetail.aspx?id={0}";
        private const string NewUrl = "~/CitizenEdit.aspx?id=New";

        public static void NavigateToCitizenDetail(int id)
        {
            HttpContext.Current.Response.Redirect(string.Format(DetailUrl,id));
        }

        public static void NaviateToNewCitizen()
        {
            HttpContext.Current.Response.Redirect(NewUrl);
        }
    }
}