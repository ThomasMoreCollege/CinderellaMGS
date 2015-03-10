using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VolunteerClass
/// </summary>
public class VolunteerClass
{
    public int VolunteerID { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
	public VolunteerClass()
	{
        VolunteerID = 0;
        FName = "";
        LName = "";
	}
}