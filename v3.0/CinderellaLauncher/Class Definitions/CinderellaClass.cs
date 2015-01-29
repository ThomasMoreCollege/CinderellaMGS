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

        private int cinderellaID;                  //the cinderella ID is set as a Primary Key(PK) to determine the Cinderellas.
        private string cinderellaFirst;           //cinderella First Name
        private string cinderellaLast;           //cinderella Last Name
        public DateTime appDate;                //cinderella Appointment Date
        public DateTime appTime;               //cinderella Appointment Time
        private string cinderellaEmail;       //cinderella E-mail Address
        private string cinderellaPhone;      //cinderella Phone Number
        public int RequestedGodMother;      //the ID of the requested Fairy Godmother. A value of '0' indicates that, that Fairy Godmother was not requested. 
        public bool SpecialNeeds;          //because this is a boolean, it asks whether or not the Cinderella is to be categorized as Special Needs in the format of True/False (bool). 
        public double diffFromappTime;    //holds the difference - in minutes - from when either Fairy Godmothers OR Cinderellas checked in to when their appointment is. 

       // public Class_Definitions.Package Package; //Accesses the Package that is associated with this Cinderella (OLD CODE----------------KEPT AS REFERENCE AND POSSIBLY BACK UP/WORKAROUND MATERIAL.

       
        //declaration of the CinderellaClass
        //constructor for the CinderellaClass
        //Input: ID, First Name, Last Name, Appointment Date/Time, Timestamp, E-Mail, Phone #(string format is used for Phone #).
        //Output: a generated cinderella class object
        //Pre-condition: The information must be correct and must be valid.
        //Post-condition: The object is generated correctly. 
        public CinderellaClass(int ID, string firstName, string lastName, DateTime appointment, DateTime timeStamp, string email, string phone)
        {
            //set information
            cinderellaID = ID;                          //cinderella ID
            cinderellaFirst = firstName;               //First Name
            cinderellaLast = lastName;                //Last Name
            appDate = appointment;                   //Appointment
            appTime = timeStamp;                    //Timestamp
            cinderellaEmail = email;               //E-Mail
            cinderellaPhone = phone;              //Phone #
            RequestedGodMother = 0;              //Requested Godmother Status. '1' = Requested. '0' = Not Requested.
            SpecialNeeds = false;               //indicates whether or not the Cinderella is categorized as a Special Needs individual. 
        }

        //CinderellaClass
        //This is the default constructor.
        //Input: None.
        //Output: A blank object is generated.
        //Pre-condition: None.
        //Post-condition: An object is generated succesfully.
        
        public CinderellaClass()
        {

        }

        //CinderellaClass
        //This is the constructor for the CinderellaClass.
        //Input: ID, first and lastname, and appointment datetime
        //Output: A CinderellaClass object is generated. 
        //Pre-condition: information is correct and valid
        //Post-condition: A CinderellaClass object is generated correctly and successfully.
        public CinderellaClass(string firstName, string lastName, int id, DateTime apptTime)
        {
            cinderellaID = id;                   //Cinderella ID
            cinderellaFirst = firstName;        //First Name
            cinderellaLast = lastName;         //Last Name
            appTime = apptTime;               //Appointment Time
            RequestedGodMother = 0;          //Requested Godmother Status. '1' = Requested. '0' = Not Requested.
            SpecialNeeds = false;           //indicates whether or not the Cinderella is categorized as a Special Needs individual.
        }

        //setCinderellaFirstName
        //Sets the name of a cinderella.
        //Input: The First Name of a cinderella.
        //Output: 'firstname' is updated successfully.
        //Pre-condition: The name must be correct and valid.
        //Post-condition: The name is valid has been set correctly.
        public void setCinderellaFirstName(string Name)
        {
            cinderellaFirst = Name;
        }

        //getCinderellaID
        //returns the ID of a cinderella.
        //Input: None.
        //Output: Returns the ID of a cinderella.
        //Pre-condition: The cinderella has an ID.
        //Post-condition: The ID is returned succesfully.
        public int getCinderellaID()
        {
            return cinderellaID;                  //This returns the primary key = cinderellaID.
        }

        //getFirstName
        //Returns the first name of a cinderella.
        //Input: None.
        //Output: Returns the First Name of a cinderella.
        //Pre-condition: the cinderella has a First Name.
        //Post-condition: the First Name is returned succesfully.
        public string getFirstName()                //gets the first name of a cinderalla. 
        { 
            return cinderellaFirst;              //return the First Name. 
        }

        //getLastName
        //returns the last name of the cinderella
        //Input: None
        //Output: Returns the last name of a cinderella.
        //Pre-condition: the cinderella has a Last Name.
        //Post-condition: the last name is returned correctly.
        public string getLastName()                 //gets the Last Name of a cinderella.
        {  
            return cinderellaLast;               //return the Last Name.
        }

        //getCinderellaDate
        //Returns the appointment date of a cinderella.
        //Input: None. 
        //Output: Returns the appointment date of a cinderella.
        //Pre-condition: the cinderella has an appointment date.
        //Post-condition: the appointment date of the cinderella is returned succesfully.
        public DateTime getCinderellaDate()     //gets the appointment date of the cinderella.
        {           
            return appDate;                      //returns the appointment date of the cinderella. 
        }

        //getCinderellaTime
        //Returns the appointment time of the cinderella. 
        //Input: None.
        //Output: Returns the appointment time of the cinderella.
        //precondition: The cinderella has an appointment time.
        //postcondition: The appointment time of the cinderella is returned succesfully.
        public DateTime getCinderellaTime()         //gets the appointment time of the cinderella. 
        {             
            return appTime;                      //returns the appointment time of the cinderella. 
        }

        //getCinderellaEmail
        //Returns the E-Mail of the cinderella.
        //Input: None.
        //Output: Returns the E-Mail of the cinderella.
        //Pre-condition: The cinderella has an email.
        //Post-condition: The email is returned succesfully.
        public string getCinderellaEmail()
        {
            return cinderellaEmail;              //returns the cinderella's E-Mail.
        }

        //getCinderellaPhone
        //Returns the cinderella's phone number.
        //Input: None. 
        //Output: Returns the phone number of the cinderella.
        //precondition: The cinderella has a phone number.
        //postcondition: The phone number is returned succesfully.
        public string getCinderellaPhone()          //gets the Cinderella'a phone #.
        {
            return cinderellaPhone;              //returns the cinderella's phone #.
        }

        public void add()                       //adds the Cinderella with her information. 
        {

        }
    }
}
