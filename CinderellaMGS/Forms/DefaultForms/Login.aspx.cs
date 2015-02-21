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
        }
        else if ((Session["CurrentUser"].ToString()) == "Admin")
        {
            // Sets admin menu links to visible for admin access
            (this.Master as MasterPage).RevealAdmin(true);
        }

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        conn.Open();
        string checkUsername = "SELECT count(*) FROM Accounts WHERE Username='" + UsernameTextBox.Text + "'";
        SqlCommand com = new SqlCommand(checkUsername, conn);
        int validUsername = Convert.ToInt32(com.ExecuteScalar().ToString());
        if (validUsername == 0)
        {
            LoginErrorLabel.Visible = true;
        }
        else
        {
            LoginErrorLabel.Visible = false;
            Session["CurrentUser"] = UsernameTextBox.Text;
            Response.Redirect("HomePage.aspx");
        }


        conn.Close();


        // Sets up the session for keeping track of username and directs to HomePage
       // Session["CurrentUser"] = UsernameTextBox.Text;
        //Response.Redirect("HomePage.aspx");
    }


}