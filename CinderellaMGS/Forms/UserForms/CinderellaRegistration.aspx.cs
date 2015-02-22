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

        //Disable/enable the appropiate textboxes upon chosing a referral radio button
    }
    public void NewReferralRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (NewReferralRadioButton.Checked == true)
        {
            ExistingReferralDropDownList.Enabled = false;
            ExistingReferralDropDownList.BackColor = System.Drawing.Color.LightGray;

            NewReferralNameTextBox.Enabled = true;
            NewReferralNameTextBox.BackColor = System.Drawing.Color.White;

            NewSchoolAgencyTextBox.Enabled = true;
            NewSchoolAgencyTextBox.BackColor = System.Drawing.Color.White;

            ReferralNotesTextBox.Enabled = true;
            ReferralNotesTextBox.BackColor = System.Drawing.Color.White;
        }
    }
    public void ExistingReferralRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (ExistingReferralRadioButton.Checked == true)
        {
            ExistingReferralDropDownList.Enabled = true;
            ExistingReferralDropDownList.BackColor = System.Drawing.Color.White;

            NewReferralNameTextBox.Enabled = false;
            NewReferralNameTextBox.BackColor = System.Drawing.Color.LightGray;

            NewSchoolAgencyTextBox.Enabled = false;
            NewSchoolAgencyTextBox.BackColor = System.Drawing.Color.LightGray;

            ReferralNotesTextBox.Enabled = false;
            ReferralNotesTextBox.BackColor = System.Drawing.Color.LightGray;
        }
    }
}