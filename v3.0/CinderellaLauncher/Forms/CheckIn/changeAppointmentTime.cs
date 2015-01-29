using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CinderellaLauncher
{
    /*changeAppointmentTime.cs
     * 
     * -Changes the appointment time of the selected Cinderella from the CheckIn gridview
     * -The appointment time may be changed to either the current date and time or a date and time that is entered/selected by the user
     * 
     * -Select:
     *      -Manual time and date or current time and date
     *      -If manual time and date are selected:
     *              -Select the date for the new appointment
     *              -Select the time for the new appointment
     *      
     * -Output:None
     * 
     * -Precondition:
     *      -Cinderella must be selected in the CheckIn gridview
     * 
     * -Postcondition:
     *      -The selected Cinderella's appointment time and date are updated in the database with the new date and time
     */

    public partial class changeAppointmentTime : Form
    {
        SQL_Queries query = new SQL_Queries();

        int cindID = 0;
        public changeAppointmentTime(string id)
        {
            InitializeComponent();
            cindID = Convert.ToInt32(id);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void changeAppointmentTime_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //When clicked needs to change the time in the database for the specified cinderella

            //Displays the time of the new appointment that has been entered
            //MessageBox.Show("The New Appointment Time is ", "New Appointment Time");

            if (currentButton.Checked)
            {
                query.updateCinderellaAppt(cindID);
            }
            else
            {
                string date = datePicker.Value.ToString();
                string time = timePicker.Value.ToString();

                query.updateCinderellaAppt(cindID, date, time);
            }

          //  Thread.CurrentThread.Abort();
            this.Close();
        }

        private void manualButton_CheckedChanged(object sender, EventArgs e)
        {          
            newApptDateLabel.Enabled = !newApptDateLabel.Enabled;
            newApptTimeLabel.Enabled = !newApptTimeLabel.Enabled;
            datePicker.Enabled = !datePicker.Enabled;
            timePicker.Enabled = !timePicker.Enabled;
        }
    }
}
