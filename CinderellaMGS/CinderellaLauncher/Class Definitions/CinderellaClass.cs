using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using CinderellaLauncher;

namespace CinderellaLauncher
{
    public class CinderellaClass
    {
        //include the connection string;
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        /*These variables(right below) are declare to be assigned to*/

        private int cinderellaID;           //the cinderella ID is set as a primary key to determine the cinderellas
        private string cinderellaFirst;     //cinderella first name
        private string cinderellaLast;      //cinderella last name
        public DateTime appDate;           //cinderella appointment date
        public DateTime appTime;           //cinderella appointment time
        private string cinderellaEmail;     //cinderella email address
        private string cinderellaPhone;     //cinderella phone number
        public int RequestedGodMother;      //the ID of the requested Fairy Godmother  a value of 0 means non requested
        public bool SpecialNeeds;         //wther or not the Cinderella is special needs
        public double diffFromappTime;         //holds the difference in minutes from when they checked in to when the appointment is 

       // public Class_Definitions.Package Package; //Accesses the Package that is associated with this Cinderella

       
        //CinderellaClass
        //constructor for the cinderella class
        //Input: ID, first and lastname, appointment datetime, timestamp, email, and phone
        //Output: generated cinderella class object
        //precondition: information is correct and valid
        //postcondition: object is generated correctly
        public CinderellaClass(int ID, string firstName, string lastName, DateTime appointment, DateTime timeStamp, string email, string phone)
        {
            //set information
            cinderellaID = ID;
            cinderellaFirst = firstName;
            cinderellaLast = lastName;
            appDate = appointment;
            appTime = timeStamp;
            cinderellaEmail = email;
            cinderellaPhone = phone;
            RequestedGodMother = 0;
            SpecialNeeds = false;
        }

        //CinderellaClass
        //default constructor
        //Input: none
        //Output: blank object generated
        //precondition: none
        //postcondition object generated succesfully
        public CinderellaClass()
        {

        }

        //CinderellaClass
        //constructor for the cinderella class
        //Input: ID, first and lastname, and appointment datetime
        //Output: generated cinderella class object
        //precondition: information is correct and valid
        //postcondition: object is generated correctly
        public CinderellaClass(string firstName, string lastName, int id, DateTime apptTime)
        {
            cinderellaID = id;
            cinderellaFirst = firstName;
            cinderellaLast = lastName;
            appTime = apptTime;
            RequestedGodMother = 0;
            SpecialNeeds = false;
        }

        //setCinderellaFirstName
        //sets the name of the cinderella
        //Input: the first name of the cinderella
        //Output: firstname is updated
        //precondition: the name is correct and valid
        //postcondition: the name has been set correctly
        public void setCinderellaFirstName(string Name)
        {
            cinderellaFirst = Name;
        }

        //getCinderellaID
        //returns the id of the cinderella
        //Input: none
        //Output: returns the id
        //precondition: the cinderella has an ID
        //postcondition: the id is returned succesfully
        public int getCinderellaID()
        {
            return cinderellaID;                  //return the primary key
        }

        //getFirstName
        //returns the first name of the cinderella
        //Input: none
        //Output: returns the first name
        //precondition: the cinderella has an first name
        //postcondition: the first name is returned succesfully
        public string getFirstName()
        { 
            return cinderellaFirst;              //return the first name
        }

        //getLastName
        //returns the last name of the cinderella
        //Input: None
        //Output: returns the last name
        //precondition: the cinderella has a last name
        //postcondition: the last anme is returned correctly
        public string getLastName()
        {  
            return cinderellaLast;               //return the last name
        }

        //getCinderellaDate
        //returns the appointment date
        //Input: none
        //Output: returns the appointment date
        //precondition: the cinderella has an appointment date
        //postcondition: the appointment date is returned succesfully
        public DateTime getCinderellaDate()
        {           
            return appDate;                      //return the appointment date
        }

        //getCinderellaTime
        //returns the appointment time
        //Input: none
        //Output: returns the appointment time
        //precondition: the cinderella has an appointment time
        //postcondition: the appointment time is returned succesfully
        public DateTime getCinderellaTime()
        {             
            return appTime;                      //return the appointment time
        }

        //getCinderellaEmail
        //returns the email of the cinderella
        //Input: none
        //Output: returns the email
        //precondition: the cinderella has an email
        //postcondition: the email is returned succesfully
        public string getCinderellaEmail()
        {
            return cinderellaEmail;              //return cinderella email
        }

        //getCinderellaPhone
        //retuns the cinderella's phone number
        //Input: none
        //Output: returns the phone number
        //precondition: the cinderella has a phone number
        //postcondition: the phone number is returned succesfully
        public string getCinderellaPhone()
        {
            return cinderellaPhone;              //return cinderella phone
        }

        public void add()
        {

        }
    }
}
