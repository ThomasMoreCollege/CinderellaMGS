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

public partial class Forms_UserForms_VolunteerCheckin : System.Web.UI.Page
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
    protected void CheckinButton_Click(object sender, EventArgs e)
    {
        // Checking to make sure a Volunteer is selected
        if (VolunteerGridView.SelectedRow == null)
        {
            // Outputs error message if no Volunteer is selected
            String errorVar = "Please select a Volunteer";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else
        {
            // Creating a variable to hold a string of the Volunteer's ID
            string SelectedVolunteerID = VolunteerGridView.SelectedValue.ToString();
            // Creating a variable to hold the current time
            string now = DateTime.Now.ToString();

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            // SQL string to INSERT Waiting status into StatusRecord
            string sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                            + "VALUES ('" + SelectedVolunteerID + "', '" + now + "', 'Ready', 'Y')";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            // SQL string to UPDATE Pending status 
            sql = "UPDATE VolunteerStatusRecord "
                    + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                    + "WHERE Volunteer_ID = '" + SelectedVolunteerID + "' AND IsCurrent = 'Y'";

            // Execute query
            SqlCommand comm2 = new SqlCommand(sql, conn);
            comm2.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            // Rebind the data to refresh the Grid
            VolunteerGridView.DataBind();
            VolunteerGridView.SelectedIndex = -1;
        }
    }
}