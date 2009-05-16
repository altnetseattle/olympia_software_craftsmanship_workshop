using System;
using System.Web;

namespace Sufors.Helpers
{
    public static class ReportHelper
    {
        private const string NewCitizenReportUrl = "~/ReportEdit.aspx?citizenid={0}";
        private const string CitizenReportUrl = "~/ReportEdit.aspx?citizenid={0}&id={1}";
        public static void NavigateToNewReportForCitizen(int id)
        {
            HttpContext.Current.Response.Redirect(string.Format(NewCitizenReportUrl,id));
        }

        public static void NavigateToReport(int id, int citizenId)
        {
            HttpContext.Current.Response.Redirect(String.Format(CitizenReportUrl,citizenId, id));

        }
    }
}