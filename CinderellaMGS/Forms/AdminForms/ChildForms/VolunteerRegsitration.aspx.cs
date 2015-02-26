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

public partial class Forms_AdminForms_GodMotherRegsitration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RegisterFormButton_Click(object sender, EventArgs e)
    {

        string firstName = FirstTextBox.Text;
        string lastName = LastNameTextBox.Text;
        string address = AddresstextBox.Text;
        string city = CityTextBox.Text;
        string state = StateTextBox.Text;
        string zipCode = ZipCodeTextBox.Text;
        string phone = PhoneTextBox.Text;
        string email = EmailTextBox.Text;

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        string getTotal = "SELECT Count(VolunteerID) FROM Volunteer";
        SqlCommand getNumVolunteers = new SqlCommand(getTotal, conn);
        getNumVolunteers.ExecuteNonQuery();
        int totalVolunteers = (Int32)getNumVolunteers.ExecuteScalar();
        totalVolunteers = totalVolunteers + 1;    // Used for the key counter. (+1 to the number of current rows.)

        string sql = "INSERT INTO Volunteer (VolunteerID, FirstName, LastName, Address, City, State, Zipcode, Phone, Email) VALUES ('" + totalVolunteers + "', '" + firstName + "', '" + lastName + "', '" + address + "', '" + city + "', '" + state + "', '" + zipCode + "', '" + phone + "', '" + email + "')";

        // Execute query
        SqlCommand comm1 = new SqlCommand(sql, conn);
        comm1.ExecuteNonQuery();

        string sqlTwo = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + totalVolunteers + "', GetDate(), 'Pending', 'Y')";

        // Execute query
        SqlCommand comm2 = new SqlCommand(sqlTwo, conn);
        comm2.ExecuteNonQuery();

        conn.Close();

        FirstTextBox.Text = "";
        LastNameTextBox.Text = "";
        AddresstextBox.Text = "";
        CityTextBox.Text = "";
        StateTextBox.Text = "";
        ZipCodeTextBox.Text = "";
        PhoneTextBox.Text = "";
        EmailTextBox.Text = "";
    }
}