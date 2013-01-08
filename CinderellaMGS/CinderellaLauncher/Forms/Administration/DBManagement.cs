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
     * DBManagement.cs
     * 
     * -Allows the administrator to enter sql queries manually
     * 
     * -Input:
     *      -SQL Query
     *      
     * -Output:
     *      -Results from the entered query
     *      
     * -Precondition: 
     *      -Must be logged in as an administrator
     *      
     * -Postcondition: None
     * 
     */ 
    public partial class DBManagement : Form
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        SQL_Queries query = new SQL_Queries();
        DatabaseIO db = new DatabaseIO();

        private BindingSource dgvBindingSource = new BindingSource();
        private SqlDataAdapter dgvDataAdapter;
        private DataTable dgvDataTable; 

        public DBManagement()
        {
            InitializeComponent();
            
        }

        private void runQueryButton_Click(object sender, EventArgs e)
        {
            string userQuery = queryBox.Text;

            try
            {

                if (userQuery[0] == 's' || userQuery[0] == 'S')
                {
                    refreshMe(userQuery);
                }
                else
                {
                    db.ExecuteQuery(userQuery);
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void refreshMe(string q)
        {
            dgvDataTable = new DataTable();
            dgv.DataSource = dgvBindingSource;
            dgvDataAdapter = new SqlDataAdapter(q, connection);
            dgvDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dgvBindingSource.EndEdit();
            dgvDataTable.Clear();
            dgvDataAdapter.Fill(dgvDataTable);
            dgvBindingSource.DataSource = dgvDataTable;

            dgv.Refresh();

        }

        private void dBPurgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult warning = MessageBox.Show("You are about to remove:\r\n\r\n ALL TRANSACTIONAL DATA\r\n\r\nProceed?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

           if (warning == DialogResult.Yes)
           {
               query.resetDB();
               MessageBox.Show("Transactional data has been purged.");
           }
           else
           {
               MessageBox.Show("Purge avoided");
           }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            queryBox.Text = "";
            queryBox.Focus();
        }

        private void deleteFairyGodmothersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult warning = MessageBox.Show("You are about to remove:\r\n\r\n ALL FAIRY GODMOTHERS\r\n\r\nProceed?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (warning == DialogResult.Yes)
            {
                query.deleteFGs();
                MessageBox.Show("Fairy Godmothers have been purged.");
            }
            else
            {
                MessageBox.Show("Purge avoided");
            }
        }

        private void deleteCinderellasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult warning = MessageBox.Show("You are about to remove:\r\n\r\n ALL CINDERELLAS\r\n\r\nProceed?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (warning == DialogResult.Yes)
            {
                query.deleteCinderellas();
                MessageBox.Show("Cinderellas have been purged.");
            }
            else
            {
                MessageBox.Show("Purge avoided");
            }
        }

        private void fullPurgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult warning = MessageBox.Show("You are about to remove:\r\n\r\n ALL DATA:\r\n FAIRY GODMOTHERS,CINDERELLAS, and ALL TRANSACTIONAL DATA\r\n\r\nProceed?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (warning == DialogResult.Yes)
            {
                query.resetDB();
                query.deleteFGs();
                query.deleteCinderellas();

                MessageBox.Show("All data has been purged.");
            }
            else
            {
                MessageBox.Show("Purge avoided");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DBManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
