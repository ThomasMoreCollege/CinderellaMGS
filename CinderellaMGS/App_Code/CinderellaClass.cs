using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CinderellaClass
/// </summary>
public class CinderellaClass
{
    //Cinderella Properties
    private int _cinderellaID;
    private string _firstName;
    private string _lastName;
    private DateTime _scheduleAppointmentTime;
    private DateTime _arrivalTime;
    private int _priority;

    // Blank constructor
    public CinderellaClass() { }

    // Constructor taking every variable except for Priority, which is calculated by ScheuleAppointmentTime and ArrivalTime
    public CinderellaClass(int conID, string conFName, string conLName, DateTime conScheduleAppointmentTime, DateTime conArrivalTime)
    {
        _cinderellaID = conID;
        _firstName = conFName;
        _lastName = conLName;
        _scheduleAppointmentTime = conScheduleAppointmentTime;
        _arrivalTime = conArrivalTime;

        // Comparing ScheduleAppointmentTime and ArrivalTime to get Priority
        if ((_scheduleAppointmentTime.Subtract(_arrivalTime).TotalMinutes) >= 15)
        {
            _priority = 2;   // Early - Priorty 2
        }
        else if ((_arrivalTime.Subtract(_scheduleAppointmentTime).TotalMinutes) >= 15)
        {
            _priority = 3;   // Late - Priority 3
        }
        else
        {
            _priority = 1;   // On time - Priority 1
        }
    }

    //Property accessors and mutators
    public int CinderellaID
    {
        get { return _cinderellaID; }
        set { _cinderellaID = value; }
    }
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }
    public DateTime ScheduleAppointmentTime
    {
        get { return _scheduleAppointmentTime; }
        set { _scheduleAppointmentTime = value; }
    }
    public DateTime ArrivalTime
    {
        get { return _arrivalTime; }
        set { _arrivalTime = value; }
    }
    public int Priority
    {
        get { return _priority; }
        set { _priority = value; }
    }

    // Checks if a Cinderella has been waiting for at least X minutes
    public bool WaitingForXTime(double X)
    {
        // NOTE: X = number of minutes to check if Cinderella was waiting for 

        // Creating a variable to hold the current time
        DateTime now = DateTime.Now;

        // Checking if the time difference between now and the arrival is at least X minutes
        if ((now.Subtract(_arrivalTime).TotalMinutes) >= X)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    // Checks if the ScheduledAppointmentTime is in the next X minutes given
    public bool InScheduledTimeWindow(double X)
    {
        // NOTE: X = number of minutes to base time window off of 

        // Creating a variable to hold the current time
        DateTime now = DateTime.Now;

        if ((_scheduleAppointmentTime.Subtract(now).TotalMinutes) <= X)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}