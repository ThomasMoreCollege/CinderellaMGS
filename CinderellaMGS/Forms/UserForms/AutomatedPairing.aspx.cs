using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL
using System.Data; // Must be included if using data tables

public partial class Forms_UserForms_AutomatedPairing : System.Web.UI.Page
{
    public static VolunteerQueue.VolunteerQueue volunteerQueue = new VolunteerQueue.VolunteerQueue();
    public static CinderellaQueue.CinderellaQueue cinderellaQueue = new CinderellaQueue.CinderellaQueue();
    public static int counter = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();

        counter++;
        Label1.Text = counter.ToString();
        if (!(volunteerQueue.isEmpty()) && !(cinderellaQueue.isEmpty()))
        {
            int volunteerID = volunteerQueue.getValofFrontNode().VolunteerID;
            int cinderellaID = cinderellaQueue.getValofFrontNode().CinderellaID;

            volunteerQueue.dequeue();
            cinderellaQueue.dequeue();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            //Query to pair cinderella in the database
            string pairCinderellaQuery = "UPDATE Cinderella "
                                    + "SET Volunteer_ID='" + volunteerID.ToString() + "' "
                                    + "WHERE CinderellaID='" + cinderellaID.ToString() + "'";

            //Turn string into a SQL command
            SqlCommand pairCinderella = new SqlCommand(pairCinderellaQuery, conn);

            // Execute query
            pairCinderella.ExecuteNonQuery();

            //Get current Time
            DateTime now = DateTime.Now;

            /************************
             * Edit Cinderella Info *
             * **********************/

            //Query to end cinderella's "Waiting For Godmother" status record in the database
            string endCurrentCinStatusQuery = "UPDATE CinderellaStatusRecord "
                                    + "SET IsCurrent='N', EndTime='" + now + "' "
                                    + "WHERE IsCurrent='Y'";

            //Turn string into a SQL command
            SqlCommand endCurrentCinStatus = new SqlCommand(endCurrentCinStatusQuery, conn);

            // Execute query
            endCurrentCinStatus.ExecuteNonQuery();

            //Insert new status record "Paired" for volunteer
            string addNewCinStatusRecordQuery = "INSERT INTO CinderellaStatusRecord (Cinderella_ID,StartTime,Status_Name,IsCurrent) VALUES ('" + cinderellaID + "', '" + now + "', 'Paired', 'Y')";

            //Execute query 
            SqlCommand addNewCinStatusRecord = new SqlCommand(addNewCinStatusRecordQuery, conn);

            //Execute Query 
            addNewCinStatusRecord.ExecuteNonQuery();


            /***********************
             * Edit Volunteer Info *
             * *********************/

            //Query to end volunteer's "Waiting For Godmother" status record in the database
            string endCurrentVolStatusQuery = "UPDATE VolunteerStatusRecord "
                                    + "SET IsCurrent='N', EndTime='" + now + "' "
                                    + "WHERE IsCurrent='Y'";

            //Turn string into a SQL command
            SqlCommand endCurrentVolStatus = new SqlCommand(endCurrentVolStatusQuery, conn);

            // Execute query
            endCurrentVolStatus.ExecuteNonQuery();

            //Insert new status record "Paired" for volunteer
            string addNewVolStatusRecordQuery = "INSERT INTO VolunteerStatusRecord (Volunteer_ID,StartTime,Status_Name,IsCurrent) VALUES ('" + volunteerID + "', '" + now + "', 'Paired', 'Y')";

            //Execute query 
            SqlCommand addNewVolStatusRecord = new SqlCommand(addNewVolStatusRecordQuery, conn);

            //Execute Query 
            addNewVolStatusRecord.ExecuteNonQuery();

            conn.Close();
        }
        Response.AppendHeader("Refresh", 10 + "; URL=AutomatedPairing.aspx");
    }
}