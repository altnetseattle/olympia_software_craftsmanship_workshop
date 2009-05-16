using System;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        _dateLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy");
    }
}