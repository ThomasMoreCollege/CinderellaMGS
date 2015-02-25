using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL

public partial class Forms_AdminForms_ChildForms_DeleteAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        //        DELETE FROM table_name
        //WHERE some_column=some_value;
        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        //Initialize a string variable to hold a query
        string deleteUserQuery = "DELETE FROM Accounts WHERE Username=@Uname";

        //Execute query 
        SqlCommand deleteAccount = new SqlCommand(deleteUserQuery, conn);

        //Add values to variables in the query
        deleteAccount.Parameters.AddWithValue("@Uname", ExistingAcctsListBox.SelectedValue.ToString());

        //Execute Query 
        deleteAccount.ExecuteNonQuery();

        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();

        ExistingAcctsListBox.DataSourceID = "AccountsToBeDeletedSqlDataSource";
        ExistingAcctsListBox.DataTextField = "Username";
        ExistingAcctsListBox.DataValueField = "Username";
        ExistingAcctsListBox.DataBind();
    }
}