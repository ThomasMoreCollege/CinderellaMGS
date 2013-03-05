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
    public partial class CinderellaCheckInBarcode : Form
    {
        public CinderellaCheckInBarcode()
        {
            InitializeComponent();
        }

        private void CinderellaCheckInBarcode_Load(object sender, EventArgs e)
        {

        }


        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        SQL_Queries query = new SQL_Queries();





        private void finishCheckIn(string id)
        {
            id = CinderellaCheckInBarcodeTextbox.Text;
            query.setCinderellaStatus(id, 2);

            SqlConnection sqlConnection = new SqlConnection("Server=db.cisdept.thomasmore.edu,50336;Database=cinderellaMGS2012; User Id=cinderellamgs; Password=cinderellamgs2012;");
            sqlConnection.Open();
            SqlCommand Test = new SqlCommand();

            Test.CommandText = "SELECT Cinderellas.firstName, Cinderellas.lastName From Cinderellas WHERE Cinderellas.id = " + id; ;
            Test.CommandType = CommandType.Text;
            Test.Connection = sqlConnection;

            SqlDataReader Read;
            Read = Test.ExecuteReader();

            
            while (Read.Read())
                {
                    DisplayCindi.Text = "You have Checked In: " + Read["firstName"].ToString() + " " + Read["lastName"];
                }
            sqlConnection.Close();
            CinderellaCheckInBarcodeTextbox.Clear();
        }

        private void CinderellaCheckInBarcodeTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                {
                    this.BackColor = System.Drawing.Color.Green;
                    
                    UITimer timer1 = new UITimer();

                    timer1.Interval = 4000;

                    timer1.Enabled = true;

                    timer1.Tick += new System.EventHandler(OnTimerEvent);



                    string id = CinderellaCheckInBarcodeTextbox.Text;

                    string currentTime = query.getTime(Convert.ToInt32(id));


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
                            timeLbl.Text="Person is one or more hours late";
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
                           timeLbl.Text="Person is one or more hours early";
                        }

                        finishCheckIn(id);
                    }
                    // This person is EXACTLY on time. This will probably not happen.
                    else
                    {
                        finishCheckIn(id);

                    }

                }
            }


        }


        private void OnTimerEvent(object sender, EventArgs e)
        {

            DisplayCindi.Text = "";
            timeLbl.Text = "";
            this.BackColor = System.Drawing.Color.LavenderBlush;

        }

        private void CinderellaCheckInBarcodeTextbox_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
