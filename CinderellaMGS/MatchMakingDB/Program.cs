using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Data.Odbc;
using CinderellaLauncher;
using BusinessLogic;

namespace CinderellaLauncher
{
    class Program
    {
        //creates an object to access the db queries
        SQL_Queries sql = new SQL_Queries();
        //main
        //Purpose: to handle the db interactions and the loops that occur for amtchmaking
        //input: None, except for DB interactions
        //Output: updates sent back to the DB
        //preconditions: this program is not being made anywhere and the DB is functional
        //postconditions: the db has been left in a consistent state, all matches have been updated to the DB, and matchmaking is no longer running
        static void Main()
        {

            try
            {
                //create two lists to keep track of cinderellas and godmothers who have been matched
                List<int> oldCinderellas = new List<int>();
                List<int> oldGodMothers = new List<int>();
                while (true)
                {
                    //creates lists to hold the cinderellas/godmothers pulled down from the db
                    //theese will be "deleted" at the start of each loop
                    List<CinderellaClass> Cinderella = new List<CinderellaClass>();
                    List<FairyGodmother> GodMother = new List<FairyGodmother>();
                    //holds the unsorted cinderellas
                    List<CinderellaClass> UnsortCinderella = new List<CinderellaClass>();
                    //creates an object to do the matchmaking
                    Program match = new Program();
                    //gets the cinderellas from the db
                    match.GetCinderellas(ref UnsortCinderella, Cinderella.Count, ref oldCinderellas);
                    //gets the godmothers from the db
                    match.GetGodMothers(ref GodMother, GodMother.Count, ref oldGodMothers);


                    //list to hold the matchedcinderellas from the DB
                    List<CinderellaClass> MatchedCinderella = new List<CinderellaClass>();
                    match.GetPairedCinderellas(ref MatchedCinderella); //get the matched cinderellas inorder to refreash the screen

                    List<FairyGodmother> MatchedGodMother = new List<FairyGodmother>();//get the cinderellas that have been matched from the DB
                    match.GetPairedGodMother(ref MatchedGodMother, ref MatchedCinderella);//show the godmother that has been matched to the cinderella
                    MatchMakingLogic Logic = new MatchMakingLogic();

                    int Cinderellacount = UnsortCinderella.Count;//loop control variable



                    //gets the difference between checkin and appointment time
                    foreach (CinderellaClass cinder in UnsortCinderella)
                    {
                        cinder.diffFromappTime = match.EarlyLateTime(cinder.appTime);
                    }

                    //sorts the cinderellas based on the difference between checkin and appointment time

                    Cinderella = match.SortCinderellas(ref UnsortCinderella);

                    for (int i = 0; i < Cinderellacount; i++)//makes the matches
                    {
                        Logic.MakeMatch(ref Cinderella, ref GodMother, ref MatchedCinderella, ref MatchedGodMother);
                    }
                    //create lists to hold the matched ids of the cinderellas and the god mothers
                    List<int> MatchedCinderellaID = new List<int>();
                    List<int> MatchedGodMotherID = new List<int>();
                    //fill each of the lists
                    foreach (CinderellaClass Cinder in MatchedCinderella)
                    {
                        MatchedCinderellaID.Add(Cinder.getCinderellaID());
                    }
                    foreach (FairyGodmother PersonalShopper in MatchedGodMother)
                    {
                        MatchedGodMotherID.Add(PersonalShopper.getFairyID());
                    }
                    if ((MatchedCinderellaID.Count > 0) && (MatchedGodMotherID.Count > 0))
                    {//update the matches to the DB
                        SQL_Queries queries = new SQL_Queries();
                        //loops through all the matches nd make the appropiate DB action
                        for (int i = 0; i < MatchedCinderellaID.Count; i++)
                        {
                            if (queries.FGCurrentStatus(MatchedGodMotherID[i]) == 4)
                            {
                                //update the list of cinderellas taht ahve been through matchmaking
                                oldCinderellas.Add(MatchedCinderellaID[i]);

                                //pair the cinderellas
                                queries.pairCinderella(MatchedCinderellaID[i], MatchedGodMotherID[i]);
                                //set the status of the cinderella and the fairy god mother
                                if (queries.CinderellaCurrentStatus(MatchedCinderellaID[i]) != 3)
                                {
                                    queries.setCinderellaStatus(MatchedCinderellaID[i].ToString(), 3);
                                }
                                if (queries.FGCurrentStatus(MatchedGodMotherID[i]) != 2)
                                {
                                    queries.setFGStatus(MatchedGodMotherID[i].ToString(), 2);
                                }
                            }

                        }
                    }
                    //clear the lists of ID's
                    MatchedGodMotherID.Clear();
                    MatchedCinderellaID.Clear();
                    //pause execution for 5 seconds
                    Thread.Sleep(5000);
                }

            }
            catch (Exception e)
            {
                //this will hopefully get around random crashes
                Thread bug = new Thread(() => Main());
                bug.Start();
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
        //Input: the list of cindererllas that have been through matchmaking before, a list to fill with cindererllas, and the amount to get
        //Output: updated list of cindererllas pulled down from the db
        //precondition: all inputs are valid, and the database is functioning correctly and the data in it has no errors
        //postcondition: the queue is generated correctly
        void GetCinderellas(ref List<CinderellaClass> Cinderella, int count, ref List<int> oldCinderellas)
        {
            //sets up the query to get 15 cinderellas that have the correct status
            string query = sql.CinderellasList(15, 2);
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
                bool priority = false;
                foreach (CinderellaClass cinderellaToAdd in Cinderella)
                {
                    if (cinderellaToAdd.getCinderellaID() == cinder.getCinderellaID())
                    {
                        cinderellaExists = true;
                    }
                }
                if (cinderellaExists == false)
                    //cinderella doesnt exist, add to list
                {
                    if (count < 15)
                    {
                        //check to see if the cinderella has been through before
                        foreach (int id in oldCinderellas)
                        {
                            if (cinder.getCinderellaID() == id)
                            {
                                priority = true;
                            }
                        }
                        if (priority)
                            //cinderella has been through before, she gets added to the front of the queue
                        {
                            Cinderella.Insert(0, cinder);
                        }
                        else
                            //cinderella has not been through before, added normally
                        {
                            Cinderella.Add(cinder);
                        }
                    }
                    count += 1;
                }
            }
            //clean up
            reader.Close();
            conn.Close();
        }

        //GetGodMothers
        //Fills a list with the GodMothers from the DB
        //Input: the list of GodMothers that have been through matchmaking before, a list to fill with GodMothers, and the amount to get
        //Output: updated list of GodMothers pulled down from the db
        //precondition: all inputs are valid, and the database is functioning correctly and the data in it has no errors
        //postcondition: the queue is generated correctly
        void GetGodMothers(ref List<FairyGodmother> godMother, int count, ref List<int> oldGodMothers)
        {   //sets up the query to get 15 pending godmothers
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
                bool godmotherexists = false;
                bool priority = false;
                //check to see if the god motehr is already in the list
                foreach (FairyGodmother shopper in godMother)
                {
                    if (NewFairyGodmother.getFairyID() == shopper.getFairyID())
                    {
                        godmotherexists = true;
                    }
                }
                //godmother doesnt exist, time to add it to the list
                if (godmotherexists == false)
                {
                    //check to see if the god motehr has been through before
                    foreach (int id in oldGodMothers)
                    {
                        if (NewFairyGodmother.getFairyID() == id)
                        {
                            priority = true;
                        }
                    }
                    if (priority)
                        //god mother has been through before add to the front of the queue
                    {
                        godMother.Insert(0, NewFairyGodmother);
                    }
                    else
                        //add normally
                    {
                        godMother.Add(NewFairyGodmother);
                    }
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
    }
        }