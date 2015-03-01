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


public partial class Forms_AdminForms_GodmotherClocking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TakeOffBreakButton_Click(object sender, EventArgs e)
    {
        if (VolunteerOnBreakGridView.SelectedRow == null)
        {
            // Outputs error message if no Vlolunteer is selected
            String errorVar = "Please select a Volunteer from the On Break table";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else
        {
            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            // Variable to hold selected Volunteer's ID
            string SelectedVolunteerID = VolunteerOnBreakGridView.SelectedValue.ToString();

            // Creating a variable to hold the current time
            string now = DateTime.Now.ToString();

            // SQL string to update the Volunteer's current status (On Break) to not current
            string sql = "UPDATE VolunteerStatusRecord "
                            + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                            + "WHERE Volunteer_ID = '" + SelectedVolunteerID + "' AND IsCurrent = 'Y'";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            // SQL string to insert new current status of Ready
            sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                    + "VALUES ('" + SelectedVolunteerID + "', '" + now + "', 'Ready', 'Y')";

            // Execute query
            SqlCommand comm2 = new SqlCommand(sql, conn);
            comm2.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            // Rebind the data to refresh the Grids
            VolunteerOffBreakGridView.DataBind();
            VolunteerOffBreakGridView.SelectedIndex = -1;

            VolunteerOnBreakGridView.DataBind();
            VolunteerOnBreakGridView.SelectedIndex = -1;
        }
    }
    protected void SendOnBreakButton_Click(object sender, EventArgs e)
    {
        if (VolunteerOffBreakGridView.SelectedRow == null)
        {
            // Outputs error message if no Vlolunteer is selected
            String errorVar = "Please select a Volunteer from the Working";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else
        {
            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            // Variable to hold selected Volunteer's ID
            string SelectedVolunteerID = VolunteerOffBreakGridView.SelectedValue.ToString();

            // Creating a variable to hold the current time
            string now = DateTime.Now.ToString();

            // SQL string to update the Volunteer's current status to not current
            string sql = "UPDATE VolunteerStatusRecord "
                            + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                            + "WHERE Volunteer_ID = '" + SelectedVolunteerID + "' AND IsCurrent = 'Y'";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            // SQL string to insert new current status of On Break
            sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                    + "VALUES ('" + SelectedVolunteerID + "', '" + now + "', 'On Break', 'Y')";

            // Execute query
            SqlCommand comm2 = new SqlCommand(sql, conn);
            comm2.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            // Rebind the data to refresh the Grids
            VolunteerOffBreakGridView.DataBind();
            VolunteerOffBreakGridView.SelectedIndex = -1;

            VolunteerOnBreakGridView.DataBind();
            VolunteerOnBreakGridView.SelectedIndex = -1;
        }
    }
}