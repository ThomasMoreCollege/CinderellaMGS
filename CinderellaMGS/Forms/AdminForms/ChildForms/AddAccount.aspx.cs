using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL

public partial class Forms_AdminForms_ChildForms_AddAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateAccButton_Click(object sender, EventArgs e)
    {
        try
        {

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            //Initialize a string variable to hold a query
            string addNewUser = "INSERT INTO Accounts (Username,Password) VALUES (@Uname, @Upassword)";

            //Execute query 
            SqlCommand insertNewAccount = new SqlCommand(addNewUser, conn);

            //Add values to variables in the query
            insertNewAccount.Parameters.AddWithValue("@Uname", NewUserNameTextBox.Text);
            insertNewAccount.Parameters.AddWithValue("@Upassword", PasswordTextBox.Text);

            //Execute Query 
            insertNewAccount.ExecuteNonQuery();

            Response.Redirect("~/Forms/DefaultForms/Login.aspx");

            Label.Text = "Success!";

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();
        }
        catch (Exception ex)
        {
            Label.Text = "Error" + ex.ToString();
        };
    }
}