using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sufors.Helpers;

public partial class CitizenList : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // This is an appropriate UI function.
        _newLink.Command += PageCommand;
        _SetupDataSource();
        _SetupGridView();
    }

    private void _SetupDataSource()
    {
        _sqlDataSource.ConnectionString = ConfigurationManager.ConnectionStrings["SUFORS"].ConnectionString;
        _sqlDataSource.SelectCommand = "usp_GetCitizenList";// = new SqlDataSource(ConfigurationManager.ConnectionStrings["SUFORS"].ConnectionString, "usp_GetCitizenList");
        _sqlDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
    }

    //private SqlDataSource _sqlDataSource;

    private void _SetupGridView()
    {
        var idBoundField = new ButtonField
                               {
                                   DataTextField = "ID",
                                   ButtonType = ButtonType.Link,
                                   CommandName = "Select",
                                   HeaderText = "Select"
                               };
        var firstNameField = new BoundField
                                 {
                                     DataField = "FirstName",
                                     HeaderText = "First Name",
                                     SortExpression = "FirstName, LastName"
                                 };
        var lastNameField = new BoundField
                                {
                                    DataField = "LastName",
                                    HeaderText = "Last Name",
                                    SortExpression = "LastName, FirstName"
                                };
        var phoneField = new BoundField
                             {
                                 DataField = "Phone",
                                 HeaderText = "Phone",
                                 SortExpression = "Phone"
                             };
        var emailField = new BoundField
                             {
                                 DataField = "EmailAddress",
                                 HeaderText = "Email Address",
                                 SortExpression = "EmailAddress"
                             };

        _gridView.Columns.Add(idBoundField);
        _gridView.Columns.Add(firstNameField);
        _gridView.Columns.Add(lastNameField);
        _gridView.Columns.Add(phoneField);
        _gridView.Columns.Add(emailField);

        _gridView.DataSourceID = "_sqlDataSource";
        _gridView.DataKeyNames = new[]{"Id"};
        _gridView.RowCommand += GridCommand;
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