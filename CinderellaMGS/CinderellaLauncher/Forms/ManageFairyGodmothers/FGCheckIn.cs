using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinderellaLauncher;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Diagnostics;


namespace CinderellaLauncher
{
    /*FGCheckIn.cs
     * 
     * -The user is able to search for a fairy godmother by first or last name or both
     * to search for a particular fairy godmother to check-in to the system or they can
     * select from the list of all the fairy godmothers to check-in to the system.
     * -The user can also view the fairy godmother's by shift and they can change the
     * role the fairy godmother will perform for the particular shift selected. 
     * 
     * -Input: 
     *      -If using the search section to find a name, then the user must enter either 
     *       the first or last names or both
     *       
     * -Output: None
     * 
     * -Precondition:
     *      -Fairy Godmother must be selected
     * 
     * -Postcondition:
     *      -Fairy Godmothers' status is changed in the database
     *      -Fairy Godmothers' role, if changed, is changed in the database
     *      
     */ 
    public partial class FGCheckIn : Form
    {
        bool isResized = false;
        int orgWidth = 910; // Original Width 
        int orgHeight = 550; // Original Height
        int expWidth = 1250; // Expanded width

        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        SQL_Queries query = new SQL_Queries();

        private BindingSource fgDGVBindingSource = new BindingSource();
        private SqlDataAdapter fgDGVDataAdapter;
        //private SqlCommandBuilder fgDGVSqlCommandBuilder;
        private DataTable fgDGVDataTable;
        private SqlCommand updateCommand;

        private string firstName = "";
        private string lastName = "";
        private string address = "";
        private string state = "";
        private string city = "";
        private string zip = "";
        private string phone = "";
        private string email = "";

        // Determines whether they work during the indicated shift
        private bool worksFriPM = false;
        private bool worksSatAM = false;
        private bool worksSatPM = false;

        // Role for shift if they work then
        private string friPMRoleID = "0";
        private string satAMRoleID = "0";
        private string satPMRoleID = "0";

        // Used for shift/role determination 
        DataTable shiftInfo;
        SqlDataAdapter da;
        public static int rows = 1;
        public static int columns = 0;
        public static float yPos = 60;
        public static float yPos2 = 60;

        public FGCheckIn()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(search_KeyUp);

            this.shiftComboBox.SelectedIndex = 0;

            
        }

        void search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                refreshButtonFGCheckIn.PerformClick();
            }
        }

      /*  public void refreshMe()
        {
            // Refresh DGV
            SqlCommand searchCommand = new SqlCommand(query.fgListStatus("1"));
            fgDGVBindingSource.EndEdit();
            fgDGVDataTable.Clear();

            fgDGVDataAdapter.SelectCommand = searchCommand;
            fgDGVDataAdapter.SelectCommand.Connection = connection;

            fgDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            fgDGVDataAdapter.Fill(fgDGVDataTable);

            fgDGV.Refresh();
            fgDGV.ClearSelection();
        }*/

        private void fgDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                // Grab the values from the cells of the selected row in the grid view.
                string u_id = fgDGV[0, e.RowIndex].Value.ToString();
                string u_firstName = fgDGV[1, e.RowIndex].Value.ToString();
                string u_lastName = fgDGV[2, e.RowIndex].Value.ToString();
                string u_emailAddress = fgDGV[3, e.RowIndex].Value.ToString();
                string u_phoneNumber = fgDGV[4, e.RowIndex].Value.ToString();
                string u_city = fgDGV[5, e.RowIndex].Value.ToString();
                string u_state = fgDGV[6, e.RowIndex].Value.ToString();
                string u_zip = fgDGV[7, e.RowIndex].Value.ToString();
                string u_address = fgDGV[8, e.RowIndex].Value.ToString();


                // This sqlCommand object is created by passing it a string returned from SQL_Queries. First, the updateCinderella method is
                // called by passing it the attributes to be updated. It then returns a string which is a complete SQL statement, which is given
                // to the SqlCommand.
                updateCommand = new SqlCommand(query.updateFairyGodmother(u_id, u_firstName, u_lastName, u_emailAddress, u_phoneNumber, u_city, u_state, u_zip, u_address));

                // Assign custom update command to the dataAdapter. This is necessary when multiple tables are used in the select.
                fgDGVDataAdapter.UpdateCommand = updateCommand;

                // the updateCommand apparently needs a "connection"
                updateCommand.Connection = connection;

                // Force EndEdit on all rows so that this executes properly.
                // Call update method to commit to the DB.
                fgDGVBindingSource.EndEdit();
                fgDGVDataAdapter.Update(fgDGVDataTable);
            }
            catch (SqlException updateError)
            {
                MessageBox.Show("Editing currently not supported after using the search feature.\r\nPlease click refresh and find the desired person manually.");
            }
        }

        private void FGCheckin_Load(object sender, EventArgs e)
        {
            Thread update = new Thread(() => guiupdate(0));
            update.Start();
           // guiupdate();  
           
        }

        public void guiupdate(int shiftNo)
        {
            try
            {
               // while (true)
              //  {
                    fgDGV.Invoke(new Action(delegate()
                        {
                            fgDGV.DataSource = fgDGVBindingSource;
                        }));

                    if (shiftNo == 0)
                        fgDGVDataAdapter = new SqlDataAdapter(query.fgListStatus("1"), connection);
                    else
                        fgDGVDataAdapter = new SqlDataAdapter(query.fgListStatus("1",shiftNo.ToString()), connection);

                    //fgDGVSqlCommandBuilder = new SqlCommandBuilder(fgDGVDataAdapter);
                    fgDGVDataTable = new DataTable();
                    fgDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    fgDGVDataAdapter.Fill(fgDGVDataTable);

                    fgDGV.Invoke(new Action(delegate()
                        {
                            fgDGVBindingSource.DataSource = fgDGVDataTable;
                        }));

                    fgDGV.Invoke(new Action(delegate()
                    {
                        fgDGV.Columns[0].Visible = false;
                    }));


                    //fgDGV.Columns["id"].Visible = false;
                    //Thread.Sleep(5000);
             //   }
                // f1.datagridview1.Columns[0].Visible = false;
                    
                  
            }
            catch (Exception t)
            {
               // Thread.CurrentThread.Abort();
               // MessageBox.Show(t.ToString());
            }
        }

        private void shiftComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int shift = 0;

            string textShift = shiftComboBox.Text.ToString();

            if (textShift == "All Shifts")
            {
                shift = 0;
                tabControl1.SelectedIndex = 0;
            }
            else if (textShift == "Friday PM")
            {
                shift = 1;
                tabControl1.SelectedIndex = 0;
            }
            else if (textShift == "Saturday AM")
            {
                shift = 2;
                tabControl1.SelectedIndex = 1;
            }
            else if (textShift == "Saturday PM")
            {
                shift = 3;
                tabControl1.SelectedIndex = 2;
            }

            guiupdate(shift);

        }

        //Checks-in a fairy godmother to the system
        private void checkInButton_Click(object sender, EventArgs e)
        {
            try
            {
               // MessageBox.Show("FriPMRID: " + friPMRoleID + " - SatAMRID: " + satAMRoleID + " - SatPMRID " + satPMRoleID);
               // MessageBox.Show(worksFriPM.ToString() + worksSatAM.ToString() + worksSatPM.ToString());
                
               
                  string id = fgDGV.SelectedRows[0].Cells[0].Value.ToString();
               

                DateTime today = DateTime.Now;
                DateTime t1 = new DateTime(2013, 3, 15, 12, 0, 0);
                DateTime t2 = new DateTime(2013, 3, 16, 12, 0, 0);
                DateTime t3 = new DateTime(2013, 3, 16, 18, 0, 0);

                if (today.Date < t2)
                {

                    int role = query.ShiftWorkerRole(Convert.ToInt32(id), 1);
                    tabControl1.SelectedIndex = 0;
                    if (role == 3)
                    {
                        friPMRoleID = Convert.ToString(role);
                        friPMCheckInOutButton.Checked = true;
                    }
                    else if (role == 4)
                    {
                        friPMRoleID = Convert.ToString(role);
                        friPMPSButton.Checked = true;
                    }

                    else if (role == 5)
                    {
                        friPMRoleID = Convert.ToString(role);
                        friPMAlterationsButton.Checked = true;
                    }

                    else if (role == 6)
                    {
                        friPMRoleID = Convert.ToString(role);
                        friPMVolunteerButton.Checked = true;
                    }


                }

                
                
                
                else if (today.Date >= t2 && today.Date < t3)
                {

                    int role = query.ShiftWorkerRole(Convert.ToInt32(id), 2);
                    tabControl1.SelectedIndex = 1;
                    if (role == 3)
                    {
                        satAMRoleID = Convert.ToString(role);
                        satAMCheckInOutButton.Checked = true;
                    }
                    else if (role == 4)
                    {
                        satAMRoleID = Convert.ToString(role);
                        satAMPSButton.Checked = true;
                    }

                    else if (role == 5)
                    {
                        satAMRoleID = Convert.ToString(role);
                        satAMAlterationsButton.Checked = true;
                    }

                    else if (role == 6)
                    {
                        satAMRoleID = Convert.ToString(role);
                        satAMVolunteerButton.Checked = true;
                    }

                }

                    else if (today.Date >= t3)
                    {
                        
                    int role = query.ShiftWorkerRole(Convert.ToInt32(id), 2);
                    tabControl1.SelectedIndex = 2;
                    if (role == 3)
                    {
                        satPMRoleID = Convert.ToString(role);
                        satPMCheckInOutButton.Checked = true;
                    }
                    else if (role == 4)
                    {
                        satPMRoleID = Convert.ToString(role);
                        satPMPSButton.Checked = true;
                    }

                    else if (role == 5)
                    {
                        satPMRoleID = Convert.ToString(role);
                        satPMAlterationsButton.Checked = true;
                    }

                    else if (role == 6)
                    {
                        satPMRoleID = Convert.ToString(role);
                        satPMVolunteerButton.Checked = true;
                    }



                    




                }

                
                if(Convert.ToInt32(friPMRoleID) > 0 || Convert.ToInt32(satAMRoleID) > 0 || Convert.ToInt32(satPMRoleID) > 0)
                {

                    // Get ID of the fairygodmother in the currently selected row of gridview
                  
                       
                    
                    

                    if (worksFriPM)
                    {
                        query.AddGodmotherShift(id, "1", friPMRoleID);
                    }
                    if (worksSatAM)
                    {
                        query.AddGodmotherShift(id, "2", satAMRoleID);
                    }
                    if (worksSatPM)
                    {
                        query.AddGodmotherShift(id, "3", satPMRoleID);                  
                    }


                    query.setFGStatus(id, 4);


                    // Refresh DGV
                    SqlCommand searchCommand = new SqlCommand(query.fgListStatus("1"));
                    fgDGVBindingSource.EndEdit();
                    fgDGVDataTable.Clear();

                    fgDGVDataAdapter.SelectCommand = searchCommand;
                    fgDGVDataAdapter.SelectCommand.Connection = connection;

                    fgDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    fgDGVDataAdapter.Fill(fgDGVDataTable);

                    fgDGV.Refresh();
                    fgDGV.ClearSelection();
                  //  fgDGV.AutoResizeColumns();
                }
                else
                    MessageBox.Show("You must select a role");
            }
            catch (ArgumentOutOfRangeException noSelection)
            {
                MessageBox.Show("You must select someone.");
            }
            
        }

        private void fgDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            // All of this takes care of the automatic role and shift selection.
            if (e.RowIndex > -1)
            {
                // Get the fg's ID
                string fgID = fgDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
               

                // Construct and fill a datatable of the fg's shifts and roles
                shiftInfo = new DataTable();
                da = new SqlDataAdapter( query.getFGShiftInfo(fgID), connection);
                da.Fill(shiftInfo);


                // <----- BEGIN RESET OF VALUES
                worksFriPM = false;
                worksSatAM = false;
                worksSatPM = false;
                friPMRoleID = "0";
                satAMRoleID = "0";
                satPMRoleID = "0";

                friPMCheckInOutButton.Checked = false;
                friPMPSButton.Checked = false;
                friPMAlterationsButton.Checked = false;
                friPMVolunteerButton.Checked = false;

                satAMCheckInOutButton.Checked = false;
                satAMPSButton.Checked = false;
                satAMAlterationsButton.Checked = false;
                satAMVolunteerButton.Checked = false;

                satPMCheckInOutButton.Checked = false;
                satPMPSButton.Checked = false;
                satPMAlterationsButton.Checked = false;
                satPMVolunteerButton.Checked = false;

                // END RESET OF VALUES ----->

                // Parse through the datatable and set values appropriately.
                // Get a row, check its shiftID, set the appropriate boolean and role value
                foreach (DataRow row in shiftInfo.Rows)
                {
                    if (row["shiftID"].ToString() == "1")
                    {
                        worksFriPM = true;
                        friPMRoleID = row["roleID"].ToString();
                    }
                    else if (row["shiftID"].ToString() == "2")
                    {
                        worksSatAM = true;
                        satAMRoleID = row["roleID"].ToString();
                    }
                    else if (row["shiftID"].ToString() == "3")
                    {
                        worksSatPM = true;
                        satPMRoleID = row["roleID"].ToString();
                    }

                }

                

                // These switches take care of checking the correct radio buttons.
                if (worksFriPM)
                {
                    int foo = Convert.ToInt32(friPMRoleID);

                    switch (foo)
                    {
                        case 1:
                            break;
                        case 2:
                            friPMCheckInOutButton.Checked = true;
                            break;
                        case 3:
                            friPMCheckInOutButton.Checked = true;
                            break;
                        case 4:
                            friPMPSButton.Checked = true;
                            break;
                        case 5:
                            friPMAlterationsButton.Checked = true;
                            break;
                        case 6:
                            friPMVolunteerButton.Checked = true;
                            break;

                        default:
                            MessageBox.Show("Huh?");
                            break;
                    }
                    
                }

                if (worksSatAM)
                {
                    int foo = Convert.ToInt32(satAMRoleID);

                    switch (foo)
                    {
                        case 1:
                            break;
                        case 2:
                            satAMCheckInOutButton.Checked = true;
                            break;
                        case 3:
                            satAMCheckInOutButton.Checked = true;
                            break;
                        case 4:
                            satAMPSButton.Checked = true;
                            break;
                        case 5:
                            satAMAlterationsButton.Checked = true;
                            break;
                        case 6:
                            satAMVolunteerButton.Checked = true;
                            break;

                        default:
                            MessageBox.Show("Huh?");
                            break;
                    }
                }
                if (worksSatPM)
                {
                    int foo = Convert.ToInt32(satPMRoleID);

                    switch (foo)
                    {
                        case 1:
                            break;
                        case 2:
                            satPMCheckInOutButton.Checked = true;
                            break;
                        case 3:
                            satPMCheckInOutButton.Checked = true;
                            break;
                        case 4:
                            satPMPSButton.Checked = true;
                            break;
                        case 5:
                            satPMAlterationsButton.Checked = true;
                            break;
                        case 6:
                            satPMVolunteerButton.Checked = true;
                            break;

                        default:
                            MessageBox.Show("Huh?");
                            break;
                    }
                }
            }
        }

        //Adds a new fairy godmother and their information into the database
        private void addButton_Click(object sender, EventArgs e)
        {
           
        }

        private void undoCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread undoCheckIn = new Thread(() => Application.Run(new UndoCheckIn()));
            undoCheckIn.Start();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chatNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Thread> FormThreads = new List<Thread>();//keeps track of form threads for latter termination

            //this is where the threading of the online chat will prompt
            Thread FGcheckinChat = new Thread(() => Application.Run(new ClientApp()));
            FGcheckinChat.Name = "chat";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "chat")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("Chat window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FGcheckinChat.Start();
                FormThreads.Add(FGcheckinChat);//adds the thread to the list
            }
        }

        //Searches for the fairy godmother by the first name, last name, or both that are entered into the text boxes
        private void searchButton_Click(object sender, EventArgs e)
        {
            string fname = firstNameBox.Text;
            string lname = lastNameBox.Text;

            SqlCommand searchCommand = new SqlCommand(query.fglistSearch(firstNameBox.Text, lastNameBox.Text));

            fgDGVBindingSource.EndEdit();
            fgDGVDataTable.Clear();

            fgDGVDataAdapter.SelectCommand = searchCommand;
            fgDGVDataAdapter.SelectCommand.Connection = connection;

            fgDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            fgDGVDataAdapter.Fill(fgDGVDataTable);

            fgDGV.Refresh();
            fgDGV.ClearSelection();
            //searchDGV.AutoResizeColumns();
        }

        // FRIDAY PM BUTTONS
        private void friPMCheckInOutButton_Click(object sender, EventArgs e)
        {
            worksFriPM = true;
            friPMRoleID = "3";
        }

        private void friPMPSButton_Click(object sender, EventArgs e)
        {
            worksFriPM = true;
            friPMRoleID = "4";
        }

        private void friPMAlterationsButton_Click(object sender, EventArgs e)
        {
            worksFriPM = true;
            friPMRoleID = "5";
        }

        private void friPMVolunteerButton_Click(object sender, EventArgs e)
        {
            worksFriPM = true;
            friPMRoleID = "6";
        }

        // SATURDAY AM BUTTONS
        private void satAMCheckInOutButton_Click(object sender, EventArgs e)
        {
            worksSatAM = true;
            satAMRoleID = "3";
        }

        private void satAMPSButton_Click(object sender, EventArgs e)
        {
            worksSatAM = true;
            satAMRoleID = "4";
        }

        private void satAMVolunteerButton_Click(object sender, EventArgs e)
        {
            worksSatAM = true;
            satAMRoleID = "5";
        }

        private void satAMAlterationsButton_Click(object sender, EventArgs e)
        {
            worksSatAM = true;
            satAMRoleID = "6";
        }

        // SATURDAY PM BUTTONS
        private void satPMCheckInOutButton_Click(object sender, EventArgs e)
        {
            worksSatPM = true;
            satPMRoleID = "3";
        }

        private void satPMPSButton_Click(object sender, EventArgs e)
        {
            worksSatPM = true;
            satPMRoleID = "4";
        }

        private void satPMAlterationsButton_Click(object sender, EventArgs e)
        {
            worksSatPM = true;
            satPMRoleID = "5";
        }

        private void satPMVolunteerButton_Click(object sender, EventArgs e)
        {
            worksSatPM = true;
            satPMRoleID = "6";
        }

        private void refreshButtonFGCheckIn_Click(object sender, EventArgs e)
        {
            guiupdate(0);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoCheckInToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Thread undoCheck = new Thread(() => Application.Run(new UndoCheckIn()));
            undoCheck.Start();
        }

        private void clearButton1_Click(object sender, EventArgs e)
        {
            worksFriPM = false;
            friPMRoleID = "0";         
            
            friPMCheckInOutButton.Checked = false;
            friPMPSButton.Checked = false;
            friPMAlterationsButton.Checked = false;
            friPMVolunteerButton.Checked = false;
            
        }

        private void clearButton2_Click(object sender, EventArgs e)
        {
            worksSatAM = false;
            satAMRoleID = "0";

            satAMCheckInOutButton.Checked = false;
            satAMPSButton.Checked = false;
            satAMAlterationsButton.Checked = false;
            satAMVolunteerButton.Checked = false;
        }

        private void clearButton3_Click(object sender, EventArgs e)
        {
            worksSatPM = false;
            satPMRoleID = "0";

            satPMCheckInOutButton.Checked = false;
            satPMPSButton.Checked = false;
            satPMAlterationsButton.Checked = false;
            satPMVolunteerButton.Checked = false;
        }

        private void addFairyGodmotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addColumns();

            Thread addFairyGodmother = new Thread(() => Application.Run(new AddFairyGodmother()));
            addFairyGodmother.Start();
        }
        
        public static void addColumns()
        {
            if (columns == 3)
            {
                addRows();
                columns = 1;
            }


            else
            {
                ++columns;
            }
        }

        public static int countColumns()
        {
            return columns;
        }
        public static void addRows()
        {
            if (rows == 10)
                rows = 1;
            else
                ++rows;
        }

        public static int countRows()
        {
            return rows;
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thread aboutThread = new Thread(() => Application.Run(new About()));
            aboutThread.Start();
        }

        private void userManualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("C:\\CinderellaMGS\\cinderellamgs\\CinderellaMGS\\Documentation\\Help\\UserManual.pdf"))
            {
                Process.Start("C:\\CinderellaMGS\\cinderellamgs\\CinderellaMGS\\Documentation\\Help\\UserManual.pdf");
                return;
            }
            if (System.IO.File.Exists("..\\..\\..\\Documentation\\Help\\UserManual.pdf"))
            {
                Process.Start("..\\..\\..\\Documentation\\Help\\UserManual.pdf");
                return;
            }
            MessageBox.Show("File: C:\\CinderellaMGS\\cinderellamgs\\CinderellaMGS\\Documentation\\Help\\UserManual.pdf   Does Not Exist.");
        }
        //Barcode scanns and checks in FairyGodmother Error checking needed yet
        private void BarcodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                {
                    //try
                    //{
                        // MessageBox.Show("FriPMRID: " + friPMRoleID + " - SatAMRID: " + satAMRoleID + " - SatPMRID " + satPMRoleID);
                        // MessageBox.Show(worksFriPM.ToString() + worksSatAM.ToString() + worksSatPM.ToString());
                        if (Convert.ToInt32(friPMRoleID) > 0 || Convert.ToInt32(satAMRoleID) > 0 || Convert.ToInt32(satPMRoleID) > 0)
                        {

                            // Get ID of the fairygodmother From the textbox
                            string id = BarcodeTextBox.Text;
                            BarcodeTextBox.Text = "";



                            if (worksFriPM)
                            {
                                query.AddGodmotherShift(id, "1", friPMRoleID);
                            }
                            if (worksSatAM)
                            {
                                query.AddGodmotherShift(id, "2", satAMRoleID);
                            }
                            if (worksSatPM)
                            {
                                query.AddGodmotherShift(id, "3", satPMRoleID);
                            }


                            query.setFGStatus(id, 4);


                            // Refresh DGV
                            SqlCommand searchCommand = new SqlCommand(query.fgListStatus("1"));
                            fgDGVBindingSource.EndEdit();
                            fgDGVDataTable.Clear();

                            fgDGVDataAdapter.SelectCommand = searchCommand;
                            fgDGVDataAdapter.SelectCommand.Connection = connection;

                            fgDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                            fgDGVDataAdapter.Fill(fgDGVDataTable);

                            fgDGV.Refresh();
                            fgDGV.ClearSelection();
                            //  fgDGV.AutoResizeColumns();
                        }
                        else
                            MessageBox.Show("You must select a role");
                  //  }
                //    catch (ArgumentOutOfRangeException noSelection)
                   // {
                    //    MessageBox.Show("You must select someone.");
                   // }

                }
            }
        }

        private void fairyGodmotherCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread FGCheckInBarcode = new Thread(() => Application.Run(new FGCheckInBarcode()));
            FGCheckInBarcode.Start();
        }

        public static float nextYposition()
        {
            return yPos;
        }
    }
}
