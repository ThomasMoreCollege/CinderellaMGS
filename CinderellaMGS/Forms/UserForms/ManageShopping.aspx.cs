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

public partial class Forms_UserForms_ManageShopping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();

        // Disabling controls until a gridview is selected
        GoShoppingButton.Enabled = false;

    }
    protected void GoShoppingButton_Click(object sender, EventArgs e)
    {
        string SelectedCinderellaID = PairedCinderellaGridView.SelectedValue.ToString();
        // Creating a variable to hold the current time
        string now = DateTime.Now.ToString();

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection.
        conn1.Open();

        // SQL string to get the VolunteerID from the Cinderella entity
        string sql = "SELECT Volunteer_ID "
                        + "FROM Cinderella "
                        + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";

        // Execute SQL
        SqlCommand comm1 = new SqlCommand(sql, conn1);

        string SelectedVolunteerID = comm1.ExecuteScalar().ToString();

        // SQL string to UPDATE Cinderella's status to not current
        sql = "UPDATE CinderellaStatusRecord "
                + "SET IsCurrent = 'N', EndTime = '" + now + "' "
                + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "' AND IsCurrent = 'Y'";
        // Execute SQL
        SqlCommand comm2 = new SqlCommand(sql, conn1);
        comm2.ExecuteNonQuery();

        // SQL string to INSERT a new Shopping status for Cinderella
        sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                + "VALUES ('" + SelectedCinderellaID + "', '" + now + "', 'Shopping', 'Y')";
        // Execute SQL
        SqlCommand comm3 = new SqlCommand(sql, conn1);
        comm3.ExecuteNonQuery();

        // SQL string to UPDATE Volunteer's status to not current
        sql = "UPDATE VolunteerStatusRecord "
                + "SET IsCurrent = 'N', EndTime = '" + now + "' "
                + "WHERE Volunteer_ID = '" + SelectedVolunteerID + "' AND IsCurrent = 'Y'";
        // Execute SQL
        SqlCommand comm4 = new SqlCommand(sql, conn1);
        comm4.ExecuteNonQuery();

        // SQL string to INSERT a new Shopping status for Volunteer
        sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
        + "VALUES ('" + SelectedVolunteerID + "', '" + now + "', 'Shopping', 'Y')";
        // Execute SQL
        SqlCommand comm5 = new SqlCommand(sql, conn1);
        comm5.ExecuteNonQuery();


        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();

        // Rebind the data to refresh the grid
        PairedCinderellaGridView.DataBind();
        PairedCinderellaGridView.SelectedIndex = -1;

        ShoppingGridView.DataBind();
        ShoppingGridView.SelectedIndex = -1;

        GoShoppingButton.Enabled = false;
    }
    protected void PairedCinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Enabling the GoShopping button
        GoShoppingButton.Enabled = true;
    }
}