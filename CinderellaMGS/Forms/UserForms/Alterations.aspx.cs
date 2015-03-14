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
        string sql = "INSERT INTO Package (Cinderella_ID, DressSize, DressColor, DressLength, InAlterations) "
                    + "VALUES ('" + SelectedShoppingCinderellaID + "', '"
                                    + DressSizeDropDownList.SelectedValue + "', '"
                                    + DressColorDropDownList.SelectedValue + "', '"
                                    + DressLengthDropDownList.SelectedValue + "', 'Y')";
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

    protected void submitAlterationsButton_Click(object sender, EventArgs e)
    {
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

        // Alteration's user entry checks.
        char testStraps = 'N';
        char testMending = 'N';
        char testTakeIn = 'N';
        char testZipper = 'N';
        char testDarts = 'N';
        char testBust = 'N';
        char testHem = 'N';

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

        // Resetting the checkboxes
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

        string SelectedCinderellaID = CinderellaDressAlterationsGridView.SelectedValue.ToString();

        // Get the Volunteer's ID.
        string getVolunteerID = "SELECT VolunteerID "
                                + "FROM Volunteer "
                                + "WHERE LastName = '" + SeamstressDropDownList.SelectedItem.Text + "'";
        SqlCommand com2 = new SqlCommand(getVolunteerID, conn1);
        string getVolID = Convert.ToString(com2.ExecuteScalar().ToString());


        // Update the alterations table with the user inputed data form the form.
        string alterationChange = "INSERT INTO Alteration (Cinderella_ID, AlterationNotes, Straps, Darts, FixZipper, GeneralMending, Bust, Hem, GeneralTakeIn, Volunteer_ID)"
                                    + "VALUES ('" + SelectedCinderellaID + "', '" 
                                                    + notesTextBox.Text  + "', '" 
                                                    + testStraps + "', '" 
                                                    + testDarts + "', '" 
                                                    + testZipper + "', '" 
                                                    + testMending + "', '" 
                                                    + testBust + "', '" 
                                                    + testHem + "', '" 
                                                    + testTakeIn + "', '" 
                                                    + getVolID + "')";
        
        // Execute SQL
        SqlCommand insertNewRole = new SqlCommand(alterationChange, conn1);
        insertNewRole.ExecuteNonQuery();

        // Update the Cinderella's current status to Not Current
        string updateSelectedCinderella = "UPDATE CinderellaStatusRecord "
                                            + "SET EndTime = '" + DateTime.Now + "', IsCurrent = 'N' "
                                            + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "' AND IsCurrent = 'Y'";
        // Execute SQL
        SqlCommand updateRoleEndTime = new SqlCommand(updateSelectedCinderella, conn1);
        updateRoleEndTime.ExecuteNonQuery();

        // Change the Cinderella's state to 'Waiting for Dress' in the CinderellaStatusRecord table.
        string waitingForDressChange = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                                        + "VALUES ('" + SelectedCinderellaID + "', '" + DateTime.Now + "', 'Waiting for Dress', 'Y')";
        // Execute SQL
        SqlCommand updateRole = new SqlCommand(waitingForDressChange, conn1);
        updateRole.ExecuteNonQuery();

        // Outputting message to verify transaction
        //updateSuccessLabel.Visible = true;
        //nameDisplaySuccessMessage.Visible = true;
        //updateSuccessLabel.ForeColor = System.Drawing.Color.Green;
        //nameDisplaySuccessMessage.ForeColor = System.Drawing.Color.Green;
        //nameDisplaySuccessMessage.Text = "Updated: " + CinderellaDressAlterationsGridView.SelectedRow.Cells[2].Text + "'s Dress";

        // Rebind the data to refresh the grid
        CinderellaDressAlterationsGridView.DataBind();
        CinderellaDressAlterationsGridView.SelectedIndex = -1;

        CinderellaShoppingGridView.DataBind();
        CinderellaShoppingGridView.SelectedIndex = -1;

        // Resetting the notes textbox
        notesTextBox.Text = "";

        // TO DO.................
        // Update the package query.
        // Add a check on cinderella_id in the package table to see if there is a record already estabilished for the cinderella. If true -> update, if false -> insert.
        // What dress sizes are are using --> Check on all drop down lists...
        // Instert Dress Recieved/PIcked up
        // Date/ID key update problem with back to back status ends/begins.

        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();
    }
    protected void CinderellaDressAlterationsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        StrapsCheckBox.Enabled = true;
        GeneralMendingCheckBox.Enabled = true;
        GeneralTakeinCheckBox.Enabled = true;
        FixZipperCheckBox.Enabled = true;
        notesTextBox.Enabled = true;
        DartsCheckBox.Enabled = true;
        BustCheckBox.Enabled = true;
        HemCheckBox.Enabled = true;
        submitAlterationsButton.Enabled = true;
        SeamstressDropDownList.Enabled = true;
    }
    protected void CinderellaShoppingGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        DressSizeDropDownList.Enabled = true;
        DressColorDropDownList.Enabled = true;
        DressLengthDropDownList.Enabled = true;
        AltertationsCheckinButton.Enabled = true;
    }
}