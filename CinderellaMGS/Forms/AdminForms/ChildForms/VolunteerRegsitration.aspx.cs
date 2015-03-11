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
        (this.Master as MasterPage).ManageMasterLayout();
    }
    protected void RegisterFormButton_Click(object sender, EventArgs e)
    {

        string firstName = FirstTextBox.Text;
        string lastName = LastNameTextBox.Text;
        string email = EmailTextBox.Text;
        
        string phone = PhoneTextBox.Text;
        if (phone == string.Empty)
        {
            phone = "--";
        }
        
        string address = AddresstextBox.Text;
        if (address == string.Empty)
        {
            address = "--";
        }
       
        string city = CityTextBox.Text;
        if (city == string.Empty)
        {
            city = "--";
        }
        
        string state = StateTextBox.Text;
        if (state == string.Empty)
        {
            state = "--";
        }
        
        string zipCode = ZipCodeTextBox.Text;
        if (zipCode == string.Empty)
        {
            zipCode = "--";
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();
        string sql = "INSERT INTO Volunteer (FirstName, LastName, Address, City, State, Zipcode, Phone, Email) "
                        + "VALUES ( '" + firstName + "', '" + lastName + "', '" + address + "', '" + city + "', '" + state + "', '" + zipCode + "', '" + phone + "', '" + email + "')";

        // Execute query
        SqlCommand comm1 = new SqlCommand(sql, conn);
        comm1.ExecuteNonQuery();

        // String to retrieve the recently inserted VolunteerID
        string sqlTwo = "SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
        SqlCommand comm2 = new SqlCommand(sqlTwo, conn);
        string newID = comm2.ExecuteScalar().ToString();

        //  SQL string to insert Volunteer into VolunteerStatusRecord with a current status of Pending
        string sqlThree = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                            + "VALUES ('" + newID + "', GetDate(), 'Pending', 'Y')";
        SqlCommand comm3 = new SqlCommand(sqlThree, conn);
        comm3.ExecuteNonQuery();

        // Checking if a Role is selected for the Friday Shift
        if (FridayRolesDropDownList.SelectedValue != "Not Volunteering")
        {
            // Creating a variable to hold the role for Friday
            string FriRole = FridayRolesDropDownList.SelectedValue;

            // If Personal Shopper is selected, making the role Godmother
            if (FriRole == "Personal Shopper")
            {
                FriRole = "Godmother";
            }
            // String to INSERT Volunteer ShiftRecord for Friday
            string sqlFour = "INSERT INTO VolunteerShiftRecord (Volunteer_ID, Shift_Name, Role_Name) "
                            + "VALUES('" + newID + "', 'Friday', '" + FriRole + "')";
            SqlCommand comm4 = new SqlCommand(sqlFour, conn);
            comm4.ExecuteNonQuery();
        }

        // Checking if a Role is selected for the Saturday Shift
        if (SaturdayRolesDropDownList.SelectedValue != "Not Volunteering")
        {
            // Creating a variable to hold the role for Friday
            string SatRole = SaturdayRolesDropDownList.SelectedValue;

            // If Personal Shopper is selected, making the role Godmother
            if (SatRole == "Personal Shopper")
            {
                SatRole = "Godmother";
            }
            // String to INSERT Volunteer ShiftRecord for Saturday
            string sqlFive = "INSERT INTO VolunteerShiftRecord (Volunteer_ID, Shift_Name, Role_Name) "
                            + "VALUES('" + newID + "', 'Saturday', '" + SatRole + "')";
            SqlCommand comm5 = new SqlCommand(sqlFive, conn);
            comm5.ExecuteNonQuery();
        }


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