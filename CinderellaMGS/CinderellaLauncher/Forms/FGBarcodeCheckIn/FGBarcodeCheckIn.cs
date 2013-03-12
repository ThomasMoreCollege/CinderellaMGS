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
using System.Timers;
using UITimer = System.Windows.Forms.Timer;


namespace CinderellaLauncher
{
    

    public partial class FGCheckInBarcode : Form
    {
        public FGCheckInBarcode()
        {
            InitializeComponent();
        }

        private void FGCheckInBarcode_Load(object sender, EventArgs e)
        {

        }


   private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        SQL_Queries query = new SQL_Queries();




        private void BarcodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //int id = Convert.ToInt16(BarcodeTextBox.Text);
                string id = BarcodeTextBox.Text;


                /*DateTime today = DateTime.Now;
                DateTime t1 = new DateTime (2013, 3, 15, 12, 0, 0);
                DateTime t2 = new DateTime(2013, 3, 16, 12, 0, 0);
                DateTime t3 = new DateTime(2013, 3, 16, 18, 0, 0);
                //MessageBox.Show (Convert.ToString(today.Date));
                //MessageBox.Show(Convert.ToString(today.TimeOfDay));
                */




                
                {
                    /*

                    if (today.Date < t2)
                    {
                        query.setFGStatusScan(id, 4, 1);

                    }

                    else if (today.Date >= t2 && today.Date < t3)
                    {
                        query.setFGStatusScan(id, 4, 2);
                    }


                    else if (today.Date >= t3)
                    {
                        query.setFGStatusScan(id, 4, 3);
                    }*/


                    query.setFGStatus(id, 4);

                }
               
            }

        }
        private void OnTimerEvent(object sender, EventArgs e)
        {

            //DisplayCindi.Text = "";
            //timeLbl.Text = "";
            this.BackColor = System.Drawing.Color.LavenderBlush;

        }
    }
}
