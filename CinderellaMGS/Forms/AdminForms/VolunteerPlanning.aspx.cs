using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_AdminForms_VolunteerPlanning : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // This page gives an overview of the roles that volunteers have signed up for at a date 
        // previous to the event's weekend.
    }
    protected void selectDayDropDownListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Makes the alterations section visible.
        alterationsLabel.Visible = true;
        alterationsGridView.Visible = true;

        // Makes the dress organizers section visible.
        dressOrganizersLabel.Visible = true;
        dressOrganizersGridView.Visible = true;

        // Makes the personal shoppers section visible.
        personalShoppersLabel.Visible = true;
        personalShoppersGridView.Visible = true;

        // Makes the no role reported section visible.
        noRoleReportedLabel.Visible = true;
        noRoleReportedGridView.Visible = true;

        // Makes the not volunteeering section visible.
        notVolunteeringLabel.Visible = true;
        notVolunteeringGridView.Visible = true;

        // Functions if the user selects 'Friday' from the drop down box.
        if (selectDayDropDownListBox.SelectedItem.Text == "Friday")
        {
            // Set the GridViews to the Friday Data Sources.
            alterationsGridView.DataSourceID = "FridayAlterationDS";
            dressOrganizersGridView.DataSourceID = "FridayDressOrganizersDS";
            personalShoppersGridView.DataSourceID = "FridayPersonalShoppersDS";
            noRoleReportedGridView.DataSourceID = "FridayNoRoleDS";
            notVolunteeringGridView.DataSourceID = "FridayNotVolunteeringDS";
        }
        // Functions if the user selects 'Saturday' from the drop down box.
        else if (selectDayDropDownListBox.SelectedItem.Text == "Saturday")
        {
            //Set the Gridviews to the Saturday Data Sources.
            alterationsGridView.DataSourceID = "SaturdayAlterationsDS";
            dressOrganizersGridView.DataSourceID = "SaturdayDressOrganizerDS";
            personalShoppersGridView.DataSourceID = "SaturdayPersonalShoppersDS";
            noRoleReportedGridView.DataSourceID = "SaturdayNoRoleDS";
            notVolunteeringGridView.DataSourceID = "SaturdayNotVolunteeringDS";
        }
        // Fucntions if the user selects 'Select Day' from the drop down box.
        else
        {
            // Makes the alterations section visible.
            alterationsLabel.Visible = false;
            alterationsGridView.Visible = false;

            // Makes the dress organizers section visible.
            dressOrganizersLabel.Visible = false;
            dressOrganizersGridView.Visible = false;

            // Makes the personal shoppers section visible.
            personalShoppersLabel.Visible = false;
            personalShoppersGridView.Visible = false;

            // Makes the no role reported section visible.
            noRoleReportedLabel.Visible = false;
            noRoleReportedGridView.Visible = false;

            // Makes the not volunteering section visible.
            notVolunteeringLabel.Visible = false;
            notVolunteeringGridView.Visible = false;
        }

    }
}