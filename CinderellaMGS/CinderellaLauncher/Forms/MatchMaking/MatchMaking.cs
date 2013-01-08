using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinderellaLauncher;
using BusinessLogic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Data.Odbc;
using System.Collections;

namespace CinderellaLauncher
{
    /*
     * MatchMaking.cs
     * 
     * -Pairs Cinderellas with a personal shopper
     * 
     * -Input: None
     * 
     * -Output:
     *      -Names of Cinderella's and personal shoppers
     *      -Lined up with who they are matched with
     *      
     * -Precondition:
     *      -Have to be checked-in
     *      
     * -Postcondition:
     *      -Personal Shoppers' status is changed in the database
     *      -Cinderellas' status is changed in the database
     * 
     */ 
    public partial class MatchMaking : Form
    {
        SQL_Queries sql = new SQL_Queries();
        ArrayList matchedPersonalShop = new ArrayList();
        public MatchMaking()
        {
           InitializeComponent();
            //starts the DB + output generation on a seperate thread
           Thread matches = new Thread(MakeMatches);
           matches.Start();
           //sets the draw mode for the listboxes to use the overridin method
           personalShopperListBox.DrawMode = DrawMode.OwnerDrawFixed;
           personalShopperListBox.DrawItem += personalShopperListBox_DrawItem;
           cinderellaListBox.DrawMode = DrawMode.OwnerDrawFixed;
           cinderellaListBox.DrawItem += cinderellaListBox_DrawItem;
        }

        //MakeMatches
        //does the matchmaking every 5 seconds
        //Input: information will be queried from the DB
        //Output: information displayed to the screen
        //precondition: the DB contains the information and that it is in a valid and correct state
        //postcondition: no threads are running and the db is still in a consistent and correct state
        public void MakeMatches()
        {
            try {
                
                while (true)
                {
                    //creates lists to hold the cinderellas and the godmothers that are pulled down from the db
                    List<CinderellaClass> Cinderella = new List<CinderellaClass>();
                    List<FairyGodmother> GodMother = new List<FairyGodmother>();
                    //List to store the cinderellas before they are sorted
                    List<CinderellaClass> UnsortCinderella = new List<CinderellaClass>();
                    //fills the lis tof unsorted cinderellas
                    GetCinderellas(ref UnsortCinderella);
                    //fills the godmothers list
                    GetGodMothers(ref GodMother);

                    //creates and then fills lists of paired cinderellas and godmothers
                    List<CinderellaClass> MatchedCinderella = new List<CinderellaClass>();
                    GetPairedCinderellas(ref MatchedCinderella);
                    List<FairyGodmother> MatchedGodMother = new List<FairyGodmother>();
                    GetPairedGodMother(ref MatchedGodMother, ref MatchedCinderella);

                    int Cinderellacount = UnsortCinderella.Count;//loop control 

                    

                    //gets the difference between checkin and appointment time
                    foreach (CinderellaClass cinder in UnsortCinderella)
                    {
                        cinder.diffFromappTime = EarlyLateTime(cinder.appTime);
                    }
                    
                    //sorts the cinderellas based on the difference between checkin and appointment time
                    
                    Cinderella = SortCinderellas(ref UnsortCinderella);

                    //Cinderella = UnsortCinderella;

                    //clears the gui
                    cinderellaListBox.Invoke(new Action(delegate()
                        {
                            cinderellaListBox.Items.Clear();
                        }));
                    personalShopperListBox.Invoke(new Action(delegate()
                        {
                            personalShopperListBox.Items.Clear();
                        }));
                    //outputs to the GUI
                    foreach (CinderellaClass name in MatchedCinderella)//output matched cinderellas
                    {
                        cinderellaListBox.Invoke(new Action(delegate()
                            {
                                
                                cinderellaListBox.Items.Add(name.getFirstName() + " " + name.getLastName());
                            }));
                    }
                    foreach (CinderellaClass name in Cinderella)//output nonmatched cinderellas
                    {
                        cinderellaListBox.Invoke(new Action(delegate()
                            {
                                if (cinderellaListBox.Items.Count < 15)//keeps the listbox from scrolling
                                {
                                    cinderellaListBox.Items.Add(name.getFirstName() + " " + name.getLastName());
                                }
                            }));
                    }
                    foreach (FairyGodmother godMotherName in MatchedGodMother)//output matched godMothers
                    {
                        personalShopperListBox.Invoke(new Action(delegate()
                            {
                                
                                personalShopperListBox.Items.Add(godMotherName.getFirstName() + " " + godMotherName.getLastName());
                                matchedPersonalShop.Add(godMotherName.getFirstName() + " " + godMotherName.getLastName());
                            }));
                    }
                    foreach (FairyGodmother godMotherName in GodMother)//output nonmatched godMothers
                    {
                        personalShopperListBox.Invoke(new Action(delegate()
                           {
                               if (personalShopperListBox.Items.Count < 15)//keeps the listbox from scrolling
                               {
                                   personalShopperListBox.Items.Add(godMotherName.getFirstName() + " " + godMotherName.getLastName());
                               }
                           }));
                    }

                    Thread.Sleep(2500);//2.5 seconds
                }
                
        }
            catch (Exception e){
                this.Close();
            }
        }

        //EarlyLateTime
        //calculates the how far from the appointment the cinderella is
        //Input: the appointment time
        //Output: return the number of minutes
        //precondition: the appointment time and the system time are correct and valid
        //postcondition: the difference between the arrival and appoitnment time is calculated and returned correctly
        public double EarlyLateTime(DateTime appointmentTime)
        {
            DateTime currentTime = Convert.ToDateTime("1/1/0001" + " " + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString());
            
           TimeSpan difference = (currentTime - appointmentTime);
           double duration = difference.Minutes + (difference.Hours * 60);
            return duration;
        }

        //SortCinderella
        //sorts the cinderellas
        //Input: the list of cinderellas to be sorted
        //Output: the sorted list of cinderellas
        //precondition: the unsorted list is in a correct and valid state
        //postcondition: the sorted list is correct and valid, and has been sorted correctly
        public List<CinderellaClass> SortCinderellas(ref List<CinderellaClass> unsortedCinderella)
        {
            //creates a list to hold the sorted cinderellas
            List<CinderellaClass> sortedCinderella = new List<CinderellaClass>();
            CinderellaClass cinderella;
            //for loops through the unsorted list and adds to the sorted list if they fall within the time range in each loop
            //checks for those 15 minutes or less early but not late
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i];
                if ((cinderella.diffFromappTime <= 15) && (cinderella.diffFromappTime > 0))
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                }
            }
            //checks for those 30 minutes or less early but not late
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i];
                if (cinderella.diffFromappTime <= 30)
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                }
            }
            //checks for those 45 minutes or less early but not late
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i];
                if (cinderella.diffFromappTime <= 45)
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                }
            }
            //checks for those 60 minutes or less early but not late
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i];
                if (cinderella.diffFromappTime <= 60)
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                } 
            }
            //checks for those more than 60 minutes early
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i]; 
                if (cinderella.diffFromappTime > 60)
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                }
            }
            //checks for those 15 minutes or less late, but not early
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i];
                if (cinderella.diffFromappTime >= -15)
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                }
            }
            //checks for those 30 minutes or less late, but not early
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i];
                if (cinderella.diffFromappTime >= -30)
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                }
            }
            //checks for those 45 minutes or less late, but not early
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i];
                if (cinderella.diffFromappTime >= -45)
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                }
            }
            //checks for those 60 minutes or less late, but not early
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i];
                if (cinderella.diffFromappTime >= -60)
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                }
            }
            //checks for those more than 60 minutes late
            for (int i = 0; i < unsortedCinderella.Count; i++)
            {
                cinderella = unsortedCinderella[i];
                if (cinderella.diffFromappTime < -60)
                {
                    sortedCinderella.Add(cinderella);
                    unsortedCinderella.Remove(cinderella);
                    continue;
                }
            }
            return sortedCinderella;
        }

        //GetCinderellas
        //Fills a list with the cindererllas from the DB
        //Input: a list to hold the cinderellas, and information pulled down from the DB
        //Output: the list of cinderellas has been filled with at most 15 cinderellas
        //precondition: the DB is in a correct and valid state
        //postcondition: the DB is still in a correct and valid state,a nd no duplicate cinderellas ahve been added to the list
        public void GetCinderellas(ref List<CinderellaClass> Cinderella)
        {
            //sets up the query to get 15 cinderellas that have the correct status
            string query = sql.CinderellasList(15,2);
            //sets up the sql connection and sqlDataReader
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //read from DB into cinderella class
                CinderellaClass cinder = new CinderellaClass(reader.GetString(1), reader.GetString(2), reader.GetInt32(0), Convert.ToDateTime(reader.GetDateTime(3)));
                //check to see if the cinderella is already in the list
                bool cinderellaExists = false;
                foreach (CinderellaClass cinderellaToAdd in Cinderella)
                {
                    if (cinderellaToAdd.getCinderellaID() == cinder.getCinderellaID())
                    {
                        cinderellaExists = true;
                    }
                }
                //if the cinderella doesnt exist add them
                if (cinderellaExists == false)
                {
                    Cinderella.Add(cinder);
                }
            }
            //clean up
            reader.Close();
            conn.Close();
        }

        //GetGodMothers
        //fills a list with GodMothers from the DB
        //Input: a list to hold the GodMothers, and information pulled down from the DB
        //Output: the list of GodMothers has been filled with at most 15 GodMothers
        //precondition: the DB is in a correct and valid state
        //postcondition: the DB is still in a correct and valid state,a nd no duplicate GodMothers have been added to the list
        public void GetGodMothers(ref List<FairyGodmother> godMother)
        {
            //sets up the query to get 15 pending godmothers
            string query = sql.PersonalShoppersList(15, 4);
            //sets up the connection and the sqlDataReader
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //read from DB into godmother class
                FairyGodmother NewFairyGodmother = new FairyGodmother(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                bool canInsert = true;
                foreach (FairyGodmother shopper in godMother)
                {
                    //check to see if the godmother is already in the list and if not add them to it
                    if (shopper.getFairyID() == NewFairyGodmother.getFairyID())
                    {
                        canInsert = false;
                    }
                }
                if (canInsert)
                {
                    godMother.Add(NewFairyGodmother);
                }
            }
            //clean up
            reader.Close();
            conn.Close();
        }

        //GetPairedCinderellas
        //gets up to 15 paired cinderellas
        //Input: a List to hold the paired cinderellas, and information pulled down from the DB
        //Output: the list has been filled with at most 15 paired cinderellas
        //precondition: the DB is in a correct and valid state
        //postcondition: the DB is stil in a correct and valid state, and no suplicates have been added to the list
        public void GetPairedCinderellas(ref List<CinderellaClass> PairedCinderella)
        {
            //sets up the query to get at most 15 paired cinderellas
            string query = sql.CinderellasList(15, 3);
            //sets up the connection and the sqlDataReader
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //read from DB into cinderella class
                CinderellaClass cinder = new CinderellaClass(reader.GetString(1), reader.GetString(2), reader.GetInt32(0), reader.GetDateTime(3));
                bool canInsert = true;
                foreach (CinderellaClass cinderella in PairedCinderella)
                {//checks to see if the paired cinderella is already in the list and if not add them to it
                    if (cinderella.getCinderellaID() == cinder.getCinderellaID())
                    {
                        canInsert = false;
                    }
                }
                if (canInsert)
                {
                    PairedCinderella.Add(cinder);
                }
            }
            //clean up
            reader.Close();
            conn.Close();
        }

        //GetPairedGodMother
        //gets the godmothers who are paired to each of the cinderellas in the pairedcinderella list
        //Input: the list of paired cinderellas, a list to hold the godmothers, and information pulled down from the db
        //Output: the godmother list filled with the godmothers paired to the cinderellas
        //precondition: the pairedcinderella and the DB are in a correct and valid state
        //postcondition: the godmother list has correctly filled, and the DB is still in a correct and valid state
        public void GetPairedGodMother(ref List<FairyGodmother> PairedGodMother, ref List<CinderellaClass> PairedCinderella)
        {
            //loops through to get the godmother that is matched to each cinderella
            foreach (CinderellaClass cinderella in PairedCinderella)
	    {
            //sets up the query to get the godmother paired to the cinderella
            string query = sql.PairedPersonalShoppers(cinderella.getCinderellaID());
            //sets up the connection and the sqlDataReader
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //read from DB into godmother class
                FairyGodmother NewFairyGodmother = new FairyGodmother(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                bool canInsert = true;
                foreach (FairyGodmother shopper in PairedGodMother)
                {//checks to see if the godmotehr is already in the list and if not add them to it
                    if (shopper.getFairyID() == NewFairyGodmother.getFairyID())
                    {
                        canInsert = false;
                    }
                }
                if (canInsert)
                {
                    PairedGodMother.Add(NewFairyGodmother);
                }
            }
            //clean up
            reader.Close();
            conn.Close();
        }
        }

        //personalShopperListBox_DrawItem
        //overrides the default draw item fucntion, inorder to set every other row to be shaded pink, instead of white
        //Input: the lsitbox and row index
        //Output: the row and background have been drawn with the correct colors
        //precondition: the inputed index is correct and valid
        //postcondition: every item has been drawn correctly
        public void personalShopperListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //sets up the background for the listbox
            e.DrawBackground();
            Graphics g = e.Graphics;
            //gets the index for the row in the listbox
            int currentIndex = e.Index;
            //draws the background snow color
            g.FillRectangle(new SolidBrush(Color.Snow), e.Bounds);
            ListBox paintBox = (ListBox)sender;
             SizeF textSize = new SizeF();
             float nameLength = 0;
             float namePos = 0;
            try{
             textSize = g.MeasureString(paintBox.Items[e.Index].ToString(), e.Font);
             nameLength = g.MeasureString(paintBox.Items[e.Index].ToString(), e.Font).Width;
             namePos = paintBox.Width - nameLength;
            }catch(ArgumentOutOfRangeException f)
            {
            }
            //holds the color to set the highlight to be
            Color prettyColor;
            if (currentIndex >= 0 && currentIndex < personalShopperListBox.Items.Count)
            {
                //if the row is even numbered use snow, otherwise use pink
                if (currentIndex % 2 == 0)
                {
                    prettyColor = Color.Snow;
                }
                else
                {
                    prettyColor = Color.Pink;
                }
                //draws the highlight
                g.FillRectangle(new SolidBrush(prettyColor), e.Bounds);

               
                
                if (paintBox.Items[e.Index].ToString().Equals(matchedPersonalShop[e.Index].ToString()))
                {
                  
                    g.DrawString(paintBox.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Black), namePos, e.Bounds.Top);
                }
                else
                {
                    g.DrawString(paintBox.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Black), e.Bounds, StringFormat.GenericDefault);
                }
                e.DrawFocusRectangle();
            }
      
        }

        //cinderellaListBox_DrawItem
        //overrides the default draw item fucntion, inorder to set every other row to be shaded pink, instead of white
        //Input: the lsitbox and row index
        //Output: the row and background have been drawn with the correct colors
        //precondition: the inputed index is correct and valid
        //postcondition: every item has been drawn correctly
        public void cinderellaListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //sets up the background for the listbox
            e.DrawBackground();
            Graphics g = e.Graphics;
            //gets the index for the row in the listbox
            int thecurrentIndex = e.Index;
            //draws the background snow color
            g.FillRectangle(new SolidBrush(Color.Snow), e.Bounds);
            ListBox otherpaintBox = (ListBox)sender;
            //holds the color to set the highlight to be
            Color otherprettyColor;
            if (thecurrentIndex >= 0 && thecurrentIndex < cinderellaListBox.Items.Count)
            {
                //if the row is even numbered use snow, otherwise use pink
                if (thecurrentIndex % 2 == 0)
                {
                    otherprettyColor = Color.Snow;
                }
                else
                {
                    otherprettyColor = Color.Pink;
                }
                //draws the highlight
                g.FillRectangle(new SolidBrush(otherprettyColor), e.Bounds);
              
                g.DrawString(otherpaintBox.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Black), e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
       
        }

        private void MatchMaking_Load(object sender, EventArgs e)
        {

        }
        }
    }

