using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sufors.Helpers;

public partial class ReportEdit : Page
{
    private string citizenId;
    private string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString.Get("id");
        citizenId = Request.QueryString.Get("citizenid");

        if (!Page.IsPostBack)
        {
            Session.Add("_returnUrl", Request.UrlReferrer.PathAndQuery);
            switch (id)
            {
                case "New":
                case null:
                    _reportFormView.ChangeMode(FormViewMode.Insert);
                    break;
                default:
                    _reportFormView.ChangeMode(FormViewMode.Edit);
                    break;
            }


            _insertButton.Visible = _reportFormView.CurrentMode == FormViewMode.Insert;
            _updateButton.Visible = _reportFormView.CurrentMode == FormViewMode.Edit;
        }
    }

    protected void PageCommand(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
                _reportFormView.InsertItem(false);
                break;
            case "Update":
                _reportFormView.UpdateItem(false);
                break;
            case "Cancel":

                break;
        }

        SiteNavigationHelper.NavigateToReturnPage();
    }

    protected void _reportSqlDataSource_Inserting(object sender, SqlDataSourceCommandEventArgs e)
    {
        if (citizenId != null)
            e.Command.Parameters["@citizenId"].Value = citizenId;
    }
}