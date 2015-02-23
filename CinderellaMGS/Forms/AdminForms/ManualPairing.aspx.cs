using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_AdminForms_ManualPairing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MatchButton_Click(object sender, EventArgs e)
    {
        if (CinderellaGridView.SelectedRow == null)
        {
            // NOTE - look at Tommy's error code and implement here
            MatchButton.Text = "Need Cinderella";
        }
        else if (GodmotherGridView.SelectedRow == null)
        {
            // NOTE - look at Tommy's error code and implement here
            MatchButton.Text = "Need Godmother";
        }
        else
        {
            // SQL code to set up a match between the two and send them shopping, again will need to look at Tommy's code
        }
    }
}