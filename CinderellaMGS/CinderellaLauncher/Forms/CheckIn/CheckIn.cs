using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinderellaLauncher;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
// http://www.switchonthecode.com/tutorials/csharp-tutorial-binding-a-datagridview-to-a-database


namespace CinderellaLauncher
{
    /*CheckIn.cs
     * 
     * -The user is able to check-in cinderella's and can search for their name by using
     * the search function on the form (entering first name, last name, organization, or
     * all three or by searching the list until the name is visible
     * 
     * -Input:
     *      -If using the search function either the first name, last name, organization,
     *      or all three need to be entered into the correct textboxes
     * 
     * -Output:
     *      -If the person is early or late by more than an hour, a message box appears 
     *      alerting the user that the selected cinderella is early of late by more than
     *      an hour
     *      
     * -Precondition:
     *      -A cinderella must be selected
     * 
     * -Postcondition:
     *      -The Cinderella's status is changed in the database
     * 
     */
    public partial class CheckIn : Form
    {
        List<Thread> FormThreads = new List<Thread>();//keeps track of form threads for latter termination
        
        static SQL_Queries query = new SQL_Queries();


        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        private BindingSource searchDGVBindingSource = new BindingSource();
        private DataTable searchDGVDataTable;
        private SqlDataAdapter searchDGVDataAdapter;  
        private SqlCommand updateCommand;
       
       

        public CheckIn()
        {
            InitializeComponent();
            lastNameBox.Focus();
       
            this.KeyPreview = true;

            this.KeyUp += new KeyEventHandler(search_KeyUp);
        
        }

        void search_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                refreshButtonCheckIn.PerformClick();
            }
        }
        
        private void CheckIn_Load(object sender, EventArgs e)
        {
         //   lastNameBox.Focus();
            Thread getData = new Thread(() => fillTable());
          
            getData.Start();
           // searchDGV_CellContentClick(searchDGV, new DataGridViewCellEventArgs(0, 0));
           
           
            

        }

      
        public void fillTable()
        {
            
            try
            {
               
            //    while (true)
            //    {
                    searchDGVDataTable = new DataTable();
                  
                    // Give the DGV a datasource
                    searchDGV.Invoke(new Action(delegate()
                        {
                            searchDGV.DataSource = searchDGVBindingSource;
                           
                        }));

                    // Give the dataAdapter a select query and connection string
                    searchDGVDataAdapter = new SqlDataAdapter(query.checkInList(), connection);
                   

                    // Not sure yet ...
                    searchDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;

                    // Fill the dataTable from the dataAdapter
                    searchDGVDataAdapter.Fill(searchDGVDataTable);
                  //  searchDGV.Columns[0].Visible = false;
                    

                    // Make the datasource for the binding data source the data table
                    searchDGV.Invoke(new Action(delegate()
                       {
                           searchDGVBindingSource.DataSource = searchDGVDataTable;

                           searchDGV.ClearSelection();
                       }));
                    //  searchDGV.AutoResizeColumns();
               //     Thread.Sleep(5000);
             //   }
                    
            }
                
            catch (Exception e)
            {

                Thread.CurrentThread.Abort();
                
            }
          //  searchDGV_CellContentClick(searchDGV, new DataGridViewCellEventArgs(0, 0));
           
           
            //end invoke?
          //  lastNameBox.Focus();
        }

        private void checkInButton_Click(object sender, EventArgs e)
        {
            // 3:date, 4:time
            if (searchDGV.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select someone");
                return;
            }
            string id = searchDGV.SelectedRows[0].Cells[0].Value.ToString();
            string currentTime = searchDGV.SelectedRows[0].Cells[4].Value.ToString();


            DateTime now = DateTime.Now;
            DateTime cT = Convert.ToDateTime(currentTime);
            int foo = DateTime.Compare(now, cT);

            // This person is late for their appointment
            if (foo > 0)
            {
               
                long diff = now.Ticks - cT.Ticks;
                TimeSpan span = TimeSpan.FromTicks(diff);

                int offBy = span.Hours;

                if (offBy >= 1)
                {
                    // Ask if user wants to checkin as is, change the appt time, or wait.
                    MessageBox.Show("Person is one or more hours late");
                }

                finishCheckIn(id);
              

            }
            // This person is early for their appointment
            else if (foo < 0)
            {
               
                long diff = cT.Ticks - now.Ticks;
                TimeSpan span = TimeSpan.FromTicks(diff);
                int offBy = span.Hours;

                if (offBy >= 1)
                {
                    // Ask if user wants to checkin as is, change the appt time, or wait.
                    MessageBox.Show("Person is one or more hours early");
                }

                finishCheckIn(id);
            }
            // This person is EXACTLY on time. This will probably not happen.
            else
            {
                finishCheckIn(id);

            }
       
        }

        private void finishCheckIn(string id)
        {
            query.setCinderellaStatus(id, 2);

            searchDGVBindingSource.EndEdit();
            searchDGVDataTable.Clear();
            searchDGVDataAdapter.Fill(searchDGVDataTable);
            searchDGV.Refresh();
        }

        private void addCinderellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread addCinderella = new Thread(() => Application.Run(new AddCinderella()));
            addCinderella.Start();
            //AddCinderella add = new AddCinderella();
            //add.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread login2 = new Thread(() => Application.Run(new Login()));
            login2.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Grab the values from the cells of the selected row in the grid view.
            int id = Convert.ToInt32(searchDGV[0,e.RowIndex].Value);
            string firstName = searchDGV[1,e.RowIndex].Value.ToString();
            string lastName = searchDGV[2, e.RowIndex].Value.ToString();
            string apptDate = searchDGV[3, e.RowIndex].Value.ToString();
            string apptTime = searchDGV[4, e.RowIndex].Value.ToString();

            // This sqlCommand object is created by passing it a string returned from SQL_Queries. First, the updateCinderella method is
            // called by passing it the attributes to be updated. It then returns a string which is a complete SQL statement, which is given
            // to the SqlCommand.
            updateCommand = new SqlCommand(query.updateCinderella(id, firstName, lastName, apptDate, apptTime));

            // Assign custom update command to the dataAdapter. This is necessary when multiple tables are used in the select.
            searchDGVDataAdapter.UpdateCommand = updateCommand;

            // the updateCommand apparently needs a "connection"
            updateCommand.Connection = connection;
            
            // Force EndEdit on all rows so that this executes properly.
            // Call update method to commit to the DB.
            searchDGVBindingSource.EndEdit();
            searchDGVDataAdapter.Update(searchDGVDataTable);
        }

        private void changeAppointmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = searchDGV.SelectedRows[0].Cells[0].Value.ToString();

                Thread changeApptTime = new Thread(() => Application.Run(new changeAppointmentTime(id)));
                changeApptTime.Name = "capt";
                
                bool found = false;
                foreach (Thread forms in FormThreads)
                {
                    if (forms.Name == "capt")
                    {
                        if (forms.IsAlive)
                        {
                            found = true;
                        }
                    }
                }
                if (found)//prevents someone from having multiple copies of the same window open
                {
                    MessageBox.Show("Change Appointment Time window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    changeApptTime.Start();
                    FormThreads.Add(changeApptTime);//adds the thread to the list
                }


            }
            catch(Exception f)
            {
                MessageBox.Show("Please select someone");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string fname = firstNameBox.Text;
            string lname = lastNameBox.Text;
            string org = organizationTextBox.Text;

            SqlCommand searchCommand = new SqlCommand(query.CheckInSearch(firstNameBox.Text, lastNameBox.Text, organizationTextBox.Text));
            searchDGVBindingSource.EndEdit();
            searchDGVDataTable.Clear();

            searchDGVDataAdapter.SelectCommand = searchCommand;
            searchDGVDataAdapter.SelectCommand.Connection = connection;

            searchDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            searchDGVDataAdapter.Fill(searchDGVDataTable);

            searchDGV.Refresh();
            searchDGV.ClearSelection();
            //searchDGV.AutoResizeColumns();
           

        }
       
     



        

        private void resetButton_Click(object sender, EventArgs e)
        {
            firstNameBox.Text = "";
            lastNameBox.Text = "";
            organizationTextBox.Text = "";

            SqlCommand searchCommand = new SqlCommand(query.CheckInSearch("", "", ""));
            searchDGVBindingSource.EndEdit();
            searchDGVDataTable.Clear();

            searchDGVDataAdapter.SelectCommand = searchCommand;
            searchDGVDataAdapter.SelectCommand.Connection = connection;

            searchDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            searchDGVDataAdapter.Fill(searchDGVDataTable);

            searchDGV.Refresh();
            searchDGV.ClearSelection();
          //  searchDGV.AutoResizeColumns();
        }

        private void chatNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this is where the threading of the online chat will prompt
            Thread cinderellaCheckInChat = new Thread(() => Application.Run(new ClientApp()));
            cinderellaCheckInChat.Name = "chat";
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
                cinderellaCheckInChat.Start();
                FormThreads.Add(cinderellaCheckInChat);//adds the thread to the list
            }
        }

        private void organizationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void schoolLabel_Click(object sender, EventArgs e)
        {

        }

        private void searchDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  searchDGV.Columns[0].Visible = false;
            //searchDGV.Refresh();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void refreshButtonCheckIn_Click(object sender, EventArgs e)
        {
            fillTable();
            //searchDGV_CellContentClick(searchDGV, new DataGridViewCellEventArgs(0, 0));
        }

        private void undoCinderellaCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread undoCheckedInCinderella = new Thread(() => Application.Run(new UndoCinderellaCheckIn()));
            undoCheckedInCinderella.Start();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread aboutThread = new Thread(() => Application.Run(new About()));
            aboutThread.Start();
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void cinderellaCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread cinderellaCheckInBarcode = new Thread(() => Application.Run(new CinderellaCheckInBarcode()));
            cinderellaCheckInBarcode.Start();
        }
    }
}
// string selectCommand = "Select Cinderellas.id,Cinderellas.firstName AS 'First Name',Cinderellas.lastName AS 'Last Name',Cinderellas.apptDate AS 'Date',Cinderellas.apptTime AS 'Time',Cinderellas.phoneNumber AS 'Phone' from Cinderellas";
