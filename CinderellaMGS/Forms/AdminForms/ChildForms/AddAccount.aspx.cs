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

        //Check password strength
        if (PasswordTextBox.Text.Length < 8)
        {
            Password1ErrorLabel.Text = "Password must be at least eight characters long.";
            Password1ErrorLabel.Visible = true;
            errorCounter++;
        }
        else
        {
            Password1ErrorLabel.Visible = false;
        }

        //Check if passwords are matching
        if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
        {
            Password2ErrorLabel.Text = "Passwords do not match.";
            Password2ErrorLabel.Visible = true;
            errorCounter++;
        }
        else
        {
            Password2ErrorLabel.Visible = false;
        }

        //Check if at least one permission was selected 
        if (AdminCheckBox.Checked == false && AlterationsCheckBox.Checked == false && CheckInCheckBox.Checked == false && CheckOutCheckBox.Checked == false && PairingCheckBox.Checked == false)
        {
            PermissionsErrorLabel.Text = "Account must be given permission(s).";
            PermissionsErrorLabel.Visible = true;
            errorCounter++;
        }
        else
        {
            PermissionsErrorLabel.Visible = false;
        }


        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();


        if (errorCounter == 0)
        {
            try
            {

                //Initialize database connection with "DefaultConnection" setup in the web.config
                SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                //Open the connection 
                conn2.Open();

                //Initialize a string variable to hold a query
                string addNewUser = "INSERT INTO Accounts (Username,Password) VALUES (@Uname, @Upassword)";

                //Execute query 
                SqlCommand insertNewAccount = new SqlCommand(addNewUser, conn2);

                //Add values to variables in the query
                insertNewAccount.Parameters.AddWithValue("@Uname", NewUserNameTextBox.Text);
                insertNewAccount.Parameters.AddWithValue("@Upassword", PasswordTextBox.Text);

                //Execute Query 
                insertNewAccount.ExecuteNonQuery();

                //Show success label
                AddedAccountLabel.Visible = true;

                //Refresh Listbox of usernames
                ExistingUserNamesListBox.DataSourceID = "ExistingUserNamesSqlDataSource";
                ExistingUserNamesListBox.DataTextField = "Username";
                ExistingUserNamesListBox.DataValueField = "Username";
                ExistingUserNamesListBox.DataBind();

                //REMEMBER TO CLOSE CONNECTION!!
                conn2.Close();
            }
            catch (Exception ex)
            {
                AddedAccountLabel.Text = "Account was not added successfully";
            };
        }
    }
    protected void AdminCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (AdminCheckBox.Checked == true)
        {
            AlterationsCheckBox.Checked = true;
            CheckInCheckBox.Checked = true;
            CheckOutCheckBox.Checked = true;
            PairingCheckBox.Checked = true;

            AlterationsCheckBox.Enabled = false;
            CheckInCheckBox.Enabled = false;
            CheckOutCheckBox.Enabled = false;
            PairingCheckBox.Enabled = false;
        }

        if (AdminCheckBox.Checked == false)
        {
            AlterationsCheckBox.Checked = false;
            CheckInCheckBox.Checked = false;
            CheckOutCheckBox.Checked = false;
            PairingCheckBox.Checked = false;

            AlterationsCheckBox.Enabled = true;
            CheckInCheckBox.Enabled = true;
            CheckOutCheckBox.Enabled = true;
            PairingCheckBox.Enabled = true;
        }
    }
}