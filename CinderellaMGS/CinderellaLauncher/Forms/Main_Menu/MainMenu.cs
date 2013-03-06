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
using System.Drawing.Drawing2D;


namespace CinderellaLauncher
{
    /*
     * MainMenu.cs
     * 
     * -Visible to the administrator only, allows them to have access to all the forms
     * 
     * -Input: None
     * 
     * -Output: None
     * 
     * -Precondition:
     *      -Must be logged in as an admin
     *      
     * -Postcondition:
     *      -The selected button opens the specified form
     * 
     */ 
    public partial class MainMenu : Form
    {
        List<Thread> FormThreads = new List<Thread>();//keeps track of form threads for latter termination
        public MainMenu()
        {
            InitializeComponent();

            
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread checkIn = new Thread(() => Application.Run(new CheckIn()));
            checkIn.Name = "checkIn";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "checkIn")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                
                MessageBox.Show("Check-In window already open.","Already Running",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                checkIn.Start();
                FormThreads.Add(checkIn);//adds the thread to the list
            }
        }

        private void checkOutButton_Click(object sender, EventArgs e)
        {
            Thread checkOut = new Thread(() => Application.Run(new CheckOut()));
            checkOut.Name = "checkOut";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "checkOut")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("Check-Out window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                checkOut.Start();
                FormThreads.Add(checkOut);//adds the thread to the list
            }
        }

        private void alterationsButton_Click(object sender, EventArgs e)
        {
            Thread alterations = new Thread(() => Application.Run(new Alterations()));
            alterations.Name = "alterations";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "alterations")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("Alterations window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                alterations.Start();
                FormThreads.Add(alterations);//adds the thread to the list
            }
        }


        private void managePSButton_Click(object sender, EventArgs e)
        {
            Thread managePS = new Thread(() => Application.Run(new ManagePS()));
            managePS.Name = "managePS";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "managePS")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("Shopping Management window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                managePS.Start();
                FormThreads.Add(managePS);//adds the thread to the list
            }
        }

        private void matchMakingButton_Click(object sender, EventArgs e)
        {
            Thread matchMaking = new Thread(() => Application.Run(new MatchMaking()));
            matchMaking.Name = "matchMaking";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "matchMaking")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("Match Making window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                matchMaking.Start();
                FormThreads.Add(matchMaking);//adds the thread to the list
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

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

        private void addCinderellaButton_Click(object sender, EventArgs e)
        {
            Thread addCinderella = new Thread(() => Application.Run(new AddCinderella()));
            addCinderella.Name = "addCinderella";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "addCinderella")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("Add Cinderella window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                addCinderella.Start();
                FormThreads.Add(addCinderella);//adds the thread to the list
            }
           
        }

        private void PSCheckin_Click(object sender, EventArgs e)
        {
            Thread fGCheckin = new Thread(() => Application.Run(new FGCheckIn()));
            fGCheckin.Name = "fGCheckin";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "fGCheckin")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("Fairy Godmother Check-In window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fGCheckin.Start();
                FormThreads.Add(fGCheckin);//adds the thread to the list
            }
        }

        private void chatOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //this is where the threading of the online chat will prompt
            Thread chat = new Thread(() => Application.Run(new ClientApp()));
            chat.Name = "chat";
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
                chat.Start();
                FormThreads.Add(chat);//adds the thread to the list
            }
        }

        private void viewCinderellasButton_Click(object sender, EventArgs e)
        {
            Thread viewCinderellas = new Thread(() => Application.Run(new ViewCinderellas()));
            viewCinderellas.Name = "viewCinderellas";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "viewCinderellas")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("View Cinderellas window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                viewCinderellas.Start();
                FormThreads.Add(viewCinderellas);//adds the thread to the list
            }
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            Thread administration = new Thread(() => Application.Run(new AdminMenu()));
            administration.SetApartmentState(ApartmentState.STA);
            administration.Name = "administration";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "administration")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("Administration window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                administration.Start();
                FormThreads.Add(administration);//adds the thread to the list
            }
        }

        private void aboutCinderellaMGSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread aboutThread = new Thread(() => Application.Run(new About()));
            aboutThread.Start();
        }
    }
}
