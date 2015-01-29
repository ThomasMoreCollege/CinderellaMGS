using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Printing;
using IDAutomation_FontEncoder;

namespace CinderellaLauncher
{
    /*
     * AdminMenu.cs
     *
     * -Allows the administrator to access forms that are not available to other users
     * such as pairing, importing cinderellas or fairy godmothers, database management,
     * status control for fairy godmothers, the master search form, and access to all user
     * forms
     *
     * -Input: None
     *
     * -Output: None
     *
     * -Precondition:
     *      -Must be logged in as administrator
     *     
     * -Postcondition:
     *      -Taken to the form that is specified on the selected button
     *
     */
   


    public partial class AdminMenu : Form
    {
        SQL_Queries query = new SQL_Queries();
        clsBarCode PrintLabel = new clsBarCode();
        private DataTable PG;
        private BindingSource PGBindingSource = new BindingSource();

        private SqlCommand updateCommand;
        private SqlDataAdapter PrintGridAdapter;

       
        List<Thread> FormThreads = new List<Thread>();//keeps track of form threads for latter termination
 
        public static ProgressBar cinderellaProgess = new ProgressBar();
        public AdminMenu()
        {
            InitializeComponent();
            this.Controls.Add(cinderellaProgess);
           
        }
       
        private void statusControlButton_Click(object sender, EventArgs e)
        {
            Thread statusControl = new Thread(() => Application.Run(new StatusControl()));
            statusControl.Name = "statusControl";
            statusControl.SetApartmentState(ApartmentState.STA);
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "statusControl")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
 
                MessageBox.Show("Status Control window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                statusControl.Start();
                FormThreads.Add(statusControl);//adds the thread to the list
            }
        }
 
        private void databaseMgtButton_Click(object sender, EventArgs e)
        {
            Thread dbMgt = new Thread(() => Application.Run(new DBManagement()));
 
            dbMgt.Name = "dbMgt";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "dbMgt")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
 
                MessageBox.Show("DBManagement window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dbMgt.Start();
                FormThreads.Add(dbMgt);//adds the thread to the list
            }
        }
        private void accessAllButton_Click(object sender, EventArgs e)
        {
            Thread allForms = new Thread(() => Application.Run(new MainMenu()));
            allForms.Name = "allForms";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "allForms")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {

                MessageBox.Show("DBManagement window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                allForms.Start();
                FormThreads.Add(allForms);//adds the thread to the list
            }
        }

        private void viewCinderellasButton_Click(object sender, EventArgs e)
        {
            Thread viewCinderellas = new Thread(() => Application.Run(new ViewCinderellas()));
            viewCinderellas.SetApartmentState(ApartmentState.STA);
            viewCinderellas.Start();
        }

        //importCinderella_Click
        //handles the importcinderella buttun and calls the function to import the cinderella excel file into the db
        //Input: UI interaction from the user
        //Output: the readcinderella method of appointmentlistio is called
        //precondition: the db is connectable and querable. the user wished to import the cinderella information into the db
        //postcondition: the excel file has been read into the DB
        public void importCinderella_Click(object sender, EventArgs e)
        {
            // ProgressBar cinderellaProgess = new ProgressBar();
            cinderellaProgess.Location = new System.Drawing.Point(328, 184);
            cinderellaProgess.Name = "cinderellaImportStatus";
            cinderellaProgess.Width = 163;
            cinderellaProgess.Height = 25;
            cinderellaProgess.Minimum = 0;
            cinderellaProgess.Maximum = 100;
            cinderellaProgess.Value = 0;
            cinderellaProgess.Style = ProgressBarStyle.Continuous;
            cinderellaProgess.ForeColor = Color.YellowGreen;

            // cinderellaProgess.SetBounds(328, 126, 163, 30);

            cinderellaProgess.Show();
            cinderellaProgess.Visible = true;
            cinderellaProgess.BringToFront();
            BusinessLogic.ApointmentListIO gettingCinderellas = new BusinessLogic.ApointmentListIO();
            gettingCinderellas.readCinderellas();

        }

        //importGodMothers_Click
        //handles the importGodMothers buttun and calls the function to import the godmothers into the db
        //Input: UI interaction from the user
        //Output: the readGodmother method of appointmentlistio is called
        //precondition: the db is connectable and querable. the user wished to import the godmother information into the db
        //postcondition: the excel file has been read into the DB
        public void importGodMothers_Click(object sender, EventArgs e)
        {
            BusinessLogic.ApointmentListIO gettingGodmothers = new BusinessLogic.ApointmentListIO();
            gettingGodmothers.readGodmothers();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chatNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread chatNow = new Thread(() => Application.Run(new ClientApp()));
            chatNow.Start();
        }

        private void pairingButton_Click(object sender, EventArgs e)
        {
            Thread pair = new Thread(() => Application.Run(new MatchMaking()));
            pair.Start();
            Process.Start("C:\\GitHub\\CinderellaMGS\\CinderellaMGS\\MatchMakingDB\\bin\\Debug\\MatchMakingDB");
        }

        private void matchmakingButton_Click(object sender, EventArgs e)
        {
            //    Thread matchProcess = new Thread(() => Application.Run(new Program()));

            // matchProcess.SetApartmentState(ApartmentState.STA);
            //   matchProcess.Start();
            // pairingProcess.
        }

        private void masterSearchButton_Click(object sender, EventArgs e)
        {
            Thread ms = new Thread(() => Application.Run(new MasterSearch()));
            ms.Start();
        }

        private void startChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Chat_Server.exe");
        }

        private void allCinderellasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread P = new Thread(() => Application.Run(new CinderellaLauncher.Forms.Print()));
           P.Start();
        }

        private void allFairyGodmothersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread FG = new Thread(() => Application.Run(new CinderellaLauncher.Forms.FGPrint()));
            FG.Start();
        }
    }
}