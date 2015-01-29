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
    /*UndoCinderellaCheckIn.cs
     * 
     * -Allows the user to change a Cinderella's status back to the previous status
     * before they were checked-in
     * 
     * -Input: None
     * 
     * -Output: None
     * 
     * -Precondition:
     *      -Cinderella must be checked-in
     *      -Cinderella must be selected in the data grid view
     * 
     * -Postcondition:
     *      -Cinderella's status is changed and is put back into the list of cinderella's
     *      waiting to be checked-in to the system
     * 
     */
    public partial class UndoCinderellaCheckIn : Form
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        private SQL_Queries query = new SQL_Queries();

        private BindingSource undoDGVBindingSource = new BindingSource();
        private SqlDataAdapter undoDGVDataAdapter;
        private SqlCommandBuilder undoDGVSqlCommandBuilder;
        private DataTable undoDGVDataTable;

        public UndoCinderellaCheckIn()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(search_KeyUp);

        }
        void search_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F5)
            {
                refreshButton.PerformClick();
            }
        }
        private void UndoCinderellaCheckIn_Load(object sender, EventArgs e)
        {
            undoDGV.DataSource = undoDGVBindingSource;
            undoDGVDataAdapter = new SqlDataAdapter(query.CinderellasUndoList(), connection);
            undoDGVSqlCommandBuilder = new SqlCommandBuilder(undoDGVDataAdapter);
            undoDGVDataTable = new DataTable();
            undoDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            undoDGVDataAdapter.Fill(undoDGVDataTable);
            undoDGVBindingSource.DataSource = undoDGVDataTable;
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (undoDGV.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Please select one person.");
                    return;
                }
                string id = undoDGV.SelectedRows[0].Cells[0].Value.ToString();

                query.undoCinderellaUntilThisStatus(Convert.ToInt32(id), 1);


                SqlCommand refreshCommand = new SqlCommand(query.CinderellasUndoList());
                undoDGVBindingSource.EndEdit();
                undoDGVDataTable.Clear();

                undoDGVDataAdapter.SelectCommand = refreshCommand;
                undoDGVDataAdapter.SelectCommand.Connection = connection;

                undoDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                undoDGVDataAdapter.Fill(undoDGVDataTable);

                undoDGV.Refresh();
                undoDGV.ClearSelection();
            }
            catch (Exception f)
            {
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            undoDGV.DataSource = undoDGVBindingSource;
            undoDGVDataAdapter = new SqlDataAdapter(query.CinderellasUndoList(), connection);
            undoDGVSqlCommandBuilder = new SqlCommandBuilder(undoDGVDataAdapter);
            undoDGVDataTable = new DataTable();
            undoDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            undoDGVDataAdapter.Fill(undoDGVDataTable);
            undoDGVBindingSource.DataSource = undoDGVDataTable;
        }
    }
}
