using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL

public partial class Forms_AdminForms_ChildForms_EditAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }
    protected void EditUserNameButton_Click(object sender, EventArgs e)
    {
        if (CurrentAcctsListBox.SelectedIndex > -1)
        {
            NewUsernameTextBox.Enabled = true;
            NewUsernameTextBox.BackColor = System.Drawing.Color.White;
            EditAccountFormButton.Enabled = true;

            NewUsernameRequiredFieldValidator.Enabled = true;
        }

    }
    protected void EditAcctTypeButton_Click(object sender, EventArgs e)
    {
        if (CurrentAcctsListBox.SelectedIndex > -1)
        {
            NewAccountTypeRadioButtonList.Enabled = true;
            EditAccountFormButton.Enabled = true;
        }

    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //Enable all button
        ChangePasswordButton.Enabled = true;
        EditUserNameButton.Enabled = true;
        EditAcctTypeButton.Enabled = true;

        //Disable New USer textbox
        NewUsernameTextBox.Enabled = false;
        NewUsernameTextBox.BackColor = System.Drawing.Color.LightGray;
        NewUsernameTextBox.Text = "";

        //Disable and unselect Radiobutton controls and 
        NewAccountTypeRadioButtonList.Enabled = false;
        foreach (ListItem item in NewAccountTypeRadioButtonList.Items)
        {
            item.Selected = false;
        }

        //Hide label notifying account changed if it is visible
        ChangedAccountLabel.Visible = false;

        //Disable Save Button
        EditAccountFormButton.Enabled = false;

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn1.Open();

        //Initialize a string variable to hold a query
        string retrieveUsernameQuery = "SELECT Username FROM Accounts WHERE Username='" + CurrentAcctsListBox.SelectedItem.Text + "'";

        //Execute query 
        SqlCommand com1 = new SqlCommand(retrieveUsernameQuery, conn1);

        //Retrieve results from query and store in a varaible 
        string selectedUsername = com1.ExecuteScalar().ToString();

        UserNameLabel.Text = selectedUsername;
        HiddenTextBox1.Text = selectedUsername;

        conn1.Close();

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn2.Open();

        //Initialize a string variable to hold a query
        string retrieveAcctTypeQuery = "SELECT Account_Type FROM Accounts WHERE Username='" + CurrentAcctsListBox.SelectedItem.Text + "'";

        //Execute query 
        SqlCommand com2 = new SqlCommand(retrieveAcctTypeQuery, conn2);

        //Retrieve results from query and store in a varaible 
        string selectedAcctType = com2.ExecuteScalar().ToString();

        CurrentAcctTypeLabel.Text = selectedAcctType;

        if (selectedAcctType == "Administrator")
        {
            NewAccountTypeRadioButtonList.Items[0].Selected = true;
        }
        if (selectedAcctType == "Standard")
        {
            NewAccountTypeRadioButtonList.Items[1].Selected = true;
        }
        if (selectedAcctType == "Pairing")
        {
            NewAccountTypeRadioButtonList.Items[2].Selected = true;
        }
        conn2.Close();
    }
    protected void EditAccountFormButton_Click(object sender, EventArgs e)
    {


        //Variable that keeps tally of number of errors
        int errorCounter = 0;
        int catchCounter = 0;

        //Try to change username only if username text box is enabled
        if (NewUsernameTextBox.Enabled == true)
        {
            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn1.Open();

            //Initialize a string variable to hold a query
            string checkUserNameInput = "SELECT count(*) "
                                        + "FROM Accounts "
                                        + "WHERE Username='" + NewUsernameTextBox.Text + "'";

            //Execute query 
            SqlCommand com1 = new SqlCommand(checkUserNameInput, conn1);

            //Retrieve results from query and store in a varaible 
            int validUserLogin = Convert.ToInt32(com1.ExecuteScalar().ToString());

            //Check if username textbox is empty

            //Validate if such a user login already exists
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
            if (errorCounter == 0 && IsValid)
            {
                try
                {

                    //Initialize database connection with "DefaultConnection" setup in the web.config
                    SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                    //Open the connection 
                    conn2.Open();

                    string editAcctQuery = "UPDATE Accounts "
                                            + "SET Username=@Uname WHERE Username='" + CurrentAcctsListBox.SelectedItem.Text + "'";

                    //Execute query 
                    SqlCommand editAccount = new SqlCommand(editAcctQuery, conn2);

                    //Add values to variables in the query
                    editAccount.Parameters.AddWithValue("@Uname", NewUsernameTextBox.Text);

                    editAccount.ExecuteNonQuery();

                    //REMEMBER TO CLOSE CONNECTION!!
                    conn2.Close();


                }
                catch (Exception ex)
                {
                    ChangedAccountLabel.Text = "Account was not added successfully";
                    ChangedAccountLabel.Visible = true;
                    catchCounter++;

                };
            }


        }
        if (NewAccountTypeRadioButtonList.Enabled == true)
        {
            if (NewAccountTypeRadioButtonList.SelectedItem.Text == CurrentAcctTypeLabel.Text)
            {
                NewAcctTypeErrorLabel.Visible = true;
                NewAcctTypeErrorLabel.Text = "Account type is already assigned.";
                errorCounter++;
            }
            else
            {
                NewAcctTypeErrorLabel.Visible = false;
            }

            if (errorCounter == 0 && IsValid)
            {
                try
                {
                    //Initialize database connection with "DefaultConnection" setup in the web.config
                    SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                    //Open the connection 
                    conn3.Open();

                    string editAcctQuery = "UPDATE Accounts "
                                            + "SET Account_Type=@UacctType "
                                            + "WHERE Username='" + CurrentAcctsListBox.SelectedItem.Text + "'";

                    //Execute query 
                    SqlCommand editAccount = new SqlCommand(editAcctQuery, conn3);

                    //Add values to variables in the query
                    editAccount.Parameters.AddWithValue("@UacctType", NewAccountTypeRadioButtonList.SelectedItem.Text);

                    editAccount.ExecuteNonQuery();

                    //REMEMBER TO CLOSE CONNECTION!!
                    conn3.Close();
                }
                catch (Exception ex)
                {
                    ChangedAccountLabel.Text = "Account was not added successfully";
                    ChangedAccountLabel.Visible = true;
                    catchCounter++;
                };
            }
        }

        if (NewPasswordTextBox.Enabled == true)
        {
            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection currentPasswordConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            currentPasswordConn.Open();

            //Initialize a string variable to hold a query

            // string checkUserNameInput = "SELECT count(*) FROM Accounts WHERE Username='" + NewUserNameTextBox.Text + "'";
            string checkCurrentPassword = "SELECT count(*) "
                                            + "FROM Accounts "
                                            + "WHERE Username='" + CurrentAcctsListBox.SelectedItem.Text + "' AND Password='" + CurrentPasswordTextBox.Text + "'";

            //Execute query 
            SqlCommand command1 = new SqlCommand(checkCurrentPassword, currentPasswordConn);

            //Retrieve results from query and store in a varaible 
            int validCurrentPassword = Convert.ToInt32(command1.ExecuteScalar().ToString());

            if (validCurrentPassword == 0)
            {
                //Display error message
                InvalidPasswordLabel.Text = "Password is incorrect.";
                InvalidPasswordLabel.Visible = true;
                errorCounter++;
            }
            else
            {
                InvalidPasswordLabel.Visible = false;
            }
            currentPasswordConn.Close();
            if (errorCounter == 0 && IsValid)
            {
                try
                {
                    //Initialize database connection with "DefaultConnection" setup in the web.config
                    SqlConnection conn4 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                    //Open the connection 
                    conn4.Open();

                    string editPasswordQuery = "UPDATE Accounts "
                                                + "SET Password=@Upassword "
                                                + "WHERE Username='" + CurrentAcctsListBox.SelectedItem.Text + "'";

                    //Execute query 
                    SqlCommand editPassword = new SqlCommand(editPasswordQuery, conn4);

                    //Add values to variables in the query
                    editPassword.Parameters.AddWithValue("@Upassword", NewPasswordTextBox.Text);

                    editPassword.ExecuteNonQuery();

                    //REMEMBER TO CLOSE CONNECTION!!
                    conn4.Close();
                }
                catch (Exception ex)
                {
                    ChangedAccountLabel.Text = "Account was not added successfully";
                    ChangedAccountLabel.Visible = true;
                    catchCounter++;
                };
            }
        }

        if (catchCounter == 0 && errorCounter == 0 && IsValid)
        {
            //Show success label
            ChangedAccountLabel.Visible = true;

            //Refresh Listbox of usernames
            CurrentAcctsListBox.DataSourceID = "AccountsToBeEdittedSqlDataSource";
            CurrentAcctsListBox.DataTextField = "Username";
            CurrentAcctsListBox.DataValueField = "Username";
            CurrentAcctsListBox.DataBind();

            //Clear and disable new Username Textbox
            NewUsernameTextBox.Text = "";
            NewUsernameTextBox.Enabled = false;
            NewUsernameTextBox.BackColor = System.Drawing.Color.LightGray;

            //Disable and clear radiobuttons
            NewAccountTypeRadioButtonList.Enabled = false;
            foreach (ListItem item in NewAccountTypeRadioButtonList.Items)
            {
                item.Selected = false;
            }

            //Reset all labels
            UserNameLabel.Text = "--";
            CurrentAcctTypeLabel.Text = "--";
            UserNameErrorLabel.Visible = false;
            NewAcctTypeErrorLabel.Visible = false;
            InvalidPasswordLabel.Visible = false;

            //Reset username listbox
            CurrentAcctsListBox.SelectedIndex = -1;

            //Disable Save and change password button and password labels Button
            EditAccountFormButton.Enabled = false;

            //Disable Password Change
            CurrentPasswordTextBox.Enabled = false;
            CurrentPasswordTextBox.BackColor = System.Drawing.Color.LightGray;

            NewPasswordTextBox.Enabled = false;
            NewPasswordTextBox.BackColor = System.Drawing.Color.LightGray;

            ConfirmPasswordTextBox.Enabled = false;
            ConfirmPasswordTextBox.BackColor = System.Drawing.Color.LightGray;
        }
        
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        //Disable validators
        NewUsernameRequiredFieldValidator.Enabled = false;

        CurrentPasswordRequiredFieldValidator.Enabled = false;
        NewPasswordRequiredFieldValidator.Enabled = false;
        NewPasswordRegularExpressionValidator.Enabled = false;

        //Disable Password Change
        CurrentPasswordTextBox.Enabled = false;
        CurrentPasswordTextBox.BackColor = System.Drawing.Color.LightGray;

        NewPasswordTextBox.Enabled = false;
        NewPasswordTextBox.BackColor = System.Drawing.Color.LightGray;

        ConfirmPasswordTextBox.Enabled = false;
        ConfirmPasswordTextBox.BackColor = System.Drawing.Color.LightGray;

        //Clear and disable new Username Textbox
        NewUsernameTextBox.Text = "";
        NewUsernameTextBox.Enabled = false;
        NewUsernameTextBox.BackColor = System.Drawing.Color.LightGray;
        
        //Disable and clear radiobuttons
        NewAccountTypeRadioButtonList.Enabled = false;
        foreach (ListItem item in NewAccountTypeRadioButtonList.Items)
        {
            item.Selected = false;
        }
        
        //Reset all label
        UserNameLabel.Text = "--";
        CurrentAcctTypeLabel.Text = "--";
        UserNameErrorLabel.Visible = false;
        NewAcctTypeErrorLabel.Visible = false;
        InvalidPasswordLabel.Visible = false;

        //Reset username listbox
        CurrentAcctsListBox.SelectedIndex = -1;

        //Hide Success message
        ChangedAccountLabel.Visible = false;

        //Disable all buttons
        ChangePasswordButton.Enabled = false;
        EditAcctTypeButton.Enabled = false;
        EditUserNameButton.Enabled = false;
        EditAccountFormButton.Enabled = false;
    }
    protected void ChangePasswordButton_Click(object sender, EventArgs e)
    {
        if (CurrentAcctsListBox.SelectedIndex > -1)
        {
            EditAccountFormButton.Enabled = true;

            //Enable Validators 
            CurrentPasswordRequiredFieldValidator.Enabled = true;
            NewPasswordRequiredFieldValidator.Enabled = true;
            NewPasswordRegularExpressionValidator.Enabled = true;

            //Enable Password Change
            CurrentPasswordTextBox.Enabled = true;
            CurrentPasswordTextBox.BackColor = System.Drawing.Color.White;

            NewPasswordTextBox.Enabled = true;
            NewPasswordTextBox.BackColor = System.Drawing.Color.White;

            ConfirmPasswordTextBox.Enabled = true;
            ConfirmPasswordTextBox.BackColor = System.Drawing.Color.White;
        }
    }
}