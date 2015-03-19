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
        UndoShoppingButton.Enabled = false;
        BreakPairingButton.Enabled = false;
    }
    protected void GoShoppingButton_Click(object sender, EventArgs e)
    {
        // String to hold the Selected Cinderella ID
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

        // Notifying user of success
        NotificationLabel.Text = "Cinderella " + PairedCinderellaGridView.SelectedRow.Cells[1].Text.ToString()
                                    + " and Volunteer " + PairedCinderellaGridView.SelectedRow.Cells[3].Text.ToString() + " successfully changed from Paired to Shopping";
        NotificationLabel.Visible = true;

        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();

        // Rebind the data to refresh the grid
        PairedCinderellaGridView.DataBind();
        PairedCinderellaGridView.SelectedIndex = -1;

        ShoppingGridView.DataBind();
        ShoppingGridView.SelectedIndex = -1;

        GoShoppingButton.Enabled = false;
        UndoShoppingButton.Enabled = false;
        BreakPairingButton.Enabled = false;
    }
    protected void PairedCinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Enabling the GoShopping button
        GoShoppingButton.Enabled = true;
        BreakPairingButton.Enabled = true;

        //Disablign the undo controls
        UndoShoppingButton.Enabled = false;
        ShoppingGridView.SelectedIndex = -1;
    }
    protected void ShoppingGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Enabling the UndoShopping button
        UndoShoppingButton.Enabled = true;

        // Disabling the go shopping controls
        GoShoppingButton.Enabled = false;
        BreakPairingButton.Enabled = false;
        PairedCinderellaGridView.SelectedIndex = -1;
    }
    protected void UndoShoppingButton_Click(object sender, EventArgs e)
    {
        // String to hold the Selected Cinderella ID
        string SelectedCinderellaID = ShoppingGridView.SelectedValue.ToString();

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
                + "VALUES ('" + SelectedCinderellaID + "', '" + now + "', 'Paired', 'Y')";
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
        + "VALUES ('" + SelectedVolunteerID + "', '" + now + "', 'Paired', 'Y')";
        // Execute SQL
        SqlCommand comm5 = new SqlCommand(sql, conn1);
        comm5.ExecuteNonQuery();

        // Notifying user of success
        NotificationLabel.Text = "Cinderella " + ShoppingGridView.SelectedRow.Cells[1].Text.ToString()
                                    + " and Volunteer " + ShoppingGridView.SelectedRow.Cells[3].Text.ToString() + " successfully changed from Shopping to Paired";
        NotificationLabel.Visible = true;

        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();

        // Rebind the data to refresh the grid
        PairedCinderellaGridView.DataBind();
        PairedCinderellaGridView.SelectedIndex = -1;

        ShoppingGridView.DataBind();
        ShoppingGridView.SelectedIndex = -1;

        GoShoppingButton.Enabled = false;
        UndoShoppingButton.Enabled = false;
        BreakPairingButton.Enabled = false;
    }
    protected void BreakPairingButton_Click(object sender, EventArgs e)
    {
        // String to hold the Selected Cinderella ID
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

        // SQL string to INSERT a new Waiting for Godmother status for Cinderella
        sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                + "VALUES ('" + SelectedCinderellaID + "', '" + now + "', 'Waiting for Godmother', 'Y')";
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

        // SQL string to INSERT a new Ready status for Volunteer
        sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
        + "VALUES ('" + SelectedVolunteerID + "', '" + now + "', 'Ready', 'Y')";
        // Execute SQL
        SqlCommand comm5 = new SqlCommand(sql, conn1);
        comm5.ExecuteNonQuery();

        sql = "UPDATE Cinderella "
                + "SET Volunteer_ID = NULL "
                + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";
        // Execute SQL
        SqlCommand comm6 = new SqlCommand(sql, conn1);
        comm6.ExecuteNonQuery();

        try
        {

            //Retrieve ID of selected volunteer
            int cinID = Convert.ToInt32(SelectedCinderellaID);

            //Create object instance with selected volunteer
            CinderellaClass returnedCinderella = new CinderellaClass(cinID);

            //Lock application state so that no else can access it 
            Application.Lock();

            //Initialize a local copy of volunteer queue
            CinderellaQueue.CinderellaQueue cinderellaAutomatedQueueCopy = new CinderellaQueue.CinderellaQueue();

            //Copy queue in the application session into the local copy
            cinderellaAutomatedQueueCopy = Application["cinderellaAutomatedQueue"] as CinderellaQueue.CinderellaQueue;

            //Insert volunter to the queue
            cinderellaAutomatedQueueCopy.enqueueToFront(returnedCinderella);

            //Copy changes into application queue
            Application["cinderellaAutomatedQueue"] = cinderellaAutomatedQueueCopy;

            //Unlock Application session
            Application.UnLock();
        }
        catch
        {

        }

        try
        {
            //Retrieve ID of selected volunteer
            int volID = Convert.ToInt32(SelectedVolunteerID);

            //Create object instance with selected volunteer
            VolunteerClass returnedVolunteer = new VolunteerClass(volID);

            //Lock application state so that no else can access it 
            Application.Lock();

            //Initialize a local copy of volunteer queue
            VolunteerQueue.VolunteerQueue volunteerQueueCopy = new VolunteerQueue.VolunteerQueue();

            //Copy queue in the application session into the local copy
            volunteerQueueCopy = Application["volunteerQueue"] as VolunteerQueue.VolunteerQueue;

            //Insert volunter to the queue
            volunteerQueueCopy.enqueueToFront(returnedVolunteer);

            //Copy changes into application queue
            Application["volunteerQueue"] = volunteerQueueCopy;

            //Unlock Application session
            Application.UnLock();
        }
        catch (Exception ex)
        {

        }

        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();

        // Rebind the data to refresh the grid
        PairedCinderellaGridView.DataBind();
        PairedCinderellaGridView.SelectedIndex = -1;

        ShoppingGridView.DataBind();
        ShoppingGridView.SelectedIndex = -1;

        GoShoppingButton.Enabled = false;
        UndoShoppingButton.Enabled = false;
        BreakPairingButton.Enabled = false;
    }
}