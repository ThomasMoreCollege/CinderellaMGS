using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_UserForms_ManageAppointment : System.Web.UI.Page
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
    protected void SearchByButton_Click(object sender, EventArgs e)
    {
        if (SearchDropDown.SelectedValue == "First Name")
        {
            // Sort List Box by First Name
        }
        else
        {
            // Sort List Box by Last Name
        }
    }
    protected void ChangeAppointmentButton_Click(object sender, EventArgs e)
    {
        // SQL code to edit Cinderella information with new Appointment time data
    }
}