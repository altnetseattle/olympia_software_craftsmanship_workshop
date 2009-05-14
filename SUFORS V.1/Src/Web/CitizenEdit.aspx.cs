using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sufors.Helpers;

public partial class CitizenEdit : Page
{
    /// <summary>
    /// TODO: This method appears to be managing the session, view mode, and persistence. Tsk tsk. Also untestable.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (! Page.IsPostBack)
        {
            string id = Request.QueryString.Get("id");
            Session.Add("_returnUrl", Request.UrlReferrer.PathAndQuery);
            switch (id)
            {
                case "New":
                case null:
                    _citizenFormView.ChangeMode(FormViewMode.Insert);
                    break;
                default:
                    _citizenFormView.ChangeMode(FormViewMode.Edit);
                    break;
            }


            _insertButton.Visible = _citizenFormView.CurrentMode == FormViewMode.Insert;
            _updateButton.Visible = _citizenFormView.CurrentMode == FormViewMode.Edit;
        }
    }

    /// <summary>
    /// TODO: I would rather have as much logic as possible in a testable class instead of the web UI.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void PageCommand(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
                _citizenFormView.InsertItem(false);
                break;
            case "Update":
                _citizenFormView.UpdateItem(false);
                break;
            case "Cancel":
                
                break;
        }

        SiteNavigationHelper.NavigateToReturnPage();
    }
}