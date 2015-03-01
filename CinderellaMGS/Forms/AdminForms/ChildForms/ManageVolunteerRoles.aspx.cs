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

        
        
    }
    protected void volunteerListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        roleDropDownList.Enabled = true;

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

        conn1.Close();
    }
}