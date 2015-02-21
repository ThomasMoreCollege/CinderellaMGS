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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
        
        }


        // Checking if a session is running
        if ((Session["CurrentUser"] == null) || (Session["CurrentUser"].ToString()) != "Admin")
        {
            // Sets admin menu to not visible
            (this.Master as MasterPage).RevealAdmin(false);
            (this.Master as MasterPage).RevealAllUserFeatures(false);
        }
        else if ((Session["CurrentUser"].ToString()) == "Admin")
        {
            // Sets admin menu links to visible for admin access
            (this.Master as MasterPage).RevealAdmin(true);
            (this.Master as MasterPage).RevealAllUserFeatures(true);
        }

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        
        //Open the connection 
        conn.Open();
        
        //Initialize a string variable to hold a query
        string checkUserInput = "SELECT count(*) FROM Accounts WHERE Username='" + UsernameTextBox.Text + "' AND Password='" + PasswordTextBox.Text + "'";
        
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
            // Sets up the session for keeping track of username and directs to HomePage
            LoginErrorLabel.Visible = false;
            Session["CurrentUser"] = UsernameTextBox.Text;
            Response.Redirect("HomePage.aspx");
        }

        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();

        

    }


}