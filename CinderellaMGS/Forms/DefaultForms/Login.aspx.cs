using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        
        //Open the connection 
        conn.Open();
        
        //Initialize a string variable to hold a query
        string checkUserInput = "SELECT count(*) "
                                + "FROM Accounts "
                                + "WHERE Username='" + UsernameTextBox.Text + "' AND Password='" + PasswordTextBox.Text + "'";
        
        //Execute query 
        SqlCommand com1 = new SqlCommand(checkUserInput, conn);
        
        //Retrieve results from query and store in a varaible 
        int validUserLogin = Convert.ToInt32(com1.ExecuteScalar().ToString());
        
        //Validate if such a user login is correct exists
        if (validUserLogin == 0)
        {
            //Display error message
            LoginErrorLabel.Visible = true;
        }
        else
        {
            //Query to retrieve the account type
            string acctTypeQuery = "SELECT Account_Type "
                                    + "FROM Accounts "
                                    + "WHERE Username='" + UsernameTextBox.Text + "' AND Password='" + PasswordTextBox.Text + "'";
            
            //Execute query 
            SqlCommand com2 = new SqlCommand(acctTypeQuery, conn);

            //Store account type into a string variable
            string acctType = com2.ExecuteScalar().ToString();

            // Sets up the session for keeping track of username and account type and re-directs to HomePage
            LoginErrorLabel.Visible = false;
            Session["CurrentUser"] = UsernameTextBox.Text;
            Session["CurrentAccType"] = acctType;
            Response.Redirect("HomePage.aspx");
        }

        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();

        

    }


}