using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_UserForms_CinderellaRegistration : System.Web.UI.Page
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
    protected void ExistingReferralRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        ExistingReferralDropDownList.Enabled = true;
        NewReferralNameTextBox.Enabled = false;
        NewSchoolAgencyTextBox.Enabled = false;
    }
    protected void NewReferralRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        ExistingReferralDropDownList.Enabled = false;
    }
}