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

public partial class Forms_AdminForms_ChildForms_Status : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Refreshes page every 10 seconds to update information
        Response.AppendHeader("Refresh", 10 + "; URL=Status.aspx");

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        // Creating a variable to hold the current date
        DateTime today = DateTime.Today.Date;

        // SQL to count total Cinderellas  with CurrentStatus 'Pending' for today
        string CinderSQL = "SELECT COUNT (CinderellaID) "
                + "FROM Cinderella "
                + "INNER JOIN CinderellaStatusRecord "
                + "ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID "
                + "WHERE Status_Name = 'Pending' AND IsCurrent = 'Y' AND CAST(AppointmentDateTime as DATE) = '" + today + "'";

        // Execute query
        SqlCommand comm1 = new SqlCommand(CinderSQL, conn);
        int total = Convert.ToInt32(comm1.ExecuteScalar());

        CinderellaPendingLabel.Text = total.ToString();

        // SQL to count total Cinderellas with CurrentStatus 'Waiting for Godmother'
        CinderSQL = "SELECT COUNT (CinderellaID) "
                + "FROM Cinderella "
                + "INNER JOIN CinderellaStatusRecord "
                + "ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID "
                + "WHERE Status_Name = 'Waiting for Godmother' AND IsCurrent = 'Y'";

        // Execute query
        SqlCommand comm2 = new SqlCommand(CinderSQL, conn);
        total = Convert.ToInt32(comm2.ExecuteScalar());

        WaitingForGodmotherLabel.Text = total.ToString();

        // SQL to count total Cinderellas with CurrentStatus 'Shopping'
        CinderSQL = "SELECT COUNT (CinderellaID) "
                + "FROM Cinderella "
                + "INNER JOIN CinderellaStatusRecord "
                + "ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID "
                + "WHERE Status_Name = 'Shopping' AND IsCurrent = 'Y'";

        // Execute query
        SqlCommand comm3 = new SqlCommand(CinderSQL, conn);
        total = Convert.ToInt32(comm3.ExecuteScalar());

        CinderellaShoppingLabel.Text = total.ToString();

        // SQL to count total Cinderellas with CurrentStatus 'Shopping'
        CinderSQL = "SELECT COUNT (CinderellaID) "
                + "FROM Cinderella "
                + "INNER JOIN CinderellaStatusRecord "
                + "ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID "
                + "WHERE Status_Name = 'Waiting for Package' AND IsCurrent = 'Y'";

        // Execute query
        SqlCommand comm4 = new SqlCommand(CinderSQL, conn);
        total = Convert.ToInt32(comm4.ExecuteScalar());

        WaitingForPackageLabel.Text = total.ToString();

        // SQL to count total Cinderellas with CurrentStatus 'Checked Out' for today
        CinderSQL = "SELECT COUNT (CinderellaID) "
                + "FROM Cinderella "
                + "INNER JOIN CinderellaStatusRecord "
                + "ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID "
                + "WHERE Status_Name = 'Checked Out' AND IsCurrent = 'Y' AND CAST(AppointmentDateTime as DATE) = '" + today + "'";

        // Execute query
        SqlCommand comm5 = new SqlCommand(CinderSQL, conn);
        total = Convert.ToInt32(comm5.ExecuteScalar());

        CinderellaCheckedOutLabel.Text = total.ToString();

        // SQL to count total Volunteers with CurrentStatus 'Pending'
        string VolSQL = "SELECT COUNT (VolunteerID) "
                + "FROM Volunteer "
                + "INNER JOIN VolunteerStatusRecord "
                + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                + "WHERE Status_Name = 'Pending' AND IsCurrent = 'Y'";

        // Execute query
        SqlCommand comm6 = new SqlCommand(VolSQL, conn);
        total = Convert.ToInt32(comm6.ExecuteScalar());

        VolunteerPendingLabel.Text = total.ToString();

        // SQL to count total Volunteers with CurrentStatus 'Ready' and CurrentRole 'Godmother'
        VolSQL = "SELECT COUNT (VolunteerID) "
                + "FROM Volunteer "
                + "INNER JOIN VolunteerStatusRecord "
                + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                + "INNER JOIN VolunteerRoleRecord "
                + "ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID "
                + "WHERE Status_Name = 'Ready' AND VolunteerStatusRecord.IsCurrent = 'Y' AND Role_Name = 'Godmother' AND VolunteerRoleRecord.IsCurrent = 'Y'";

        // Execute query
        SqlCommand comm7 = new SqlCommand(VolSQL, conn);
        total = Convert.ToInt32(comm7.ExecuteScalar());

        VolunteerReadyLabel.Text = total.ToString();

        // SQL to count total Volunteers with CurrentStatus 'Shopping' and CurrentRole 'Godmother'
        VolSQL = "SELECT COUNT (VolunteerID) "
                + "FROM Volunteer "
                + "INNER JOIN VolunteerStatusRecord "
                + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                + "INNER JOIN VolunteerRoleRecord "
                + "ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID "
                + "WHERE Status_Name = 'Shopping' AND VolunteerStatusRecord.IsCurrent = 'Y' AND Role_Name = 'Godmother' AND VolunteerRoleREcord.IsCurrent = 'Y'";

        // Execute query
        SqlCommand comm8 = new SqlCommand(VolSQL, conn);
        total = Convert.ToInt32(comm8.ExecuteScalar());

        VolunteerShoppingLabel.Text = total.ToString();

        // SQL to count total Volunteers with CurrentStatus 'On Break'
        VolSQL = "SELECT COUNT (VolunteerID) "
                + "FROM Volunteer "
                + "INNER JOIN VolunteerStatusRecord "
                + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                + "WHERE Status_Name = 'On Break' AND VolunteerStatusRecord.IsCurrent = 'Y'";

        // Execute query
        SqlCommand comm9 = new SqlCommand(VolSQL, conn);
        total = Convert.ToInt32(comm9.ExecuteScalar());

        VolunteerOnBreakLabel.Text = total.ToString();

        // SQL to count total Packages with InPackaging 'Y'
        string PackSQL = "SELECT COUNT (Cinderella_ID) "
                + "FROM Package "
                + "WHERE InPackaging = 'Y'";

        // Execute query
        SqlCommand comm10 = new SqlCommand(PackSQL, conn);
        total = Convert.ToInt32(comm10.ExecuteScalar());

        PackagingLabel.Text = total.ToString();

        // SQL to count total Packages with InPackaging 'N'
        PackSQL = "SELECT COUNT (Cinderella_ID) "
                + "FROM Package "
                + "WHERE InPackaging = 'N'";

        // Execute query
        SqlCommand comm11 = new SqlCommand(PackSQL, conn);
        total = Convert.ToInt32(comm11.ExecuteScalar());

        PackageCheckedOutLabel.Text = total.ToString();

        // SQL to count total Packages with InPackaging 'N'
        PackSQL = "SELECT COUNT (Cinderella_ID) "
                + "FROM Alteration "
                + "WHERE EndAlterationTime = null";

        // Execute query
        SqlCommand comm12 = new SqlCommand(PackSQL, conn);
        total = Convert.ToInt32(comm12.ExecuteScalar());

        DressAlterationsLabel.Text = total.ToString();

        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();
    }
}