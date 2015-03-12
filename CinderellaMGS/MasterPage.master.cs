﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void RevealAdmin(bool showAdmin)
    {
        if (showAdmin)
        {
            AdminTitle.Visible = true;
            UserTitle.Visible = true;

            //Enable all user features if they were disabled
            AlterationsHyperLink.Visible = true;
            AutomatedPairingHyperLink.Visible = true;
            CinderellaCheckInHyperLink.Visible = true;
            ManagePackageHyperLink.Visible = true;
            CinderellRegistrationHyperLink.Visible = true;
            ManageAppointmentHyperLink.Visible = true;
            ManageShoppingHyperLink.Visible = true;
        }
        else
        {
            AdminTitle.Visible = false;
            UserTitle.Visible = false;
        }
    }

    public void RevealAllUserFeatures(bool showAllUser)
    {
        if (showAllUser)
        {
            UserTitle.Visible = true;
            AdminTitle.Visible = false;

            //Enable all user features if they were disabled
            AlterationsHyperLink.Visible = true;
            AutomatedPairingHyperLink.Visible = true;
            CinderellaCheckInHyperLink.Visible = true;
            ManagePackageHyperLink.Visible = true;
            CinderellRegistrationHyperLink.Visible = true;
            ManageAppointmentHyperLink.Visible = true;
            ManageShoppingHyperLink.Visible = true;
        }
        else
        {
            UserTitle.Visible = false;
            AdminTitle.Visible = false;
        }
    }

    public void RevealAutonmatedPairingOnly(bool showAutoPairing)
    {
        if (showAutoPairing)
        {
            UserTitle.Visible = true;
            AdminTitle.Visible = false;

            //Disable all other links under user features except for automatted pairing
            AlterationsHyperLink.Visible = false;
            AutomatedPairingHyperLink.Visible = true;
            CinderellaCheckInHyperLink.Visible = false;
            ManagePackageHyperLink.Visible = false;
            CinderellRegistrationHyperLink.Visible = false;
            ManageAppointmentHyperLink.Visible = false;
            ManageShoppingHyperLink.Visible = false;

        }
        else
        {
            UserTitle.Visible = false;
            AdminTitle.Visible = false;
        }
    }

    public void ManageMasterLayout()
    {
        // Checking if a session is running
        if (Session["CurrentAccType"] != null)
        {
            if (Session["CurrentAccType"].ToString() == "Administrator")
            {
                WelcomeLabel.Text = "Welcome, " + Session["CurrentUser"].ToString() + " | ";
                WelcomeLabel.Visible = true;
                RevealAdmin(true);
                LogOffLinkButton.Visible = true;
                LoginHyperLink.Visible = false;
            }
            else if (Session["CurrentAccType"].ToString() == "Standard")
            {
                WelcomeLabel.Text = "Welcome, " + Session["CurrentUser"].ToString() + " | ";
                WelcomeLabel.Visible = true;
                RevealAllUserFeatures(true);
                LogOffLinkButton.Visible = true;
                LoginHyperLink.Visible = false;
            }
            else if (Session["CurrentAccType"].ToString() == "Pairing")
            {
                WelcomeLabel.Text = "Welcome, " + Session["CurrentUser"].ToString() + " | ";
                WelcomeLabel.Visible = true;
                RevealAutonmatedPairingOnly(true);
                LogOffLinkButton.Visible = true;
                LoginHyperLink.Visible = false;
            }
            else
            {
                WelcomeLabel.Text = "--";
                WelcomeLabel.Visible = false;
                RevealAdmin(false);
                RevealAllUserFeatures(false);
                RevealAutonmatedPairingOnly(false);
                LogOffLinkButton.Visible = false;
                LoginHyperLink.Visible = true;
            }
            
        }
        else
        {
            // Sets admin menu to not visible
            WelcomeLabel.Text = "--";
            WelcomeLabel.Visible = false;
            RevealAdmin(false);
            RevealAllUserFeatures(false);
            RevealAutonmatedPairingOnly(false);
            LogOffLinkButton.Visible = false;
            LoginHyperLink.Visible = true;


            // Sets admin menu links to visible for admin access
            //(this.Master as MasterPage).RevealAdmin(true);
            //(this.Master as MasterPage).RevealAllUserFeatures(true);
        }
    }
    protected void LogOffLinkButton_Click(object sender, EventArgs e)
    {
        Session["CurrentAccType"] = null;
        Session["CurrentUser"] = null;
        Response.Redirect("~/Forms/DefaultForms/HomePage.aspx");
    }
}
