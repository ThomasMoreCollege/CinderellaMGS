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
   
    protected void RegisterCinderellaButton_Click1(object sender, EventArgs e)
    {
        // Store the user input into easy to insert variables. 
        string firstname = FirstTextBox.Text;
        string lastname = LastNameTextBox.Text;
        string newReferralName = NewReferralNameTextBox.Text;
        string newReferralAgency = NewSchoolAgencyTextBox.Text;
        string phoneNumber = PhoneNumberTextBox.Text;
        string email = EmailTextBox.Text;
        string notes = ReferralNotesTextBox.Text;


        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        string getTotal = "SELECT Count(CinderellaID) FROM Cinderella";
        SqlCommand getNumCinderellas = new SqlCommand(getTotal, conn);
        getNumCinderellas.ExecuteNonQuery();
        int totalCinderellas = (Int32)getNumCinderellas.ExecuteScalar();

        totalCinderellas = totalCinderellas + 1;

        string sql = "INSERT INTO Cinderella (CinderellaID, FirstName, LastName, Phone, Email, AppointmentDateTime, Note) VALUES ('" + totalCinderellas + "', '" + firstname + "', '" + lastname + "', '" + phoneNumber + "', '" + email + "', '2015-02-23 12:00:00.000', '" + notes + "')";


        // Execute query
        SqlCommand comm1 = new SqlCommand(sql, conn);
        comm1.ExecuteNonQuery();

        string sqlTwo = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + totalCinderellas + "', GetDate(), 'Pending', 'Y')";

        // Execute query
        SqlCommand comm2 = new SqlCommand(sqlTwo, conn);
        comm2.ExecuteNonQuery();

        conn.Close();


        FirstTextBox.Text = "";
        LastNameTextBox.Text = "";
        NewReferralNameTextBox.Text = "";
        NewSchoolAgencyTextBox.Text = "";
        PhoneNumberTextBox.Text = "";
        EmailTextBox.Text = "";
        ReferralNotesTextBox.Text = "";


    }
}