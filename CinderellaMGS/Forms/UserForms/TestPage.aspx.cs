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

public partial class Forms_UserForms_TestPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int newCinderellaID = Convert.ToInt32(CinderellaGridView.SelectedValue);
        string newFName = CinderellaGridView.SelectedRow.Cells[2].Text;
        string newLName = CinderellaGridView.SelectedRow.Cells[1].Text;
        DateTime newScheduleAppointmentTime = Convert.ToDateTime(CinderellaGridView.SelectedRow.Cells[3].Text);

        DateTime now = DateTime.Now;

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        string sql = "SELECT EndTime "
                    + "FROM CinderellaStatusRecord "
                    + "WHERE Cinderella_ID = '" + newCinderellaID + "' AND Status_Name = 'Pending'";

        // Execute query
        SqlCommand comm1 = new SqlCommand(sql, conn);
        DateTime newArrivalTime = Convert.ToDateTime(comm1.ExecuteScalar());

        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();

        // Rebind the data to refresh the Grid
        CinderellaGridView.DataBind();
        CinderellaGridView.SelectedIndex = -1;

        CinderellaClass ChosenCinderella = new CinderellaClass(newCinderellaID, newFName, newLName, newScheduleAppointmentTime, newArrivalTime);

        Button1.Text = ChosenCinderella.Priority.ToString();
        Label1.Text = ChosenCinderella.ScheduleAppointmentTime.ToString();
        Label2.Text = ChosenCinderella.ArrivalTime.ToString();
    }
}