using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CinderellaLauncher
{
    /*
     * StatusControl.cs
     * 
     * -Allows the admin to manually change the status of the selected fairy godmother
     * 
     * -Input:
     *      -If using the search function a first name, last name, or both must be entered
     *      -Select the radio button you want to assign the specified fairy godmother to
     *      
     * -Output: None
     * 
     * -Precondition:
     *      -Fairy Godmother name must be selected in the data grid
     *      
     * -Postcondition:
     *      -The fairy godmother that was selected and modified is given a new status
     *      in the database
     *     
     */ 
    public partial class StatusControl : Form
    {
        static SQL_Queries query = new SQL_Queries();

        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        private BindingSource searchDGVBindingSource = new BindingSource();
        private DataTable searchDGVDataTable;
        private SqlDataAdapter searchDGVDataAdapter;
       

        public StatusControl()
        {
            InitializeComponent();
            this.KeyPreview = true;

            this.KeyUp += new KeyEventHandler(search_KeyUp);

        }
        void search_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
            }
        }

        private void StatusControl_Load(object sender, EventArgs e)
        {

            searchDGVDataTable = new DataTable();
            searchDGV.DataSource = searchDGVBindingSource;   
            searchDGVDataAdapter = new SqlDataAdapter(query.fgListShort(), connection);
            searchDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            searchDGVDataAdapter.Fill(searchDGVDataTable);
            searchDGVBindingSource.DataSource = searchDGVDataTable;

            searchDGV.ClearSelection();
            //searchDGV.AutoResizeColumns();
        }

        private void setStatusButton_Click(object sender, EventArgs e)
        {
            int selectedStatus = 0;

            if (unavailableButton.Checked)
                selectedStatus = 1;
            else if (pairedButton.Checked)
                selectedStatus = 2;
            else if (shoppingButton.Checked)
                selectedStatus = 3;
            else if (availableButton.Checked)
                selectedStatus = 4;
            else if (alterationsButton.Checked)
                selectedStatus = 5;
            else if (pendingButton.Checked)
                selectedStatus = 6;

            string id = searchDGV.SelectedRows[0].Cells[0].Value.ToString();

            query.setFGStatus(id, selectedStatus);

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string fname = firstNameBox.Text;
            string lname = lastNameBox.Text;

            SqlCommand searchCommand = new SqlCommand(query.fglistSearch(firstNameBox.Text, lastNameBox.Text));
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

            SqlCommand searchCommand = new SqlCommand(query.fgListShort());
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
