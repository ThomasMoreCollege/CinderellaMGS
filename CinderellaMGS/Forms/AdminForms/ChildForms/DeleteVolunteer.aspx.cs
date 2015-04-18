using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL
using System.Data; // Must be included if using data tables

public partial class Forms_AdminForms_ChildForms_DeleteVolunteer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }
    protected void VolunteerGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Do not show confirmation label and enable button when a volunteer is selected
        ConfirmLabel.Visible = false;
        DeleteVoluntFormButton.Enabled = true;

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Store Query string
        string retrieveVolunteerInfoQuery = "SELECT FirstName,LastName,Email,Phone,Address,City,State,Zipcode "
                                            + "FROM Volunteer "
                                            + "WHERE VolunteerID='" + VolunteerGridView.SelectedValue.ToString() + "'";
        
        //Execute query 
        SqlCommand retrieveInfo = new SqlCommand(retrieveVolunteerInfoQuery, conn1);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(retrieveInfo);

        //Create a new dataset to hold the query results
        DataSet dataSet = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(dataSet);

        //Display appropiate info based on selected volunteer
        FisrtNameLabel.Text = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
        LastNameLabel.Text = dataSet.Tables[0].Rows[0]["LastName"].ToString();
        EmailLabel.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
        PhoneLabel.Text = dataSet.Tables[0].Rows[0]["Phone"].ToString();
        AddressLabel.Text = dataSet.Tables[0].Rows[0]["Address"].ToString();
        CityLabel.Text = dataSet.Tables[0].Rows[0]["City"].ToString();
        StateLabel.Text = dataSet.Tables[0].Rows[0]["State"].ToString();
        ZipcodeLabel.Text = dataSet.Tables[0].Rows[0]["Zipcode"].ToString();
         
    }

    protected void DeleteVoluntFormButton_Click(object sender, EventArgs e)
    {

        //Create local variable to hold volunteer IDr 
        string getVolunteerID = VolunteerGridView.SelectedValue.ToString();

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        //Query to retrieve information needed for confirmation label
        string volunteerInfoQuery = "SELECT Volunteer.VolunteerID, Volunteer.LastName, Volunteer.FirstName, VolunteerStatusRecord.Status_Name, Volunteer.IsValid "
                                    + "FROM Volunteer "
                                    + "INNER JOIN VolunteerStatusRecord "
                                    + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                                    + "WHERE VolunteerStatusRecord.IsCurrent = 'Y' "
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

        //Check if volunteer is not deleted
        if (isValid == "Y")
        {
            //If volunteer is shopping notify the user that role cannot be changed
            if (currentStatus == "Shopping")
            {
                ConfirmLabel.Text = firstName + " " + lastName + " is currently shopping and cannot be deleted at the moment.";
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
                    }
                    catch
                    {

                    }
                }
                else if (currentStatus == "Ready")
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

                // SQL string to INSERT a new status of Deleted for Volunteer 
                string addNewVolunteerStatusQuery = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                        + "VALUES ('" + getVolunteerID + "', '" + DateTime.Now + "', 'Deleted', 'Y')";
                SqlCommand addNewVolunteerStatus = new SqlCommand(addNewVolunteerStatusQuery, conn);
                addNewVolunteerStatus.ExecuteNonQuery();

                //Initialize a string variable to hold a query
                string softDeleteVolQuery = "UPDATE Volunteer "
                                                + "SET IsValid='N' "
                                                + "WHERE VolunteerID='" + getVolunteerID + "'";
                //Execute query 
                SqlCommand softDeleteVol = new SqlCommand(softDeleteVolQuery, conn);

                //Execute Query 
                softDeleteVol.ExecuteNonQuery();

                ConfirmLabel.Text = firstName + " " + lastName + " has been deleted.";
                ConfirmLabel.ForeColor = System.Drawing.Color.Green;
                ConfirmLabel.Visible = true;
            }
        }
        else
        {
            ConfirmLabel.Text = firstName + " " + lastName + " has already been deleted.";
            ConfirmLabel.Visible = true;
            ConfirmLabel.ForeColor = System.Drawing.Color.Green;
        }

        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();

        //Refresh Grid
        VolunteerGridView.DataSourceID = "VolunteersToBeDeletedSqlDataSource";
        VolunteerGridView.DataBind();

        FisrtNameLabel.Text = "--";
        LastNameLabel.Text = "--";
        EmailLabel.Text = "--";
        PhoneLabel.Text = "--";
        AddressLabel.Text = "--"; ;
        CityLabel.Text = "--";
        StateLabel.Text = "--";
        ZipcodeLabel.Text = "--";

        DeleteVoluntFormButton.Enabled = false;
    }
}