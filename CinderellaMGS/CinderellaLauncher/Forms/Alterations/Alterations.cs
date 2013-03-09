using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinderellaLauncher;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Diagnostics;
using CinderellaLauncher.Forms;

// Statuses: Shopping = 4, Alterations = 6


namespace CinderellaLauncher
{
    /*Alterations.cs
     * 
     * -A currently shopping cinderella's dress size and color is selected and 
     * checked into alterations
     * -Once the cinderella is checked into alterations the user selects the name
     * of the cinderella and selects the boxes that match what is being done to the
     * dress of the current cinderella along with the name of the seamstress(selected 
     * from a dropdown list), and any additional notes that needed to be entered
     * 
     * -Input:
     *      -Size and color of dress
     *      -The alterations needing to be done
     *      -Notes(optional)
     *      -The name of the seamstress
     * 
     * -Output: None
     * 
     * -Precondition:
     *      -Cinderella must be selected from the data grids
     *      
     * -Postcondition:
     *      -The Cinderella's status is changed in the database
     *      
     */
    public partial class Alterations : Form
    {
        bool isResized = false;

        static SQL_Queries query = new SQL_Queries();
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

        private BindingSource shoppingCinderellasDGVBindingSource = new BindingSource();
        private DataTable shoppingCinderellasDGVDataTable;
        private SqlDataAdapter shoppingCinderellasDGVDataAdapter;


        private BindingSource alterationsCinderellasDGVBindingSource = new BindingSource();
        private DataTable alterationsCinderellasDGVDataTable;
        private SqlDataAdapter alterationsCinderellasDGVDataAdapter;

        private BindingSource alteratorsBindingSource = new BindingSource();
        private DataTable alteratorsDataTable;
        private SqlDataAdapter alteratorsDataAdapter;


        // Input variables
        string notes = "";

        bool straps = false;
        bool zipper = false;
        bool bust = false;
        bool darts = false;
        bool mending = false;
        bool takeIn = false;
        bool hem = false;

        string alterator = "";

        public Alterations()
        {

            InitializeComponent();

            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(search_KeyUp);

        }
        void search_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F5)
            {
                refreshButtonAlterations.PerformClick();
            }
        }



        private void Alterations_Load(object sender, EventArgs e)
        {
            try
            {
                shoppingCinderellasDGVDataTable = new DataTable();
                shoppingCinderellasDGV.DataSource = shoppingCinderellasDGVBindingSource;
                shoppingCinderellasDGVDataAdapter = new SqlDataAdapter(query.statusList(4), connection);
                shoppingCinderellasDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                shoppingCinderellasDGVDataAdapter.Fill(shoppingCinderellasDGVDataTable);
                shoppingCinderellasDGVBindingSource.DataSource = shoppingCinderellasDGVDataTable;
                shoppingCinderellasDGV.ClearSelection();

                alterationsCinderellasDGVDataTable = new DataTable();
                alterationsCinderellasDGV.DataSource = alterationsCinderellasDGVBindingSource;
                alterationsCinderellasDGVDataAdapter = new SqlDataAdapter(query.CinderellasInAlteration(), connection);
                alterationsCinderellasDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                alterationsCinderellasDGVDataAdapter.Fill(alterationsCinderellasDGVDataTable);
                alterationsCinderellasDGVBindingSource.DataSource = alterationsCinderellasDGVDataTable;
                alterationsCinderellasDGV.ClearSelection();

                alteratorsDataTable = new DataTable();
                alteratorsDropDownList.DataSource = alteratorsBindingSource;
                alteratorsDataAdapter = new SqlDataAdapter(query.fgListRoleCheckedIn("5"), connection);
                alteratorsDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                alteratorsDataAdapter.Fill(alteratorsDataTable);
                alteratorsBindingSource.DataSource = alteratorsDataTable;

                // Make a new column in the table to allow the dropdownlist to show first and last name
                alteratorsDataTable.Columns.Add("FullName", typeof(string), "firstName + ' ' + lastName");
                alteratorsDropDownList.DisplayMember = "FullName";
                alteratorsDropDownList.ValueMember = "id";

            }
            catch (Exception f)
            {
                MessageBox.Show("Alt_Load" + f.ToString());
            }
        }

        public void guiupdate()
        {
            try
            {
                shoppingCinderellasDGVBindingSource.EndEdit();
                shoppingCinderellasDGVDataTable.Clear();
                shoppingCinderellasDGVDataAdapter.Fill(shoppingCinderellasDGVDataTable);
                shoppingCinderellasDGV.Refresh();

                alterationsCinderellasDGVBindingSource.EndEdit();
                alterationsCinderellasDGVDataTable.Clear();
                alterationsCinderellasDGVDataAdapter.Fill(alterationsCinderellasDGVDataTable);
                alterationsCinderellasDGV.Refresh();

                alteratorsBindingSource.EndEdit();
                alteratorsDataTable.Clear();
                alteratorsDataAdapter.Fill(alteratorsDataTable);
                alteratorsDropDownList.Refresh();
            }
            catch (Exception t)
            {
                // Thread.CurrentThread.Abort();
            }
        }

        private void alterationsCinderellasDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                cinderellaNameLabel.Text = alterationsCinderellasDGV.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + alterationsCinderellasDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {

                string id = alterationsCinderellasDGV.SelectedRows[0].Cells[0].Value.ToString();

                // Only way I could find to do this, seems somewhat odd...
                DataRow selectedDataRow = ((DataRowView)alteratorsDropDownList.SelectedItem).Row;
                alterator = selectedDataRow["id"].ToString();


                int iZipper = Convert.ToInt32(zipper);
                int iBust = Convert.ToInt32(bust);
                int iDarts = Convert.ToInt32(darts);
                int iMending = Convert.ToInt32(mending);
                int iTakeIn = Convert.ToInt32(takeIn);
                int iHem = Convert.ToInt32(hem);
                int iStraps = Convert.ToInt32(straps);

                notes = notesTextBox.Text;
                SQL_Queries dbMagic = new SQL_Queries();
                string query = dbMagic.checkAlterations(id);
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                bool exists = false;
                int rowCount = 0;
                while (reader.Read())
                {

                    rowCount++;
                }

                if (rowCount == 1)
                {
                    dbMagic.updateAlterations(id, notes, iStraps, iDarts, iZipper, iMending, iTakeIn, iBust, iHem, alterator);
                }
                else
                {
                    dbMagic.addAlterations(id);
                }

                alterationsCinderellasDGV.ClearSelection();
                strapsCheckBox.Checked = false;
                zipperCheckBox.Checked = false;
                bustCheckBox.Checked = false;
                dartsCheckBox.Checked = false;
                generalMendingCheckBox.Checked = false;
                generalTakeInCheckBox.Checked = false;
                hemCheckBox.Checked = false;
                notesTextBox.Text = "";

                //refresh left gridview
                SqlCommand refreshCommandAlt = new SqlCommand(dbMagic.CinderellasInAlteration());
                alterationsCinderellasDGVBindingSource.EndEdit();
                alterationsCinderellasDGVDataTable.Clear();

                alterationsCinderellasDGVDataAdapter.SelectCommand = refreshCommandAlt;
                alterationsCinderellasDGVDataAdapter.SelectCommand.Connection = connection;

                alterationsCinderellasDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                alterationsCinderellasDGVDataAdapter.Fill(alterationsCinderellasDGVDataTable);

                alterationsCinderellasDGV.Refresh();
                alterationsCinderellasDGV.ClearSelection();
                // alterationsCinderellasDGV.AutoResizeColumns();
            }

            catch (Exception error)
            {
                MessageBox.Show("Input not valid");
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void finishedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void BarcodeTextBoxAlterations_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                //might have to rewrite how people are added to alteration through the scanner.. 

                /*   if (shoppingCinderellasDGV.SelectedRows.Count != 1)
                   {
                       MessageBox.Show("Please select a Cinderella that is shopping to check in.");
                       return;
                   }*/
                if (dressColorComboBox.SelectedItem == null || dressSizeComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select both a dress size and color");
                    return;
                }

                string id = BarcodeTextBoxAlterations.Text;


                string dressColor = dressColorComboBox.SelectedItem.ToString();
                int dressSize = Convert.ToInt32(dressSizeComboBox.SelectedItem);

                query.checkOutUpdate(Convert.ToInt32(id), dressSize, dressColor);
                query.addAlterations(id);
                query.setCinderellaStatus(id, 6); // string id, int status
                query.FGLeavesCinderella(Convert.ToInt32(id));


                // Refresh the two datagrids
                SqlCommand refreshCommandShop = new SqlCommand(query.statusList(4));
                shoppingCinderellasDGVBindingSource.EndEdit();
                shoppingCinderellasDGVDataTable.Clear();

                shoppingCinderellasDGVDataAdapter.SelectCommand = refreshCommandShop;
                shoppingCinderellasDGVDataAdapter.SelectCommand.Connection = connection;

                shoppingCinderellasDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                shoppingCinderellasDGVDataAdapter.Fill(shoppingCinderellasDGVDataTable);

                shoppingCinderellasDGV.Refresh();
                shoppingCinderellasDGV.ClearSelection();
                // shoppingCinderellasDGV.AutoResizeColumns();



                SqlCommand refreshCommandAlt = new SqlCommand(query.CinderellasInAlteration());
                alterationsCinderellasDGVBindingSource.EndEdit();
                alterationsCinderellasDGVDataTable.Clear();

                alterationsCinderellasDGVDataAdapter.SelectCommand = refreshCommandAlt;
                alterationsCinderellasDGVDataAdapter.SelectCommand.Connection = connection;

                alterationsCinderellasDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                alterationsCinderellasDGVDataAdapter.Fill(alterationsCinderellasDGVDataTable);

                alterationsCinderellasDGV.Refresh();
                alterationsCinderellasDGV.ClearSelection();
                // alterationsCinderellasDGV.AutoResizeColumns();

                dressSizeComboBox.ResetText();
                dressColorComboBox.ResetText();
                BarcodeTextBoxAlterations.Text = "";
            }
        }

        private void checkinButton_Click(object sender, EventArgs e)
        {
            if (shoppingCinderellasDGV.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a Cinderella that is chopping to check in.");
                return;
            }
            if (dressColorComboBox.SelectedItem == null || dressSizeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select both a dress size and color");
                return;
            }

            string id = shoppingCinderellasDGV.SelectedRows[0].Cells[0].Value.ToString();

            string dressColor = dressColorComboBox.SelectedItem.ToString();
            int dressSize = Convert.ToInt32(dressSizeComboBox.SelectedItem);

            query.checkOutUpdate(Convert.ToInt32(id), dressSize, dressColor);
            query.addAlterations(id);
            query.setCinderellaStatus(id, 6); // string id, int status
            query.FGLeavesCinderella(Convert.ToInt32(id));


            // Refresh the two datagrids
            SqlCommand refreshCommandShop = new SqlCommand(query.statusList(4));
            shoppingCinderellasDGVBindingSource.EndEdit();
            shoppingCinderellasDGVDataTable.Clear();

            shoppingCinderellasDGVDataAdapter.SelectCommand = refreshCommandShop;
            shoppingCinderellasDGVDataAdapter.SelectCommand.Connection = connection;

            shoppingCinderellasDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            shoppingCinderellasDGVDataAdapter.Fill(shoppingCinderellasDGVDataTable);

            shoppingCinderellasDGV.Refresh();
            shoppingCinderellasDGV.ClearSelection();
            // shoppingCinderellasDGV.AutoResizeColumns();



            SqlCommand refreshCommandAlt = new SqlCommand(query.CinderellasInAlteration());
            alterationsCinderellasDGVBindingSource.EndEdit();
            alterationsCinderellasDGVDataTable.Clear();

            alterationsCinderellasDGVDataAdapter.SelectCommand = refreshCommandAlt;
            alterationsCinderellasDGVDataAdapter.SelectCommand.Connection = connection;

            alterationsCinderellasDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            alterationsCinderellasDGVDataAdapter.Fill(alterationsCinderellasDGVDataTable);

            alterationsCinderellasDGV.Refresh();
            alterationsCinderellasDGV.ClearSelection();
            // alterationsCinderellasDGV.AutoResizeColumns();

            dressSizeComboBox.ResetText();
            dressColorComboBox.ResetText();
        }

        private void strapsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            straps = !straps;
        }

        private void zipperCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            zipper = !zipper;
        }

        private void bustCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bust = !bust;
        }

        private void dartsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            darts = !darts;
        }

        private void generalMendingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mending = !mending;
        }

        private void generalTakeInCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            takeIn = !takeIn;
        }

        private void hemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hem = !hem;
        }

        private void chatNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Thread> FormThreads = new List<Thread>();//keeps track of form threads for latter termination

            //this is where the threading of the online chat will prompt
            Thread alterChat = new Thread(() => Application.Run(new ClientApp()));
            alterChat.Name = "chat";
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
                alterChat.Start();
                FormThreads.Add(alterChat);//adds the thread to the list
            }
        }

        private void refreshButtonAlterations_Click(object sender, EventArgs e)
        {
            guiupdate();
        }

        private void shoppingCinderellasDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void Search_Click(object sender, EventArgs e)
        {

            string q = query.MasterSearchBox(SearchBox.Text);
            shoppingCinderellasDGVDataTable = new DataTable();
            shoppingCinderellasDGV.DataSource = shoppingCinderellasDGVBindingSource;
            shoppingCinderellasDGVDataAdapter = new SqlDataAdapter(q, connection);
            shoppingCinderellasDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            shoppingCinderellasDGVDataAdapter.Fill(shoppingCinderellasDGVDataTable);
            shoppingCinderellasDGVBindingSource.DataSource = shoppingCinderellasDGVDataTable;
            shoppingCinderellasDGV.ClearSelection();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread Printer = new Thread(() => Application.Run(new CinderellaLauncher.Forms.Print()));
            Printer.Start();
        }

        private void fGPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread FGPrinter = new Thread(() => Application.Run(new CinderellaLauncher.Forms.FGPrint()));
            FGPrinter.Start();
        }
    }
}
