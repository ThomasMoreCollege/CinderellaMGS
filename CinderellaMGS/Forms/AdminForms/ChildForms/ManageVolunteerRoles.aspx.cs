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
    }


    protected void roleDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void changeRoleButton_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        conn.Open();

        string getVolunteerID = "SELECT VolunteerID FROM Volunteer WHERE LastName = '" + volunteerListBox.SelectedItem.Text + "'";
        SqlCommand com1 = new SqlCommand(getVolunteerID, conn);
        string getID = Convert.ToString(com1.ExecuteScalar().ToString());

        string updateCurrentRole = "UPDATE VolunteerRoleRecord SET EndTime = '" + DateTime.Now + "', IsCurrent = 'N' WHERE Volunteer_ID = '" + getID + "' AND IsCurrent = 'Y'";
        SqlCommand updateRole = new SqlCommand(updateCurrentRole, conn);
        updateRole.ExecuteNonQuery();



        string sql = "INSERT INTO VolunteerRoleRecord (Volunteer_ID, StartTime, Role_Name, IsCurrent) VALUES ( '" + getID  + "', '" + DateTime.Now +"', '" + roleDropDownList.SelectedItem.Text + "', '" + 'Y' + "')";

        // Execute query
        SqlCommand comm1 = new SqlCommand(sql, conn);
        comm1.ExecuteNonQuery();

        conn.Close();
        roleDropDownList.DataBind();

        userNorificationLabel.ForeColor = System.Drawing.Color.Green;

        string notification = "Successly Updated " + volunteerListBox.SelectedItem.Text + " from " + currentRoleDisplay.Text + " to " + roleDropDownList.SelectedItem.Text + "!";
        userNorificationLabel.Text = notification;

        roleDropDownList.Enabled = false;
        currentRoleDisplay.Text = "---";
        changeRoleButton.Enabled = false;
        
    }

    protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        roleDropDownList.Enabled = true;
        userNorificationLabel.Enabled = false;
        userNorificationLabel.Text = "";
        changeRoleButton.Enabled = false;


        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn1.Open();

        //Initialize a string variable to hold a query
        string getAvailableRoles = "SELECT RoleType.RoleName FROM RoleType WHERE RoleType.RoleName <> 'Administrator' AND RoleType.RoleName <> (SELECT RoleType.RoleName FROM RoleType INNER JOIN VolunteerRoleRecord ON RoleType.RoleName = VolunteerRoleRecord.Role_Name INNER JOIN Volunteer ON VolunteerRoleRecord.Volunteer_ID = Volunteer.VolunteerID WHERE VolunteerRoleRecord.IsCurrent = 'Y' AND Volunteer.LastName = '" + volunteerListBox.SelectedItem.Text + "')";

        //Execute query 
        SqlCommand com1 = new SqlCommand(getAvailableRoles, conn1);


        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(com1); 
        DataSet myDataSet = new DataSet();
        mySqlDataAdapter.Fill(myDataSet); 
        roleDropDownList.DataSource = myDataSet;
        roleDropDownList.DataTextField = "RoleName";
        roleDropDownList.DataValueField = "RoleName";
        roleDropDownList.DataBind();

        string getSelectedVolunteerRole = "SELECT VolunteerRoleRecord.Role_Name FROM VolunteerRoleRecord INNER JOIN Volunteer ON VolunteerRoleRecord.Volunteer_ID = Volunteer.VolunteerID WHERE Volunteer.LastName = '" + volunteerListBox.SelectedItem.Text + "' AND VolunteerRoleRecord.IsCurrent = 'Y'";

        SqlCommand com2 = new SqlCommand(getSelectedVolunteerRole, conn1);

        string currentVolunteerRole = Convert.ToString(com2.ExecuteScalar().ToString());

        currentRoleDisplay.Text = currentVolunteerRole;


        conn1.Close();
    }
    protected void roleDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
    {
        changeRoleButton.Enabled = true;
    }
}