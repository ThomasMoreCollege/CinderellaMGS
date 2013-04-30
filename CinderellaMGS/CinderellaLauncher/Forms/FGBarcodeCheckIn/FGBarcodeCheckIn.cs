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
                
                string id = BarcodeTextBox.Text;


                DateTime today = DateTime.Now;
                DateTime t1 = new DateTime(2013, 3, 15, 12, 0, 0);
                DateTime t2 = new DateTime(2013, 3, 16, 12, 0, 0);
                DateTime t3 = new DateTime(2013, 3, 16, 18, 0, 0);
                //MessageBox.Show (Convert.ToString(today.Date));
                //MessageBox.Show(Convert.ToString(today.TimeOfDay));
                int FGStatus= Convert.ToInt32(query.getFGStatus(id));
                
                
                
                
 

                    if (FGStatus == 1)
                    {
                        query.setFGStatus(id, 4);




                        Thread Success = new Thread(() => Application.Run(new CinderellaLauncher.Forms.BarcodeCheckIn.Success()));
                        Success.Start();


                        
                      

                          /*  if (today.Date < t2)
                            {

                             int role = query.ShiftWorkerRole(Convert.ToInt32(id), 1);


                            if (role == 1) { DisplayCindi.Text = "Role: Administrator"; }

                            else if (role == 2) { DisplayCindi.Text = "Role: Check in/Check out"; }

                            else if (role == 3) { DisplayCindi.Text = "Role: Administrator"; }

                            else if (role == 4) { DisplayCindi.Text = "Role: Personal Shopper"; }

                            else if (role == 5) { DisplayCindi.Text = "Role: Alterator"; }

                            else if (role == 6) { DisplayCindi.Text = "Role: Volunteer"; }


                            }

                            else if (today.Date >= t2 && today.Date < t3)
                            {
                                int role = query.ShiftWorkerRole(Convert.ToInt32(id), 2);


                                if (role == 1) { DisplayCindi.Text = "Role: Administrator"; }

                                else if (role == 2) { DisplayCindi.Text = "Role: Check in/Check out"; }

                                else if (role == 3) { DisplayCindi.Text = "Role: Administrator"; }

                                else if (role == 4) { DisplayCindi.Text = "Role: Personal Shopper"; }

                                else if (role == 5) { DisplayCindi.Text = "Role: Alterator"; }

                                else if (role == 6) { DisplayCindi.Text = "Role: Volunteer"; }
                            }


                            else if (today.Date >= t3)
                            {
                                int role = query.ShiftWorkerRole(Convert.ToInt32(id), 3);


                                if (role == 1) { DisplayCindi.Text = "Role: Administrator"; }

                                else if (role == 2) { DisplayCindi.Text = "Role: Check in/Check out"; }

                                else if (role == 3) { DisplayCindi.Text = "Role: Administrator"; }

                                else if (role == 4) { DisplayCindi.Text = "Role: Personal Shopper"; }

                                else if (role == 5) { DisplayCindi.Text = "Role: Alterator"; }

                                else if (role == 6) { DisplayCindi.Text = "Role: Volunteer"; }
                            }*/



                       
                        }
                             else
                            {
                                Thread Fail = new Thread(() => Application.Run(new CinderellaLauncher.Forms.BarcodeCheckIn.Fail()));
                                Fail.Start();
                            }
                    }

                   

            }
        
        private void OnTimerEvent(object sender, EventArgs e)
        {

            DisplayCindi.Text = "";
            timeLbl.Text = "";
            BarcodeTextBox.Text = "";
            this.BackgroundImage = null;

        }
    }
}
