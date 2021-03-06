﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

public partial class Forms_CinderellaCheckin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }

    protected void CheckInButton_Click(object sender, EventArgs e)
    {
        
        
        // Checking to make sure a Cinderella is selected
        if (CinderellaGridView.SelectedRow == null)
        {
            // Outputs error message if no Cinderella is selected
            String errorVar = "Please select a Cinderella";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else
        {
           
                // Remove the update message from the screen.
                SuccessLabel.Visible = false;

                // Creating a variable to hold a string of the Cinderella's ID
                string SelectedCinderellaID = CinderellaGridView.SelectedValue.ToString();

                // Creating a variable to hold the current time
                string now = DateTime.Now.ToString();

                //Initialize database connection with "DefaultConnection" setup in the web.config
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                //Open the connection 
                conn.Open();

                if (needsManualPairingCheckBox.Checked == true){
                    string updateCinderellaManPairStatus = "UPDATE Cinderella "
                                                            + "SET isManuallyPaired = 'Y' "
                                                            + "WHERE CinderellaID = '" + CinderellaGridView.SelectedValue.ToString() + "'";
                    // Execute query
                    SqlCommand comm = new SqlCommand(updateCinderellaManPairStatus, conn);
                    comm.ExecuteNonQuery();
                }

                // SQL string to select the Cinderella's paired status
                string sql = "SELECT isManuallyPaired "
                                + "FROM Cinderella "
                                + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";
                // Execute query
                SqlCommand getPairingStatus = new SqlCommand(sql, conn);

                string CinderellaPairStatus = getPairingStatus.ExecuteScalar().ToString();




                // SQL string to UPDATE Pending status 
                sql = "UPDATE CinderellaStatusRecord "
                            + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                            + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "' AND IsCurrent = 'Y'";

                // Execute query
                SqlCommand comm1 = new SqlCommand(sql, conn);
                comm1.ExecuteNonQuery();

                // SQL string to INSERT Waiting status into StatusRecord
                sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                        + "VALUES ('" + SelectedCinderellaID + "', '" + now + "', 'Waiting for Godmother', 'Y')";

                // Execute query
                SqlCommand comm2 = new SqlCommand(sql, conn);
                comm2.ExecuteNonQuery();

                //REMEMBER TO CLOSE CONNECTION!!
                conn.Close();

                GridViewRow currentRow = CinderellaGridView.SelectedRow;

                string notification = "" + currentRow.Cells[2].Text + " " + currentRow.Cells[1].Text + " has been successfully checked in!";
                SuccessLabel.Text = notification;
                SuccessLabel.Visible = true;

                // Rebind the data to refresh the Grid
                CinderellaGridView.DataBind();
                CinderellaGridView.SelectedIndex = -1;


                // Make the NeedsManualPairingCheckBox in accessable.
                needsManualPairingCheckBox.Checked = false;
                needsManualPairingCheckBox.Enabled = false;
            
            try{

                //Retrieve ID of selected volunteer
                int cinID = Convert.ToInt32(SelectedCinderellaID);

                //Create object instance with selected volunteer
                CinderellaClass checkinCinderella = new CinderellaClass(cinID);

                //Lock application state so that no else can access it 
                Application.Lock();

                // If manually paired skip insert into QUEUE
                if (CinderellaPairStatus == "Y")
                {
                  
                }
                else
                {
                    //Initialize a local copy of volunteer queue
                    CinderellaQueue.CinderellaQueue cinderellaAutomatedQueueCopy = new CinderellaQueue.CinderellaQueue();

                    //Copy queue in the application session into the local copy
                    cinderellaAutomatedQueueCopy = Application["cinderellaAutomatedQueue"] as CinderellaQueue.CinderellaQueue;

                    //Insert volunter to the queue
                    cinderellaAutomatedQueueCopy.priorityEnqueue(checkinCinderella);

                    //Copy changes into application queue
                    Application["cinderellaAutomatedQueue"] = cinderellaAutomatedQueueCopy;

                    //Unlock Application session
                    Application.UnLock();

                    string notification2 = "" + currentRow.Cells[2].Text + " " + currentRow.Cells[1].Text + " has been successfully checked in!";
                    SuccessLabel.Text = notification2;
                    SuccessLabel.Visible = true;
                }
            }
            catch
            {
                SuccessLabel.Text = "Fail";
                SuccessLabel.ForeColor = System.Drawing.Color.Red;
                SuccessLabel.Visible = true;
            }
        }
    }
    protected void CinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        SuccessLabel.Visible = false;
        needsManualPairingCheckBox.Enabled = true;

        // Creating a variable to hold a string of the Cinderella's ID
        string SelectedCinderellaID = CinderellaGridView.SelectedValue.ToString();

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        // SQL string to select the Cinderella's paired status
        string sql = "SELECT isManuallyPaired "
                        + "FROM Cinderella "
                        + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";
        // Execute query
        SqlCommand getPairingStatus = new SqlCommand(sql, conn);
        string CinderellaPairStatus = getPairingStatus.ExecuteScalar().ToString();

        if (CinderellaPairStatus == "Y")
        {
            needsManualPairingCheckBox.Checked = true;
        }
        else
        {
            needsManualPairingCheckBox.Checked = false;
        }
    }
}