using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sufors.Helpers;

public partial class CitizenList : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // This is an appropriate UI function.
        _newLink.Command += PageCommand;
    }

    /// <summary>
    /// TODO: Parsing with no error checking?? Untestable. UI deciding where to navigate to? pfft.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    /// <summary>
    /// TODO: Once again let's push this down a layer.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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