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

public partial class Forms_AdminForms_EndDay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }
    protected void EndDayButton_Click(object sender, EventArgs e)
    {
        // Creating a variable to hold the current time
        string now = DateTime.Now.ToString();

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        // SQL string to select all Volunteers whose current status is not Pending
        string sql = "SELECT Volunteer_ID "
                + "FROM VolunteerStatusRecord "
                + "WHERE IsCurrent = 'Y' AND Status_Name != 'Pending'";
        SqlCommand comm1 = new SqlCommand(sql, conn);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(comm1);
        //Create a new dataset to hold the query results
        DataSet dataSet = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(dataSet);

        for (int i = 0; i < dataSet.Tables[0].Select("Volunteer_ID is not null").Length; i++)
        {
            // Variable to hold the Volunteer's ID
            string SelectedVolunteerID = dataSet.Tables[0].Rows[i]["Volunteer_ID"].ToString();

            // SQL string to set each Volunteer's current Status to not Pending
            sql = "UPDATE VolunteerStatusRecord "
                        + "SET EndTime = '" + now + "', IsCurrent = 'N'"
                        + "WHERE Volunteer_ID = '" + SelectedVolunteerID + "' AND IsCurrent = 'Y'";
            // Execute SQL
            SqlCommand comm2 = new SqlCommand(sql, conn);
            comm2.ExecuteNonQuery();

            // SQL string to INSERT a new Pending status as the current status
            sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent)"
                    + "VALUES ('" + SelectedVolunteerID + "', '" + now + "', 'Pending', 'Y')";
            // Execute SQL
            SqlCommand comm3 = new SqlCommand(sql, conn);
            comm3.ExecuteNonQuery();
        }

        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();
    }
}