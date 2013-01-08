using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CinderellaMGS
{
    public partial class AddCinderella : Form
    {
        //Instantiate some Classes
        SQL_Queries sqlQuery = new SQL_Queries();
        public AddCinderella()
        {
            InitializeComponent();
        }


        //This Resets all of the text boxes and date back to original settings
        //Is called at the end of addButton_Click
        private void resetForm()
        {
            
            lastNameTextBox.Clear();
            firstNameTextBox.Clear();
            apptDatePicker.Refresh();
            comboBox1.Refresh();
            idTextBox.Clear();
            referralTextBox.Clear();
            idTextBox.Focus();
            comboBox1.SelectedIndex = 0;
        }

        // <summary>
        //inserts the data that was entered into the form to the database table Cinderella
        // </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
           
                

            

            //Try/Catch block to make sure there is data in the form and it is formatted correctly
            try
            {
                //Initiating all of the variables for the form
                string lname = "";
                string fname = "";
                string date = "";
                string id = "";
                string referral = "";
                string newTime = "";
                //Gets the last cinderellaID from the cinderella table in the database
                string maxID = sqlQuery.getMaxCinderellaID();
                int compareMaxIDReal = Convert.ToInt16(maxID);
                //set lname to the text from the lastnameTextBox
                lname = lastNameTextBox.Text;
                //set fname to the text from the firstnameTextBox
                fname = firstNameTextBox.Text;
                //sets date to the date selected from the DatePicker
                date = apptDatePicker.Value.ToString("yyyy-MM-dd");
                //time = apptTimeTextBox.Text;
                newTime = Convert.ToDateTime(comboBox1.SelectedItem).ToLongTimeString();
                //Looks at the time comboBox to see if there is anything selected
                if (comboBox1.SelectedIndex == -1)
                {
                    //If nothing is selected show a message to the user to select a time
                    MessageBox.Show("Please select an appointment time", "Select Appointment Time", MessageBoxButtons.OK);
                    //sets the time comboBox to the first time selected
                    comboBox1.SelectedIndex = 0;

                }



                //sets id to the text in idTextBox
                id = idTextBox.Text;
                //converts the text from idTextbox to an integer
                int compareMaxIDUser = Convert.ToInt16(id);
                //compares the maxID from the cinderella table to the id entered by the user
                if (compareMaxIDUser <= compareMaxIDReal)
                {
                    //if the maxId from the cinderella table is less than or equal to
                    //the id entered by the user throw a message to saying to enter a
                    //higher number than the MaxID from the cinderella table
                    MessageBox.Show("Please Enter an id larger than " + compareMaxIDReal, "Error in ID", MessageBoxButtons.OK);
                }
                else
                {
                    //there doesn't have to be a referral but if there is this sets referral
                    //to the text entered in the referraltextBox
                    referral = referralTextBox.Text;
                    //checks to see anything was entered in to id, fname and lname
                    if (id == "" || fname == "" || lname == "")
                    {
                        //if there is nothing in these variables tell the user to enter information 
                        //in all of these text boxes
                        MessageBox.Show("You have to fill in all The Information into the boxes except for Referral Name to Add a Cinderella", "Enter all Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        //put all the variables into a string and send to 
                        //the sqlquery NewCinderella to be entered into the cinderella Table
                        string addedID = sqlQuery.NewCinderella(id, fname, lname, date, newTime, referral);

                        //set there status to Added so in the database we can see which
                        //cinderella's showed up at the event
                        string statusAdded = "Added";
                        //sets the status to Added, And tells the query it is a cinderella
                        sqlQuery.setStatus(addedID, statusAdded, true, false);

                        //Set their initial status to Pended
                        string statusPending = "Pending";
                        //sets the status to Pending, And tells the query it is a cinderella
                        sqlQuery.setStatus(addedID, statusPending, true, false);
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Error already has the ID", "Error!", MessageBoxButtons.OK);

            }
           

            //calls the reset which resets the form
                resetForm();
            
        }

        //sets the fonts and colors to the form and also the drop 
        //down menu style
        public void setFormStyle()
        {

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BackColor = GlobalVar.FormBackColor;
            addButton.BackColor = GlobalVar.ButtonBackColor;
            label1.Font = GlobalVar.LabelFont;
            label2.Font = GlobalVar.LabelFont;
            label3.Font = GlobalVar.LabelFont;
            label4.Font = GlobalVar.LabelFont;
            label5.Font = GlobalVar.LabelFont;
            label6.Font = GlobalVar.LabelFont;

        }

        // <summary>
        //calls the set form method which sets the style of the form
        //sets the focus to the idTextbox the firsttab index on the form
        //makes sure that there is something selected for the timeComboBox
        // </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
        private void AddCinderella_Load(object sender, EventArgs e)
        {
            setFormStyle();
            idTextBox.Focus();
            comboBox1.SelectedIndex = 0;
            

        }

        // <summary>
        //Closes the AddCinderella_Form
        // </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        // <summary>
        //Calls the AboutBox Form and disables the AddCinderella_Form
        // </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox aboutBoxForm = new AboutBox();
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }

       
    }
}
