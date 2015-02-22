using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_AdminForms_Querying : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ExecuteButton_Click(object sender, EventArgs e)
    {
        // Code to recognize SQL command and execute appropriate SQL in database
    }
    protected void ClearButton_Click(object sender, EventArgs e)
    {
        // Clears the textbox of text
        QueryTextBox.Text = "";
    }
    protected void TableNameButton_Click(object sender, EventArgs e)
    {
        // SQL code that outputs all the table names in database
    }
}