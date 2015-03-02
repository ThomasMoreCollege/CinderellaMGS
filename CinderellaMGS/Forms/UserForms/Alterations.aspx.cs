using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

public partial class Forms_UserForms_Alterations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void searchShoppingCindButton_Click1(object sender, EventArgs e)
    {

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn1.Open();

        //Initialize a string variable to hold a query
        string getAvailableCins = "SELECT Cinderella.FirstName FROM Cinderella INNER JOIN CinderellaStatusRecord on Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID WHERE CinderellaStatusRecord.Status_Name = 'Shopping' AND CinderellaStatusRecord.isCurrent = 'Y' AND Cinderella.LastName = '" + searchTextBox.Text + "'";

        //Execute query 
        SqlCommand com1 = new SqlCommand(getAvailableCins, conn1);


        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(com1);
        DataSet myDataSet = new DataSet();
        mySqlDataAdapter.Fill(myDataSet);
        shoppingCinderellaListBox.DataSource = myDataSet;
        shoppingCinderellaListBox.DataTextField = "FirstName";
        shoppingCinderellaListBox.DataValueField = "FirstName";
        shoppingCinderellaListBox.DataBind();

        conn1.Close();
    }

  
    protected void AltertationsCheckinButton_Click(object sender, EventArgs e)
    {
        DressSizeDropDownList.Enabled = false;
        DressColorDropDownList.Enabled = false;
        DressLengthDropDownList.Enabled = false;
        AltertationsCheckinButton.Enabled = false;
        AltertationsCheckinButton.Enabled = false;
    }
    protected void shoppingCinderellaListBox_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DressSizeDropDownList.Enabled = true;
        DressColorDropDownList.Enabled = true;
        DressLengthDropDownList.Enabled = true;
        AltertationsCheckinButton.Enabled = true;
    }
}