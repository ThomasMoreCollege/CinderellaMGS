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

public partial class Forms_AdminForms_ChildForms_ManageVolunteerRoles : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }


    protected void roleDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void changeRoleButton_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        conn.Open();

        //String to get ID of selected Volunteer 
        string getVolunteerID = VolunteerGridView.SelectedValue.ToString();

        //Query to retrieve information needed for confirmation label
        string volunteerPrevRoleQuery = "SELECT Volunteer.VolunteerID, Volunteer.LastName, Volunteer.FirstName, VolunteerRoleRecord.Role_Name, VolunteerStatusRecord.Status_Name "
                                    + "FROM Volunteer "
                                    + "INNER JOIN VolunteerRoleRecord "
                                    + "ON Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID "
                                    + "INNER JOIN VolunteerStatusRecord "
                                    + "ON Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID "
                                    + "WHERE VolunteerRoleRecord.IsCurrent = 'Y' "
                                    + "AND  VolunteerStatusRecord.IsCurrent = 'Y' "
                                    + "AND VolunteerRoleRecord.Role_Name != 'Alterations' "
                                    + "AND Volunteer.IsValid = 'Y' "
                                    + "AND Volunteer.VolunteerID = '" + getVolunteerID + "'";

        //Execute query 
        SqlCommand volunteerPrevRole = new SqlCommand(volunteerPrevRoleQuery, conn);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(volunteerPrevRole);

        //Create a new dataset to hold the query results
        DataSet dataSet = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(dataSet);

        //Store info to be used for confirmation label in local variables 
        string firstName = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
        string lastName = dataSet.Tables[0].Rows[0]["LastName"].ToString();
        string currentStatus = dataSet.Tables[0].Rows[0]["Status_Name"].ToString();
        string oldRole = dataSet.Tables[0].Rows[0]["Role_Name"].ToString();
        string newRole = roleDropDownList.SelectedItem.Text;

        //If volunteer is shopping notify the user that role cannot be changed
        if (currentStatus == "Shopping")
        {
            ConfirmLabel.Text = firstName + " " + lastName + " is currently shopping and cannot have their role changed at the moment.";
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

                // SQL string to UPDATE all Cinderellas to 
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

                ////////////////////////////

                // SQL string to UPDATE the paired Volunteer's status
                string endVolunteerStatusQuery = "UPDATE VolunteerStatusRecord "
                                + "SET EndTime = '" + DateTime.Now + "', IsCurrent = 'N' "
                                + "WHERE Volunteer_ID = '" + getVolunteerID + "' AND IsCurrent = 'Y'";
                // Execute query string into a SQL command
                SqlCommand endVolunteerStatus = new SqlCommand(endVolunteerStatusQuery, conn);
                endVolunteerStatus.ExecuteNonQuery();

                // SQL string to INSERT a new status of Ready for Cinderella
                string addNewVolunteerStatusQuery = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                        + "VALUES ('" + getVolunteerID + "', '" + DateTime.Now + "', 'Ready', 'Y')";
                SqlCommand addNewVolunteerStatus = new SqlCommand(addNewVolunteerStatusQuery, conn);
                addNewVolunteerStatus.ExecuteNonQuery();

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

            string updateCurrentRole = "UPDATE VolunteerRoleRecord "
                                        + "SET EndTime = '" + DateTime.Now + "', IsCurrent = 'N' "
                                        + "WHERE Volunteer_ID = '" + getVolunteerID + "' AND IsCurrent = 'Y'";

            SqlCommand updateRole = new SqlCommand(updateCurrentRole, conn);

            updateRole.ExecuteNonQuery();

            string changeRoleQuery = "INSERT INTO VolunteerRoleRecord (Volunteer_ID, StartTime, Role_Name, IsCurrent) "
                            + "VALUES ( '" + getVolunteerID + "', '" + DateTime.Now + "', '" + roleDropDownList.SelectedItem.Text + "', '" + 'Y' + "')";

            // Execute query
            SqlCommand changeRole = new SqlCommand(changeRoleQuery, conn);
            changeRole.ExecuteNonQuery();


            //Put Volunteer into pairing queue if role is switched to Godmother
            if (roleDropDownList.SelectedItem.Text == "Godmother")
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
                }
                catch (Exception ex)
                {

                }
            }

            ConfirmLabel.Text = firstName + " " + lastName + "'s role has been changed from " + oldRole + " to " + newRole + ".";
            ConfirmLabel.Visible = true;
        }
        
        conn.Close();
        roleDropDownList.DataBind();
        VolunteerGridView.DataBind();

        //GridViewRow currentRow = VolunteerGridView.SelectedRow;

        //string notification = "Successfully changed " + currentRow.Cells[2].Text + " " + currentRow.Cells[3].Text + " to a " + currentRow.Cells[4].Text + " role!";
        roleDropDownList.Enabled = false;
        changeRoleButton.Enabled = false;
        VolunteerGridView.SelectedIndex = -1;
        
    }

    protected void roleDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
    {
        changeRoleButton.Enabled = true;
    }

    protected void VolunteerGridView_SelectedIndexChanged1(object sender, EventArgs e)
    {
        roleDropDownList.Enabled = true;
        changeRoleButton.Enabled = true;

        //When a new volunteer is selected do not display confirmation label anymore
        ConfirmLabel.Visible = false;

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn1.Open();

        //Initialize a string variable to hold a query
        string getAvailableRoles = "SELECT RoleType.RoleName "
                                    + "FROM RoleType "
                                    + "WHERE RoleType.RoleName <> 'Administrator' "
                                            + "AND RoleType.RoleName <> (SELECT RoleType.RoleName "
                                                                        + "FROM RoleType "
                                                                        + "INNER JOIN VolunteerRoleRecord "
                                                                            + "ON RoleType.RoleName = VolunteerRoleRecord.Role_Name "
                                                                        + "INNER JOIN Volunteer "
                                                                            + "ON VolunteerRoleRecord.Volunteer_ID = Volunteer.VolunteerID "
                                                                        + "WHERE VolunteerRoleRecord.IsCurrent = 'Y' AND VolunteerRoleRecord.Volunteer_ID = '" + VolunteerGridView.SelectedValue.ToString() + "')";

        //Execute query 
        SqlCommand com1 = new SqlCommand(getAvailableRoles, conn1);


        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(com1);
        DataSet myDataSet = new DataSet();
        mySqlDataAdapter.Fill(myDataSet);
        roleDropDownList.DataSource = myDataSet;
        roleDropDownList.DataTextField = "RoleName";
        roleDropDownList.DataValueField = "RoleName";
        roleDropDownList.DataBind();

        string getSelectedVolunteerRole = "SELECT VolunteerRoleRecord.Role_Name "
                                            + "FROM VolunteerRoleRecord "
                                            + "INNER JOIN Volunteer "
                                                + "ON VolunteerRoleRecord.Volunteer_ID = Volunteer.VolunteerID "
                                            + "WHERE Volunteer.VolunteerID = '" + VolunteerGridView.SelectedValue.ToString() + "' "
                                                        + "AND VolunteerRoleRecord.IsCurrent = 'Y'";

        SqlCommand com2 = new SqlCommand(getSelectedVolunteerRole, conn1);

        string currentVolunteerRole = Convert.ToString(com2.ExecuteScalar().ToString());

        conn1.Close();
    }
}