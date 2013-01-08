using System;
using System.Collections;
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
using BusinessLogic;
using System.Diagnostics;

namespace CinderellaLauncher
{
    /*ShoppintMgt.cs
     * 
     * Allows the user to change a personal shoppers' status to shopping or 
     * to manually override the current pairing of a cinderella and personal shopper
     * with a new personal shopper for the selected cinderella
     * 
     * -Input: None
     * 
     * -Output: None
     * 
     * -Precondition:
     *      -To send a personal shopper shopping a name must be selected from the data grid
     *      -To manually pair a cinderella and personal shopper both must be selected from the 
     *          corresponding data grids
     * 
     * -PostCondition:
     *      -A personal shopper is marked as shopping in the database
     *      
     */ 

    public partial class ManagePS : Form
    {
        List<Thread> FormThreads = new List<Thread>();//keeps track of form threads for latter termination

        static SQL_Queries query = new SQL_Queries();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

        //string selectCommandPSDGVMain = "SELECT id, firstName AS 'First Name', lastName AS 'Last Name', state AS 'State' FROM FairyGodmothers WHERE currentStatus = 4";     //Available
        string selectCommandPSDGVPairing = query.PersonalShoppers(2, 4);     //Paired or Available
        string selectCommandcinderellaDGVPairing = query.Cinderellas(2,3); //Waiting or Paired


        private BindingSource psDGVMainBindingSource = new BindingSource(); 
        private SqlDataAdapter psDGVMainDataAdapter;
        private SqlCommandBuilder psDGVMainSqlCommandBuilder; 
        private DataTable psDGVMainDataTable;

        private BindingSource psDGVPairingBindingSource = new BindingSource();
        private SqlDataAdapter psDGVPairingDataAdapter;
        private SqlCommandBuilder psDGVPairingSqlCommandBuilder;
        private DataTable psDGVPairingDataTable;

        private BindingSource cinderellaDGVPairingBindingSource = new BindingSource();
        private SqlDataAdapter cinderellaDGVPairingDataAdapter;
        private SqlCommandBuilder cinderellaDGVPairingSqlCommandBuilder;
        private DataTable cinderellaDGVPairingDataTable;

        
        public ManagePS()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(ManagePS_Load);
            this.KeyPreview = true;

            this.KeyUp += new KeyEventHandler(search_KeyUp);

        }
        void search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
        private void ManagePS_Load(object sender, EventArgs e)
        {
            try
            {
                // Take care of the Personal Shopper management grid view
                Thread update = new Thread(() => guiupdate());
                update.Start();
              //  cinderellaDGVPairing.AutoResizeColumns();

               // guiupdate();
            }
            catch (SqlException f)
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
                    
                    psDGVMain.Invoke(new Action(delegate()
                        {
                            psDGVMain.DataSource = psDGVMainBindingSource;
                        }));
                    psDGVMainDataAdapter = new SqlDataAdapter(query.fgListRoleManagement(4), connection);
                    psDGVMainSqlCommandBuilder = new SqlCommandBuilder(psDGVMainDataAdapter);
                    psDGVMainDataTable = new DataTable();
                    psDGVMainDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    psDGVMainDataAdapter.Fill(psDGVMainDataTable);
                    
                    psDGVMain.Invoke(new Action(delegate()
                        {
                            psDGVMainBindingSource.DataSource = psDGVMainDataTable;
                            //  psDGVMain.AutoResizeColumns();
                            psDGVMain.ClearSelection();
                        }));

                    // Take care of the Personal Shopper gridview for manual matching
                    
                    psDGVPairing.Invoke(new Action(delegate()
                        {
                            psDGVPairing.DataSource = psDGVPairingBindingSource;
                        }));
                    psDGVPairingDataAdapter = new SqlDataAdapter(selectCommandPSDGVPairing, connection);
                    psDGVPairingSqlCommandBuilder = new SqlCommandBuilder(psDGVPairingDataAdapter);
                    psDGVPairingDataTable = new DataTable();
                    psDGVPairingDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    psDGVPairingDataAdapter.Fill(psDGVPairingDataTable);
                    
                    psDGVPairing.Invoke(new Action(delegate()
                        {
                            psDGVPairingBindingSource.DataSource = psDGVPairingDataTable;
                        }));
                    //  psDGVPairing.AutoResizeColumns();

                    // Take care of the Cinderella gridview for manual matching
                    
                    cinderellaDGVPairing.Invoke(new Action(delegate()
                        {
                            cinderellaDGVPairing.DataSource = cinderellaDGVPairingBindingSource;
                        }));
                    cinderellaDGVPairingDataAdapter = new SqlDataAdapter(selectCommandcinderellaDGVPairing, connection);
                    cinderellaDGVPairingSqlCommandBuilder = new SqlCommandBuilder(cinderellaDGVPairingDataAdapter);
                    cinderellaDGVPairingDataTable = new DataTable();
                    cinderellaDGVPairingDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    cinderellaDGVPairingDataAdapter.Fill(cinderellaDGVPairingDataTable);
                    
                    cinderellaDGVPairing.Invoke(new Action(delegate()
                        {
                            cinderellaDGVPairingBindingSource.DataSource = cinderellaDGVPairingDataTable;
                        }));
                   // Thread.Sleep(5000);
             //   }
            }
            catch (Exception t)
            {
              //  Thread.CurrentThread.Abort();
            }
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = psDGVMain.SelectedRows[0].Cells[0].Value.ToString();
                query.setFGStatus(id, 3);

                // Refresh the datagrid
                SqlCommand refreshCommand = new SqlCommand(query.fgListRoleManagement(4));
                psDGVMainBindingSource.EndEdit();
                psDGVMainDataTable.Clear();

                psDGVMainDataAdapter.SelectCommand = refreshCommand;
                psDGVMainDataAdapter.SelectCommand.Connection = connection;

                psDGVMainDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                psDGVMainDataAdapter.Fill(psDGVMainDataTable);

                psDGVMain.Refresh();
                psDGVMain.ClearSelection();
               // psDGVMain.AutoResizeColumns();
            }
            catch (Exception error)
            {
                MessageBox.Show("You must select someone.");
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Thread openForms in FormThreads)
            {//terminates all form threads and taking the forms with them.
                openForms.Abort();
            }
            Thread logout = new Thread(() => Application.Run(new Login()));
            FormThreads.Clear();//removes non running threads from the List
            logout.Start();
            this.Close();
        }
        private void pairButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection personalShopper =  psDGVPairing.SelectedRows;
            DataGridViewSelectedRowCollection cinderella = cinderellaDGVPairing.SelectedRows;
            if ((psDGVPairing.SelectedRows.Count != 1) || (cinderellaDGVPairing.SelectedRows.Count != 1))
            {
                MessageBox.Show("You must select someone.");
                return;
            }
            SQL_Queries dbMagic = new SQL_Queries();
            //bool isPaired = false;
            //string query = dbMagic.getCinderellaStats(Convert.ToInt32(cinderella[0].Cells[0].Value));

            if (dbMagic.CinderellaCurrentStatus(Convert.ToInt32(cinderella[0].Cells[0].Value)) == 3)
            {
                dbMagic.undoFGPairFromCinderellaID(Convert.ToInt32(cinderella[0].Cells[0].Value));
            }
            if (dbMagic.CinderellaCurrentStatus(Convert.ToInt32(cinderella[0].Cells[0].Value)) != 3)
            {
                dbMagic.setCinderellaStatus(cinderella[0].Cells[0].Value.ToString(), 3);
            }
            if (dbMagic.FGCurrentStatus(Convert.ToInt32(personalShopper[0].Cells[0].Value)) == 2)
            {
                dbMagic.undoCinderellaPairFromFGID(Convert.ToInt32(personalShopper[0].Cells[0].Value));
            }
            if (dbMagic.FGCurrentStatus(Convert.ToInt32(personalShopper[0].Cells[0].Value)) != 2)
            {
                dbMagic.setFGStatus(personalShopper[0].Cells[0].Value.ToString(), 2);
            }
            dbMagic.pairCinderella(Convert.ToInt32(cinderella[0].Cells[0].Value),Convert.ToInt32(personalShopper[0].Cells[0].Value));

            /*
            string query = dbMagic.getFgPaired(Convert.ToInt32(Convert.ToInt32(cinderella[0].Cells[0].Value)));
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader.FieldCount < 1)
                {
                    break;
                }
            dbMagic.setFGStatus(reader.GetInt32(0).ToString(), 4);
            //Thread.Sleep(1000);
            }
            string query2 = dbMagic.getCinderellaPaired(Convert.ToInt32(personalShopper[0].Cells[0].Value));
            SqlCommand command2 = new SqlCommand(query2, conn);
            reader.Close();
            dbMagic.setFGStatus(personalShopper[0].Cells[0].Value.ToString(), 4);
            dbMagic.setCinderellaStatus(Convert.ToInt32(cinderella[0].Cells[0].Value).ToString(), 2);
            dbMagic.clearCinderellaFairyGodmotherID(Convert.ToInt32(cinderella[0].Cells[0].Value));
            //Thread.Sleep(1000);
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2.FieldCount < 1)
                {
                    break;
                }
                int id = reader2.GetInt32(0);
                dbMagic.setCinderellaStatus(id.ToString(), 2);
                dbMagic.clearCinderellaFairyGodmotherID(id);
              //  Thread.Sleep(1000);
            }
            reader2.Close();
            dbMagic.pairCinderella(Convert.ToInt32(cinderella[0].Cells[0].Value), Convert.ToInt32(personalShopper[0].Cells[0].Value));
            dbMagic.setCinderellaStatus(cinderella[0].Cells[0].Value.ToString(), 3);
            dbMagic.setFGStatus(personalShopper[0].Cells[0].Value.ToString(), 2);
           // Thread.Sleep(1000);
            conn.Close();*/

            MessageBox.Show("Pairing Complete");
            guiupdate();
        }

        private void chatNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Thread> FormThreads = new List<Thread>();//keeps track of form threads for latter termination
            
            Thread shoppingChat = new Thread(() => Application.Run(new ClientApp()));

            //this is where the threading of the online chat will prompt
            shoppingChat.Name = "chat";
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
                shoppingChat.Start();
                FormThreads.Add(shoppingChat);//adds the thread to the list
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guiupdate();
        }

        private void ManagePS_Load_1(object sender, EventArgs e)
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
    }
}
