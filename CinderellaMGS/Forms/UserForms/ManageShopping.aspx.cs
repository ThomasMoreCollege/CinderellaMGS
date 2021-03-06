﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.ComponentModel.Design;

public partial class Forms_UserForms_ManageShopping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();

        // Disabling controls until a gridview is selected
        GoShoppingButton.Enabled = false;
        UndoShoppingButton.Enabled = false;
        //BreakPairingButton.Enabled = false;
    }
    protected void GoShoppingButton_Click(object sender, EventArgs e)
    {
        try
        {
            // String to hold the Selected Cinderella ID
            string SelectedCinderellaID = PairedCinderellaGridView.SelectedValue.ToString();

            // Creating a variable to hold the current time
            string now = DateTime.Now.ToString();

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection.
            conn1.Open();

            //Query to retrieve information needed for confirmation label
            string cinderellaStatusQuery = "SELECT Status_Name, Volunteer_ID "
                                        + "FROM Cinderella "
                                        + "INNER JOIN CinderellaStatusRecord "
                                            + "ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID "
                                        + "WHERE CinderellaStatusRecord.IsCurrent = 'Y' "
                                            + "AND Cinderella.CinderellaID = '" + SelectedCinderellaID + "'";

            //Execute query 
            SqlCommand cinderellaPrevRole = new SqlCommand(cinderellaStatusQuery, conn1);

            //Create a new adapter
            SqlDataAdapter adapter = new SqlDataAdapter(cinderellaPrevRole);

            //Create a new dataset to hold the query results
            DataSet dataSet = new DataSet();

            //Store the results in the adapter 
            adapter.Fill(dataSet);

            //Store info to be used for confirmation label in local variables 
            string CinderellaCurrentStatus = dataSet.Tables[0].Rows[0]["Status_Name"].ToString();
            string pairedVolunteer = dataSet.Tables[0].Rows[0]["Volunteer_ID"].ToString();

            if (CinderellaCurrentStatus == "Paired")
            {
                string volunteerStatusRoleQuery = "SELECT Status_Name, Role_Name "
                                            + "FROM Volunteer "
                                            + "INNER JOIN VolunteerStatusRecord "
                                                + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                                            + "INNER JOIN VolunteerRoleRecord "
                                                + "ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID "
                                            + "WHERE VolunteerStatusRecord.IsCurrent = 'Y' "
                                                + "AND VolunteerRoleRecord.IsCurrent = 'Y' "
                                                + "AND Volunteer.VolunteerID = '" + pairedVolunteer + "'";
                //Execute query 
                SqlCommand volunteerInfo = new SqlCommand(volunteerStatusRoleQuery, conn1);

                //Create a new adapter
                SqlDataAdapter volAdapter = new SqlDataAdapter(volunteerInfo);

                //Create a new dataset to hold the query results
                DataSet volDataSet = new DataSet();

                //Store the results in the adapter 
                volAdapter.Fill(volDataSet);

                //Store info to be used for confirmation label in local variables 
                string VolunteerCurrentStatus = volDataSet.Tables[0].Rows[0]["Status_Name"].ToString();
                string VolunteerCurrentRole = volDataSet.Tables[0].Rows[0]["Role_Name"].ToString();

                if (VolunteerCurrentStatus == "Paired" && VolunteerCurrentRole == "Godmother")
                {
                    // SQL string to get the VolunteerID from the Cinderella entity
                    string sql = "SELECT Volunteer_ID "
                                    + "FROM Cinderella "
                                    + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";

                    // Execute SQL
                    SqlCommand comm1 = new SqlCommand(sql, conn1);

                    string SelectedVolunteerID = comm1.ExecuteScalar().ToString();

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

                    // Notifying user of success
                    NotificationLabel.Text = "Cinderella " + PairedCinderellaGridView.SelectedRow.Cells[1].Text.ToString()
                                                + " and Volunteer " + PairedCinderellaGridView.SelectedRow.Cells[3].Text.ToString() + " successfully changed from Paired to Shopping";
                    NotificationLabel.Visible = true;
                }
            }

            //REMEMBER TO CLOSE CONNECTION!!
            conn1.Close();
        }
        catch (Exception ex)
        {
        }

        // Rebind the data to refresh the grid
        PairedCinderellaGridView.DataBind();
        PairedCinderellaGridView.SelectedIndex = -1;

        ShoppingGridView.DataBind();
        ShoppingGridView.SelectedIndex = -1;

        ManualCinderellaGridView.DataBind();

        VolunteerPairingGridView.DataBind();

        GoShoppingButton.Enabled = false;
        UndoShoppingButton.Enabled = false;
        //BreakPairingButton.Enabled = false;
    }
    protected void PairedCinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        NotificationLabel.Visible = false;
        // Enabling the GoShopping button
        GoShoppingButton.Enabled = true;
        //BreakPairingButton.Enabled = true;

        //Disabling the undo controls
        UndoShoppingButton.Enabled = false;
        ShoppingGridView.SelectedIndex = -1;

        // Disabling the manual pair controls
        ManualCinderellaGridView.SelectedIndex = -1;
        VolunteerPairingGridView.SelectedIndex = -1;
        ManualPairButton.Enabled = false;
    }
    protected void ShoppingGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        NotificationLabel.Visible = false;

        // Enabling the UndoShopping button
        UndoShoppingButton.Enabled = true;

        // Disabling the go shopping controls
        GoShoppingButton.Enabled = false;
        //BreakPairingButton.Enabled = false;
        PairedCinderellaGridView.SelectedIndex = -1;

        // Disabling the manual pair controls
        ManualCinderellaGridView.SelectedIndex = -1;
        VolunteerPairingGridView.SelectedIndex = -1;
        ManualPairButton.Enabled = false;
    }
    protected void UndoShoppingButton_Click(object sender, EventArgs e)
    {
        try
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

            // Notifying user of success
            NotificationLabel.Text = "Cinderella " + ShoppingGridView.SelectedRow.Cells[1].Text.ToString()
                                        + " and Volunteer " + ShoppingGridView.SelectedRow.Cells[3].Text.ToString() + " successfully changed from Shopping to Paired";
            NotificationLabel.Visible = true;

            //REMEMBER TO CLOSE CONNECTION!!
            conn1.Close();
        }
        catch (Exception ex)
        {
        }
        // Rebind the data to refresh the grid
        PairedCinderellaGridView.DataBind();
        PairedCinderellaGridView.SelectedIndex = -1;

        ShoppingGridView.DataBind();
        ShoppingGridView.SelectedIndex = -1;

        // Refresh the databinding for the volunteer grid.
        VolunteerPairingGridView.DataBind();

        ManualCinderellaGridView.DataBind();

        GoShoppingButton.Enabled = false;
        UndoShoppingButton.Enabled = false;
        //BreakPairingButton.Enabled = false;
    }
    //protected void BreakPairingButton_Click(object sender, EventArgs e)
    //{

    //}
    protected void ManualPairButton_Click(object sender, EventArgs e)
    {
        try
        {
            NotificationLabel.Visible = false;

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            conn.Open();

            //Retrieve IDs of cinderella and volunteer
            string selectedCinderellaID = ManualCinderellaGridView.SelectedValue.ToString();
            string selectedVolunteerID = VolunteerPairingGridView.SelectedValue.ToString();



            //////////////////////////////////////////////////////////////////////////////////////////////////
            //Retireve first and last name of volunteer and cinderella for notification labal (lines 231-)////
            /////////////////////////////////////////////////////////////////////////////////////////////////

            //Retrieve volunteer full name

            //Query to retrieve information needed for confirmation label
            string volunteerFullNameQuery = "SELECT Volunteer.LastName, Volunteer.FirstName "
                                        + "FROM Volunteer "
                                        + "WHERE Volunteer.VolunteerID = '" + selectedVolunteerID + "'";

            //Execute query 
            SqlCommand volunteerFullName = new SqlCommand(volunteerFullNameQuery, conn);

            //Create a new adapter
            SqlDataAdapter adapter = new SqlDataAdapter(volunteerFullName);

            //Create a new dataset to hold the query results
            DataSet dataSet = new DataSet();

            //Store the results in the adapter 
            adapter.Fill(dataSet);

            //Store info to be used for confirmation label in local variables 
            string volFirstName = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
            string voLastName = dataSet.Tables[0].Rows[0]["LastName"].ToString();


            //Retrieve Cinderella full name

            //Query to retrieve information needed for confirmation label
            string cinderellaFullNameQuery = "SELECT Cinderella.LastName, Cinderella.FirstName "
                                        + "FROM Cinderella "
                                        + "WHERE Cinderella.CinderellaID = '" + selectedCinderellaID + "'";

            //Execute query 
            SqlCommand cinderellaFullName = new SqlCommand(cinderellaFullNameQuery, conn);

            //Create a new adapter
            SqlDataAdapter adapter2 = new SqlDataAdapter(cinderellaFullName);

            //Create a new dataset to hold the query results
            DataSet dataSet2 = new DataSet();

            //Store the results in the adapter 
            adapter2.Fill(dataSet2);

            //Store info to be used for confirmation label in local variables 
            string cinFirstName = dataSet2.Tables[0].Rows[0]["FirstName"].ToString();
            string cinLastName = dataSet2.Tables[0].Rows[0]["LastName"].ToString();



            // Variable to hold current time
            DateTime now = DateTime.Now;

            //Write query to retrieve current CinderellaStatus
            string retrieveCinderellaCurrentStatusQuery = "SELECT Status_Name "
                                        + "FROM CinderellaStatusRecord "
                                        + "WHERE IsCurrent='Y' AND Cinderella_ID='" + selectedCinderellaID + "'";

            //Write query to retrieve current VolunteerStatus
            string retrieveVolunteerCurrentStatusQuery = "SELECT Status_Name "
                                        + "FROM VolunteerStatusRecord "
                                        + "WHERE IsCurrent='Y' AND Volunteer_ID='" + selectedVolunteerID + "'";

            //Convert Strings into SQL commands
            SqlCommand retrieveCinderellaCurrentStatus = new SqlCommand(retrieveCinderellaCurrentStatusQuery, conn);

            SqlCommand retrieveVolunteerCurrentStatus = new SqlCommand(retrieveVolunteerCurrentStatusQuery, conn);

            //Retrieve results from queries and store in a varaible 
            string currentCinderellaStatus = retrieveCinderellaCurrentStatus.ExecuteScalar().ToString();
            string currentVolunteerStatus = retrieveVolunteerCurrentStatus.ExecuteScalar().ToString();

            //Check if volunteer is deleted. If so notify user
            if (currentVolunteerStatus == "Deleted")
            {
                NotificationLabel.Text = volFirstName + " " + voLastName + " has been deleted and cannot be currently paired.";
                NotificationLabel.ForeColor = System.Drawing.Color.Red;
                NotificationLabel.Visible = true;
            }
            //Check if volunteer is shopping. If so notify user
            else if (currentVolunteerStatus == "Shopping")
            {
                NotificationLabel.Text = volFirstName + " " + voLastName + " is shopping and cannot be currently paired.";
                NotificationLabel.ForeColor = System.Drawing.Color.Red;
                NotificationLabel.Visible = true;
            }
            //Check if volunteer is on break. If so notify user
            else if (currentVolunteerStatus == "On Break")
            {
                NotificationLabel.Text = volFirstName + " " + voLastName + " is on break and cannot be currently paired.";
                NotificationLabel.ForeColor = System.Drawing.Color.Red;
                NotificationLabel.Visible = true;
            }
            //Check if cinderella is shopping. If so notify user
            else if (currentCinderellaStatus == "Shopping")
            {
                NotificationLabel.Text = cinFirstName + " " + cinLastName + " is shopping and cannot be currently paired.";
                NotificationLabel.ForeColor = System.Drawing.Color.Red;
                NotificationLabel.Visible = true;
            }
            else
            {
                // Checking if the Cinderella is already paired to a volunteer
                if (currentCinderellaStatus == "Paired")
                {
                    // SQL string to get Volunteer paired to selected Cinderella
                    string sql = "SELECT Volunteer_ID "
                                    + "FROM Cinderella "
                                    + "WHERE CinderellaID = '" + selectedCinderellaID + "'";
                    // Execute Query
                    SqlCommand comm1 = new SqlCommand(sql, conn);
                    string pairedVolunteer = comm1.ExecuteScalar().ToString();


                    // Guaranteeing that the INSERTED 'Ready' status will not interefere with the later INSERTED 'Paired' status
                    if (pairedVolunteer != selectedVolunteerID.ToString())
                    {
                        // SQL string to UPDATE the paired Volunteer's status
                        sql = "UPDATE VolunteerStatusRecord "
                                        + "SET EndTime = '" + now + "', IsCurrent = 'N'"
                                        + "WHERE Volunteer_ID = '" + pairedVolunteer + "' AND IsCurrent = 'Y'";
                        // Execute query string into a SQL command
                        SqlCommand comm2 = new SqlCommand(sql, conn);
                        comm2.ExecuteNonQuery();


                        // SQL string to INSERT a new Ready status for volunteer
                        sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                                + "VALUES ('" + pairedVolunteer + "', '" + now + "', 'Ready', 'Y')";
                        SqlCommand comm3 = new SqlCommand(sql, conn);
                        comm3.ExecuteNonQuery();

                        // re-adding the pairedVolunteer to the queue at front
                        try
                        {
                            //Retrieve ID of selected volunteer
                            int volID = Convert.ToInt32(pairedVolunteer);

                            //Create object instance with selected volunteer
                            VolunteerClass oldVolunteer = new VolunteerClass(volID);

                            //Lock application state so that no else can access it 
                            Application.Lock();

                            //Initialize a local copy of volunteer queue
                            VolunteerQueue.VolunteerQueue volunteerQueueCopy = new VolunteerQueue.VolunteerQueue();

                            //Copy queue in the application session into the local copy
                            volunteerQueueCopy = Application["volunteerQueue"] as VolunteerQueue.VolunteerQueue;

                            //Insert volunter to the queue
                            volunteerQueueCopy.enqueueToFront(oldVolunteer);

                            //Copy changes into application queue
                            Application["volunteerQueue"] = volunteerQueueCopy;

                            //Unlock Application session
                            Application.UnLock();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                // Checking if the Volunteer is already paired to a Cinderella
                if (currentVolunteerStatus == "Paired")
                {

                    // SQL string to get Cinderella paired to selected Volunteer
                    string sql = "SELECT CinderellaID "
                                    + "FROM Cinderella "
                                    + "INNER JOIN CinderellaStatusRecord "
                                    + "ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID "
                                    + "WHERE Volunteer_ID = '" + selectedVolunteerID + "' AND IsCurrent = 'Y' AND Status_Name = 'Paired'";

                    // Execute Query
                    SqlCommand comm1 = new SqlCommand(sql, conn);
                    string pairedCinderella = comm1.ExecuteScalar().ToString();

                    // SQL string to UPDATE paired cinderella to not have a volunteer
                    sql = "UPDATE Cinderella "
                            + "SET Volunteer_ID = NULL "
                            + "WHERE CinderellaID = '" + pairedCinderella + "'";

                    // Execute Query
                    SqlCommand comm2 = new SqlCommand(sql, conn);
                    comm2.ExecuteNonQuery();

                    // Guaranteeing that the INSERTED 'Waiting for Godmother' status will not interefere with the later INSERTED 'Paired' status
                    if (pairedCinderella != selectedCinderellaID.ToString())
                    {
                        // SQL string to UPDATE the paired Cinderella's status
                        sql = "UPDATE CinderellaStatusRecord "
                                        + "SET EndTime = '" + now + "', IsCurrent = 'N'"
                                        + "WHERE Cinderella_ID = '" + pairedCinderella + "' AND IsCurrent = 'Y'";
                        // Execute query string into a SQL command
                        SqlCommand comm3 = new SqlCommand(sql, conn);
                        comm3.ExecuteNonQuery();

                        // SQL string to INSERT a new status of Waiting for Godmother for Cinderella
                        sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                                + "VALUES ('" + pairedCinderella + "', '" + now + "', 'Waiting for Godmother', 'Y')";
                        SqlCommand comm4 = new SqlCommand(sql, conn);
                        comm4.ExecuteNonQuery();

                        sql = "SELECT Cinderella.isManuallyPaired "
                            + "FROM Cinderella "
                            + "WHERE CinderellaID = '" + pairedCinderella + "'";

                        // Execute Query
                        SqlCommand retrieveManualPairingStatus = new SqlCommand(sql, conn);
                        string manualPairingStatus = retrieveManualPairingStatus.ExecuteScalar().ToString();

                        // Re-adding pairedCinderella to the queue at front
                        try
                        {
                            if (manualPairingStatus == "N")
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
                        }
                        catch
                        {

                        }

                    }

                }

                //Query to pair cinderella in the database
                string pairCinderellaQuery = "UPDATE Cinderella "
                                        + "SET Volunteer_ID='" + selectedVolunteerID + "' "
                                        + "WHERE CinderellaID='" + selectedCinderellaID + "'";

                //Turn string into a SQL command
                SqlCommand pairCinderella = new SqlCommand(pairCinderellaQuery, conn);

                // Execute query
                pairCinderella.ExecuteNonQuery();

                /************************
                * Edit Cinderella Info *
                * **********************/

                //Query to end cinderella's "Waiting For Godmother" status record in the database
                string endCurrentCinStatusQuery = "UPDATE CinderellaStatusRecord "
                                        + "SET IsCurrent='N', EndTime='" + now + "' "
                                        + "WHERE IsCurrent='Y' And Cinderella_ID='" + selectedCinderellaID + "'";

                //Turn string into a SQL command
                SqlCommand endCurrentCinStatus = new SqlCommand(endCurrentCinStatusQuery, conn);

                // Execute query
                endCurrentCinStatus.ExecuteNonQuery();

                //Insert new status record "Paired" for volunteer
                string addNewCinStatusRecordQuery = "INSERT INTO CinderellaStatusRecord (Cinderella_ID,StartTime,Status_Name,IsCurrent) "
                                                    + "VALUES ('" + selectedCinderellaID + "', '" + now + "', 'Paired', 'Y')";

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
                                        + "WHERE IsCurrent='Y' AND Volunteer_ID='" + selectedVolunteerID + "'";

                //Turn string into a SQL command
                SqlCommand endCurrentVolStatus = new SqlCommand(endCurrentVolStatusQuery, conn);

                // Execute query
                endCurrentVolStatus.ExecuteNonQuery();

                //Insert new status record "Paired" for volunteer
                string addNewVolStatusRecordQuery = "INSERT INTO VolunteerStatusRecord (Volunteer_ID,StartTime,Status_Name,IsCurrent) "
                                                    + "VALUES ('" + selectedVolunteerID + "', '" + now + "', 'Paired', 'Y')";

                //Execute query 
                SqlCommand addNewVolStatusRecord = new SqlCommand(addNewVolStatusRecordQuery, conn);

                //Execute Query 
                addNewVolStatusRecord.ExecuteNonQuery();


                //Dequeue volunteer from the automated pairing queue so that she does not get paired with another person (duplicate pairings)
                try
                {
                    //Retrieve ID of selected volunteer
                    int cinID = Convert.ToInt32(selectedCinderellaID);

                    //Lock application state so that no else can access it 
                    Application.Lock();

                    //Initialize a local copy of volunteer queue
                    CinderellaQueue.CinderellaQueue cinderellaAutomatedQueueCopy = new CinderellaQueue.CinderellaQueue();

                    //Copy queue in the application session into the local copy
                    cinderellaAutomatedQueueCopy = Application["cinderellaAutomatedQueue"] as CinderellaQueue.CinderellaQueue;

                    //Insert volunter to the queue
                    cinderellaAutomatedQueueCopy.selectiveDequeue(cinID);

                    //Copy changes into application queue
                    Application["cinderellaAutomatedQueue"] = cinderellaAutomatedQueueCopy;

                    //Unlock Application session
                    Application.UnLock();
                }
                catch (Exception ex)
                {

                }

                //Dequeue cinderella from the automated pairing queue so that she does not get paired with another person (pairing overriden)
                try
                {
                    //Retrieve ID of selected volunteer
                    int volID = Convert.ToInt32(selectedVolunteerID);

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


                NotificationLabel.Text = cinFirstName + " " + cinLastName + " has been paired with " + volFirstName + " " + voLastName + ".";
                NotificationLabel.ForeColor = System.Drawing.Color.Green;
                NotificationLabel.Visible = true;
            }
            //Close connection to database
            conn.Close();
        }
        catch (Exception ex)
        {
        }

        //Refresh databinding
        ManualCinderellaGridView.DataBind();
        VolunteerPairingGridView.DataBind();
        PairedCinderellaGridView.DataBind();
        ShoppingGridView.DataBind();

        //Disable and unselect gridviews
        ManualPairButton.Enabled = false;
        ManualCinderellaGridView.SelectedIndex = -1;
        VolunteerPairingGridView.SelectedIndex = -1;
        PairedCinderellaGridView.SelectedIndex = -1;
        ShoppingGridView.SelectedIndex = -1;

        
    }
    protected void ManualCinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        NotificationLabel.Visible = false;

        //Enable pair button only if volunteer and cinderella have been selected
        if (ManualCinderellaGridView.SelectedIndex > -1 && VolunteerPairingGridView.SelectedIndex > -1)
        {
            ManualPairButton.Enabled = true;
        }
        else
        {
            ManualPairButton.Enabled = false;
        }

        // Disabling the go shopping controls
        GoShoppingButton.Enabled = false;
        //BreakPairingButton.Enabled = false;
        PairedCinderellaGridView.SelectedIndex = -1;

        //Disabling the undo controls
        UndoShoppingButton.Enabled = false;
        ShoppingGridView.SelectedIndex = -1;

    }
    protected void VolunteerPairingGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        NotificationLabel.Visible = false;

        //Enable pair button only if volunteer and cinderella have been selected
        if (ManualCinderellaGridView.SelectedIndex > -1 && VolunteerPairingGridView.SelectedIndex > -1)
        {
            ManualPairButton.Enabled = true;
        }
        else
        {
            ManualPairButton.Enabled = false;
        }

        // Disabling the go shopping controls
        GoShoppingButton.Enabled = false;
        //BreakPairingButton.Enabled = false;
        PairedCinderellaGridView.SelectedIndex = -1;

        //Disabling the undo controls
        UndoShoppingButton.Enabled = false;
        ShoppingGridView.SelectedIndex = -1;
    }
    protected void ManualCinderellaGridView_DataBound(object sender, EventArgs e)
    {

        // Iterating for every row in the GridVew
        for (int i = 0; i < ManualCinderellaGridView.Rows.Count; i++)
        {
            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection.
            conn1.Open();

            // SQL string to select whether Cinderellas from the GridView are to be manually paired or not
            string sql = "SELECT IsManuallyPaired "
                            + "FROM Cinderella "
                            + "WHERE CinderellaID = '" + ManualCinderellaGridView.DataKeys[i].Value.ToString() + "'";
            SqlCommand comm1 = new SqlCommand(sql, conn1);

            // Variable to hold that value
            string ManuallyPair = comm1.ExecuteScalar().ToString();

            sql = "SELECT EndTime "
                    + "FROM CinderellaStatusRecord "
                    + "WHERE Status_Name = 'Pending' "
                        + "AND IsCurrent = 'N' "
                        + "AND Cinderella_ID = '" + ManualCinderellaGridView.DataKeys[i].Value.ToString() + "'";
            SqlCommand comm2 = new SqlCommand(sql, conn1);

            DateTime ArrivalTime = Convert.ToDateTime(comm2.ExecuteScalar());

            DateTime now = DateTime.Now;

            double WaitingTime = (now.Subtract(ArrivalTime).TotalMinutes);

            if (ManuallyPair == "Y")
            {
                if (WaitingTime >= 60)
                {
                    ManualCinderellaGridView.Rows[i].BackColor = ColorTranslator.FromHtml("#ff7474");
                }
                else
                {
                    ManualCinderellaGridView.Rows[i].BackColor = ColorTranslator.FromHtml("#ffe85f");
                }
            }
            else
            {
                ManualCinderellaGridView.Rows[i].BackColor = ColorTranslator.FromHtml("#50e153");
            }

            //REMEMBER TO CLOSE CONNECTION!!
            conn1.Close();
        }
    }

    protected void AllVolunteersGridView_DataBound(object sender, EventArgs e)
    {
        // Iterating for every row in the GridVew
        for (int i = 0; i < VolunteerPairingGridView.Rows.Count; i++)
        {
            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection.
            conn1.Open();

            // SQL string to determine status of Volunteer
            string sql = "SELECT Status_Name "
                        + "FROM VolunteerStatusRecord "
                        + "WHERE Volunteer_ID = '" + VolunteerPairingGridView.DataKeys[i].Value.ToString() + "' AND IsCurrent = 'Y'";
            SqlCommand comm2 = new SqlCommand(sql, conn1);
            string status = comm2.ExecuteScalar().ToString();

            if (status == "Paired")
            {
                VolunteerPairingGridView.Rows[i].BackColor = ColorTranslator.FromHtml("#ffe85f");
            }
            else
            {
                VolunteerPairingGridView.Rows[i].BackColor = ColorTranslator.FromHtml("#50e153");
            }

            //REMEMBER TO CLOSE CONNECTION!!
            conn1.Close();
        }
    }
}

//// String to hold the Selected Cinderella ID
//string SelectedCinderellaID = PairedCinderellaGridView.SelectedValue.ToString();

//// Creating a variable to hold the current time
//string now = DateTime.Now.ToString();

////Initialize database connection with "DefaultConnection" setup in the web.config
//SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

////Open the connection.
//conn1.Open();

//// SQL string to get the VolunteerID from the Cinderella entity
//string sql = "SELECT Volunteer_ID "
//                + "FROM Cinderella "
//                + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";

//// Execute SQL
//SqlCommand comm1 = new SqlCommand(sql, conn1);

//string SelectedVolunteerID = comm1.ExecuteScalar().ToString();

//// SQL string to UPDATE Cinderella's status to not current
//sql = "UPDATE CinderellaStatusRecord "
//        + "SET IsCurrent = 'N', EndTime = '" + now + "' "
//        + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "' AND IsCurrent = 'Y'";
//// Execute SQL
//SqlCommand comm2 = new SqlCommand(sql, conn1);
//comm2.ExecuteNonQuery();

//// SQL string to INSERT a new Waiting for Godmother status for Cinderella
//sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
//        + "VALUES ('" + SelectedCinderellaID + "', '" + now + "', 'Waiting for Godmother', 'Y')";
//// Execute SQL
//SqlCommand comm3 = new SqlCommand(sql, conn1);
//comm3.ExecuteNonQuery();

//// SQL string to UPDATE Volunteer's status to not current
//sql = "UPDATE VolunteerStatusRecord "
//        + "SET IsCurrent = 'N', EndTime = '" + now + "' "
//        + "WHERE Volunteer_ID = '" + SelectedVolunteerID + "' AND IsCurrent = 'Y'";
//// Execute SQL
//SqlCommand comm4 = new SqlCommand(sql, conn1);
//comm4.ExecuteNonQuery();

//// SQL string to INSERT a new Ready status for Volunteer
//sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
//+ "VALUES ('" + SelectedVolunteerID + "', '" + now + "', 'Ready', 'Y')";
//// Execute SQL
//SqlCommand comm5 = new SqlCommand(sql, conn1);
//comm5.ExecuteNonQuery();

//sql = "UPDATE Cinderella "
//        + "SET Volunteer_ID = NULL "
//        + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";
//// Execute SQL
//SqlCommand comm6 = new SqlCommand(sql, conn1);
//comm6.ExecuteNonQuery();

//try
//{

//    //Retrieve ID of selected volunteer
//    int cinID = Convert.ToInt32(SelectedCinderellaID);

//    //Create object instance with selected volunteer
//    CinderellaClass returnedCinderella = new CinderellaClass(cinID);

//    //Lock application state so that no else can access it 
//    Application.Lock();

//    //Initialize a local copy of volunteer queue
//    CinderellaQueue.CinderellaQueue cinderellaAutomatedQueueCopy = new CinderellaQueue.CinderellaQueue();

//    //Copy queue in the application session into the local copy
//    cinderellaAutomatedQueueCopy = Application["cinderellaAutomatedQueue"] as CinderellaQueue.CinderellaQueue;

//    //Insert volunter to the queue
//    cinderellaAutomatedQueueCopy.enqueueToFront(returnedCinderella);

//    //Copy changes into application queue
//    Application["cinderellaAutomatedQueue"] = cinderellaAutomatedQueueCopy;

//    //Unlock Application session
//    Application.UnLock();
//}
//catch
//{

//}

//try
//{
//    //Retrieve ID of selected volunteer
//    int volID = Convert.ToInt32(SelectedVolunteerID);

//    //Create object instance with selected volunteer
//    VolunteerClass returnedVolunteer = new VolunteerClass(volID);

//    //Lock application state so that no else can access it 
//    Application.Lock();

//    //Initialize a local copy of volunteer queue
//    VolunteerQueue.VolunteerQueue volunteerQueueCopy = new VolunteerQueue.VolunteerQueue();

//    //Copy queue in the application session into the local copy
//    volunteerQueueCopy = Application["volunteerQueue"] as VolunteerQueue.VolunteerQueue;

//    //Insert volunter to the queue
//    volunteerQueueCopy.enqueueToFront(returnedVolunteer);

//    //Copy changes into application queue
//    Application["volunteerQueue"] = volunteerQueueCopy;

//    //Unlock Application session
//    Application.UnLock();
//}
//catch (Exception ex)
//{

//}

////REMEMBER TO CLOSE CONNECTION!!
//conn1.Close();

//// Rebind the data to refresh the grid
//PairedCinderellaGridView.DataBind();
//PairedCinderellaGridView.SelectedIndex = -1;

//ShoppingGridView.DataBind();
//ShoppingGridView.SelectedIndex = -1;

//GoShoppingButton.Enabled = false;
//UndoShoppingButton.Enabled = false;
//BreakPairingButton.Enabled = false;