using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace CinderellaLauncher
{
    /*UndoCheckIn.cs
     * 
     * A Fairy Godmother can be removed from the checked-in list of fairy godmothers
     * by using this form to undo their checked-in status. For example: a fairy
     * godmother was accidentally selected for check-in for some reason, the user can
     * correct this mistake through this form
     * 
     * -Input: None
     * 
     * -Output: None
     * 
     * -Precondition:
     *      -Fairy Godmother must be checked-in
     *      -A Fairy Godmother must be selected from the data grid view
     *      
     * -Postcondition:
     *      -The Fairy Godmother that was selected to be undone is reverted
     *       back to their former status before being checked-in to the system
     * 
     */ 

    public partial class UndoCheckIn : Form
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        private SQL_Queries query = new SQL_Queries();

        private BindingSource fairyGodmothersDGVBindingSource = new BindingSource();
        private SqlDataAdapter fairyGodmothersDGVDataAdapter;
        private SqlCommandBuilder fairyGodmothersDGVSqlCommandBuilder;
        private DataTable fairyGodmothersDGVDataTable;

        public UndoCheckIn()
        {
            InitializeComponent();
          this.KeyPreview = true;

            this.KeyUp += new KeyEventHandler(search_KeyUp);

        }
        void search_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                refreshButtonUndoCheckIn.PerformClick();
            }
        }
        private void UndoCheckIn_Load(object sender, EventArgs e)
        {
            fairyGodmothersDGV.DataSource = fairyGodmothersDGVBindingSource;
            fairyGodmothersDGVDataAdapter = new SqlDataAdapter(query.fgListCheckedIn(), connection);
            fairyGodmothersDGVSqlCommandBuilder = new SqlCommandBuilder(fairyGodmothersDGVDataAdapter);
            fairyGodmothersDGVDataTable = new DataTable();
            fairyGodmothersDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            fairyGodmothersDGVDataAdapter.Fill(fairyGodmothersDGVDataTable);
            fairyGodmothersDGVBindingSource.DataSource = fairyGodmothersDGVDataTable;
           // fairyGodmothersDGV.AutoResizeColumns();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (fairyGodmothersDGV.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Please select one person.");
                    return;
                }
                string id = fairyGodmothersDGV.SelectedRows[0].Cells[0].Value.ToString();

                query.undoFGUntilThisStatus(Convert.ToInt32(id), 1);


                SqlCommand refreshCommand = new SqlCommand(query.fgListCheckedIn());
                fairyGodmothersDGVBindingSource.EndEdit();
                fairyGodmothersDGVDataTable.Clear();

                fairyGodmothersDGVDataAdapter.SelectCommand = refreshCommand;
                fairyGodmothersDGVDataAdapter.SelectCommand.Connection = connection;

                fairyGodmothersDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                fairyGodmothersDGVDataAdapter.Fill(fairyGodmothersDGVDataTable);

                fairyGodmothersDGV.Refresh();
                fairyGodmothersDGV.ClearSelection();
                //  fairyGodmothersDGV.AutoResizeColumns();
            }
            catch (Exception f)
            {
            }
   
        }

        private void refreshButtonUndoCheckIn_Click(object sender, EventArgs e)
        {
            fairyGodmothersDGV.DataSource = fairyGodmothersDGVBindingSource;
            fairyGodmothersDGVDataAdapter = new SqlDataAdapter(query.fgListCheckedIn(), connection);
            fairyGodmothersDGVSqlCommandBuilder = new SqlCommandBuilder(fairyGodmothersDGVDataAdapter);
            fairyGodmothersDGVDataTable = new DataTable();
            fairyGodmothersDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            fairyGodmothersDGVDataAdapter.Fill(fairyGodmothersDGVDataTable);
            fairyGodmothersDGVBindingSource.DataSource = fairyGodmothersDGVDataTable;
        }
    }
}
