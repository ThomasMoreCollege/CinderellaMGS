using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using CinderellaLauncher;
using System.Configuration;

namespace CinderellaLauncher
{
    public class FairyGodmother
    {
        //include the connection string;
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        /*These variables(right below) are declared and assigned to Fairy Godmothers.*/

        private int fairyID;                                             //the fairy ID is set as a Primary Key(PK).
        private string fairyFirstName;                                  //First Name of Fairy Godmother.
        private string fairyLastName;                                  //Last Name of Fairy Godmother. 
        private string fairyRole;                                     //Fairy Godmother role.
        private DateTime fairyAppDate;                               //Fairy Godmother Appointment Date.
        private DateTime fairyAppTime;                              //Fairy Godmother Appointment Time.
        private string fairyShiftType;                             //Type of Shift for a Fairy Godmother.
        private string fairyEmail;                                //Fairy Godmother E-Mail.     
        private string fairyPhone;                               //Fairy Godmother Phone Number.
        private string fairyCity;                               //Fairy Godmother City of Residence.
        private string fairyState;                             //Fairy Godmother State of Residence. 
        public bool CanHandleSpecialNeeds;                    //Indicates whether or not the Fairy Godmother is capable and willing to deal with Special Needs Cinderellas.

        /*Like the cinderellaID in the "CinderellaClass.cs" file, the fariyID too will have its
         own Primary Key(PK) to determine the Fairy Godmothers' and their respective roles. In this action,
         the personal shoppers are assigned to pair up with the cinderellas.  Their IDs will determine who the personal
         shoppers are, such as their names, roles, and their appointment date and time with the cinderellas.*/

        //FairyGodmother
        //constructor for the Fairy Godmother. 
        //Input: ID, First Name, Last Name, role, appointment date, appointment time, shift, E-Mail, Phone Number, city, and state. 
        //Output: a class object is generated succesfully.
        //Pre-condition: all inputs are correct and valid.
        //Post-condition: an object is generated correctly.
        public FairyGodmother(int ID, string fname, string lname, string role, DateTime fairyDate, DateTime fairyTime, string shift, string email, string phoneNumber, string city, string state)
        {
            fairyID = ID;                                   //Fairy Godmother ID.
            fairyFirstName = fname;                        //Fairy Godmother First Name.
            fairyLastName = lname;                        //Fairy Godmother Last Name.
            fairyRole = role;                            //Role of the Fairy Godmother.
            fairyAppDate = fairyDate;                   //Fairy Godmother Appointment Date.
            fairyAppTime = fairyTime;                  //Fairy Gdmother Appointment Time. 
            fairyShiftType = shift;                   //Type of shift that a Fairy Godmother will maintain. 
            fairyEmail = email;                      //Fairy Godmother E-Mail. 
            fairyPhone = phoneNumber;               //Fairy Godmother Phone Number. 
            fairyCity = city;                      //Fairy Godmother City of Residence. 
            fairyState = state;                   //Fairy Godmother State of Residence.
        }

        //FairyGodmother
        //default constructor
        //Input: None.
        //Output: a blank class object is generated.
        //precondition: None.
        //postcondition:a class object corrected succesfully. 
        public FairyGodmother()
        {

        }

        //FairyGodmother
        //constructor for the class
        //Input: Id and the first and last name
        //Output: class object generated succesfully
        //precondition: all inputs are correct and valid
        //postcondition: object gennerated correctly
        public FairyGodmother(int ID, string firstName, string lastName)
        {
            fairyID = ID;
            fairyFirstName = firstName;
            fairyLastName = lastName;
        }

        //setFirstName
        //sets the first name of the fairy godmother
        //Input: first name
        //Ouptut: first name updated
        //precondition: input correct and valid
        //postcondition: first name updated correctly
        public void setFirstName(string Name)
        {
            fairyFirstName = Name;
        }


        //getFairyID
        //returns the god mother id
        //Input: none
        //Output: returns the id
        //precondition: the godmother has an id
        //postcondition: the ID has been returned succesfully
        public int getFairyID()
        {           
            return fairyID;    //return the fairyID
        }

        //getFirstName
        //returns the god mother's first name
        //Input: none
        //Output: returns the first name
        //precondition: the godmother has a first name
        //postcondition: the first name has been returned succesfully
        public string getFirstName()
        {            
            return fairyFirstName;   //return firstName
        }

        //getLastName
        //returns the last name
        //Input: none
        //Output: returns the last name
        //precondition: the god mother has a last name
        //postcondition: the last anem has been returned succesfully
        public string getLastName()
        {            
            return fairyLastName;    //return lastName
        }

        //getFairyRole
        //returns the godmother's role
        //Input: none
        //Output: returns the role
        //precondition: the god mother has a role
        //postcondition: the role has been returned succesfully
        public string getFairyRole()
        {            
            return fairyRole;       //return the fairyRole
        }

        //getFairyDate
        //returns the appointment date
        //Input: none
        //Output: returns the appointment date
        //precondition: the godmother has a appointment date
        //postcondition: the appointment date has been returned succesfully
        public DateTime getFairyDate()
        {            
            return fairyAppDate;    //return the appointment date for the fairy godmother
        }

        //getFairyTime
        //returns the appointment time
        //Input: none
        //Output: returns the appointment time
        //precondition: the godmother has a appointment time
        //postcondition: the appointment time has been returned succesfully
        public DateTime getFairyTime()
        {
            return fairyAppTime;    //return the appointment time for the fairy godmothers
        }

        //getShift
        //returns the shift type
        //Input: none
        //Output: returns the shift type
        //precondition: the godmother has a shift type
        //postcondition: the shift type has been returned succesfully
        public string getShift()
        {
            return fairyShiftType; //return shiftType
        }

        //getEmail
        //returns the email
        //Input: none
        //Output: returns the email
        //precondition: the godmother has a email
        //postcondition: the email has been returned succesfully
        public string getEmail()
        {
            return fairyEmail;    //return email
        }

        //getFairyPhoneNumber
        //returns the phone number
        //Input: none
        //Output: returns the phone number
        //precondition: the godmother has a phone number
        //postcondition: the phone number has been returned succesfully
        public string getFairyPhoneNumber()
        {
            return fairyPhone;   //return fairy's phone number
        }

        //getFairyCity
        //returns the fairy's city
        //Input: none
        //Output: returns the fairy's city
        //precondition: the godmother has a city
        //postcondition: the fairy's city has been returned succesfully
        public string getFairyCity()
        {
            return fairyCity;    //return fairy's city
        }

        //getFairyState
        //returns the fairy's state
        //Input: none
        //Output: returns the fairy's state
        //precondition: the godmother has a state
        //postcondition: the fairy's state has been returned succesfully
        public string getFairyState()
        {
            return fairyState;   //return fairy's state
        }
    }
}
