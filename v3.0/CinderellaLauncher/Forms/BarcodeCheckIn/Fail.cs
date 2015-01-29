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
using UITimer = System.Windows.Forms.Timer;

namespace CinderellaLauncher.Forms.BarcodeCheckIn
{
    public partial class Fail : Form
    {
        public Fail()
        {

            InitializeComponent();

            UITimer timer1 = new UITimer();

            timer1.Interval = 3000;

            timer1.Enabled = true;

            timer1.Tick += new System.EventHandler(OnTimerEvent);

        }


        private void OnTimerEvent(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
