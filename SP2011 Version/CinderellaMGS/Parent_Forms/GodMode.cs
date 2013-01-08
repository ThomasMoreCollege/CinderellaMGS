using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
///<summary>
///This is a god mode of a quick management form
///It allows for quick simple changes in statuses
///It also allows for manual pairing
///<summary>
namespace CinderellaMGS
{
    public partial class GodMode : Form
    {
        public GodMode()
        {
            InitializeComponent();
        }
        //Allows access to the SQL_Queries Class
        SQL_Queries sqlQuery = new SQL_Queries();
        //Opens the about box from the menu strip
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox aboutBoxForm = new AboutBox();
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }
        //closes form
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void GodMode_Load(object sender, EventArgs e)
        {
            //fill combo boxes
            //Populate with cinderella statuses
            getCStatuses();
            //Populate with fairy godmother statuses
            getGMStatuses();
            //Populate with cinderella statuses
            getCStatuses1();
            //Populate with fairy godmother statuses
            getGMStatuses1();
            //
            //fill LBs
            //Populat ListBox with Availiable fairy godmothers
            popFGListForPairing();
            //Populat ListBox with Waiting Cinderellas
            popCListForPairing();
            //populate GodmotherStatusLB
            populateGodmotherStatusLB();
            //populate CinderellaStatusLB
            populateCinderellaStatusLB();
            //
            //stylings using set variables from the GlobalVar Class
            this.BackColor = GlobalVar.FormBackColor;
            this.Font = GlobalVar.LabelFont;
            pairButton.BackColor = GlobalVar.ButtonBackColor;
            setCStatusButton.BackColor = GlobalVar.ButtonBackColor;
            setFGStatusButton.BackColor = GlobalVar.ButtonBackColor;
            groupBox1.BackColor = GlobalVar.FormBackColor;
            groupBox2.BackColor = GlobalVar.FormBackColor;
            groupBox3.BackColor = GlobalVar.FormBackColor;
            groupBox5.BackColor = GlobalVar.FormBackColor;
            cinderellaLB.BackColor = GlobalVar.FormBackColor;
            cPairableLB.BackColor = GlobalVar.FormBackColor;
            fairyGodmotherLB.BackColor = GlobalVar.FormBackColor;
            fGPairableLB.BackColor = GlobalVar.FormBackColor;
        }
        //godmother
        private void fGFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when a status is selected only show godmothers with that status
            populateGodmotherStatusLB();
        }
        //cinderella 
        private void cFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when a status is selected only show cinderellas with that ststus
            populateCinderellaStatusLB();
        }
        //
        //
        //retreavse statuses of cinderellas
        public void getCStatuses()
        {
            //Cinderella
            //use query getCinderellaStatus from sql_queries class
            DataSet dsB = sqlQuery.sqlSelect("getCinderellaStatuses");
            //Set a display value for the combobox
            this.cFilterComboBox.DisplayMember = "statusTxt";
            //set values for combo box
            this.cFilterComboBox.ValueMember = "statusName";
            //set a datasource for the information in combobox
            this.cFilterComboBox.DataSource = dsB.Tables["tableName"];
        }
        public void getCStatuses1()
        {
            //Cinderella
            //use query getCinderellaStatus from sql_queries class
            DataSet dsB = sqlQuery.sqlSelect("getCinderellaStatuses");
            //Set a display value for the combobox
            this.cStatusComboBox.DisplayMember = "statusTxt";
            //set values for combo box
            this.cStatusComboBox.ValueMember = "statusName";
            //set a datasource for the information in combobox
            this.cStatusComboBox.DataSource = dsB.Tables["tableName"];  
        }
        public void getGMStatuses()
        {
            //Fairy Godmother
            //use query getCinderellaStatus from sql_queries class
            DataSet dsB = sqlQuery.sqlSelect("getGodmotherStatuses");
            //Set a display value for the combobox
            this.fGFilterComboBox.DisplayMember = "statusTxt";
            //set values for combo box
            this.fGFilterComboBox.ValueMember = "statusName";
            //set a datasource for the information in combobox
            this.fGFilterComboBox.DataSource = dsB.Tables["tableName"];
        }
         public void getGMStatuses1()
        {
            //Fair Godmother
            //use query getCinderellaStatus from sql_queries class
            DataSet dsB = sqlQuery.sqlSelect("getGodmotherStatuses");
            //Set a display value for the combobox
            this.fGStatusComboBox.DisplayMember = "statusTxt";
            //set values for combo box
            this.fGStatusComboBox.ValueMember = "statusName";
            //set a datasource for the information in combobox
            this.fGStatusComboBox.DataSource = dsB.Tables["tableName"];
        }
        //
        //
        //Populates the listbox for the Cinderella status changes
        public void populateCinderellaStatusLB()
        {
            //fill cinderella status list
            //creates a dataset using getgodmothers from sql_Queries class
            DataSet dsA = sqlQuery.sqlSelect("getCinderellas");
            //set a string with the value of the combo boxes selected value
            string filteredStatus = cFilterComboBox.SelectedValue.ToString();
            //filter LB based on filteredStatus
            DataSet dsCS = sqlQuery.getCinderellaStatus(filteredStatus, "Name");
            //Set LB txt to Name
            this.cinderellaLB.DisplayMember = "Name";
            //Set LB values to ID
            this.cinderellaLB.ValueMember = "cinderellaID";
            //Set data source for info
            this.cinderellaLB.DataSource = dsCS.Tables["tableName"];            
        }
        //Populates the listbox for the Godmother status changes
        public void populateGodmotherStatusLB()
        {
            //fill godmother status list
            //creates a dataset using getgodmothers from sql_Queries class
            DataSet dsA = sqlQuery.sqlSelect("getGodmothers");
            //set a string with the value of the combo boxes selected value
            string filteredStatus = fGFilterComboBox.SelectedValue.ToString();
            //filter LB based on filteredStatus
            DataSet dsFGS = sqlQuery.getGodmotherStatus(filteredStatus, "Name", false);
            //Set LB txt to Name
            this.fairyGodmotherLB.DisplayMember = "Name";
            //Set LB values to ID
            this.fairyGodmotherLB.ValueMember = "fairyGodmotherID";
            //Set data source for info
            this.fairyGodmotherLB.DataSource = dsFGS.Tables["tableName"];
        }
        //set god mother status
        private void setFGStatusButton_Click(object sender, EventArgs e)
        {
            //insures no crashes from clicking the button without selecting an item from combo boxes
                try
                {
                    //after click
                    //changes the status of selected FG
                    changeFGStatus();
                    //Refreshes GodmotherLB
                    populateGodmotherStatusLB();
                    //Refreshing Pairing lists
                    popFGListForPairing();
                }
                catch
                {
                }
        }
        //
        //
        public void changeFGStatus()
        {
            //Godmother
            //set paired status
            //set selectGM to the selected value in the combo box
            string selectedGM = fairyGodmotherLB.SelectedValue.ToString();
            //set changedStatus to the selected value in the combo box
            string changedStatus = fGStatusComboBox.SelectedValue.ToString();
            //Sets a status change to the given Godmother
            //uses the setStatus query in SQL_Queries
            sqlQuery.setStatus(selectedGM, changedStatus, false, true);
        }
       //set cinderella status
        private void setCStatusButton_Click(object sender, EventArgs e)
        {
            //insures no crashes from clicking the button without selecting an item from combo boxes
                try
                {
                    //after click
                    //changes the status of selected Cinderella
                    changeCStatus();
                    //Refreshes Cinderella LB
                    populateCinderellaStatusLB();
                    //Refreshing Pairing lists
                    popCListForPairing();
                }
                catch
                {
                }
        }
        public void changeCStatus()
        {
            //Cinderella
            //set paired status
            //set selectCinderella to the selected value in the combo box
            string selectedCinderella = cinderellaLB.SelectedValue.ToString();
            //set changedStatus to the selected value in the combo box
            string changedStatus = cStatusComboBox.SelectedValue.ToString();
            //Sets a status change to the given Cinderella
            //uses the setStatus query in SQL_Queries
            sqlQuery.setStatus(selectedCinderella, changedStatus, true, true);
        }
        //populate Godmother pairing LB
        public void popFGListForPairing()
        {
            //get a dataset gmds from query geyGodmotherStatus in SQL_Queries Class
            DataSet gmds = sqlQuery.getGodmotherStatus("Available", "transID", false);
            //set the txt to Name
            this.fGPairableLB.DisplayMember = "Name";
            //set values to ID
            this.fGPairableLB.ValueMember = "fairyGodmotherID";
            //Name a datasource
            this.fGPairableLB.DataSource = gmds.Tables["tableName"];
        }
        //populate Cinderella pairing LB
        public void popCListForPairing()
        {
            //get a dataset gmds from query geyCinderellaStatus in SQL_Queries Class
            DataSet cds = sqlQuery.getCinderellaStatus("Waiting", "transID");
            //set the txt to Name
            this.cPairableLB.DisplayMember = "Name";
            //set values to ID
            this.cPairableLB.ValueMember = "cinderellaID";
            //Name a datasource
            this.cPairableLB.DataSource = cds.Tables["tableName"];
        }
        //pair c and gm manually
        public void manualPairing()
        {
            //insures no crashes from clicking the button without selecting an item in each Pair LB
            try
            {
                string gmidTemp = fGPairableLB.SelectedValue.ToString();
                string cidTemp = cPairableLB.SelectedValue.ToString();
                //set paired status
                //Queries from SQL_Queries Class setStatus and setPairing
                //Set the selected Godmother to paired
                sqlQuery.setStatus(gmidTemp, "Paired", false, true);
                //Set the selected Cinderella to paired
                sqlQuery.setStatus(cidTemp, "Paired", true, true);
                //add pairings to paired table
                sqlQuery.setPairing(gmidTemp, cidTemp);
            }
            catch
            {
                //displays when an error happens
                label5.Text = "Select both a Fairy Godmother and a Cinderella to be paired!";
            }
        }
        //initiate pairing
        private void pairButton_Click(object sender, EventArgs e)
        {
            //clear error message
            label5.Text = "";
            //perform manualPairing method
            manualPairing();
            //Refreshes Godmother pairing LB
            popFGListForPairing();
            //Refreshes Cinderella pairing LB
            popCListForPairing();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox aboutBoxForm = new AboutBox();
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox aboutBoxForm = new AboutBox();
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }

    }
}
