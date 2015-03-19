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

    protected void AltertationsCheckinButton_Click(object sender, EventArgs e)
    {
        // Checking if the DressDropDowns have selected values
        if (DressSizeDropDownList.SelectedValue == "1") { DressSizeErrorLabel.Visible = true; }
        else { DressSizeErrorLabel.Visible = false; }

        if (DressColorDropDownList.SelectedValue == "1") { DressColorErrorLabel.Visible = true; }
        else { DressColorErrorLabel.Visible = false; }

        if (DressLengthDropDownList.SelectedValue == "1") { DressLengthErrorLabel.Visible = true; }
        else { DressLengthErrorLabel.Visible = false; }

        if ((DressLengthErrorLabel.Visible == false) && (DressColorErrorLabel.Visible == false) && (DressSizeErrorLabel.Visible == false))
        {

            DressSizeDropDownList.Enabled = false;
            DressColorDropDownList.Enabled = false;
            DressLengthDropDownList.Enabled = false;
            AltertationsCheckinButton.Enabled = false;

            //Initialize database connection with "DefaultConnection" setup in the web.config 
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            // Variable to hold the shopping Cinderella
            string SelectedShoppingCinderellaID = CinderellaShoppingGridView.SelectedValue.ToString();

            //Open the connection 
            conn1.Open();

            // SQL to insert the Cinderella's Dress information into Package
            string sql = "INSERT INTO Package (Cinderella_ID, DressSize, DressColor, DressLength, InAlterations, InPackaging) "
                        + "VALUES ('" + SelectedShoppingCinderellaID + "', '"
                                        + DressSizeDropDownList.SelectedValue + "', '"
                                        + DressColorDropDownList.SelectedValue + "', '"
                                        + DressLengthDropDownList.SelectedValue + "', 'Y', 'N')";
            // Execute SQL
            SqlCommand com1 = new SqlCommand(sql, conn1);
            com1.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn1.Close();

            // Rebind the data to refresh the grid
            CinderellaDressAlterationsGridView.DataBind();
            CinderellaDressAlterationsGridView.SelectedIndex = -1;

            CinderellaShoppingGridView.DataBind();
            CinderellaShoppingGridView.SelectedIndex = -1;
        }
    }

    protected void submitAlterationsButton_Click(object sender, EventArgs e)
    {
        if (SeamstressDropDownList.SelectedIndex == 0)
        {
            Error.Visible = true;
        }
        else
        {
            Error.Visible = false;

            StrapsCheckBox.Enabled = false;
            GeneralMendingCheckBox.Enabled = false;
            GeneralTakeinCheckBox.Enabled = false;
            FixZipperCheckBox.Enabled = false;
            notesTextBox.Enabled = false;
            DartsCheckBox.Enabled = false;
            BustCheckBox.Enabled = false;
            HemCheckBox.Enabled = false;
            OtherCheckBox.Enabled = false;
            submitAlterationsButton.Enabled = false;
            SeamstressDropDownList.Enabled = false;

            // Alteration's user entry checks.
            char testStraps = 'N';
            char testMending = 'N';
            char testTakeIn = 'N';
            char testZipper = 'N';
            char testDarts = 'N';
            char testBust = 'N';
            char testHem = 'N';
            char testOther = 'N';
            char testReady = 'N';

            if (StrapsCheckBox.Checked == true)
            {
                testStraps = 'Y';
            }
            if (GeneralMendingCheckBox.Checked == true)
            {
                testMending = 'Y';
            }
            if (GeneralTakeinCheckBox.Checked == true)
            {
                testTakeIn = 'Y';
            }
            if (FixZipperCheckBox.Checked == true)
            {
                testZipper = 'Y';
            }
            if (DartsCheckBox.Checked == true)
            {
                testDarts = 'Y';
            }
            if (BustCheckBox.Checked == true)
            {
                testBust = 'Y';
            }
            if (HemCheckBox.Checked == true)
            {
                testHem = 'Y';
            }
            if (OtherCheckBox.Checked == true)
            {
                testOther = 'Y';
            }
            if (PickupRadioButtonList.SelectedValue == "Y")
            {
                testReady = 'Y';
            }

            // Resetting the checkboxes
            StrapsCheckBox.Checked = false;
            GeneralMendingCheckBox.Checked = false;
            GeneralTakeinCheckBox.Checked = false;
            FixZipperCheckBox.Checked = false;
            DartsCheckBox.Checked = false;
            BustCheckBox.Checked = false;
            HemCheckBox.Checked = false;
            OtherCheckBox.Checked = false;

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection.
            conn1.Open();

            string SelectedCinderellaID = CinderellaDressAlterationsGridView.SelectedValue.ToString();

            // A SQL Query to check if the Cinderella already has a presence in Alteration
            string sql = "SELECT Cinderella_ID "
                            + "FROM Alteration "
                            + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";

            SqlCommand testForPopulation = new SqlCommand(sql, conn1);
            // If there is no presence, INSERT
            if (testForPopulation.ExecuteScalar() == null)
            {

                // Update the alterations table with the user inputed data form the form.
                string alterationChange = "INSERT INTO Alteration (Cinderella_ID, AlterationNotes, Straps, Darts, FixZipper, GeneralMending, Bust, Hem, GeneralTakeIn, Other, Volunteer_ID, ReadyForPickup)"
                                            + "VALUES ('" + SelectedCinderellaID + "', '"
                                                            + notesTextBox.Text + "', '"
                                                            + testStraps + "', '"
                                                            + testDarts + "', '"
                                                            + testZipper + "', '"
                                                            + testMending + "', '"
                                                            + testBust + "', '"
                                                            + testHem + "', '"
                                                            + testTakeIn + "', '"
                                                            + testOther + "', '"
                                                            + SeamstressDropDownList.SelectedValue.ToString() + "', '"
                                                            + testReady + "')";

                // Execute SQL
                SqlCommand insertAlteration = new SqlCommand(alterationChange, conn1);
                insertAlteration.ExecuteNonQuery();
            }
            // Else (is presence) UPDATE
            else
            {
                sql = "UPDATE Alteration "
                        + "SET AlterationNotes='" + notesTextBox.Text
                            + "', Straps='" + testStraps
                            + "', Darts='" + testDarts
                            + "', FixZipper='" + testZipper
                            + "', GeneralMending='" + testMending
                            + "', Bust='" + testBust
                            + "', Hem='" + testHem
                            + "', GeneralTakein='" + testTakeIn
                            + "', Other='" + testOther
                            + "', Volunteer_ID='" + SeamstressDropDownList.SelectedValue.ToString()
                            + "', ReadyForPickup='" + testReady + "'"
                        + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";

                // Execute SQL
                SqlCommand updateAlteration = new SqlCommand(sql, conn1);
                updateAlteration.ExecuteNonQuery();
            }

            // Rebind the data to refresh the grid
            CinderellaDressAlterationsGridView.DataBind();
            CinderellaDressAlterationsGridView.SelectedIndex = -1;

            CinderellaShoppingGridView.DataBind();
            CinderellaShoppingGridView.SelectedIndex = -1;

            // Resetting the notes textbox
            notesTextBox.Text = "";

            //REMEMBER TO CLOSE CONNECTION!!
            conn1.Close();
        }
    }
    protected void CinderellaDressAlterationsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Enabling all the Alterations information 
        StrapsCheckBox.Enabled = true;
        GeneralMendingCheckBox.Enabled = true;
        GeneralTakeinCheckBox.Enabled = true;
        FixZipperCheckBox.Enabled = true;
        notesTextBox.Enabled = true;
        DartsCheckBox.Enabled = true;
        BustCheckBox.Enabled = true;
        HemCheckBox.Enabled = true;
        OtherCheckBox.Enabled = true;
        submitAlterationsButton.Enabled = true;
        SeamstressDropDownList.Enabled = true;

        // Disabling all the dress information
        DressSizeDropDownList.Enabled = false;
        DressColorDropDownList.Enabled = false;
        DressLengthDropDownList.Enabled = false;
        AltertationsCheckinButton.Enabled = false;

        string SelectedCinderellaID = CinderellaDressAlterationsGridView.SelectedValue.ToString();
        // Defaulting to no alterations
        StrapsCheckBox.Checked = false;
        GeneralMendingCheckBox.Checked = false;
        GeneralTakeinCheckBox.Checked = false;
        FixZipperCheckBox.Checked = false;
        DartsCheckBox.Checked = false;
        BustCheckBox.Checked = false;
        HemCheckBox.Checked = false;
        OtherCheckBox.Checked = false;
        PickupRadioButtonList.SelectedValue = "N";
        notesTextBox.Text = "";

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection.
        conn1.Open();

        string sql = "SELECT Cinderella_ID, AlterationNotes, Straps, Darts, FixZipper, GeneralMending, Bust, Hem, GeneralTakeIn, DressRetrieved, Other, ReadyForPickUp, Volunteer_ID "
                        + "FROM Alteration "
                        + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";

        //Execute query 
        SqlCommand comm1 = new SqlCommand(sql, conn1);

        if (comm1.ExecuteScalar() == null)
        {
            // Set all the values in 
        }
        else
        {
            //Create a new adapter
            SqlDataAdapter adapter = new SqlDataAdapter(comm1);

            //Create a new dataset to hold the query results
            DataSet dataSet = new DataSet();

            //Store the results in the adapter 
            adapter.Fill(dataSet);

            // Setting information equal to corresponding values in Alterations 
            if (dataSet.Tables[0].Rows[0]["Straps"].ToString() == "Y")
            { StrapsCheckBox.Checked = true; }

            if (dataSet.Tables[0].Rows[0]["Darts"].ToString() == "Y")
            { DartsCheckBox.Checked = true; }

            if (dataSet.Tables[0].Rows[0]["FixZipper"].ToString() == "Y")
            { FixZipperCheckBox.Checked = true; }

            if (dataSet.Tables[0].Rows[0]["GeneralMending"].ToString() == "Y")
            { GeneralMendingCheckBox.Checked = true; }

            if (dataSet.Tables[0].Rows[0]["Bust"].ToString() == "Y")
            { BustCheckBox.Checked = true; }

            if (dataSet.Tables[0].Rows[0]["Hem"].ToString() == "Y")
            { HemCheckBox.Checked = true; }

            if (dataSet.Tables[0].Rows[0]["GeneralTakeIn"].ToString() == "Y")
            { GeneralTakeinCheckBox.Checked = true; }

            if (dataSet.Tables[0].Rows[0]["Other"].ToString() == "Y")
            { OtherCheckBox.Checked = true; }

            if (dataSet.Tables[0].Rows[0]["ReadyForPickup"].ToString() == "Y")
            { PickupRadioButtonList.SelectedValue = "Y"; }

            notesTextBox.Text = dataSet.Tables[0].Rows[0]["AlterationNotes"].ToString();
            SeamstressDropDownList.SelectedValue = dataSet.Tables[0].Rows[0]["Volunteer_ID"].ToString();
        }

        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();
    }
    protected void CinderellaShoppingGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Enabling all the dress information
        DressSizeDropDownList.Enabled = true;
        DressColorDropDownList.Enabled = true;
        DressLengthDropDownList.Enabled = true;
        AltertationsCheckinButton.Enabled = true;

        // Disabling all the Alterations information
        StrapsCheckBox.Enabled = false;
        GeneralMendingCheckBox.Enabled = false;
        GeneralTakeinCheckBox.Enabled = false;
        FixZipperCheckBox.Enabled = false;
        notesTextBox.Enabled = false;
        DartsCheckBox.Enabled = false;
        BustCheckBox.Enabled = false;
        HemCheckBox.Enabled = false;
        submitAlterationsButton.Enabled = false;
        SeamstressDropDownList.Enabled = false;
    }
}