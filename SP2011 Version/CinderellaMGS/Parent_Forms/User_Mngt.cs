using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinderellaMGS
{
    public partial class User_Mngt : Form
    {
        UserAccounts Account = new UserAccounts();
        bool insert = true;

        public User_Mngt()
        {
            InitializeComponent();
           populateControls();
           detailsGB.Visible = false;
           setFormStyle();
        }
        /// <summary>
        /// Sets the global styles for the form.
        /// </summary>
        public void setFormStyle()
        {
            //Form
            this.BackColor = GlobalVar.FormBackColor;

            //Buttons
            newButton.BackColor = GlobalVar.ButtonBackColor;
            editButton.BackColor = GlobalVar.ButtonBackColor;
            submitButton.BackColor = GlobalVar.ButtonBackColor;
            deleteButton.BackColor = GlobalVar.ButtonBackColor;
            cancelButton.BackColor = GlobalVar.ButtonBackColor;

            //Labels
            usernameLabel.Font = GlobalVar.LabelFont;
            fnameLabel.Font = GlobalVar.LabelFont;
            lnameLabel.Font = GlobalVar.LabelFont;
            passwordLabel.Font = GlobalVar.LabelFont;
            roleLabel.Font = GlobalVar.LabelFont;
            lastLoginLabel.Font = GlobalVar.LabelFont;
        }
        /// <summary>
        /// Binds the forms controls to a datasource.
        /// </summary>
        public void populateControls()
        {
            DataSet ds = Account.getUsers();     

            this.userLB.DisplayMember = "Name";
            this.userLB.ValueMember = "loginName";
            this.userLB.DataSource = ds.Tables["tableName"];

            this.userLB.SelectedIndex = -1;

            DataSet ds2 = Account.getRoles();

            this.rolesLB.DisplayMember = "TXT";
            this.rolesLB.ValueMember = "ID";
            this.rolesLB.DataSource = ds2.Tables["tableName"];

            
            this.rolesLB.SelectedIndex = -1;
        }
        /// <summary>
        /// Calls the editUser Method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, EventArgs e)
        {
            editUser();
        }
        /// <summary>
        /// Submits the new user or changes to an existing user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            selectButton.Visible = false;
            usernameTB.ReadOnly = true;
 
            //Gather the new info
            string username = usernameTB.Text;
            string password = passwordTB.Text;
            string fname = fnameTB.Text;
            string lname = lnameTB.Text;
            
            //Make the changes
            bool successfull = Account.editAccount(username, password, lname, fname, insert);

            //First delete any existing roles  :: public void add_delete_Roles(string username, string role, bool add)
            Account.add_delete_Roles(username, "", false);
            //Add the role(s)
            foreach (DataRowView objDataRowView in rolesLB.SelectedItems)
            {
                string tempRole = objDataRowView["ID"].ToString();
                Account.add_delete_Roles(username, tempRole, true);
                //Account.AddGodmotherShift(tempString, addedID);
                //shiftList.Add(tempString);
            }
            reset();
        }
        /// <summary>
        /// Calls the reset Method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            reset();    
        }
        /// <summary>
        /// Resets the controls on the form to their default state.
        /// </summary>
        public void reset()
        {
            usernameTB.Clear();
            passwordTB.Clear();
            lnameTB.Clear();
            fnameTB.Clear();
            lastLoginTB.Clear();

            newButton.Enabled = true;
            editButton.Enabled = true;
            usernameTB.ReadOnly = true;

            detailsGB.Visible = false;
            userLB.Visible = false;
            selectButton.Visible = false;

            populateControls();
        }
        /// <summary>
        /// Calls the newUser Method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newButton_Click(object sender, EventArgs e)
        {
            newUser();
        }
        /// <summary>
        /// Loads the information for the currently selected user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectButton_Click(object sender, EventArgs e)
        {
            DataSet ds;
                try
                {
                    //Get the selected user info
                    ds = Account.getUserAccountRecord(userLB.SelectedValue.ToString());

                    usernameTB.Text = ds.Tables[0].Rows[0]["loginName"].ToString();
                    passwordTB.Text = ds.Tables[0].Rows[0]["password"].ToString();
                    fnameTB.Text = ds.Tables[0].Rows[0]["firstName"].ToString();
                    lnameTB.Text = ds.Tables[0].Rows[0]["lastName"].ToString();
                    lastLoginTB.Text = ds.Tables[0].Rows[0]["lastLogin"].ToString();

                    //Enable the Controls
                    detailsGB.Visible = true;
                }
                catch
                {//This section is not finished :(
                }
        }
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            string username = usernameTB.Text;
            Account.deleteUser(username);

            MessageBox.Show("Account has been deleted.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
        }
        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Enables and disables the appropriate controls for a new user.
        /// </summary>
        public void newUser()
        {
            usernameTB.ReadOnly = false;
            editButton.Enabled = false;
            detailsGB.Visible = true;
            submitButton.Visible = true;
            cancelButton.Visible = true;

            insert = true;
        }
        /// <summary>
        /// Enables and disables the appropriate controls to edit a user.
        /// </summary>
        public void editUser()
        {
            newButton.Enabled = false;
            editButton.Enabled = false;
            userLB.Visible = true;
            submitButton.Visible = true;
            selectButton.Visible = true;
            cancelButton.Visible = true;

            insert = false;
        }
   }
}