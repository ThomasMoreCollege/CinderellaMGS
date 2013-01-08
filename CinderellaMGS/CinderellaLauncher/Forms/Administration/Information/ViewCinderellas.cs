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
using System.Threading;

namespace CinderellaLauncher
{
    /*
     * ViewCinderella.cs
     * 
     * -Allows the administrator or the user to see what the status of 
     * all the cinderellas at any moment in time
     * 
     * -Input: None
     * 
     * -Output:
     *      -Status of where each Cinderella is at that moment along with
     *      any related information
     *      
     * -Precondition: None
     *      
     * -Postcondition: None
     * 
     */ 

    public partial class ViewCinderellas : Form
    {
        // For details about databinding nonsense see the checkin form.

        static SQL_Queries query = new SQL_Queries();
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
       

        private BindingSource shoppingDGVBindingSource = new BindingSource();
        private DataTable shoppingDGVDataTable;
        private SqlDataAdapter shoppingDGVDataAdapter;

        private BindingSource alterationsDGVBindingSource = new BindingSource();
        private DataTable alterationsDGVDataTable;
        private SqlDataAdapter alterationsDGVDataAdapter;

        private BindingSource alterationsDoneDGVBindingSource = new BindingSource();
        private DataTable alterationsDoneDGVDataTable;
        private SqlDataAdapter alterationsDoneDGVDataAdapter;

        private BindingSource doneShoppingDGVBindingSource = new BindingSource();
        private DataTable doneShoppingDGVDataTable;
        private SqlDataAdapter doneShoppingDGVDataAdapter;

        private BindingSource pairedDGVBindingSource = new BindingSource();
        private DataTable pairedDGVDataTable;
        private SqlDataAdapter pairedDGVDataAdapter;


        public ViewCinderellas()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(search_KeyUp);
        }
        void search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                refreshButtonViewCinderellas.PerformClick();
            }
        }
        private void ViewCinderellas_Load(object sender, EventArgs e)
        {
            /*
             *statusID	statusName
                1	paired
                2	Waiting
                3	Paired
                4	Shopping
                5	Done Shopping
                6	Alterations
                7	Checked Out
                8	NoShow 
             */
            try
            {
                Thread update = new Thread(() => guiupdate());
                update.Start();
               // pairedDGV.AutoResizeColumns();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
            }
        }

        public void guiupdate()
        {
            try
            {
             //   while (true)
             //   {
                    // View Cinderellas that are currently shopping
                    shoppingDGVDataTable = new DataTable();
                    shoppingDGV.Invoke(new Action(delegate()
                        {
                            shoppingDGV.DataSource = shoppingDGVBindingSource;
                        }));
                    shoppingDGVDataAdapter = new SqlDataAdapter(query.statusList(4), connection);
                    shoppingDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    shoppingDGVDataAdapter.Fill(shoppingDGVDataTable);
                    
                    shoppingDGV.Invoke(new Action(delegate()
                        {
                            shoppingDGVBindingSource.DataSource = shoppingDGVDataTable;

                            shoppingDGV.ClearSelection();
                        }));
                    // shoppingDGV.AutoResizeColumns();

                    // View Cinderellas that are in alterations----------------------------------------
                    alterationsDGVDataTable = new DataTable();
                    
                    alterationsDGV.Invoke(new Action(delegate()
                        {
                            alterationsDGV.DataSource = alterationsDGVBindingSource;
                        }));
                    alterationsDGVDataAdapter = new SqlDataAdapter(query.statusList(6), connection);
                    alterationsDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    alterationsDGVDataAdapter.Fill(alterationsDGVDataTable);
                    
                    alterationsDGV.Invoke(new Action(delegate()
                        {
                            alterationsDGVBindingSource.DataSource = alterationsDGVDataTable;

                            alterationsDGV.ClearSelection();
                        }));
                    //alterationsDGV.AutoResizeColumns();

                    // View Cinderellas that are done with alterations------------------------------------
                    alterationsDoneDGVDataTable = new DataTable();
                    
                    alterationsDoneDGV.Invoke(new Action(delegate()
                        {
                            alterationsDoneDGV.DataSource = alterationsDoneDGVBindingSource;
                        }));
                    alterationsDoneDGVDataAdapter = new SqlDataAdapter(query.alterationCompleted(), connection);
                    alterationsDoneDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    alterationsDoneDGVDataAdapter.Fill(alterationsDoneDGVDataTable);
                    
                    alterationsDoneDGV.Invoke(new Action(delegate()
                        {
                            alterationsDoneDGVBindingSource.DataSource = alterationsDoneDGVDataTable;

                            alterationsDoneDGV.ClearSelection();
                        }));
                    // alterationsDoneDGV.AutoResizeColumns();

                    // View Cinderellas that are done shopping--------------------------------------------

                    doneShoppingDGVDataTable = new DataTable();
                    
                    doneShoppingDGV.Invoke(new Action(delegate()
                        {
                            doneShoppingDGV.DataSource = doneShoppingDGVBindingSource;
                        }));
                    doneShoppingDGVDataAdapter = new SqlDataAdapter(query.statusList(5), connection);
                    doneShoppingDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    doneShoppingDGVDataAdapter.Fill(doneShoppingDGVDataTable);
                    
                    doneShoppingDGV.Invoke(new Action(delegate()
                        {
                            doneShoppingDGVBindingSource.DataSource = doneShoppingDGVDataTable;

                            doneShoppingDGV.ClearSelection();
                        }));
                    // doneShoppingDGV.AutoResizeColumns();

                    // View Cinderellas that are paired--------------------------------------------

                    pairedDGVDataTable = new DataTable();
                    
                    pairedDGV.Invoke(new Action(delegate()
                        {
                            pairedDGV.DataSource = pairedDGVBindingSource;
                        }));
                    pairedDGVDataAdapter = new SqlDataAdapter(query.statusList(3), connection);
                    pairedDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    pairedDGVDataAdapter.Fill(pairedDGVDataTable);
                    
                    pairedDGV.Invoke(new Action(delegate()
                        {
                            pairedDGVBindingSource.DataSource = pairedDGVDataTable;

                            pairedDGV.ClearSelection();
                        }));
                  //  Thread.Sleep(5000);
            //    }
            }
            catch (Exception t)
            {
              //  Thread.CurrentThread.Abort();
            }
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread stats = new Thread(() => Application.Run(new Statistics()));
            stats.Start();
        }

        private void alterationsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refreshButtonViewCinderellas_Click(object sender, EventArgs e)
        {
            guiupdate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
