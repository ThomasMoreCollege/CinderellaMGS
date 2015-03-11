using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL
using System.Data; // Must be included if using data tables

public partial class Forms_AdminForms_ChildForms_DeleteVolunteer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }
    protected void VolunteerGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        DeleteVoluntFormButton.Enabled = true;

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Store Query string
        string retrieveVolunteerInfoQuery = "SELECT FirstName,LastName,Email,Phone,Address,City,State,Zipcode "
                                            + "FROM Volunteer "
                                            + "WHERE VolunteerID='" + VolunteerGridView.SelectedValue.ToString() + "'";
        
        //Execute query 
        SqlCommand retrieveInfo = new SqlCommand(retrieveVolunteerInfoQuery, conn1);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(retrieveInfo);

        //Create a new dataset to hold the query results
        DataSet dataSet = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(dataSet);

        //Display appropiate info based on selected volunteer
        FisrtNameLabel.Text = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
        LastNameLabel.Text = dataSet.Tables[0].Rows[0]["LastName"].ToString();
        EmailLabel.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
        PhoneLabel.Text = dataSet.Tables[0].Rows[0]["Phone"].ToString();
        AddressLabel.Text = dataSet.Tables[0].Rows[0]["Address"].ToString();
        CityLabel.Text = dataSet.Tables[0].Rows[0]["City"].ToString();
        StateLabel.Text = dataSet.Tables[0].Rows[0]["State"].ToString();
        ZipcodeLabel.Text = dataSet.Tables[0].Rows[0]["Zipcode"].ToString();
         
    }

    protected void DeleteVoluntFormButton_Click(object sender, EventArgs e)
    {

        //Only soft Removal is to be used for this application


        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn2.Open();

        //Initialize a string variable to hold a query
        string softDeleteVolQuery = "UPDATE Volunteer "
                                        + "SET IsValid='N' "
                                        + "WHERE VolunteerID='" + VolunteerGridView.SelectedValue.ToString() + "'";
        //Execute query 
        SqlCommand softDeleteVol = new SqlCommand(softDeleteVolQuery, conn2);

        //Execute Query 
        softDeleteVol.ExecuteNonQuery();

        //REMEMBER TO CLOSE CONNECTION!!
        conn2.Close();

        //Refresh Grid
        VolunteerGridView.DataSourceID = "VolunteersToBeDeletedSqlDataSource";
        VolunteerGridView.DataBind();

        FisrtNameLabel.Text = "--";
        LastNameLabel.Text = "--";
        EmailLabel.Text = "--";
        PhoneLabel.Text = "--";
        AddressLabel.Text = "--"; ;
        CityLabel.Text = "--";
        StateLabel.Text = "--";
        ZipcodeLabel.Text = "--";

        DeleteVoluntFormButton.Enabled = false;
    }
}