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

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn1.Open();

        //Variable that keeps tally of number of errors
        int errorCounter = 0;

        //Initialize a string variable to hold a query
        string checkUserNameInput = "SELECT count(*) FROM Accounts WHERE Username='" + NewUserNameTextBox.Text + "'";

        //Execute query 
        SqlCommand com1 = new SqlCommand(checkUserNameInput, conn1);

        //Retrieve results from query and store in a varaible 
        int validUserLogin = Convert.ToInt32(com1.ExecuteScalar().ToString());

        //Check if username textbox is empty
        if (NewUserNameTextBox.Text == string.Empty)
        {
            UserNameErrorLabel.Text = "Please create a username.";
            UserNameErrorLabel.Visible = true;
            errorCounter++;
        }
        else
        {
            UserNameErrorLabel.Visible = false;

            //Validate if such a user login is correct exists
            if (validUserLogin != 0)
            {
                //Display error message
                UserNameErrorLabel.Text = "Username already exists.";
                UserNameErrorLabel.Visible = true;
                errorCounter++;
            }
            else
            {
                UserNameErrorLabel.Visible = false;
            }
        }

        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();

        if (errorCounter != 0 || !(IsValid))
        {
            AddedAccountLabel.Visible = false;
        }
        if (errorCounter == 0 && IsValid)
        {
            try
            {

                //Initialize database connection with "DefaultConnection" setup in the web.config
                SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                //Open the connection 
                conn2.Open();

                //Initialize a string variable to hold a query
                string addNewUser = "INSERT INTO Accounts (Username,Password,Account_Type) VALUES (@Uname, @Upassword, @Uacctype)";

                //Execute query 
                SqlCommand insertNewAccount = new SqlCommand(addNewUser, conn2);

                //Add values to variables in the query
                insertNewAccount.Parameters.AddWithValue("@Uname", NewUserNameTextBox.Text);
                insertNewAccount.Parameters.AddWithValue("@Upassword", PasswordTextBox.Text);

                if (AccountTypesRadioButtonList.Items[0].Selected == true)
                {
                    insertNewAccount.Parameters.AddWithValue("@Uacctype", AccountTypesRadioButtonList.Items[0].Text);
                }
                if (AccountTypesRadioButtonList.Items[1].Selected == true)
                {
                    insertNewAccount.Parameters.AddWithValue("@Uacctype", AccountTypesRadioButtonList.Items[1].Text);
                }
                if (AccountTypesRadioButtonList.Items[2].Selected == true)
                {
                    insertNewAccount.Parameters.AddWithValue("@Uacctype", AccountTypesRadioButtonList.Items[2].Text);
                }

                //Execute Query 
                insertNewAccount.ExecuteNonQuery();

                //REMEMBER TO CLOSE CONNECTION!!
                conn2.Close();                

                //Show success label
                AddedAccountLabel.Visible = true;

                //Refresh Listbox of usernames
                ExistingUserNamesListBox.DataSourceID = "ExistingUserNamesSqlDataSource";
                ExistingUserNamesListBox.DataTextField = "Username";
                ExistingUserNamesListBox.DataValueField = "Username";
                ExistingUserNamesListBox.DataBind();

                NewUserNameTextBox.Text = "";
                PasswordTextBox.Text = "";
                ConfirmPasswordTextBox.Text = "";
                foreach (ListItem item in AccountTypesRadioButtonList.Items)
                {
                    item.Selected = false;
                }
                NewUserNameTextBox.Focus();
                
            }
            catch (Exception ex)
            {
                AddedAccountLabel.Text = "Account was not added successfully";
                AddedAccountLabel.Visible = true;
                
            };
        }
    }


    protected void NewUserNameTextBox_TextChanged(object sender, EventArgs e)
    {
        if (AddedAccountLabel.Visible == true)
        {
            AddedAccountLabel.Visible = false;
        }
    }
    protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
    {
        if (AddedAccountLabel.Visible == true)
        {
            AddedAccountLabel.Visible = false;
        }
    }
    protected void ConfirmPasswordTextBox_TextChanged(object sender, EventArgs e)
    {
        if (AddedAccountLabel.Visible == true)
        {
            AddedAccountLabel.Visible = false;
        }
    }
}