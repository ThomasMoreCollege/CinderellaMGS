using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CinderellaClass
/// </summary>
public class CinderellaClass
{
    //
    public int CinderellaID { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public DateTime ScheduleAppointmentTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int Priority { get; set; }

    // Blank constructor
    public CinderellaClass() { }

    // Constructor taking every variable except for Priority, which is calculated by ScheuleAppointmentTime and ArrivalTime
    public CinderellaClass(int conID, string conFName, string conLName, DateTime conScheduleAppointmentTime, DateTime conArrivalTime)
    {
        CinderellaID = conID;
        FName = conFName;
        LName = conLName;
        ScheduleAppointmentTime = conScheduleAppointmentTime;
        ArrivalTime = conArrivalTime;

        // Comparing ScheduleAppointmentTime and ArrivalTime to get Priority
        if ((ScheduleAppointmentTime.Subtract(ArrivalTime).TotalMinutes) >= 15)
        {
            Priority = 2;   // Early - Priorty 2
        }
        else if ((ArrivalTime.Subtract(ScheduleAppointmentTime).TotalMinutes) >= 15)
        {
            Priority = 3;   // Late - Priority 3
        }
        else
        {
            Priority = 1;   // On time - Priority 1
        }
    }

    // Checks if a Cinderella has been waiting for at least X minutes
    public bool WaitingForXTime(double X)
    {
        // NOTE: X = number of minutes to check if Cinderella was waiting for 

        // Creating a variable to hold the current time
        DateTime now = DateTime.Now;

        // Checking if the time difference between now and the arrival is at least X minutes
        if ((now.Subtract(ArrivalTime).TotalMinutes) >= X)
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

        if ((ScheduleAppointmentTime.Subtract(now).TotalMinutes) <= X)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}