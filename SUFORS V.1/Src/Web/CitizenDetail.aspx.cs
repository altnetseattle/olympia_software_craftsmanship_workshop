using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sufors.Helpers;

public partial class CitizenDetail : System.Web.UI.Page
{
    // TODO: Storing an int at this level makes things harder because an int has no context.
    private int id;

    /// <summary>
    /// TODO: Currently handling what appears to be session management responsibilities.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //TODO: Looks like we're basically trying persist a citizen to view detail on here. We can do better.
        id = int.Parse(Request.QueryString.Get("id"));

        //TODO: This one line contains a couple of responsibilities that could be mingled with similar functionality instead.
        Session.Add("_returnUrl", Request.UrlReferrer.PathAndQuery);
            

    }

    protected void PageCommand(object sender, CommandEventArgs e)
    {
        // TODO: This switch statement should be pushed down to a level/layer where we can test.
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

        // TODO: The page/view should not be orchestrating its own redirect.
        SiteNavigationHelper.NavigateToReturnPage();
    }
}
