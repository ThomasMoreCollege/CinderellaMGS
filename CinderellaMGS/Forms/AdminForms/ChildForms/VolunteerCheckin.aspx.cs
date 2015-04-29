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
        (this.Master as MasterPage).ManageMasterLayout();
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

            // Creating a variable to hold the current date
            DateTime today = DateTime.Today.Date;

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            // SQL string to INSERT Waiting status into StatusRecord
            string sql = "UPDATE VolunteerStatusRecord "
                    + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                    + "WHERE Volunteer_ID = '" + SelectedVolunteerID + "' AND IsCurrent = 'Y'";
            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            // SQL string to UPDATE Pending status 
            sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                    + "VALUES ('" + SelectedVolunteerID + "', '" + now + "', 'Ready', 'Y')";
            // Execute query
            SqlCommand comm2 = new SqlCommand(sql, conn);
            comm2.ExecuteNonQuery();

            // SQL string to SELECT the Volunteer's Role for this Shift
            sql = "SELECT Role_Name "
                    + "FROM VolunteerShiftRecord "
                    + "WHERE Shift_Name = '" + DateTime.Now.DayOfWeek + "' AND Volunteer_ID = '" + SelectedVolunteerID + "'";
            SqlCommand comm3 = new SqlCommand(sql, conn);
            string ShiftRole = comm3.ExecuteScalar().ToString();

            // SQL string to INSERT the Volunteer's RoleRecord 
            sql = "INSERT INTO VolunteerRoleRecord(Volunteer_ID, StartTime, Role_Name, IsCurrent) "
                    + "VALUES ('" + SelectedVolunteerID + "', '" + now + "', '" + ShiftRole + "', 'Y')";
            // Execute query
            SqlCommand comm4 = new SqlCommand(sql, conn);
            comm4.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            // Rebind the data to refresh the Grid
            VolunteerGridView.DataBind();
            VolunteerGridView.SelectedIndex = -1;

            ResultLabel.Text = "Volunteer has been checked in";
            ResultLabel.Visible = true;

            if (ShiftRole == "Godmother")
            {
                try
                {
                    //Retrieve ID of selected volunteer
                    int volID = Convert.ToInt32(SelectedVolunteerID);

                    //Create object instance with selected volunteer
                    VolunteerClass checkinVolunteer = new VolunteerClass(volID);

                    //Lock application state so that no else can access it 
                    Application.Lock();

                    //Initialize a local copy of volunteer queue
                    VolunteerQueue.VolunteerQueue volunteerQueueCopy = new VolunteerQueue.VolunteerQueue();

                    //Copy queue in the application session into the local copy
                    volunteerQueueCopy = Application["volunteerQueue"] as VolunteerQueue.VolunteerQueue;

                    //Insert volunter to the queue
                    volunteerQueueCopy.enqueue(checkinVolunteer);

                    //Copy changes into application queue
                    Application["volunteerQueue"] = volunteerQueueCopy;

                    //Unlock Application session
                    Application.UnLock();

                    ResultLabel.Text += " and placed in queue.";

                }
                catch (Exception ex)
                {
                    ResultLabel.Visible = false;
                }
            }
        }
    }
}