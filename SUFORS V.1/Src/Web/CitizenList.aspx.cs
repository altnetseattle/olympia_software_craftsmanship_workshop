using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sufors.Helpers;

public partial class CitizenList : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        _newLink.Command += PageCommand;
    }

    protected void GridCommand(object sender, GridViewCommandEventArgs e)
    {
        var grid = e.CommandSource as GridView;
        int rowIndex = int.Parse(e.CommandArgument.ToString());
        var id = (int) grid.DataKeys[rowIndex]["Id"];

        switch (e.CommandName)
        {
            case "Select":
                CitizenHelper.NavigateToCitizenDetail(id);
                break;
        }
    }

    protected void PageCommand(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "New":
                CitizenHelper.NaviateToNewCitizen();
                break;
            case "Cancel":
                break;
        }
    }
}