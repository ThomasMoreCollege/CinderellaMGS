/*TO DO
 * IMPORTANT: Make changes to day available stuff, will screw up if TODAY is the last day of the month.
 * Display FG name in list box
 * Change time display in nameListBox_SelectedIndexChanged to reference time from database 
 * Finish documenting
*/
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
    public partial class Checkout : Form
    {
        //My naming throughout this code as follows
        //TB = text box
        //CB = combo box



        //Instantiate the sql class
        SQL_Queries sqlQuery = new SQL_Queries();

        //Both ID variables will hold the unique number for the respective data, and will be referenced several times throughout the code.
        string cinderellaID, fgID;
        //Index stores the selected index of the position selected within the nameListBox.
        //It is then referenced in pulling the data to fill all information on the right side of the form.
        int index;

        //dsA uses sqlQuery to call getCinderellas (within SQL_Queries.cs), which pulls required data
        //to display in the data fields on the form.
        //dsB performs the same function, but pulls only the information stored for the notes.
        //This is in a separate DataSet, because SQL threw errors when I tried to call this field
        //in conjunction with the data pulled in dsA.
        DataSet dsA, dsB;

        public Checkout()
        {
            InitializeComponent();
        }

        private void resetFields()
        {
            //Clears out the form.
            //This is called every time the update button is selected.
            //There is also a menu item to run this method.
            firstNameTB.Clear();
            lastNameTB.Clear();
            fgLastNameTB.Clear();
            shoeSizeCB.SelectedItem = "5";
            dressSizeCB.SelectedItem = "0";
            alteredCB.SelectedIndex = 0;
            notesTB.Clear();
            dressAvailableTB.Clear();
            changeStatusCB.SelectedIndex = 0;
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            //Sets the value of timer1 to our globally declared interval variable (currently set to 10 sec)
            //Sets the value of timer2 to 1/5 the value of timer1 
            //Timer 2 is used to show the "progress bar" - a string of periods that increments every interval
            timer1.Interval = GlobalVar.timerInterval;
            timer2.Interval = timer1.Interval / 5;
            timer1.Enabled = true;
            timer2.Enabled = true;
            //Sets the status change to the default (Done Shopping)
            changeStatusCB.SelectedIndex = 0;
            //Sets the day available to the default (Today)
            dayAvailableCB.SelectedIndex = 0;
            //Sets the sort option to Time In
            sortCB.SelectedIndex = 2;
            ampmCB.SelectedIndex = 0;
            alteredCB.SelectedIndex = 0;
            dayAvailableCB.SelectedIndex = 0;
            //Runs the populate method, which updates the data displayed in the nameListBox.
            populate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Runs the populate method, which updates the data displayed in the nameListBox.
            populate();
            //counterLabel is where the update progress is displayed. every 2 seconds a period is added, resets at 10 sec
            counterLabel.Text = "";
        }

        public void populate()
        {
            /*Header Documentation
             This purpose of populate() is to pull the data for each cinderella who is currently shopping,
             and display the name of each cinderella in the nameListBox.
             This allows the user to search for data ordered by the Time In (by transID, which is automatically assigned
             when a Cinderella is registered), last name, and by last name descending.
             It also allows to search based on the current status of the cinderella. The options Checkout provides
             are Shopping / Done Shopping / Checked-Out.
             */


            string order = ""; 
            //Sets the value of order (which will be called later when we execute a SQL query)
            // to whatever sort choice the user selects.
            switch (sortCB.SelectedIndex)
            {
                case 2:
                    order = "CinderellaTimestamp.transID";
                    break;
                case 0:
                    order = "Cinderella.lastName";
                    break;
                case 1:
                    order = "Cinderella.lastName DESC";
                    break;
                default:
                    break;
            }

            //calls getCinderellas (located in SQL_Queries), and pulls the data based on what options the user selects for
            //statuses desired and order.
                dsA = sqlQuery.getCinderellas(shoppingCheck.Checked, doneShoppingCheck.Checked, checkedOutCheck.Checked, order);
                //calls getNotes (located in SQL_Queries), and pulls the data based on what options the user selects for
                //statuses desired and order.
                dsB = sqlQuery.getNotes(shoppingCheck.Checked, doneShoppingCheck.Checked, checkedOutCheck.Checked, order);
            
            //The built in SelectionMode.None method prevents the listBox from automatically re-selecting index 0 when the information
            //is refreshed. SelectionMode.One reactivates selecting for the user.
                this.nameListBox.SelectionMode = SelectionMode.None;
            //Sets the value of the DisplayMembers to "Name" which is the data pulled for Cinderella Name
                this.nameListBox.DisplayMember = "Name";
            //Sets the value of the ValueMember to "ID" which is the data pulled for cinderella ID.
            //This is the field that will be referenced in the future to display the cinderella's data.
                this.nameListBox.ValueMember = "ID";
            //Sets the table pulled to tableName, which contains the information we need.
                this.nameListBox.DataSource = dsA.Tables["tableName"];
                this.nameListBox.SelectionMode = SelectionMode.One;

            //The following 3 if statements are a failsafe to make sure that one status is always selected
            //SQL throws an error if no status is selected.
                if (doneShoppingCheck.Checked == false && checkedOutCheck.Checked == false)
                {
                    shoppingCheck.Checked = true;
                    shoppingCheck.Enabled = false;
                }
                if (shoppingCheck.Checked == false && checkedOutCheck.Checked == false)
                {
                    doneShoppingCheck.Checked = true;
                    doneShoppingCheck.Enabled = false;
                }
                if (shoppingCheck.Checked == false && doneShoppingCheck.Checked == false)
                {
                    checkedOutCheck.Checked = true;
                    checkedOutCheck.Enabled = false;
                }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            /*Header Documentation
             The purpose of this method is to send the data entered to the database for storage.
             In depth explanation of each step to follow.
             */

            //Sets cinderella status to either done shopping or checked out, based on the selected index
            //of the changeStatusCB.
            if (changeStatusCB.SelectedIndex == 1)
            {
                sqlQuery.setStatus(cinderellaID, "Checked-Out", true, true);
                
            }
            else
            {
                //After setting the status of cinderella to Done Shopping, changes the default status in changeStatusCB to Checked-Out
                sqlQuery.setStatus(cinderellaID, "Done Shopping", true, true);
                changeStatusCB.SelectedIndex = 1;
            }

            //This if statement runs only if the current status of cinderella is Shopping
            //With the way we have everthing running, if a cinderella is Shopping, a Fairy Godmother(FG) is Paired.
            //Once a cinderella has been changed to Done Shopping, the FG is no longer with the cinderella, and is moved back to Unavailable
            if (statusTB.Text == "Shopping")
            {
                //This if statement first checks that the shift has ENDED. If this is the case, it will switch the FG to Pending
                //instead of Unavailable. Our reasons for this are that in Waiting_Area, Available FG's are displayed... we don't want to display any
                //FG's if the shift for that day has ended.
                if (sqlQuery.getShiftStartEnd(true))
                {
                    sqlQuery.setStatus(fgID, "Pending", false, true);
                }
                else
                {
                    sqlQuery.setStatus(fgID, "Unavailable", false, true);
                }
            }

            //If the CB's for shoe and dress size are empty, sets them to 0 (which is "NULL")
            if (shoeSizeCB.SelectedIndex == -1)
            {
                shoeSizeCB.SelectedIndex = 0;
            }
            if (dressSizeCB.SelectedIndex == -1)
            {
                dressSizeCB.SelectedIndex = 0;
            }


            //The following variables are used in the rather lengthy nested if statement to follow.
            string t = "";
            int militaryTime;
            string tomorrow;
            int tom;
            //calls getDate from SQL_Queries to get the current date from the database.
            string time = sqlQuery.getDate();
            string hour;


            /**************************************************************************************************
            //IMPORTANT NOTE: An addition is needed prior to this if statement.
            //Currently, it will not work properly if and only if it is the last day of any given month.
            //A test needs to be run on the value of time(current date) to check for last day of the month.
            //If this is TRUE, each instance in the following if statement needs to set the number for the month to +1
            //As well as resetting the day to 1.
             ***************************************************************************************************/


            //In some instances, cinderella's dress won't be available until the following day.
            //This code provides the functionality for us to parse the date string and +1 the date
            // add a day to the date if "Tomorrow" is selected.
            if (dayAvailableCB.SelectedIndex == 1)
            {
                //Adjusts the time string, accounting for months that are two digits long.
                if (time.Substring(0, 2) == "10" || time.Substring(0, 2) == "11" || time.Substring(0, 2) == "12")
                {
                    //pulls the day
                    tomorrow = time.Substring(3, 2);

                    //Adds one day to the date, if the day is one digit long
                    if (tomorrow.Substring(1, 1) == "/")
                    {
                        tom = Convert.ToInt32(tomorrow.Substring(0, 1)) + 1;
                        tomorrow = tom.ToString();
                        time = time.Substring(0, 2) + tomorrow + time.Substring(4, 5);
                    }
                    //... if the day is two digits long
                    else
                    {
                        tom = Convert.ToInt32(tomorrow) + 1;
                        tomorrow = tom.ToString();
                        time = time.Substring(0, 3) + tomorrow + time.Substring(5, 5);
                    }

                }
                //assuming the month is one digit long
                else
                {
                    tomorrow = time.Substring(2, 2);

                    //Adds one day to the date, if the day is one digit long
                    if (tomorrow.Substring(1, 1) == "/")
                    {
                        tom = Convert.ToInt32(tomorrow.Substring(0, 1)) + 1;
                        tomorrow = tom.ToString();
                        time = time.Substring(0, 2) + tomorrow + time.Substring(3, 5);
                    }
                    //... if the day is two digits long
                    else
                    {
                        tom = Convert.ToInt32(tomorrow) + 1;
                        tomorrow = tom.ToString();
                        time = time.Substring(0, 2) + tomorrow + time.Substring(4, 5);
                    }
                }
            }
                //If day selected is "TODAY"
            else
            {
                //if the month is two digits long
                if (time.Substring(0, 2) == "10" || time.Substring(0, 2) == "11" || time.Substring(0, 2) == "12")
                {
                    tomorrow = time.Substring(3, 2);

                    //if the day is one digit long
                    if (tomorrow.Substring(1, 1) == "/")
                    {
                        tom = Convert.ToInt32(tomorrow.Substring(0, 1));
                        tomorrow = tom.ToString();
                        time = time.Substring(0, 2) + tomorrow + time.Substring(4, 5);
                    }
                    // if the day is two digits long
                    else
                    {
                        tom = Convert.ToInt32(tomorrow);
                        tomorrow = tom.ToString();
                        time = time.Substring(0, 3) + tomorrow + time.Substring(5, 5);
                    }

                }
                //if the month is one digit long
                else
                {
                    tomorrow = time.Substring(2, 2);

                    //if the day is one digit long
                    if (tomorrow.Substring(1, 1) == "/")
                    {
                        tom = Convert.ToInt32(tomorrow.Substring(0, 1));
                        tomorrow = tom.ToString();
                        time = time.Substring(0, 2) + tomorrow + time.Substring(3, 5);
                    }
                    //if the day is two digits long
                    else
                    {
                        tom = Convert.ToInt32(tomorrow);
                        tomorrow = tom.ToString();
                        time = time.Substring(0, 2) + tomorrow + time.Substring(4, 5);
                    }
                }
            }


            //Sets the time available that will be posted to the database based on AM/PM
            //If PM, adds 12 hours to the time (database functions on military time)

            //PM
            if (ampmCB.SelectedIndex == 1)
            {
                //pulls the first two digits (the hour)
                hour = dressAvailableTB.Text.Substring(0, 2);
                //Adds 12 hours, puts the whole time back together
                militaryTime = Convert.ToInt32(hour) + 12;
                hour = militaryTime.ToString() + dressAvailableTB.Text.Substring(2, 3);
                //sets t to be the full date in the same format that is stored in the database
                t = time + " " + hour + ":00";
            }
            //AM
            else
            {
                //sets t to be the full date in the same format that is stored in the database
                t = time + " " + dressAvailableTB.Text + ":00";
            }

            string Fname = firstNameTB.Text;
            string Lname = lastNameTB.Text;

            //Calls setCinderellaDetails from SQL_Queries to UPDATE all data 
            sqlQuery.setCinderellaDetails(cinderellaID, dressSizeCB.SelectedItem.ToString(), shoeSizeCB.SelectedItem.ToString(), alteredCB.SelectedIndex, notesTB.Text, t, Fname, Lname);

            //Calls setGodmotherDetails from SQL_Queries to UPDATE all data
            sqlQuery.setGodmotherDetails(fgID, fgFirstNameTB.Text, fgLastNameTB.Text);

            //Call the populate() method to refresh the data in nameListBox
            populate();
            //Clear the fields for a new cinderella to be selected.
            resetFields();
        }

        public void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* Header Documentation
             This methods' purpose is to display all the data available in the database
             for a given cinderella that has been selected.
             This is the primary place where data is pulled and displayed from the database.
             */


            index = nameListBox.SelectedIndex;
            string status;
            string time, t1, temp;
            string currentDate = sqlQuery.getDate();
            string currentTime = sqlQuery.getDate();
            string altered;
            string shoe, dress;
            int i;
            int timePosition;


            //The following series of nested if statements set the current date(only the day) to currentDate,
            //which is referenced later.
            //Time position is used only as an index of where to begin parsing the time out of a full date string later on
            //add the currentTime **************************************************************************************************************************************
            if (currentDate.Substring(1, 1) == "/")
            {
                if (currentDate.Substring(3, 1) == "/")
                {
                    currentDate = currentDate.Substring(0, 8);
                    timePosition = 9;
                }
                else
                {
                    currentDate = currentDate.Substring(0, 9);
                    timePosition = 10;
                }
            }
            else
            {
                if (currentDate.Substring(4, 1) == "/")
                {
                    currentDate = currentDate.Substring(0, 9);
                    timePosition = 10;
                }
                else
                {
                    currentDate = currentDate.Substring(0, 10);
                    timePosition = 11;
                }
            }

            if (index == -1)
            {
                //exit method to prevent crash
                return;                
            }
            
            //Where it all happens...
            //Sets cinderellaID to the selected value of the currently selected cinderella
            cinderellaID = Convert.ToString(nameListBox.SelectedValue);

            //Sets the status(which is used elsewhere) to the data pulled based on what ID is selected
            status = dsA.Tables[0].Rows[index]["status"].ToString();
            statusTB.Text = status;

            //all of these perform the same way as the status displaying
            lastNameTB.Text = dsA.Tables[0].Rows[index]["lastName"].ToString(); 
            firstNameTB.Text = dsA.Tables[0].Rows[index]["firstName"].ToString();
            fgLastNameTB.Text = dsA.Tables[0].Rows[index]["fgLastName"].ToString();
            fgFirstNameTB.Text = dsA.Tables[0].Rows[index]["fgFirstName"].ToString();
            shoe = dsA.Tables[0].Rows[index]["shoeSize"].ToString();
            dress = dsA.Tables[0].Rows[index]["dressSize"].ToString();
            altered = dsA.Tables[0].Rows[index]["dressAltered"].ToString();
            fgID = dsA.Tables[0].Rows[index]["fgID"].ToString();
            time = dsA.Tables[0].Rows[index]["whenAvailable"].ToString();
            //notes behaves the same, but is pulled from data set B (this data set pulls only the notes information, due to data type constraints)
            notesTB.Text = dsB.Tables[0].Rows[index]["checkoutNotes"].ToString();

            // following code formats the time displayed, as well as the AM/PM field.

            //if no time is stored
            if (time == "")
            {
                //change this to reference time from the DB! ************************************************************************************************
                dressAvailableTB.Text = DateTime.Now.ToString("hh:mm");
                if (DateTime.Now.Hour > 12)
                {
                    ampmCB.SelectedIndex = 1;
                }
                else
                {
                    ampmCB.SelectedIndex = 0;
                }                
            }
            else
            {

                //parses the time string to display
                t1 = time.Substring(timePosition, 5);
                if (t1.Substring(4, 1) == ":")
                {
                    temp = t1.Substring(0, 4);
                    t1 = "0" + temp;
                }


                dressAvailableTB.Text = t1;

                //sets the position of i to the location of "AM" or "PM"
                i = timePosition + 8;
                
                //sets the ampmCB to either AM or PM
                if (time.Substring(i, 2) == "PM")
                {
                    ampmCB.SelectedIndex = 1;
                }
                else
                {
                    ampmCB.SelectedIndex = 0;
                }
            }

            //Sets the day available to TODAY if time is either blank or if the day pulled is the same as the current date.
            if (time == "" || currentDate == time.Substring(0, (timePosition - 1)))
            {
                dayAvailableCB.SelectedIndex = 0;
            }
                //if neither condition is met
            else
            {
                //if the current date is greater than the date pulled, set day available to TODAY
                if (Convert.ToInt32(currentDate) > Convert.ToInt32(time.Substring(0, (timePosition - 1))))
                {
                    dayAvailableCB.SelectedIndex = 0;
                }
                //set day available to TOMORROW if no other condition is met
                else
                {
                    dayAvailableCB.SelectedIndex = 1;
                }
            }
            

            // cases for each index of shoe size
            switch (shoe)
            {
                case "":
                    shoeSizeCB.SelectedIndex = -1;
                    break;
                case "5.0":
                    shoeSizeCB.SelectedIndex = 0;
                    break;
                case "5.5":
                    shoeSizeCB.SelectedIndex = 1;
                    break;
                case "6.0":
                    shoeSizeCB.SelectedIndex = 2;
                    break;
                case "6.5":
                    shoeSizeCB.SelectedIndex = 3;
                    break;
                case "7.0":
                    shoeSizeCB.SelectedIndex = 4;
                    break;
                case "7.5":
                    shoeSizeCB.SelectedIndex = 5;
                    break;
                case "8.0":
                    shoeSizeCB.SelectedIndex = 6;
                    break;
                case "8.5":
                    shoeSizeCB.SelectedIndex = 7;
                    break;
                case "9.0":
                    shoeSizeCB.SelectedIndex = 8;
                    break;
                case "9.5":
                    shoeSizeCB.SelectedIndex = 9;
                    break;
                case "10.0":
                    shoeSizeCB.SelectedIndex = 10;
                    break;
                case "10.5":
                    shoeSizeCB.SelectedIndex = 11;
                    break;
                case "11.0":
                    shoeSizeCB.SelectedIndex = 12;
                    break;
                case "12.0":
                    shoeSizeCB.SelectedIndex = 13;
                    break;
                case "13.0":
                    shoeSizeCB.SelectedIndex = 14;
                    break;
            }

            //cases for each index of dress size
            switch (dress)
            {
                case "":
                    dressSizeCB.SelectedIndex = -1;
                    break;
                case "0":
                    dressSizeCB.SelectedIndex = 0;
                    break;
                case "2":
                    dressSizeCB.SelectedIndex = 1;
                    break;
                case "4":
                    dressSizeCB.SelectedIndex = 2;
                    break;
                case "6":
                    dressSizeCB.SelectedIndex = 3;
                    break;
                case "8":
                    dressSizeCB.SelectedIndex = 4;
                    break;
                case "10":
                    dressSizeCB.SelectedIndex = 5;
                    break;
                case "12":
                    dressSizeCB.SelectedIndex = 6;
                    break;
                case "14":
                    dressSizeCB.SelectedIndex = 7;
                    break;
                case "16":
                    dressSizeCB.SelectedIndex = 8;
                    break;
                case "18":
                    dressSizeCB.SelectedIndex = 9;
                    break;
                case "20":
                    dressSizeCB.SelectedIndex = 10;
                    break;
                case "22":
                    dressSizeCB.SelectedIndex = 11;
                    break;
                case "24":
                    dressSizeCB.SelectedIndex = 12;
                    break;
                case "26":
                    dressSizeCB.SelectedIndex = 13;
                    break;
                case "28":
                    dressSizeCB.SelectedIndex = 14;
                    break;
                case "30":
                    dressSizeCB.SelectedIndex = 15;
                    break;
                case "32":
                    dressSizeCB.SelectedIndex = 16;
                    break;
                case "34":
                    dressSizeCB.SelectedIndex = 17;
                    break;
                case "36":
                    dressSizeCB.SelectedIndex = 18;
                    break;
                case "38":
                    dressSizeCB.SelectedIndex = 19;
                    break;
            }
//***********
            if (status == "Shopping")
            {
                changeStatusCB.SelectedIndex = 0;
            }
            else if (status == "Done Shopping")
            {
                changeStatusCB.SelectedIndex = 1;
            }

            if (altered == "False")
            {
                alteredCB.SelectedIndex = 0;
            }
            else
            {
                alteredCB.SelectedIndex = 1;
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        private void shoppingCheck_CheckedChanged(object sender, EventArgs e)
        {
            doneShoppingCheck.Enabled = true;
            checkedOutCheck.Enabled = true;

            if (shoppingCheck.Checked == false && checkedOutCheck.Checked == false)
            {
                doneShoppingCheck.Enabled = false;
            }
            else if (shoppingCheck.Checked == false && doneShoppingCheck.Checked == false)
            {
                checkedOutCheck.Enabled = false;
            }
        }

        private void doneShoppingCheck_CheckedChanged(object sender, EventArgs e)
        {
            shoppingCheck.Enabled = true;
            checkedOutCheck.Enabled = true;

            if (doneShoppingCheck.Checked == false && checkedOutCheck.Checked == false)
            {
                shoppingCheck.Enabled = false;
            }
            else if (shoppingCheck.Checked == false && doneShoppingCheck.Checked == false)
            {
                checkedOutCheck.Enabled = false;
            }
        }

        private void checkedOutCheck_CheckedChanged(object sender, EventArgs e)
        {
            doneShoppingCheck.Enabled = true;
            shoppingCheck.Enabled = true;

            if (shoppingCheck.Checked == false && checkedOutCheck.Checked == false)
            {
                doneShoppingCheck.Enabled = false;
            }
            else if (doneShoppingCheck.Checked == false && checkedOutCheck.Checked == false)
            {
                shoppingCheck.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            counterLabel.Text += ".";
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox aboutBoxForm = new AboutBox();
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox aboutBoxForm = new AboutBox();
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }

        private void nameListBox_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            counterLabel.Text = "Paused";
            counterLabel.Font = GlobalVar.LabelFont;
        }

        private void nameListBox_MouseLeave(object sender, EventArgs e)
        {
            Font CounterFont = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            timer1.Start();
            timer2.Start();
            counterLabel.Text = "";
            counterLabel.Font = CounterFont;
        }
    }
}
