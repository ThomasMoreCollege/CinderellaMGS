using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

public partial class Forms_UserForms_CinderellaRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();   
    }
    
   
    protected void RegisterCinderellaButton_Click1(object sender, EventArgs e)
    {

        // Creating a variable to hold the Date (minus the standard 12:00:00 AM setting) and Time of new appointment
        string appDate = appointmentSelectDateCalender.SelectedDate.ToString().Replace("12:00:00 AM", "");
        string appTime = ddlStartTimeHr.SelectedValue.ToString() + ":" + ddlStartTimeMin.SelectedValue.ToString() + " " + ddlStartTimeAMPM.SelectedValue;

        if (NewReferralRadioButton.Checked == true)
        {
            // Store the user input into easy to insert variables. 
            string firstname = FirstTextBox.Text.Trim();
            string lastname = LastNameTextBox.Text.Trim();
            string newReferralFirstName = NewReferralFirstNameTextBox.Text.Trim();
            string newReferralLastName = NewReferralLastNameTextBox.Text.Trim();
            string newReferralPhone = NewReferralPhoneTextBox.Text.Trim();
            string newReferralEmail = NewReferralEmailTextBox.Text.Trim();
            string newReferralAgency = NewSchoolAgencyTextBox.Text.Trim();
            string phoneNumber = PhoneNumberTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string notes = ReferralNotesTextBox.Text.Trim();
            string date = appointmentSelectDateCalender.SelectedDate.ToString("d");
            string time = appTime;
            string appointmentTime = date + ' ' + time;


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            string getTotalReferrals = "SELECT Count(ReferralID) FROM Referrals";
            SqlCommand getNumReferrals = new SqlCommand(getTotalReferrals, conn);
            getNumReferrals.ExecuteNonQuery();
            int totalReferrals = (Int32)getNumReferrals.ExecuteScalar();
            totalReferrals = totalReferrals + 1;    // Used for the key counter. (+1 to the number of current rows.)

            string sql = "INSERT INTO Cinderella (FirstName, LastName, Phone, Email, AppointmentDateTime, Note, Referral_ID) VALUES ('" + firstname + "', '" + lastname + "', '" + phoneNumber + "', '" + email + "', '" + appointmentTime + "', '" + notes + "', '" + totalReferrals + "')";

            string cinderellaIDQuery = "SELECT CinderellaID FROM Cinderella WHERE FirstName='" + firstname + "' AND LastName='" + lastname + "' AND Email='" + email + "'";
            
            string sqlThree = "INSERT INTO Referrals (ReferralID, FirstName, LastName, Phone, Email, Agency) VALUES ('" + totalReferrals + "', '" + newReferralFirstName + "', '" + newReferralLastName + "', '" + newReferralPhone + "', '" + newReferralEmail + "', '" + newReferralAgency + "')";

            // Execute query
            SqlCommand comm3 = new SqlCommand(sqlThree, conn);
            comm3.ExecuteNonQuery();

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            //Execute query 
            SqlCommand newCinderellaID = new SqlCommand(cinderellaIDQuery, conn);

            //Retrieve results from query and store in a varaible 
            string cinderellaID = newCinderellaID.ExecuteScalar().ToString();

            string sqlTwo = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + cinderellaID + "', GetDate(), 'Pending', 'Y')";

            // Execute query
            SqlCommand comm2 = new SqlCommand(sqlTwo, conn);
            comm2.ExecuteNonQuery();

            conn.Close();

            // Revent all text field values back to empty to allow for another Cinderella input.
            FirstTextBox.Text = "";
            LastNameTextBox.Text = "";
            NewReferralFirstNameTextBox.Text = "";
            NewReferalLastNameValidator.Text = "";
            NewReferralPhoneTextBox.Text = "";
            NewReferralEmailTextBox.Text = "";
            NewSchoolAgencyTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
            EmailTextBox.Text = "";
            ReferralNotesTextBox.Text = "";
            ddlStartTimeHr.SelectedIndex = -1;
            ddlStartTimeMin.SelectedIndex = -1;
            ddlStartTimeAMPM.SelectedIndex = -1;
            NewReferralLastNameTextBox.Text = "";

            ExistingReferralRadioButton.Checked = false;
            NewReferralRadioButton.Checked = false;
        }

        else if (ExistingReferralRadioButton.Checked == true)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            string agency = referralDropDownList.SelectedItem.Text;

            string getAgencyIDQuery = "SELECT referralID FROM Referrals WHERE agency = '" + agency + "'";
            SqlCommand getAgencyID = new SqlCommand(getAgencyIDQuery, conn);
            getAgencyID.ExecuteNonQuery();
            int agencyID = (Int32)getAgencyID.ExecuteScalar();

            string firstname = FirstTextBox.Text.Trim();
            string lastname = LastNameTextBox.Text.Trim();
            string phoneNumber = PhoneNumberTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string notes = ReferralNotesTextBox.Text.Trim();
            string date = appointmentSelectDateCalender.SelectedDate.ToString("d");
            string time = appTime;
            string appointmentTime = date + ' ' + time;

            string sql = "INSERT INTO Cinderella (FirstName, LastName, Phone, Email, AppointmentDateTime, Note, Referral_ID) VALUES ('" + firstname + "', '" + lastname + "', '" + phoneNumber + "', '" + email + "', '" + appointmentTime + "', '" + notes + "', '" + agencyID + "')";

            string cinderellaIDQuery = "SELECT CinderellaID FROM Cinderella WHERE FirstName='" + firstname + "' AND LastName='" + lastname + "' AND Email='" + email + "'";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            //Execute query 
            SqlCommand newCinderellaID = new SqlCommand(cinderellaIDQuery, conn);

            //Retrieve results from query and store in a varaible 
            string cinderellaID = newCinderellaID.ExecuteScalar().ToString();

            string sqlTwo = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + cinderellaID + "', GetDate(), 'Pending', 'Y')";

            // Execute query
            SqlCommand comm2 = new SqlCommand(sqlTwo, conn);
            comm2.ExecuteNonQuery();

            conn.Close();

            // Revent all text field values back to empty to allow for another Cinderella input.
            FirstTextBox.Text = "";
            //AppTimeTextBox0.Text = "";
            LastNameTextBox.Text = "";
            NewReferralFirstNameTextBox.Text = "";
            NewReferalLastNameValidator.Text = "";
            NewReferralPhoneTextBox.Text = "";
            NewReferralEmailTextBox.Text = "";
            NewSchoolAgencyTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
            EmailTextBox.Text = "";
            ReferralNotesTextBox.Text = "";
            ddlStartTimeHr.SelectedIndex = -1;
            ddlStartTimeMin.SelectedIndex = -1;
            ddlStartTimeAMPM.SelectedIndex = -1;
            NewReferralLastNameTextBox.Text = "";

            ExistingReferralRadioButton.Checked = false;
            NewReferralRadioButton.Checked = false;
          
        }

    }

    protected void NewReferralRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        ExistingReferralRadioButton.Checked = false;
        referralDropDownList.Enabled = false;
        referralDropDownList.BackColor = System.Drawing.Color.LightGray;

        NewReferralFirstNameTextBox.Enabled = true;
        NewReferralLastNameTextBox.Enabled = true;
        NewReferralPhoneTextBox.Enabled = true;
        NewReferralEmailTextBox.Enabled = true;
        NewSchoolAgencyTextBox.Enabled = true;

        NewReferalFirstNameValidator.Enabled = true;
        NewReferalLastNameValidator.Enabled = true;
        NewReferalPhoneValidator.Enabled = true;
        NewReferalEmailValidator.Enabled = true;
        NewSchoolAgengyValidator.Enabled = true;

        referralDropDownList.DataBind();
    }
    protected void ExistingReferralRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        referralDropDownList.Enabled = true;
        NewReferralRadioButton.Checked = false;
        referralDropDownList.BackColor = System.Drawing.Color.White;

        NewReferralFirstNameTextBox.Enabled = false;
        NewReferralLastNameTextBox.Enabled = false;
        NewReferralPhoneTextBox.Enabled = false;
        NewReferralEmailTextBox.Enabled = false;
        NewSchoolAgencyTextBox.Enabled = false;

        NewReferalFirstNameValidator.Enabled = false;
        NewReferalLastNameValidator.Enabled = false;
        NewReferalPhoneValidator.Enabled = false;
        NewReferalEmailValidator.Enabled = false;
        NewSchoolAgengyValidator.Enabled = false;

        referralDropDownList.DataBind();
    }
}

/*

string sqlThree = "INSERT INTO Referrals (ReferralID, FirstName, LastName, Phone, Email, Agency) VALUES ('4', '" + newReferralFirstName + "', '" + newReferralLastName + "', '" + newReferralPhone + "', '" + newReferralEmail + "', '" + newReferralAgency + "')";

*/