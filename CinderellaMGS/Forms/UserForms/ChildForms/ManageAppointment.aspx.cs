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

public partial class Forms_UserForms_ManageAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }

    protected void ChangeAppointmentButton_Click(object sender, EventArgs e)
    {
        // Defaulting notification label to not shown
        UserNotificationLabel.Visible = false;

        // Verifying that if no date is selected, today's date is set as default value
        if (NewDateCalendar.SelectedDate == DateTime.MinValue)
        {
            NewDateCalendar.SelectedDate = NewDateCalendar.TodaysDate;
        }

        // Checking to make sure a Cinderella is selected
        if (CinderellaGridView.SelectedRow == null)
        {
            // Outputs error message if no Cinderella is selected
            String errorVar = "Please select a Cinderella";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else
        {
            // Creating a variable to hold the Date (minus the standard 12:00:00 AM setting) and Time of new appointment
            string NewDate = NewDateCalendar.SelectedDate.ToString().Replace("12:00:00 AM", "");
            string NewTime = ddlStartTimeHr.SelectedValue.ToString() 
                            + ":" + ddlStartTimeMin.SelectedItem.Text
                            + " " + ddlStartTimeAMPM.SelectedValue;

            // Creating a variable to hold a string of the Cinderella's ID
            string SelectedCinderellaID = CinderellaGridView.SelectedValue.ToString();

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            // SQL string to UPDATE the appointment date/time to new setting
            string sql = "UPDATE Cinderella "
                        + "SET AppointmentDateTime = '" + NewDate + NewTime + "' "
                        + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            // Notifying the user of the submission's success
            UserNotificationLabel.Text = "Cinderella " 
                                        + CinderellaGridView.SelectedRow.Cells[3].Text 
                                        + " "
                                        + CinderellaGridView.SelectedRow.Cells[2].Text 
                                        +"'s Appointment successfully changed to "
                                        + NewDate 
                                        + NewTime 
                                        + ".";
            UserNotificationLabel.Visible = true;

            // Rebind the data to refresh the Grid
            CinderellaGridView.DataBind();
            CinderellaGridView.SelectedIndex = -1;

            // Resetting the non-GridView data
            NewDateCalendar.SelectedDate = DateTime.Now.Date;
            ddlStartTimeHr.SelectedValue = "1";
            ddlStartTimeMin.SelectedValue = "0";
            ddlStartTimeAMPM.SelectedValue = "AM";
        }

        ChangeAppointmentButton.Enabled = false;
        
    }
    protected void CinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Enabling the submission button and hiding the notification label
        ChangeAppointmentButton.Enabled = true;
        UserNotificationLabel.Visible = false;

        DateTime CinderellaAppointment = Convert.ToDateTime(CinderellaGridView.SelectedRow.Cells[4].Text);

        NewDateCalendar.SelectedDate = CinderellaAppointment.Date;
        NewDateCalendar.VisibleDate = CinderellaAppointment.Date;

        // Determining the non-military hour
        string appointmentHour = CinderellaAppointment.Hour.ToString();
        string appointmentPeriod = "AM";
        if (CinderellaAppointment.Hour > 12)
        {
            // Subtracting 12 from the military time
            appointmentHour = (CinderellaAppointment.Hour - 12).ToString();
            appointmentPeriod = "PM";
        }

        ddlStartTimeHr.SelectedValue = appointmentHour;
        ddlStartTimeMin.SelectedValue = CinderellaAppointment.Minute.ToString();
        ddlStartTimeAMPM.SelectedValue = appointmentPeriod;
    }
}