using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_CinderellaCheckin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Checking if a session is running
        if ((Session["CurrentUser"] == null) || (Session["CurrentUser"].ToString()) != "Admin")
        {
            // Sets admin menu to not visible
            (this.Master as MasterPage).RevealAdmin(false);
        }
        else if ((Session["CurrentUser"].ToString()) == "Admin")
        {
            // Sets admin menu links to visible for admin access
            (this.Master as MasterPage).RevealAdmin(true);
        }
    }
 
    protected void SortAlphabeticallyButton_Click(object sender, EventArgs e)
    {
        // SQL code to order Cinderella's in ListBox by their Last/First name
    }

    protected void SortAppointmentsButton_Click(object sender, EventArgs e)
    {
        // SQL code to order Cinderella's by their Appointment time
    }

    protected void CheckinButton_Click(object sender, EventArgs e)
    {
        // SQL code that changes the selected Cinderella's status to 'WAITING' and rebuilds list box 
        // to remove Cinderella
    }
}