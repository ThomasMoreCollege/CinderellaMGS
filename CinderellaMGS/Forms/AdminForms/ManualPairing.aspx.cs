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

public partial class Forms_AdminForms_ManualPairing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MatchButton_Click(object sender, EventArgs e)
    {
        if (CinderellaGridView.SelectedRow == null)
        {
            // Outputs error message if no Cinderella is selected
            String errorVar = "Please select a Cinderella";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else if (GodmotherGridView.SelectedRow == null)
        {
            // Outputs error message if no Godmother is selected
            String errorVar = "Please select a Godmother";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else
        {
            // Creating variables to hold a string of the Cinderella's and Gomother's ID
            string SelectedCinderellaID = CinderellaGridView.SelectedValue.ToString();
            string SelectedGodmotherID = GodmotherGridView.SelectedValue.ToString();

            // Creating a variable to hold the current time
            string now = DateTime.Now.ToString();

            
            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            // SQL string to UPDATE the Cinderella with the Volunteer's ID
            string sql = "UPDATE Cinderella "
                        + "SET Volunteer_ID = '" + SelectedGodmotherID + "'"
                        + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            // SQL string to UPDATE Cinderella current status 
            sql = "UPDATE CinderellaStatusRecord "
                    + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                    + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "' AND IsCurrent = 'Y'";

            // Execute query
            SqlCommand comm2 = new SqlCommand(sql, conn);
            comm2.ExecuteNonQuery();

            // SQL string to INSERT the Cinderella shopping status 
            sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                    + "VALUES ('" + SelectedCinderellaID + "', '" + now + "', 'Shopping', 'Y')";

            // Execute query
            SqlCommand comm3 = new SqlCommand(sql, conn);
            comm3.ExecuteNonQuery();

            // SQL string to UPDATE Volunteer current status 
            sql = "UPDATE VolunteerStatusRecord "
                    + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                    + "WHERE Volunteer_ID = '" + SelectedGodmotherID + "' AND IsCurrent = 'Y'";

            // Execute query
            SqlCommand comm4 = new SqlCommand(sql, conn);
            comm4.ExecuteNonQuery();

            // SQL string to INSERT the Volunteer shopping status 
            sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                    + "VALUES ('" + SelectedGodmotherID + "', '" + now + "', 'Shopping', 'Y')";

            // Execute query
            SqlCommand comm5 = new SqlCommand(sql, conn);
            comm5.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            // Rebind the data to refresh the Grid
            CinderellaGridView.DataBind();
            CinderellaGridView.SelectedIndex = -1;

            GodmotherGridView.DataBind();
            GodmotherGridView.SelectedIndex = -1;
        }
    }
}