using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sufors.Helpers;

public partial class CitizenDetail : System.Web.UI.Page
{
    private int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = int.Parse(Request.QueryString.Get("id"));
        Session.Add("_returnUrl", Request.UrlReferrer.PathAndQuery);
            

    }

    protected void PageCommand(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Edit":
                CitizenHelper.NaviateToEditCitizen(id);
                break;
            case "Add":
                break;
            case "Cancel":

                break;
        }

        SiteNavigationHelper.NavigateToReturnPage();
    }
}
