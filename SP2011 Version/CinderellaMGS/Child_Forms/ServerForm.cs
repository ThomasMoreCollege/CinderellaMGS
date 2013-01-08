using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinderellaMGS
{
    public partial class ServerForm : Form
    {
        //Instantiate the sql class
        SQL_Queries sqlQuery = new SQL_Queries();
        public ServerForm()
        {
            InitializeComponent();
            int interval = int.Parse(sqlQuery.getGlobalizedSettings("MatchMakerInterval"));
            timer.Interval = (interval * 1000);
            intervalLabel.Text = interval.ToString() + " seconds";

            if (sqlQuery.getGlobalizedSettings("MatchMakerStatus").ToLower() == "on")
            {
                statusLabel.Text = "On";
            }
            else
            {
                statusLabel.Text = "Off";
            }

            timer.Start();
        }
        /// <summary>
        /// After every tick the form labels are refreshed to display the current information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            //Is the process on or off?
            if (sqlQuery.getGlobalizedSettings("MatchMakerStatus").ToLower() == "on")
            {
                sqlQuery.MatchMakerProcess();
                statusLabel.Text = "On";
            }
            else
            {
                statusLabel.Text = "Off";
            }
        }
        /// <summary>
        /// Turns the matchmaker process on or off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void turnMatchMakerOnOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlQuery.getGlobalizedSettings("MatchMakerStatus").ToLower() == "on")
            {//Turn it off
                sqlQuery.sqlStatment("UPDATE [ConfigSettings] SET [propertyValue]='off'WHERE [appProperty]='MatchMakerStatus'");
                statusLabel.Text = "Off";
            }
            else
            {//turn it on
                sqlQuery.sqlStatment("UPDATE [ConfigSettings] SET [propertyValue]='on'WHERE [appProperty]='MatchMakerStatus'");
                statusLabel.Text = "On";
            }
        }
        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
