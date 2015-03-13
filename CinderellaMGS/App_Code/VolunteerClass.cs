using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VolunteerClass
/// </summary>
public class VolunteerClass
{
    private int _volunteerID;
    private string _firstName;
    private string _lastName;

    //Blank Constructor 
	public VolunteerClass()
	{
        _volunteerID = 0;
        _firstName = "";
        _lastName = "";
	}

    //Constructor to initialize varaibles 
    public VolunteerClass(int conID, string conFName, string conLName)
    {
        _volunteerID = conID;
        _firstName = conFName;
        _lastName = conLName;
    }

    //Property accessors and mutators
    public int VolunteerID
    {
        get { return _volunteerID; }
        set { _volunteerID = value; }
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
}