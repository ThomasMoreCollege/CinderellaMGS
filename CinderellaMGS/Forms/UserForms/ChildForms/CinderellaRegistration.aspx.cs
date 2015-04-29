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

        if (NewReferralRadioButton.Checked == true && IsValid == true)
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
            string isManuallyPaired = "";
            if (NoRadioButton.Checked)
            {
                isManuallyPaired = "N";
            }
            if (YesRadioButton.Checked)
            {
                isManuallyPaired = "Y";
            }


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();
            
            //Query adds new Referral into the database
            string addReferralQuery = "INSERT INTO Referrals (FirstName, LastName, Phone, Email, Agency) "
                                        + "VALUES ('" + newReferralFirstName + "', '" + newReferralLastName + "', '" + newReferralPhone + "', '" + newReferralEmail + "', '" + newReferralAgency + "')";

            // Execute adding new referral into database
            SqlCommand addReferral = new SqlCommand(addReferralQuery, conn);
            addReferral.ExecuteNonQuery();

            //Query retrieves ID of new Referral
            string referralIDQuery = "SELECT TOP 1 ReferralID "
                                     + "FROM Referrals "
                                     + "ORDER BY ReferralID DESC";

            //Execute query to retrieve new referral ID
            SqlCommand newReferralID = new SqlCommand(referralIDQuery, conn);

            //Retrieve results from query and store in a varaible 
            int referralID = Convert.ToInt32(newReferralID.ExecuteScalar().ToString());

            //Query to added new Cinderella into the database
            string addCinderellaQuery = "INSERT INTO Cinderella (FirstName, LastName, Phone, Email, AppointmentDateTime, Note, Referral_ID, isManuallyPaired) "
                                        + "VALUES ('" + firstname + "', '" + lastname + "', '" + phoneNumber + "', '" + email + "', '" + appointmentTime + "', '" + notes + "', '" + referralID + "', '" + isManuallyPaired + "')";

            // Execute query
            SqlCommand addCinderella = new SqlCommand(addCinderellaQuery, conn);
            addCinderella.ExecuteNonQuery();

            //Get newly added Cinderellas' ID 
            string cinderellaIDQuery = "SELECT TOP 1 CinderellaID "
                                     + "FROM Cinderella "
                                     + "ORDER BY CinderellaID DESC";

            //Execute query 
            SqlCommand newCinderellaID = new SqlCommand(cinderellaIDQuery, conn);

            //Retrieve results from query and store in a varaible 
            string cinderellaID = newCinderellaID.ExecuteScalar().ToString();

            //Query to add record of the Cinderellas' status
            string addCinderellaStatusRecordQuery = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                                                    + "VALUES ('" + cinderellaID + "', GetDate(), 'Pending', 'Y')";

            // Execute query
            SqlCommand addCinderellaStatusRecord = new SqlCommand(addCinderellaStatusRecordQuery, conn);
            addCinderellaStatusRecord.ExecuteNonQuery();

            conn.Close();

            ConfirmationLabel.Text = firstname + " " + lastname + " has been successfully registered.";
            ConfirmationLabel.Visible = true;

            // Reset all text field values back to empty to allow for another Cinderella input.
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
        }

        else if (ExistingReferralRadioButton.Checked == true && IsValid == true)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            //Retrieve selected referral
            string agency = referralDropDownList.SelectedItem.Text;

            //Query to retrieve selected referral ID 
            string getAgencyIDQuery = "SELECT referralID "
                                        + "FROM Referrals "
                                        + "WHERE agency = '" + agency + "'";

            //Turn query striing into SQL command 
            SqlCommand getAgencyID = new SqlCommand(getAgencyIDQuery, conn);

            //Execute query
            getAgencyID.ExecuteNonQuery();

            //Store query result into a variable
            int agencyID = (Int32)getAgencyID.ExecuteScalar();

            //Store form data into variables
            string firstname = FirstTextBox.Text.Trim();
            string lastname = LastNameTextBox.Text.Trim();
            string phoneNumber = PhoneNumberTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string notes = ReferralNotesTextBox.Text.Trim();
            string date = appointmentSelectDateCalender.SelectedDate.ToString("d");
            string time = appTime;
            string appointmentTime = date + ' ' + time;
            string isManuallyPaired = "";
            if (NoRadioButton.Checked)
            {
                isManuallyPaired = "N";
            }
            if (YesRadioButton.Checked)
            {
                isManuallyPaired = "Y";
            }

            //Insert Cinderella into Database
            string addNewCinderellaQuery = "INSERT INTO Cinderella (FirstName, LastName, Phone, Email, AppointmentDateTime, Note, Referral_ID, isManuallyPaired) "
                            + "VALUES ('" + firstname + "', '" + lastname + "', '" + phoneNumber + "', '" + email + "', '" + appointmentTime + "', '" + notes + "', '" + agencyID + "', '" + isManuallyPaired + "')";

            // Execute query
            SqlCommand comm1 = new SqlCommand(addNewCinderellaQuery, conn);
            comm1.ExecuteNonQuery();

            //Query to retrieve ID of newly added Cinderella 
            string cinderellaIDQuery = "SELECT CinderellaID "
                                        + "FROM Cinderella "
                                        + "WHERE FirstName='" + firstname + "' AND LastName='" + lastname + "' AND Email='" + email + "'";

            //Turn query string into a SQL command
            SqlCommand newCinderellaID = new SqlCommand(cinderellaIDQuery, conn);            

            //Retrieve results from query and store in a varaible 
            string cinderellaID = newCinderellaID.ExecuteScalar().ToString();

            //Insert new status record for new Cinderella
            string insertNewCinWStatusRecord = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                            + "VALUES ('" + cinderellaID + "', GetDate(), 'Pending', 'Y')";

            ///Turn query string into a SQL command            
            SqlCommand comm2 = new SqlCommand(insertNewCinWStatusRecord, conn);

            // Execute query
            comm2.ExecuteNonQuery();

            conn.Close();

            ConfirmationLabel.Text = firstname + " " + lastname + " has been successfully registered.";
            ConfirmationLabel.Visible = true;

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


          
        }


        ExistingReferralRadioButton.Checked = true;
        NewReferralRadioButton.Checked = false;
        referralDropDownList.Enabled = true;
        referralDropDownList.BackColor = System.Drawing.Color.White;

        NewReferralFirstNameTextBox.Enabled = false;
        NewReferralLastNameTextBox.Enabled = false;
        NewReferralPhoneTextBox.Enabled = false;
        NewReferralEmailTextBox.Enabled = false;
        NewSchoolAgencyTextBox.Enabled = false;

        NewReferralFirstNameTextBox.BackColor = System.Drawing.Color.Silver;
        NewReferralLastNameTextBox.BackColor = System.Drawing.Color.Silver;
        NewReferralPhoneTextBox.BackColor = System.Drawing.Color.Silver;
        NewReferralEmailTextBox.BackColor = System.Drawing.Color.Silver;
        NewSchoolAgencyTextBox.BackColor = System.Drawing.Color.Silver;

        NewReferalFirstNameValidator.Enabled = false;
        NewReferalLastNameValidator.Enabled = false;
        NewReferalPhoneValidator.Enabled = false;
        NewReferalEmailValidator.Enabled = false;
        NewSchoolAgengyValidator.Enabled = false;

        referralDropDownList.DataBind();

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

        NewReferralFirstNameTextBox.BackColor = System.Drawing.Color.White;
        NewReferralLastNameTextBox.BackColor = System.Drawing.Color.White;
        NewReferralPhoneTextBox.BackColor = System.Drawing.Color.White;
        NewReferralEmailTextBox.BackColor = System.Drawing.Color.White;
        NewSchoolAgencyTextBox.BackColor = System.Drawing.Color.White;

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

        NewReferralFirstNameTextBox.BackColor = System.Drawing.Color.Silver;
        NewReferralLastNameTextBox.BackColor = System.Drawing.Color.Silver;
        NewReferralPhoneTextBox.BackColor = System.Drawing.Color.Silver;
        NewReferralEmailTextBox.BackColor = System.Drawing.Color.Silver;
        NewSchoolAgencyTextBox.BackColor = System.Drawing.Color.Silver;

        NewReferalFirstNameValidator.Enabled = false;
        NewReferalLastNameValidator.Enabled = false;
        NewReferalPhoneValidator.Enabled = false;
        NewReferalEmailValidator.Enabled = false;
        NewSchoolAgengyValidator.Enabled = false;

        referralDropDownList.DataBind();
    }
    protected void appointmentSelectDateCalender_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void DateCustVal_Validate(object source, ServerValidateEventArgs args)
    {
        if (appointmentSelectDateCalender.SelectedDate == null
        || appointmentSelectDateCalender.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
}

/*

string sqlThree = "INSERT INTO Referrals (ReferralID, FirstName, LastName, Phone, Email, Agency) VALUES ('4', '" + newReferralFirstName + "', '" + newReferralLastName + "', '" + newReferralPhone + "', '" + newReferralEmail + "', '" + newReferralAgency + "')";

*/