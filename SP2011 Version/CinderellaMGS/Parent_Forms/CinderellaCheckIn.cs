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
     
    public partial class CinderellaCheckIn : Form
    {
        //Instantiate the sql class
        SQL_Queries sqlQuery = new SQL_Queries();
        //Creates the variable for the status to Get from the Cinderella table in database
        string statusToGet = "";
        //Creates the variable for the order of the Cinderella's
        string orderByGet = "";
        
        public CinderellaCheckIn()
        {
            InitializeComponent();
        }
        //sets the fonts and colors to the form and also the drop 
        //down menu style
        public void setFormStyle()
        {
            filterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BackColor = GlobalVar.FormBackColor;
            checkInButton.BackColor = GlobalVar.ButtonBackColor;
            sortByNameButton.BackColor = GlobalVar.ButtonBackColor;
            sortTimeButton.BackColor = GlobalVar.ButtonBackColor;
        }

        /// <summary>
        /// Retrieves all cinderellas with the current specified status.
        /// </summary>
        /// <param name="status">Status that you are checking for (ie. shopping, pending, etc)</param>
        /// <param name="order">How the data should be ordered (ie. lname)</param>
        public void populate(string status, string order)
        {
            //Gets the status passed to the class and gets all cinderellas with this status
            //Orders the cinderellas to the order that is passed to class
            DataSet dsA = sqlQuery.getCinderellaStatus(status, order);
            
            //Sets the name of the Cinderellas to be displayed into the checkInListBox
            //Sets cinderellaID to the value of each cinderella name in the checkInListBox
            this.checkInListBox.DisplayMember = "Name";
            this.checkInListBox.ValueMember = "CinderellaTimestamp.cinderellaID";
            this.checkInListBox.DataSource = dsA.Tables["tableName"];

            //Only Cinderellas that have a current status of "Pending" Should be able to be checked in
            if (status != "Pending")
            {
                checkInButton.Enabled = false;
            }
            else
            {
                //If Pending is selected then the checkIn button should be enabled
                //This way the user can checkIn cinderellas that are waiting to be checked in
                checkInButton.Enabled = true;
            }


        }

        /// <summary>
        /// Loads the CinderellaCheckIn_Form
        /// Calls the classes getStatuses, populate, and setFormStyle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CinderellaCheckIn_Load(object sender, EventArgs e)
        {
            //Gets the Statuses from the cinderella table
            getStatuses();
           
            //gives the populate class the status of the cinderella's to get('Pending')
            //gives the populate class the order by which the cinderella's should come back in('transID')
            populate("Pending", "transID");
            //sets the selected value of the statusComboBox to Pending since 
            //that is the Status which appears in the checkInListBox
            this.filterComboBox.SelectedValue = "Pending";
            
            //sets colors and styles of the form
            setFormStyle();

        }

        //Gets the Statuses that all of the Cinderella's can be
        public void getStatuses()
        {
            //Passes the keyword "getCinderellasStatuses" to the sqlSelect Statement in the 
            //SQL_Queries in the shared code 
            DataSet dsB = sqlQuery.sqlSelect("getCinderellaStatuses");
           
            //Enters in the ComboBox all the names of the Statuses the Cinderellas can get
            this.filterComboBox.DisplayMember = "statusTxt";
            this.filterComboBox.ValueMember = "statusName";
            this.filterComboBox.DataSource = dsB.Tables["tableName"];
          
           

        }

        /// <summary>
        /// Checks in The Cinderellas with the status of Pending
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkInButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Gets there ID from the List box so we know which Cinderella 
                //To change the status of Pending to Waiting
                string id = checkInListBox.SelectedValue.ToString();
                string status = "Waiting";

                //Now set the status of the Cinderella with the selected to Waiting 
                sqlQuery.setStatus(id, status, true, false);
            }
            catch
            {
                //Checks to see if there is a cinderella selected in the ListBox
                MessageBox.Show("Please Select Cinderella to be Checked-In, if there are no Cinderella's then please add one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            

            //Calls the populate method
            //Sets the statusToGet to the selected value in the statusComboBox
            //Orders the Cinderellas by their iD
            populate(statusToGet, "transID");
        }

        /// <summary>
        /// Filters the Cinderellas displayed in the ListBox by their Statuses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sets statusToGet to the selected status of the statusComboBox
            statusToGet = filterComboBox.SelectedValue.ToString();
            //Calls the populate method
            //Sets the statusToGet to the selected value in the statusComboBox
            //Orders the Cinderellas by their iD
            populate(statusToGet, "transID");
        }

        /// <summary>
        /// Closes the CinderellaCheckIn_Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //closes the form
            this.Close();
        }


        /// <summary>
        /// Sorts the Cinderellas displayed in the Listbox From A-Z
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortByNameButton_Click(object sender, EventArgs e)
        {
            //Sets orderByGet to the Name of the Cinderellas
            orderByGet = "Name";
            //Calls the populate method
            //Sets the statusToGet to the selected value in the statusComboBox
            //Orders the Cinderellas by their Name A-Z
            populate(statusToGet, orderByGet);

        }

        /// <summary>
        /// Sorts the Cinderellas displayed in the Listbox by their Appointment Date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortTimeButton_Click(object sender, EventArgs e)
        {
            //sets orderByGet to apptDate
            orderByGet = "apptDate";
            //Calls the populate method
            //Sets the statusToGet to the selected value in the statusComboBox
            //Orders the Cinderellas by their appointment dates
            populate(statusToGet, orderByGet);
        }

        /// <summary>
        /// Opens and enables the About Form of The Cinderella's Closet Project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //disables the CinderellaCheckIn_Form
            this.Enabled = false;
            //Calls the About Form
            AboutBox aboutBoxForm = new AboutBox();
            //Shows the About Form
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }

        private void addGodmotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addGodmotherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Opens and enables the AddCinderellaForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addGodmotherToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddCinderella addCinderellaForm = new AddCinderella();
            //this.Hide();
            //Disables the Cinderlla CheckIN_Form
            this.Enabled = false;
            //Shows the AddCinderella_Form
            addCinderellaForm.ShowDialog();
            //this.Show();
            //Calls the populate method
            //Sets the statusToGet to the selected value in the statusComboBox
            //Orders the Cinderellas by their iD
            populate(statusToGet, "transID");
            this.Enabled = true;
        }

        /// <summary>
        /// Closes the CinderellaCheckIn_Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Closes the CinderellaCheckIn_Form
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox aboutBoxForm = new AboutBox();
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }

      

      

      

       

      

       

      

       
    }
}
