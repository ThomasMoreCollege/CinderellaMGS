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
using System.Configuration;
using System.Data.SqlClient;

namespace CinderellaLauncher
{
    /*Login.cs
     * 
     * -Logs the user into the specific forms based on their role/station
     * 
     * -Select:
     *      -User Access or Admin Access
     *   
     * -Input:
     *      -If Admin Access was selected then a username and password must be entered
     * 
     * -Output:
     *      -If User Access is selected:
     *          -If Cinderella Check In is chosen then the Cinderella Check-In form is displayed
     *          -If Cinderella Check-Out is chosen then the Check Out form is displayed
     *          -If FairyGodmother Check-In is chosen then the FGCheckIn form is displayed
     *          -If Shopping Management is chosen then the ShoppingMgt and the Cinderella Check-In forms are displayed
     *          -If Alterations is chosen then the Alterations form is displayed
     *      -If Admin Access is selected:
     *          -The Main Menu is displayed to give the administrator access to all the forms
     *          
     * -Precondition: None
     * 
     * -Postcondition:
     *      -Taken to specified forms (see the output listed above)
     */

    public partial class Login : Form
    {
        // Used for advancedButton
        bool isResized = false; 
        

        // Dialog that will be displayed next to the database information input boxes.
        // Should explain how this login menu works.
        string connectionInformationText = "Enter connection information for the database here.\r\n\r\n" +
                                            "After your database username, password, server, and port\r\n" +
                                            "are entered, press connect to view a list of databases.\r\n\r\n" +
                                            "Once this information is correct, you will be able to log in.";

        // This is only temporary in order to test.
        static public string dbServer = "";
        static public string dbPort = "";
        static public string dbUsername = "";
        static public string dbPassword = "";
        static public string dbDatabase = "";

        public Login()
        {
            InitializeComponent();
            this.connectionInfoBox.Text = connectionInformationText;
            userAccessButton.Checked = true;
        }

      
        private void submitButton_Click(object sender, EventArgs e)
        {


            MessageLabel.Text = "";
            if ((passwordBox.Text == "") || (usernameBox.Text == ""))
            {
                MessageLabel.Text = "Both a username and a password are required.";
                return;
            }
            if (passwordBox.Text.Length > 25)//password too long - the DB stores up to 25 characters
            {
                MessageLabel.Text = "Max Password length is 25 characters.";
                return;
            }
            if (usernameBox.Text.Length > 25)//username too long max length in the database is 25 characters
            {
                MessageLabel.Text = "Max Username length is 25 characters.";
            }

            // Just a backdoor login so we can navigate the program.
            // I don't care how this is written just as long as it works correctly.
            if (usernameBox.Text == "test" && passwordBox.Text == "test")
            {
                Thread mainMenu = new Thread(() => Application.Run(new MainMenu()));
                mainMenu.Start();

                dbServer = dbServerBox.Text;
                dbPort = dbPortBox.Text;
                dbUsername = dbUsernameBox.Text;
                dbPassword = dbPasswordBox.Text;
                dbDatabase = dbDatabaseBox.Text;

                this.WindowState = FormWindowState.Minimized;
            }
            
            //Validating their login information with the database
            SQL_Queries login = new SQL_Queries();
            int role = login.validateLogin(usernameBox.Text, passwordBox.Text);


            switch (role)
            {
                case 0:     //Invalid Login
                    MessageBox.Show("Invalid Login");
                    break;

                case 1:     //Admin
                    Thread mainMenuThread = new Thread(() => Application.Run(new AdminMenu()));
                    mainMenuThread.SetApartmentState(ApartmentState.STA);
                    mainMenuThread.Start();
                    this.WindowState = FormWindowState.Minimized;
                    break;

                default:
                    MessageBox.Show("Unknown Error");
                    break;
            }
        }

        private void advancedButton_Click(object sender, EventArgs e)
        {
            int orgWidth = 770; // Original Width (really only need height, but leaving this here.)
            int orgHeight = 390; // Original Height
            int expHeight = 625; // Expanded Height

            // If the advanced button has been clicked, revert to original size and change text on button.
            if (isResized == true)
            {
                isResized = false;
                this.Height = orgHeight;  
                this.advancedButton.Text = "Advanced >>";
            }
            // If the advanced button hasn't been clicked yet, resize screen to show controls and change text on button.
            else if (isResized == false)
            {
                isResized = true;
                this.Height = expHeight;
                this.advancedButton.Text = "Advanced <<";
            }


        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["MyConnectionString"].ConnectionString = "Server=" + dbServerBox.Text + "," + dbPortBox.Text + "; Database=" + dbDatabaseBox.Text + "; User ID=" + dbUsernameBox.Text + "; Password=" + dbPasswordBox.Text + ";";
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
                string con = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(con);
                sqlcon.Open();
                sqlcon.Close();
                MessageBox.Show("Connection Successful");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Connection failed");
                //MessageBox.Show(exc.ToString());
            }

        }

        private void clearConfigLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dbServerBox.Text = "";
            dbPortBox.Text = "";
            dbUsernameBox.Text = "";
            dbPasswordBox.Text = "";
            dbDatabaseBox.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            char[] delim = { ';', ',', '=' };
            string[] parts = connection.Split(delim);
            dbServerBox.Text = parts[1];
            dbPortBox.Text = parts[2];
            dbDatabaseBox.Text = parts[4];
            dbUsernameBox.Text = parts[6];
            dbPasswordBox.Text = parts[8];
            usernameBox.Focus();
         
         //   this.KeyPreview = true;
       //     this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
          
        }

      /*  private void Login_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "A" || e.KeyCode.ToString() == "a")
            {
                advancedButton.PerformClick();
            }
        }*/

        private void adminAccessButton_CheckedChanged(object sender, EventArgs e)
        {
            /*cindCheckInOutButton.Enabled = !cindCheckInOutButton.Enabled;
            cindCheckInOutButton.Visible = !cindCheckInOutButton.Visible;
            fgCheckInButton.Enabled = !fgCheckInButton.Enabled;
            fgCheckInButton.Visible = !fgCheckInButton.Visible;
            alterationsButton.Enabled = !alterationsButton.Enabled;
            alterationsButton.Visible = !alterationsButton.Visible;

            usernameBox.Enabled = !usernameBox.Enabled;
            usernameBox.Visible = !usernameBox.Visible;
            usernameLabel.Enabled = !usernameLabel.Enabled;
            usernameLabel.Visible = !usernameLabel.Visible;
            

            passwordBox.Enabled = !passwordBox.Enabled;
            passwordBox.Visible = !passwordBox.Visible;
            passwordLabel.Enabled = !passwordLabel.Enabled;
            passwordLabel.Visible = !passwordLabel.Visible;

            submitButton.Enabled = !submitButton.Enabled;
            submitButton.Visible = !submitButton.Visible;*/

            panel1.Enabled = !panel1.Enabled;
            panel2.Enabled = !panel2.Enabled;
            panel2.Visible = !panel2.Visible;
        }

        private void cindCheckInOutButton_Click(object sender, EventArgs e)
        {
            Thread checkInThread = new Thread(() => Application.Run(new CheckIn()));
            checkInThread.Start();

            this.WindowState = FormWindowState.Minimized;
        }

        private void shoppMgtButton_Click(object sender, EventArgs e)
        {
            Thread shoppMgt = new Thread(() => Application.Run(new ManagePS()));
            shoppMgt.Start();

            Thread cindCheck = new Thread(() => Application.Run(new CheckIn()));
            cindCheck.Start();

            this.WindowState = FormWindowState.Minimized;
        }

        private void alterationsButton_Click(object sender, EventArgs e)
        {
            Thread alterationsThread = new Thread(() => Application.Run(new Alterations()));
            alterationsThread.Start();

            this.WindowState = FormWindowState.Minimized;
        }

        private void cindCheckOutButton_Click(object sender, EventArgs e)
        {
            Thread checkOutThread = new Thread(() => Application.Run(new CheckOut()));
            checkOutThread.Start();

            this.WindowState = FormWindowState.Minimized;
        }

        private void fgCheckinButton_Click(object sender, EventArgs e)
        {
            Thread fgCheckin = new Thread(() => Application.Run(new FGCheckIn()));
            fgCheckin.Start();

            this.WindowState = FormWindowState.Minimized;
        }
    }
}
