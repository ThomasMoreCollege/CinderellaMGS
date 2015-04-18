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
        (this.Master as MasterPage).ManageMasterLayout();
    }

    protected void TakeOffBreakButton_Click(object sender, EventArgs e)
    {

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        // Variable to hold selected Volunteer's ID
        string getVolunteerID = VolunteerOnBreakGridView.SelectedValue.ToString();

        //Query to retrieve information needed for confirmation label
        string volunteerInfoQuery = "SELECT Volunteer.VolunteerID, Volunteer.LastName, Volunteer.FirstName, VolunteerRoleRecord.Role_Name, VolunteerStatusRecord.Status_Name, Volunteer.IsValid  "
                                    + "FROM Volunteer "
                                    + "INNER JOIN VolunteerRoleRecord "
                                    + "ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID "
                                    + "INNER JOIN VolunteerStatusRecord "
                                    + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                                    + "WHERE VolunteerRoleRecord.IsCurrent = 'Y' "
                                    + "AND  VolunteerStatusRecord.IsCurrent = 'Y' "
                                    + "AND VolunteerRoleRecord.Role_Name != 'Alterations' "
                                    + "AND Volunteer.VolunteerID = '" + getVolunteerID + "'";

        //Execute query 
        SqlCommand volunteerInfo = new SqlCommand(volunteerInfoQuery, conn);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(volunteerInfo);

        //Create a new dataset to hold the query results
        DataSet dataSet = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(dataSet);

        //Store info to be used for confirmation label in local variables 
        string firstName = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
        string lastName = dataSet.Tables[0].Rows[0]["LastName"].ToString();
        string currentStatus = dataSet.Tables[0].Rows[0]["Status_Name"].ToString();
        string currentRole = dataSet.Tables[0].Rows[0]["Role_Name"].ToString();
        string isValid = dataSet.Tables[0].Rows[0]["IsValid"].ToString();

        // Creating a variable to hold the current time
        string now = DateTime.Now.ToString();

        //Check if volunteer is not deleted
        if (isValid == "Y")
        {
            if (currentStatus == "On Break")
            {
                // SQL string to update the Volunteer's current status (On Break) to not current
                string sql = "UPDATE VolunteerStatusRecord "
                                + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                                + "WHERE Volunteer_ID = '" + getVolunteerID + "' AND IsCurrent = 'Y'";

                // Execute query
                SqlCommand comm1 = new SqlCommand(sql, conn);
                comm1.ExecuteNonQuery();

                // SQL string to insert new current status of Ready
                sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                        + "VALUES ('" + getVolunteerID + "', '" + now + "', 'Ready', 'Y')";

                // Execute query
                SqlCommand comm2 = new SqlCommand(sql, conn);
                comm2.ExecuteNonQuery();

                //If volunteer if a Godmother, put her back into the automated pairing queue
                if (currentRole == "Godmother")
                {
                    try
                    {
                        //Retrieve ID of selected volunteer
                        int volID = Convert.ToInt32(getVolunteerID);

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

                        ConfirmLabel.Text = firstName + " " + lastName + " has been taken off of break and put back into automated pairing.";
                        ConfirmLabel.Visible = true;
                        ConfirmLabel.ForeColor = System.Drawing.Color.Green;

                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    ConfirmLabel.Text = firstName + " " + lastName + " has been taken off of break.";
                    ConfirmLabel.Visible = true;
                    ConfirmLabel.ForeColor = System.Drawing.Color.Green;
                }

            }
        }
        else
        {
            ConfirmLabel.Text = firstName + " " + lastName + " has been deleted. Cannot take off break.";
            ConfirmLabel.Visible = true;
            ConfirmLabel.ForeColor = System.Drawing.Color.Green;
        }


        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();

        // Rebind the data to refresh the Grids
        VolunteerOffBreakGridView.DataBind();
        VolunteerOffBreakGridView.SelectedIndex = -1;

        VolunteerOnBreakGridView.DataBind();
        VolunteerOnBreakGridView.SelectedIndex = -1;

        TakeOffBreakButton.Enabled = false;
    }
    protected void SendOnBreakButton_Click(object sender, EventArgs e)
    {
        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        // Variable to hold selected Volunteer's ID
        string getVolunteerID = VolunteerOffBreakGridView.SelectedValue.ToString();

        // Creating a variable to hold the current time
        string now = DateTime.Now.ToString();

        //Query to retrieve information needed for confirmation label
        string volunteerInfoQuery = "SELECT Volunteer.VolunteerID, Volunteer.LastName, Volunteer.FirstName, VolunteerStatusRecord.Status_Name, Volunteer.IsValid, VolunteerRoleRecord.Role_Name "
                                    + "FROM Volunteer "
                                    + "INNER JOIN VolunteerRoleRecord "
                                    + "ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID " 
                                    + "INNER JOIN VolunteerStatusRecord "
                                    + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                                    + "WHERE VolunteerStatusRecord.IsCurrent = 'Y' "
                                    + "AND VolunteerRoleRecord.IsCurrent = 'Y' "
                                    + "AND Volunteer.VolunteerID = '" + getVolunteerID + "'";

        //Execute query 
        SqlCommand volunteerInfo = new SqlCommand(volunteerInfoQuery, conn);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(volunteerInfo);

        //Create a new dataset to hold the query results
        DataSet dataSet = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(dataSet);

        //Store info to be used for confirmation label in local variables 
        string firstName = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
        string lastName = dataSet.Tables[0].Rows[0]["LastName"].ToString();
        string currentStatus = dataSet.Tables[0].Rows[0]["Status_Name"].ToString();
        string isValid = dataSet.Tables[0].Rows[0]["IsValid"].ToString();
        string currentRole = dataSet.Tables[0].Rows[0]["Role_Name"].ToString();

        //Check if volunteer is not deleted
        if (isValid == "Y")
        {
            if (currentStatus == "Shopping")
            {
                ConfirmLabel.Text = firstName + " " + lastName + " is currently shopping and cannot be put on break at the moment.";
                ConfirmLabel.ForeColor = System.Drawing.Color.Red;
                ConfirmLabel.Visible = true;
            }
            else
            {
                //If volunteer is Paired breaking the pairing, send cinderella back into the pairing queue, and ....
                if (currentStatus == "Paired")
                {
                    // SQL string to get Cinderella paired to selected Volunteer
                    string sql = "SELECT CinderellaID "
                                    + "FROM Cinderella "
                                    + "INNER JOIN CinderellaStatusRecord "
                                    + "ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID "
                                    + "WHERE Volunteer_ID = '" + getVolunteerID + "' AND IsCurrent = 'Y' AND Status_Name = 'Paired'";

                    // Execute Query
                    SqlCommand comm1 = new SqlCommand(sql, conn);
                    string pairedCinderella = comm1.ExecuteScalar().ToString();

                    //Update paired cinderella's volunterID attribute to null to signify that she does not have a volunteer
                    sql = "UPDATE Cinderella "
                            + "SET Volunteer_ID = NULL "
                            + "WHERE CinderellaID = '" + pairedCinderella + "'";

                    // Execute Query
                    SqlCommand comm2 = new SqlCommand(sql, conn);
                    comm2.ExecuteNonQuery();

                    // SQL string to UPDATE the paired Cinderella's status
                    sql = "UPDATE CinderellaStatusRecord "
                                    + "SET EndTime = '" + DateTime.Now + "', IsCurrent = 'N' "
                                    + "WHERE Cinderella_ID = '" + pairedCinderella + "' AND IsCurrent = 'Y'";
                    // Execute query string into a SQL command
                    SqlCommand comm3 = new SqlCommand(sql, conn);
                    comm3.ExecuteNonQuery();

                    // SQL string to INSERT a new status of Waiting for Godmother for Cinderella
                    sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                            + "VALUES ('" + pairedCinderella + "', '" + DateTime.Now + "', 'Waiting for Godmother', 'Y')";
                    SqlCommand comm4 = new SqlCommand(sql, conn);

                    comm4.ExecuteNonQuery();

                    // Re-adding pairedCinderella to the queue at front
                    try
                    {

                        //Retrieve ID of selected volunteer
                        int cinID = Convert.ToInt32(pairedCinderella);

                        //Create object instance with selected volunteer
                        CinderellaClass oldCinderella = new CinderellaClass(cinID);

                        //Lock application state so that no else can access it 
                        Application.Lock();

                        //Initialize a local copy of volunteer queue
                        CinderellaQueue.CinderellaQueue cinderellaAutomatedQueueCopy = new CinderellaQueue.CinderellaQueue();

                        //Copy queue in the application session into the local copy
                        cinderellaAutomatedQueueCopy = Application["cinderellaAutomatedQueue"] as CinderellaQueue.CinderellaQueue;

                        //Insert volunter to the queue
                        cinderellaAutomatedQueueCopy.enqueueToFront(oldCinderella);

                        //Copy changes into application queue
                        Application["cinderellaAutomatedQueue"] = cinderellaAutomatedQueueCopy;

                        //Unlock Application session
                        Application.UnLock();

                        ConfirmLabel2.Text = "Cinderella paired with " + firstName + " " + lastName + " has been put back into the automated pairing queue.";
                        ConfirmLabel2.Visible = true;
                        ConfirmLabel2.ForeColor = System.Drawing.Color.Green;
                    }
                    catch
                    {

                    }
                }
                else if (currentStatus == "Ready" && currentRole == "Godmother")
                {
                    try
                    {
                        //Retrieve ID of selected volunteer
                        int volID = Convert.ToInt32(getVolunteerID);

                        //Lock application state so that no else can access it 
                        Application.Lock();

                        //Initialize a local copy of volunteer queue
                        VolunteerQueue.VolunteerQueue volunteerQueueCopy = new VolunteerQueue.VolunteerQueue();

                        //Copy queue in the application session into the local copy
                        volunteerQueueCopy = Application["volunteerQueue"] as VolunteerQueue.VolunteerQueue;

                        //Insert volunter to the queue
                        volunteerQueueCopy.selectiveDequeue(volID);

                        //Copy changes into application queue
                        Application["volunteerQueue"] = volunteerQueueCopy;

                        //Unlock Application session
                        Application.UnLock();

                        ConfirmLabel2.Text = firstName + " " + lastName + " has been taken out from automated pairing.";
                        ConfirmLabel2.Visible = true;
                        ConfirmLabel2.ForeColor = System.Drawing.Color.Green;

                    }
                    catch (Exception ex)
                    {

                    }
                }

                // SQL string to UPDATE the paired Volunteer's status
                string endVolunteerStatusQuery = "UPDATE VolunteerStatusRecord "
                                + "SET EndTime = '" + DateTime.Now + "', IsCurrent = 'N' "
                                + "WHERE Volunteer_ID = '" + getVolunteerID + "' AND IsCurrent = 'Y'";

                // Execute query string into a SQL command
                SqlCommand endVolunteerStatus = new SqlCommand(endVolunteerStatusQuery, conn);
                endVolunteerStatus.ExecuteNonQuery();

                // SQL string to INSERT a new status of On Break for Volunteer 
                string addNewVolunteerStatusQuery = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                        + "VALUES ('" + getVolunteerID + "', '" + DateTime.Now + "', 'On Break', 'Y')";
                SqlCommand addNewVolunteerStatus = new SqlCommand(addNewVolunteerStatusQuery, conn);
                addNewVolunteerStatus.ExecuteNonQuery();


                ConfirmLabel.Text = firstName + " " + lastName + " has been put on break.";
                ConfirmLabel.ForeColor = System.Drawing.Color.Green;
                ConfirmLabel.Visible = true;
            }
        }
        else
        {
            ConfirmLabel.Text = firstName + " " + lastName + " has been deleted. Cannot be sent on break.";
            ConfirmLabel.Visible = true;
            ConfirmLabel.ForeColor = System.Drawing.Color.Green;
        }
        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();

        // Rebind the data to refresh the Grids
        VolunteerOffBreakGridView.DataBind();
        VolunteerOffBreakGridView.SelectedIndex = -1;

        VolunteerOnBreakGridView.DataBind();
        VolunteerOnBreakGridView.SelectedIndex = -1;

        SendOnBreakButton.Enabled = false;
    }
    protected void VolunteerOffBreakGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        SendOnBreakButton.Enabled = true;
        TakeOffBreakButton.Enabled = false;
        ConfirmLabel.Visible = false;
        ConfirmLabel2.Visible = false;

    }
    protected void VolunteerOnBreakGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        SendOnBreakButton.Enabled = false;
        TakeOffBreakButton.Enabled = true;
        ConfirmLabel.Visible = false;
        ConfirmLabel2.Visible = false;
    }
}