using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL
using System.Data; // Must be included if using data tables

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
    public VolunteerClass(int conID)
    {
        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Store Query string to retrieve all data neede for Cinderella object
        string retrieveCinderellaInfoQuery = "SELECT Volunteer.VolunteerID, Volunteer.FirstName, Volunteer.LastName "
                                           + "FROM Volunteer INNER JOIN VolunteerStatusRecord ON "
                                           + "Volunteer.VolunteerID = VolunteerStatusRecord.Volunteer_ID INNER JOIN VolunteerRoleRecord ON "
                                           + "Volunteer.VolunteerID = VolunteerRoleRecord.Volunteer_ID "
                                           + "WHERE (VolunteerStatusRecord.Status_Name = 'Ready') AND "
                                           + "(VolunteerStatusRecord.IsCurrent = 'Y') AND (VolunteerRoleRecord.Role_Name = 'Godmother') "
                                           + "AND (VolunteerRoleRecord.IsCurrent = 'Y') AND "
                                           + "(Volunteer.VolunteerID='" + Convert.ToString(conID) + "')";

        //Execute query 
        SqlCommand retrieveCinderellaInfo = new SqlCommand(retrieveCinderellaInfoQuery, conn1);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(retrieveCinderellaInfo);

        //Create a new dataset to hold the query results
        DataSet dataSet = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(dataSet);

        _volunteerID = conID;
        _firstName = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
        _lastName = dataSet.Tables[0].Rows[0]["LastName"].ToString();
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