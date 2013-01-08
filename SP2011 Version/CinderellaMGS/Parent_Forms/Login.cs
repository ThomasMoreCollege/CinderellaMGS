using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace CinderellaMGS
{
    public partial class Login : Form
    {
        UserAccounts Account = new UserAccounts();
        DatabaseIO Database = new DatabaseIO();
        SQL_Queries sqlQuery = new SQL_Queries();
        Utility.ModifyRegistry.ModifyRegistry myRegistry = new Utility.ModifyRegistry.ModifyRegistry();
        
        public Login()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            InitializeComponent();
            usernameTB.Focus();
            timeLabel.Text = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToShortTimeString();
            timer.Start();
        }
        /// <summary>
        /// Grabs the entered username and password and validates them against the credentials stored in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
                bool validLogin = false;
                //Get the username
                string username = usernameTB.Text;

                //get the password
                string password = Account.ProtectPassword(passwordTB.Text);
                //string password = passwordTB.Text;

                //Now check to see if they are valid
                DataSet ds = Account.getUserAccountRecord(username);

                if (ds.Tables["tableName"].Rows.Count == 0)
                {//Invalid Username
                    //Could this be a sever login??
                    if (username == sqlQuery.getGlobalizedSettings("serverUsername") && passwordTB.Text == sqlQuery.getGlobalizedSettings("serverPassword"))
                    {
                        ServerForm myForm = new ServerForm();
                        this.Hide();

                        //Update the timestamp
                        validLogin = false;
                        myForm.ShowDialog();
                        this.Show();
                        usernameTB.Clear();
                        passwordTB.Clear();
                        usernameTB.Focus();
                    }
                    else
                    {
                        MessageBox.Show("You have entered an invalid username.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        usernameTB.Clear();
                        passwordTB.Clear();
                        usernameTB.Focus();
                    }
                }
                else
                {//Valid Username so check password
                    //usernameTB.Text = ds.Tables[0].Rows[0]["loginName"].ToString();
                    string passwordInDB = ds.Tables[0].Rows[0]["password"].ToString();
                    if (password == passwordInDB)
                    {
                        validLogin = true;
                    }
                    else
                    {
                        MessageBox.Show("You have entered an invalid password.", "Invalid username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        usernameTB.Clear();
                        passwordTB.Clear();
                        usernameTB.Focus();
                    }
                }

                if (validLogin)
                {
                    Menu menuForm = new Menu(username);
                    this.Hide();

                    //Update the timestamp
                    Account.loginTimestamp(username);
                    validLogin = false;
                    menuForm.ShowDialog();
                    this.Show();
                    usernameTB.Clear();
                    passwordTB.Clear();
                    usernameTB.Focus();
                }
            }
        /// <summary>
        /// Timer Component to update the label containing the date and time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToShortTimeString();
        }
        /// <summary>
        /// Removes the existing connection string from the registry so that the user will be prompted to enter new server connection details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetBT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            myRegistry.DeleteKey("CinderellaMGS");
            MessageBox.Show("The server configuration has been reset.", "Configuration Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            usernameTB.Clear();
            passwordTB.Clear();
            usernameTB.Focus();
        }
    }
}
