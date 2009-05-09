using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sufors.Helpers;

public partial class CitizenEdit : Page
{
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