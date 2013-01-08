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
    public partial class ManageGodmothers : Form
    {
        //Instantiate the sql class
        SQL_Queries sqlQuery = new SQL_Queries();

        public ManageGodmothers()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Binds all of the forms list boxes to datasources and saves the currently selected value for each control before refreshing.
        /// </summary>
        public void populateControls()
        {
            endShiftToolStripMenuItem.Enabled = true;
            bool filterToday = false;
            if (showAllGodmothersToolStripMenuItem.Checked)
            {
                filterToday = false;
            }
            //save the selected index's
            int activeLBIndex = activeLB.SelectedIndex;
            int inactiveLBIndex = inactiveLB.SelectedIndex;
            int godmotherLBIndex = godmotherLB.SelectedIndex;
            int cinderellaLBIndex = cinderellaLB.SelectedIndex;

            //Get data for the active control
            DataSet availableDS = sqlQuery.getGodmotherStatus("Available", "transID", filterToday);

            //FairyGodmotherTimestamp.fairyGodmotherID, n.Name,
            this.activeLB.DisplayMember = "Name";
            this.activeLB.ValueMember = "FairyGodmotherTimestamp.fairyGodmotherID";
            this.activeLB.DataSource = availableDS.Tables["tableName"];
            
            //get data for the inactive control
            DataSet unavailableDS = sqlQuery.getGodmotherStatus("Unavailable", "transID", filterToday);

            this.inactiveLB.DisplayMember = "Name";
            this.inactiveLB.ValueMember = "FairyGodmotherTimestamp.fairyGodmotherID";
            this.inactiveLB.DataSource = unavailableDS.Tables["tableName"];

            DataSet currentlyShoppingDS = sqlQuery.getCurrentlyShopping();
            this.currentlyShoppingLB.DisplayMember = "PairName";
            this.currentlyShoppingLB.ValueMember = "PairName";
            this.currentlyShoppingLB.DataSource = currentlyShoppingDS.Tables["tableName"];

            DataSet shoppingCinderellasDS = sqlQuery.getCinderellaStatus("Shopping", "transID");

            //Some error checking
            if (activeLB.Items.Count == 0)
            {
                makeInactiveButton.Enabled = false;
            }
            else
            {
                makeInactiveButton.Enabled = true;
            }

            if (inactiveLB.Items.Count == 0)
            {
                makeActiveButton.Enabled = false;
            }
            else
            {
                makeActiveButton.Enabled = true;
            }

            if (godmotherLB.Items.Count == 0)
            {
                //shopButton.Enabled = false;
            }
            else
            {
                shopButton.Enabled = true;
            }

            //Shopping Management Controls
            //Get data for the godmothers control
            DataSet dsA = sqlQuery.getGodmotherStatus("Paired", "transID", filterToday);

            this.godmotherLB.DisplayMember = "Name";
            this.godmotherLB.ValueMember = "FairyGodmotherTimestamp.fairyGodmotherID";
            this.godmotherLB.DataSource = dsA.Tables["tableName"];

            //get data for the inactive control
            DataSet dsB = sqlQuery.getCinderellaStatus("Paired", "transID");

            this.cinderellaLB.DisplayMember = "Name";
            this.cinderellaLB.ValueMember = "CinderellaTimestamp.cinderellaID";
            this.cinderellaLB.DataSource = dsB.Tables["tableName"];

            //Reassign the selected index's
            try
            {
                activeLB.SelectedIndex = activeLBIndex;
            }
            catch
            {
                activeLB.SelectedIndex = -1;
            }

            try
            {
                inactiveLB.SelectedIndex = inactiveLBIndex;
            }
            catch
            {
                inactiveLB.SelectedIndex = -1;
            }
            try
            {
                godmotherLB.SelectedIndex = godmotherLBIndex;
            }
            catch
            {
                godmotherLB.SelectedIndex = -1;
            }
            try
            {
                cinderellaLB.SelectedIndex = cinderellaLBIndex;
            }
            catch
            {
                cinderellaLB.SelectedIndex = -1;
            }
            //And last but certainly not least...
            //shoppingLB.SelectedIndex = -1;

            //Get the stats
            statsTB.Text = sqlQuery.getStats();

            //Resume layout
            activeLB.ResumeLayout();
            inactiveLB.ResumeLayout();
            godmotherLB.ResumeLayout();
            cinderellaLB.ResumeLayout();
        }
        /// <summary>
        /// Opens the add Godmother form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFairyGodmotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Godmother addForm = new Add_Godmother();
            //this.Hide();
            this.Enabled = false;
            addForm.ShowDialog();
            this.Enabled = true;

            //REFRESH!
            populateControls();
        }
        /// <summary>
        /// Opens the delete Godmother form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteFairyGodmotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_Godmother deleteForm = new Delete_Godmother();
            this.Hide();
            deleteForm.ShowDialog();
            this.Show();

            //REFRESH!
            populateControls();
        }
        /// <summary>
        /// Resets the selected index for all of the list box controls.
        /// </summary>
        private void resetIndex()
        {
            //Set some default
            activeLB.SelectedIndex = -1;
            inactiveLB.SelectedIndex = -1;
            //shoppingLB.SelectedIndex = -1;
            godmotherLB.SelectedIndex = -1;
            cinderellaLB.SelectedIndex = -1;
        }
        /// <summary>
        /// Retrieves the selected active godmother and makes them inactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void makeInactiveButton_Click(object sender, EventArgs e)
        {
            if (activeLB.SelectedIndex != -1)
            {
                string id = activeLB.SelectedValue.ToString();
                //string status = "Inactive";
                string status = "Unavailable";

                //Now set the status
                sqlQuery.setStatus(id, status, false, true);//Do not run matchmaker!

                //Reset index values
                resetIndex();

                //refresh controls
                populateControls();
            }
        }
        /// <summary>
        /// Retrieves the selected inactive godmother and makes them active.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void makeActiveButton_Click(object sender, EventArgs e)
        {
            if (inactiveLB.SelectedIndex != -1)
            {
                string id = inactiveLB.SelectedValue.ToString();
                //string status = "Active";
                string status = "Available";

                //Now set the status
                sqlQuery.setStatus(id, status, false, false);

                //Reset index values
                resetIndex();

                //refresh controls
                populateControls();
            }
        }
        /// <summary>
        /// Method should be run right before the first cinderellas and godmothers go shopping.  All of the available Godmothers are randomly paired with all of the available cinderellas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void randomizeStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is currently disabled.");

            ///
            ///I believe this method does work properly however due to time contraints this feature was temporarily disabled.
            ///


            /*var result = MessageBox.Show("Randomize start will make all unavailable Godmothers available and assign them to Waiting Cinderellas. It should only be run once per day." +  "\r\n" + "Are you sure you want to start the randomize process?", "Initiate Randomize Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //public void setShiftStartEnd(bool shiftStart, bool clear)
                sqlQuery.setShiftStartEnd(true, false);
                sqlQuery.setShiftStartEnd(false, true);
                //populateControls(); No longer needed. Will run at the end of this method

                //Get the set of Godmothers we can mess with
                DataSet tempGodmothers = sqlQuery.getGodmotherStatus("Unavailable", "transID", false);

                //Create the temp list
                List<string> godmotherList = new List<string>();
                List<string> godmotherCompletedList = new List<string>();

                //Assign Godmother ID's to the list
                foreach (DataRow dr in tempGodmothers.Tables[0].Rows)
                {
                    string tempString = (dr["fairyGodmotherID"].ToString());
                    godmotherList.Add(dr["fairyGodmotherID"].ToString());
                }


                //Now add them to the timestamp table randomly
                Random randNum = new Random();


                bool completed = false;
                bool found = false;

                while (completed == false)
                {
                    int index = randNum.Next(0, (godmotherList.Count()));

                    //Have we already added this record?
                    for (int i = 0; i < godmotherCompletedList.Count(); i++)
                    {
                        string tempIndex = index.ToString();
                        string tempCompleted = godmotherCompletedList[i];
                        if (tempIndex == tempCompleted)
                        {
                            //It is already added so skip
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        //Lets time stamp this!
                        string status = "Available";

                        //Now set the status
                        sqlQuery.setStatus(godmotherList[index].ToString(), status, false, true);//changed bool importrunning to true
                        godmotherCompletedList.Add(index.ToString());
                    }
                    else
                    {
                        found = false;
                    }

                    //Are we done yet?
                    if (godmotherCompletedList.Count() == godmotherList.Count())
                    {
                        completed = true;
                    }

                    //Update form controls
                    //populateControls(); //Actually I'm thinking no on this!
                }

                //Make the matches
                DataSet tempRandomGodMothers = sqlQuery.sqlSelect("getRandomGodmotherList");
                DataSet tempCinderellas = sqlQuery.getCinderellaStatus("Waiting", "transID");

                int counter = 0;

                //Determin what the max number of either cinderellas or Godmothers
                int maxGodmother = 0;
                int maxCinderella = 0;

                int max;
                foreach (DataRow dr in tempRandomGodMothers.Tables[0].Rows)
                {
                    maxGodmother++;
                }
                foreach (DataRow dr in tempCinderellas.Tables[0].Rows)
                {
                    maxCinderella++;
                }
                if (maxCinderella > maxGodmother)
                {
                    max = maxGodmother;
                }
                else
                {
                    max = maxCinderella;
                }


                for (int a = 0; a < max; a++)
                //foreach (DataRow dr in tempRandomGodMothers.Tables[0].Rows)
                {
                    //string tempGodmotherID = (dr["fairyGodmotherID"].ToString());
                    //Get a godmother
                    string tempGodmotherID = tempRandomGodMothers.Tables[0].Rows[counter]["fairyGodmotherID"].ToString();

                    //Lets get some Cinderellas Waiting to be paired
                    string tempCinderellaID = tempCinderellas.Tables[0].Rows[counter]["cinderellaID"].ToString();

                    //Execute the query
                    sqlQuery.insertPair(tempCinderellaID, tempGodmotherID);

                    //Insert a new status
                    string status = "Paired";
                    sqlQuery.setStatus(tempGodmotherID, status, false, true);
                    sqlQuery.setStatus(tempCinderellaID, status, true, true);

                    //Increment the counter
                    counter++;
                }
            }

            populateControls();
            shopButton.Enabled = true;*/
        }
        /// <summary>
        /// Timer component to insure the controls stay up to date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            populateControls();//NH
        }
        /// <summary>
        /// Sets the status of the selected Godmother and Cinderella to shopping.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shopButton_Click(object sender, EventArgs e)
        {
            //Make sure the user has selected a cinderella and a godmother
            if (godmotherLB.SelectedIndex != -1 && cinderellaLB.SelectedIndex != -1)
            {
                string godmotherID = godmotherLB.SelectedValue.ToString();
                string cinderellaID = cinderellaLB.SelectedValue.ToString();

                string godmotherStatus = "Shopping";
                string cinderellaStatus = "Shopping";

                //Add the pairing info to the table
                // sqlQuery.setPairing(godmotherID, cinderellaID);

                //update their timestamps
                sqlQuery.setStatus(godmotherID, godmotherStatus, false, true);
                sqlQuery.setStatus(cinderellaID, cinderellaStatus, true, true);

                //Reset index values
                resetIndex();

                //Refresh screen
                populateControls();
            }
            else
            {
                MessageBox.Show("Please select a Godmother and a Cinderella.");
                //outputLabel.Text = "Please select a Godmother and a Cinderella.";

                //Refresh screen
                populateControls();
            }
        }
        /// <summary>
        /// Initial form load. Starts the time component and sets some form styles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageGodmothers_Load(object sender, EventArgs e)
        {
            populateControls();
            this.BackColor = GlobalVar.FormBackColor;
            makeActiveButton.BackColor = GlobalVar.ButtonBackColor;
            makeInactiveButton.BackColor = GlobalVar.ButtonBackColor;
            shopButton.BackColor = GlobalVar.ButtonBackColor;
            //shoppingLB.Enabled = false;

            timer.Interval = GlobalVar.timerInterval;
            timer.Start();

            //Reset index values
            resetIndex();
        }
        /// <summary>
        /// Keeps the selected index of the cinderella and godmother listboxes the same.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cinderellaLB_Click(object sender, EventArgs e)
        {
            godmotherLB.SelectedIndex = cinderellaLB.SelectedIndex;
        }
        /// <summary>
        /// Keeps the selected index of the cinderella and godmother listboxes the same.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void godmotherLB_Click(object sender, EventArgs e)
        {
            cinderellaLB.SelectedIndex = godmotherLB.SelectedIndex;
        }
        /// <summary>
        /// Calls the populate controls method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showAllGodmothersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            populateControls();
        }
        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Displays the waiting area form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waitingAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Waiting_Area waitingArea = new Waiting_Area();
            waitingArea.Show();
        }
        /// <summary>
        /// Method currently not being used.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void godmotherCurrentlyShoppingLB_Click(object sender, EventArgs e)
        {
           // cinderellaCurrentlyShoppingLB.SelectedIndex = currentlyShoppingLB.SelectedIndex;
        }
        /// <summary>
        /// Method currently not being used.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cinderellaCurrentlyShoppingLB_Click(object sender, EventArgs e)
        {
            //currentlyShoppingLB.SelectedIndex = cinderellaCurrentlyShoppingLB.SelectedIndex;
        }
        /// <summary>
        /// Ends the current shift.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("All Unavailable Godmothers will be set to Pending.");
            /*//public void setShiftStartEnd(bool shiftStart, bool clear)
            sqlQuery.setShiftStartEnd(false, false);
            sqlQuery.setShiftStartEnd(true, true);
            populateControls();*/

            //Set all godmothers back to a status of pending
            sqlQuery.endShift();

            populateControls();
        }
        /// <summary>
        /// Displays the Godmother checkin form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void godmotherCheckinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GodmotherCheckin GodmotherCheckinForm = new GodmotherCheckin();
            //this.Hide();
            this.Enabled = false;
            GodmotherCheckinForm.ShowDialog();
            this.Enabled = true;

            //REFRESH!
            populateControls();
        }
        /// <summary>
        /// Displays the applications Global about box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox aboutBoxForm = new AboutBox();
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }
    }
}
