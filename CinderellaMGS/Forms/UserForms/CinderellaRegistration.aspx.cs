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

        referralDropDownList.Enabled = false;
        
    }
    
   
    protected void RegisterCinderellaButton_Click1(object sender, EventArgs e)
    {

        if (newReferralCheckBox.Checked == true)
        {
            // Store the user input into easy to insert variables. 
            string firstname = FirstTextBox.Text;
            string lastname = LastNameTextBox.Text;
            string newReferralFirstName = NewReferralFirstNameTextBox.Text;
            string newReferralLastName = NewReferralLastNameTextBox.Text;
            string newReferralPhone = NewReferralPhoneTextBox.Text;
            string newReferralEmail = NewReferralEmailTextBox.Text;
            string newReferralAgency = NewSchoolAgencyTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            string notes = ReferralNotesTextBox.Text;
            string date = appointmentSelectDateCalender.SelectedDate.ToString("d");
            string time = AppTimeTextBox0.Text;
            string appointmentTime = date + ' ' + time;


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            string getTotal = "SELECT Count(CinderellaID) FROM Cinderella";
            SqlCommand getNumCinderellas = new SqlCommand(getTotal, conn);
            getNumCinderellas.ExecuteNonQuery();
            int totalCinderellas = (Int32)getNumCinderellas.ExecuteScalar();
            totalCinderellas = totalCinderellas + 1;    // Used for the key counter. (+1 to the number of current rows.)


            string getTotalReferrals = "SELECT Count(ReferralID) FROM Referrals";
            SqlCommand getNumReferrals = new SqlCommand(getTotalReferrals, conn);
            getNumReferrals.ExecuteNonQuery();
            int totalReferrals = (Int32)getNumReferrals.ExecuteScalar();
            totalReferrals = totalReferrals + 1;    // Used for the key counter. (+1 to the number of current rows.)

            string sql = "INSERT INTO Cinderella (CinderellaID, FirstName, LastName, Phone, Email, AppointmentDateTime, Note, Referral_ID) VALUES ('" + totalCinderellas + "', '" + firstname + "', '" + lastname + "', '" + phoneNumber + "', '" + email + "', '" + appointmentTime + "', '" + notes + "', '" + totalReferrals + "')";
            string sqlTwo = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + totalCinderellas + "', GetDate(), 'Pending', 'Y')";
            string sqlThree = "INSERT INTO Referrals (ReferralID, FirstName, LastName, Phone, Email, Agency) VALUES ('" + totalReferrals + "', '" + newReferralFirstName + "', '" + newReferralLastName + "', '" + newReferralPhone + "', '" + newReferralEmail + "', '" + newReferralAgency + "')";

            // Execute query
            SqlCommand comm3 = new SqlCommand(sqlThree, conn);
            comm3.ExecuteNonQuery();

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

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
            AppTimeTextBox0.Text = "";
            NewReferralLastNameTextBox.Text = "";

            existingReferralCheckBox.Checked = false;
            newReferralCheckBox.Checked = false;
        }

        else if (existingReferralCheckBox.Checked == true)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            string agency = referralDropDownList.SelectedItem.Text;

            string getTotal = "SELECT Count(CinderellaID) FROM Cinderella";
            SqlCommand getNumCinderellas = new SqlCommand(getTotal, conn);
            getNumCinderellas.ExecuteNonQuery();
            int totalCinderellas = (Int32)getNumCinderellas.ExecuteScalar();
            totalCinderellas = totalCinderellas + 1;    // Used for the key counter. (+1 to the number of current rows.)

            string getAgencyIDQuery = "SELECT referralID FROM Referrals WHERE agency = '" + agency + "'";
            SqlCommand getAgencyID = new SqlCommand(getAgencyIDQuery, conn);
            getAgencyID.ExecuteNonQuery();
            int agencyID = (Int32)getAgencyID.ExecuteScalar();

            string firstname = FirstTextBox.Text;
            string lastname = LastNameTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
            string email = EmailTextBox.Text;
            string notes = ReferralNotesTextBox.Text;
            string date = appointmentSelectDateCalender.SelectedDate.ToString("d");
            string time = AppTimeTextBox0.Text;
            string appointmentTime = date + ' ' + time;

            string sql = "INSERT INTO Cinderella (CinderellaID, FirstName, LastName, Phone, Email, AppointmentDateTime, Note, Referral_ID) VALUES ('" + totalCinderellas + "', '" + firstname + "', '" + lastname + "', '" + phoneNumber + "', '" + email + "', '" + appointmentTime + "', '" + notes + "', '" + agencyID + "')";
            string sqlTwo = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + totalCinderellas + "', GetDate(), 'Pending', 'Y')";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            // Execute query
            SqlCommand comm2 = new SqlCommand(sqlTwo, conn);
            comm2.ExecuteNonQuery();

            conn.Close();

            // Revent all text field values back to empty to allow for another Cinderella input.
            FirstTextBox.Text = "";
            AppTimeTextBox0.Text = "";
            LastNameTextBox.Text = "";
            NewReferralFirstNameTextBox.Text = "";
            NewReferalLastNameValidator.Text = "";
            NewReferralPhoneTextBox.Text = "";
            NewReferralEmailTextBox.Text = "";
            NewSchoolAgencyTextBox.Text = "";
            PhoneNumberTextBox.Text = "";
            EmailTextBox.Text = "";
            ReferralNotesTextBox.Text = "";
            AppTimeTextBox0.Text = "";
            NewReferralLastNameTextBox.Text = "";

            existingReferralCheckBox.Checked = false;
            newReferralCheckBox.Checked = false;
          
        }

    }

    protected void existingReferralCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        referralDropDownList.Enabled = true;
        newReferralCheckBox.Checked = false;

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
    protected void newReferralCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        existingReferralCheckBox.Checked = false;
        referralDropDownList.Enabled = false;

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
}

/*

string sqlThree = "INSERT INTO Referrals (ReferralID, FirstName, LastName, Phone, Email, Agency) VALUES ('4', '" + newReferralFirstName + "', '" + newReferralLastName + "', '" + newReferralPhone + "', '" + newReferralEmail + "', '" + newReferralAgency + "')";

*/