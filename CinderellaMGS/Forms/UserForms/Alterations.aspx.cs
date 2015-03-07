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
        (this.Master as MasterPage).ManageMasterLayout();
    }

    protected void searchShoppingCindButton_Click1(object sender, EventArgs e)
    {
        updateSuccessLabel.Visible = false;
        nameDisplaySuccessMessage.Visible = false;
        shoppingCinderellaListBox.Enabled = true;
        CinderellasInAlterationListBox.Items.Clear();


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
        shoppingCinderellaListBox.Enabled = false;

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn1.Open();

        // Get the Cinderella's ID.
        string getCinderellaID = "SELECT CinderellaID FROM Cinderella WHERE FirstName = '" + shoppingCinderellaListBox.SelectedItem.Text + "'";
        SqlCommand com1 = new SqlCommand(getCinderellaID, conn1);
        string getID = Convert.ToString(com1.ExecuteScalar().ToString());

        // Update the EndTime and the isCurrent values for the 'Shopping' status entry in the CinderellaStatusRecord table.
        string updateSelectedCinderella = "UPDATE CinderellaStatusRecord SET EndTime = '" + DateTime.Now + "', IsCurrent = 'N' WHERE Cinderella_ID = '" + getID + "' AND IsCurrent = 'Y'";
        SqlCommand updateRole = new SqlCommand(updateSelectedCinderella, conn1);
        updateRole.ExecuteNonQuery();



        // Change the Cinderella's state to 'Alterations' in the CinderellaStatusRecord table.
        string alterationChange = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + getID + "', '" + DateTime.Now + "', 'Alterations', 'Y')";
        SqlCommand insertNewRole = new SqlCommand(alterationChange, conn1);
        insertNewRole.ExecuteNonQuery();

        



        /*
        string ifQuery = "SELECT CASE WHEN EXISTS (SELECT Package.Cinderella_ID FROM Package "
	        + "INNER JOIN Cinderella ON Package.Cinderella_ID = Cinderella.CinderellaID " 
            + "WHERE Cinderella.FirstName = '" + shoppingCinderellaListBox.SelectedItem.Text + "') THEN 1 ELSE 0 END AS AnyData";
        SqlCommand ifCommand = new SqlCommand(ifQuery, conn1);
        // int testPackageRecord = ifCommand.ExecuteNonQuery();

        if (ifCommand.ExecuteNonQuery() == 1)
        {
            // 
            string packageUpdate = "Update Package SET DressSize = '" + DressSizeDropDownList.SelectedItem.Text + "', "
                         + "DressColor = '" + DressColorDropDownList.SelectedItem.Text + "', DressLength = '"
                         + DressLengthDropDownList.SelectedItem.Text + "' WHERE Cinderella_ID = '" + getID + "'";
            SqlCommand updatePackage = new SqlCommand(packageUpdate, conn1);
            updatePackage.ExecuteNonQuery();
        }
        else if (ifCommand.ExecuteNonQuery() == 0)
        {
            // Working.
            // Create a new entry in the package table.
            string packageUpdate = "INSERT INTO Package (Cinderella_ID, DressSize, DressColor, Dresslength, InPackaging, InAlterations) VALUES ('" + getID + "', '" + DressSizeDropDownList.SelectedValue + "', '" + DressColorDropDownList.SelectedValue + "', '" + DressLengthDropDownList.SelectedValue + "', 'N', 'Y')";
            SqlCommand insertNewPackage = new SqlCommand(packageUpdate, conn1);
            insertNewPackage.ExecuteNonQuery();
        }
        */






        //Initialize a string variable to hold a query.
        // Get a list of the Cinerella's currently in alterations.
        string getShoppingCins = "SELECT Cinderella.FirstName, Cinderella.LastName FROM Cinderella INNER JOIN CinderellaStatusRecord ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID WHERE CinderellaStatusRecord.Status_Name = 'Alterations' AND CinderellaStatusRecord.IsCurrent = 'Y'";

        //Execute query 
        SqlCommand com2 = new SqlCommand(getShoppingCins, conn1);

        // Display the results from the getShoppingsCins query in the CinderellasInAlterationsListBox.
        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(com2);
        DataSet myDataSet = new DataSet();
        mySqlDataAdapter.Fill(myDataSet);
        CinderellasInAlterationListBox.DataSource = myDataSet;
        CinderellasInAlterationListBox.DataTextField = "FirstName";
        CinderellasInAlterationListBox.DataValueField = "FirstName";
        CinderellasInAlterationListBox.DataBind();

        conn1.Close();


    }
    protected void shoppingCinderellaListBox_SelectedIndexChanged1(object sender, EventArgs e)
    {
        updateSuccessLabel.Visible = false;
        nameDisplaySuccessMessage.Visible = false;
        DressSizeDropDownList.Enabled = true;
        DressColorDropDownList.Enabled = true;
        DressLengthDropDownList.Enabled = true;
        AltertationsCheckinButton.Enabled = true;
    }

    protected void CinderellasInAlterationListBox_SelectedIndexChanged1(object sender, EventArgs e)
    {
        updateSuccessLabel.Visible = false;
        nameDisplaySuccessMessage.Visible = false;
        StrapsCheckBox.Enabled = true;
        GeneralMendingCheckBox.Enabled = true;
        GeneralTakeinCheckBox.Enabled = true;
        FixZipperCheckBox.Enabled = true;
        notesTextBox.Enabled = true;
        DartsCheckBox.Enabled = true;
        BustCheckBox.Enabled = true;
        HemCheckBox.Enabled = true;
        submitDressButton.Enabled = true;
        SeamstressDropDownList.Enabled = true;
    }
    protected void submitDressButton_Click(object sender, EventArgs e)
    {
        StrapsCheckBox.Enabled = false;
        GeneralMendingCheckBox.Enabled = false;
        GeneralTakeinCheckBox.Enabled = false;
        FixZipperCheckBox.Enabled = false;
        notesTextBox.Enabled = false;
        DartsCheckBox.Enabled = false;
        BustCheckBox.Enabled = false;
        HemCheckBox.Enabled = false;
        submitDressButton.Enabled = false;
        SeamstressDropDownList.Enabled = false;

        // Alteration's user entry checks.
        char testStraps = ' ';
        char testMending = ' ';
        char testTakeIn = ' ';
        char testZipper = ' ';
        char testDarts = ' ';
        char testBust = ' ';
        char testHem = ' ';



        if (StrapsCheckBox.Checked == true)
            testStraps = 'Y';
        else
            testStraps = 'N';

        if (GeneralMendingCheckBox.Checked == true)
            testMending = 'Y';
        else
            testMending = 'N';

        if (GeneralTakeinCheckBox.Checked == true)
            testTakeIn = 'Y';
        else
            testTakeIn = 'N';

        if (FixZipperCheckBox.Checked == true)
            testZipper = 'Y';
        else
            testZipper = 'N';

        if (DartsCheckBox.Checked == true)
            testDarts = 'Y';
        else
            testDarts = 'N';

        if (BustCheckBox.Checked == true)
            testBust = 'Y';
        else
            testBust = 'N';

        if (HemCheckBox.Checked == true)
            testHem = 'Y';
        else
            testHem = 'N';

        StrapsCheckBox.Checked = false;
        GeneralMendingCheckBox.Checked = false;
        GeneralTakeinCheckBox.Checked = false;
        FixZipperCheckBox.Checked = false;
        DartsCheckBox.Checked = false;
        BustCheckBox.Checked = false;
        HemCheckBox.Checked = false;


        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection.
        conn1.Open();

        // Get the Cinderella's ID.
        // Get the Cinderella's ID.
        string getCinderellaID = "SELECT CinderellaID FROM Cinderella WHERE FirstName = '" + CinderellasInAlterationListBox.SelectedItem.Text + "'";
        SqlCommand com1 = new SqlCommand(getCinderellaID, conn1);
        string getCinID = Convert.ToString(com1.ExecuteScalar().ToString());


        // Get the Volunteer's ID.
        string getVolunteerID = "SELECT VolunteerID FROM Volunteer WHERE LastName = '" + SeamstressDropDownList.SelectedItem.Text + "'";
        SqlCommand com2 = new SqlCommand(getVolunteerID, conn1);
        string getVolID = Convert.ToString(com2.ExecuteScalar().ToString());


        // Update the alterations table with the user inputed data form the form.
        string alterationChange = "INSERT INTO Alteration (Cinderella_ID, AlterationNotes, Straps, Darts, FixZipper, GeneralMending, Bust, Hem, GeneralTakeIn, Volunteer_ID)"
        + "VALUES ('" + getCinID + "', '" + notesTextBox.Text  + "', '" + testStraps + "', '" + testDarts + "', '" + testZipper + "', '" + testMending 
        + "', '" + testBust + "', '" + testHem + "', '" + testTakeIn + "', '" + getVolID + "')";


        SqlCommand insertNewRole = new SqlCommand(alterationChange, conn1);
        insertNewRole.ExecuteNonQuery();

        // Update the EndTime and the isCurrent values for the 'Alterations' status entry in the CinderellaStatusRecord table.
        string updateSelectedCinderella = "UPDATE CinderellaStatusRecord SET EndTime = '" + DateTime.Now + "', IsCurrent = 'N' WHERE Cinderella_ID = '" + getCinID + "' AND IsCurrent = 'Y'";
        SqlCommand updateRoleEndTime = new SqlCommand(updateSelectedCinderella, conn1);
        updateRoleEndTime.ExecuteNonQuery();

        // Change the Cinderella's state to 'Waiting for Dress' in the CinderellaStatusRecord table.
        string wiatingForDressChange = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + getCinID + "', '" + DateTime.Now + "', 'Waiting for Dress', 'Y')";
        SqlCommand updateRole = new SqlCommand(wiatingForDressChange, conn1);
        updateRole.ExecuteNonQuery();

        updateSuccessLabel.Visible = true;
        nameDisplaySuccessMessage.Visible = true;
        updateSuccessLabel.ForeColor = System.Drawing.Color.Green;
        nameDisplaySuccessMessage.ForeColor = System.Drawing.Color.Green;
        nameDisplaySuccessMessage.Text = "Updated: " + CinderellasInAlterationListBox.SelectedItem.Text;


        //Initialize a string variable to hold a query.
        // Get a list of the Cinerella's currently in alterations.
        string getShoppingCins = "SELECT Cinderella.FirstName, Cinderella.LastName FROM Cinderella INNER JOIN CinderellaStatusRecord ON Cinderella.CinderellaID = CinderellaStatusRecord.Cinderella_ID WHERE CinderellaStatusRecord.Status_Name = 'Alterations' AND CinderellaStatusRecord.IsCurrent = 'Y'";

        //Execute query 
        SqlCommand com3 = new SqlCommand(getShoppingCins, conn1);

        // Display the results from the getShoppingsCins query in the CinderellasInAlterationsListBox.
        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(com3);
        DataSet myDataSet = new DataSet();
        mySqlDataAdapter.Fill(myDataSet);
        CinderellasInAlterationListBox.DataSource = myDataSet;
        CinderellasInAlterationListBox.DataTextField = "FirstName";
        CinderellasInAlterationListBox.DataValueField = "FirstName";
        CinderellasInAlterationListBox.DataBind();

        CinderellasInAlterationListBox.DataBind();
        notesTextBox.Text = "";

        // TO DO.................
        // Update the package query.
        // Add a check on cinderella_id in the package table to see if there is a record already estabilished for the cinderella. If true -> update, if false -> insert.
        // What dress sizes are are using --> Check on all drop down lists...
        // Instert Dress Recieved/PIcked up
        // Date/ID key update problem with back to back status ends/begins.

        // Close the connection.
        conn1.Close();

    }
}