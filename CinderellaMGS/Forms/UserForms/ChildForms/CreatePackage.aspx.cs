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

public partial class Forms_UserForms_Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }
    protected void CheckoutButton_Click(object sender, EventArgs e)
    {
        UserNotificationLabel.Visible = false;

        // Checking if the DressDropDowns have selected values
        if (DressSizeDropDown.SelectedValue == "1") { DressSizeErrorLabel.Visible = true; }
        else { DressSizeErrorLabel.Visible = false; }

        if (DressColorDropDown.SelectedValue == "1") { DressColorErrorLabel.Visible = true; }
        else { DressColorErrorLabel.Visible = false; }

        if (DressLengthDropDown.SelectedValue == "1") { DressLengthErrorLabel.Visible = true; }
        else { DressLengthErrorLabel.Visible = false; }

        if (ShoeSizeDropDown.SelectedValue == "1") { ShoeSizeErrorLabel.Visible = true; }
        else { ShoeSizeErrorLabel.Visible = false; }

        if (ShoeColorDropDown.SelectedValue == "1") { ShoeColorErrorLabel.Visible = true; }
        else { ShoeColorErrorLabel.Visible = false; }

        if ((DressLengthErrorLabel.Visible == false) &&
            (DressColorErrorLabel.Visible == false) &&
            (DressSizeErrorLabel.Visible == false) &&
            (ShoeSizeErrorLabel.Visible == false) &&
            (ShoeColorErrorLabel.Visible == false))
        {
            // Creating variables to hold a string of the Cinderella's ID and the Godmother's ID
            string SelectedCinderellaID = "";

            // Variables to hold information of dress/shoes/jewelry
            string DressSize = DressSizeDropDown.SelectedValue;
            string DressLength = DressLengthDropDown.SelectedValue;
            string DressColor = DressColorDropDown.SelectedValue;
            string ShoeSize = ShoeSizeDropDown.SelectedValue;
            string ShoeColor = ShoeColorDropDown.SelectedValue;
            string Notes = NotesTextBox.Text;
            string Necklace = "N";
            string HeadPiece = "N";
            string Bracelet = "N";
            string Ring = "N";
            string Earring = "N";
            string Other = "N";

            // Strings to hold today's date and current time
            string today = DateTime.Today.ToString();
            string now = DateTime.Now.ToString();


            // Validating all checkboxes
            if (NecklaceCheckBox.Checked == true)
            {
                Necklace = "Y";
            }
            if (HeadpieceCheckBox.Checked == true)
            {
                HeadPiece = "Y";
            }
            if (BraceletCheckBox.Checked == true)
            {
                Bracelet = "Y";
            }
            if (RingCheckBox.Checked == true)
            {
                Ring = "Y";
            }
            if (EarringCheckBox.Checked == true)
            {
                Earring = "Y";
            }
            if (OtherCheckBox.Checked == true)
            {
                Other = "Y";
            }

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            // SQL for inserting an entirely new Cinderella Package; no Dress in alterations
            if (CinderellaGridView.SelectedRow != null)
            {
                // Creating variables to hold a string of the Cinderella's ID and the Godmother's ID
                SelectedCinderellaID = CinderellaGridView.SelectedValue.ToString();

                // SQL string to INSERT package information
                string sql = "INSERT INTO Package (Cinderella_ID, DressSize, DressColor, DressLength, ShoeSize, ShoeColor, Necklace, Ring, Bracelet, HeadPiece, Earrings, Other, CheckoutNotes, WhenAvailable, InPackaging, InAlterations)"
                                + "VALUES ('" + SelectedCinderellaID + "', '"
                                                + DressSize + "', '" + DressColor + "', '" + DressLength + "', '"
                                                + ShoeSize + "', '" + ShoeColor + "', '"
                                                + Necklace + "', '" + Ring + "', '" + Bracelet + "', '" + HeadPiece + "', '" + Earring + "', '" + Other + "', '"
                                                + Notes + "', '" + today + "', 'Y', 'N')";

                // Execute query
                SqlCommand comm1 = new SqlCommand(sql, conn);
                comm1.ExecuteNonQuery();
            }
            // SQL for updating the Package of a Cinderella whose Dress is in alterations and already in incomplete Package
            else if (PackagesGridView.SelectedRow != null)
            {
                // Creating variables to hold a string of the Cinderella's ID and the Godmother's ID
                SelectedCinderellaID = PackagesGridView.SelectedValue.ToString();

                // SQL string to UPDATE package information with articles
                string sql = "UPDATE Package "
                                + "SET DressSize='" + DressSize + "', DressColor='" + DressColor + "', DressLength='" + DressLength + "', "
                                                + "ShoeSize='" + ShoeSize + "', ShoeColor='" + ShoeColor + "', "
                                                + "Necklace='" + Necklace + "', Ring='" + Ring + "', Bracelet='" + Bracelet + "', Headpiece='" + HeadPiece + "', Earrings='" + Earring + "', Other='" + Other + "', "
                                                + "CheckoutNotes='" + Notes + "', WhenAvailable='" + today + "', InPackaging='Y' "
                                + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";
                // Execute query
                SqlCommand dressUpdate = new SqlCommand(sql, conn);
                dressUpdate.ExecuteNonQuery();
            }

            // Overlapping SQL to update Cinderella's and Volunteer's information
            // Only occurs if a selection is present in a GridView
            if (CinderellaGridView.SelectedRow != null || PackagesGridView.SelectedRow != null)
            {
                // SQL string to SELECT Volunteer ID from selected Cinderella and assign it to a varirable
                string sql = "SELECT Volunteer_ID "
                        + "FROM Cinderella "
                        + "WHERE CinderellaID = '" + SelectedCinderellaID + "'";

                // Execute query
                SqlCommand comm4 = new SqlCommand(sql, conn);
                string GodmotherID = comm4.ExecuteScalar().ToString();

                // SQL string to UPDATE Godmother status 
                sql = "UPDATE VolunteerStatusRecord "
                        + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                        + "WHERE Volunteer_ID = '" + GodmotherID + "' AND IsCurrent = 'Y'";


                // Execute query
                SqlCommand comm5 = new SqlCommand(sql, conn);
                comm5.ExecuteNonQuery();

                // SQL string to INSERT On Break status into StatusRecord
                sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) "
                        + "VALUES ('" + GodmotherID + "', '" + now + "', 'On Break', 'Y')";

                // Execute query
                SqlCommand comm6 = new SqlCommand(sql, conn);
                comm6.ExecuteNonQuery();

                // SQL string to UPDATE Cinderella status 
                sql = "UPDATE CinderellaStatusRecord "
                        + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                        + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "' AND IsCurrent = 'Y'";

                // Execute query
                SqlCommand comm2 = new SqlCommand(sql, conn);
                comm2.ExecuteNonQuery();

                // SQL string to INSERT Waiting status into CinderellaStatusRecord
                sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                        + "VALUES ('" + SelectedCinderellaID + "', '" + now + "', 'Waiting for Package', 'Y')";

                // Execute query
                SqlCommand comm3 = new SqlCommand(sql, conn);
                comm3.ExecuteNonQuery();
            }
            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            string Cinderella = "";

            if (PackagesGridView.SelectedIndex != -1)
            {
                Cinderella = PackagesGridView.SelectedRow.Cells[2].Text
                                    + " "
                                    + PackagesGridView.SelectedRow.Cells[1].Text;
            }
            else
            {
                Cinderella = CinderellaGridView.SelectedRow.Cells[2].Text
                                    + " "
                                    + CinderellaGridView.SelectedRow.Cells[1].Text;
            }

            // Notifying user that package was created
            UserNotificationLabel.Text = "Cinderella "
                                        + Cinderella
                                        + "'s package was created. "
                                        + "To Edit the package and add dresses from alterations to it, "
                                        + "see the Edit Package page.";
            UserNotificationLabel.Visible = true;
            UserNotificationLabel.ForeColor = System.Drawing.Color.Green;

            // Rebind the data to refresh the Grid
            CinderellaGridView.DataBind();
            CinderellaGridView.SelectedIndex = -1;
            PackagesGridView.DataBind();
            PackagesGridView.SelectedIndex = -1;

            // Disabling checkout button
            CheckoutButton.Enabled = false;

            // Resetting shoes and dresses to default values
            ShoeSizeDropDown.SelectedValue = "1";
            ShoeColorDropDown.SelectedValue = "1";
            DressSizeDropDown.SelectedValue = "1";
            DressColorDropDown.SelectedValue = "1";
            DressLengthDropDown.SelectedValue = "1";

            // Clearing the checkboxes
            NecklaceCheckBox.Checked = false;
            RingCheckBox.Checked = false;
            HeadpieceCheckBox.Checked = false;
            EarringCheckBox.Checked = false;
            BraceletCheckBox.Checked = false;
            OtherCheckBox.Checked = false;

            NotesTextBox.Text = "";
        }
        else
        {
            UserNotificationLabel.Text = "ERROR: Please select all necessary information.";
            UserNotificationLabel.Visible = true;
            UserNotificationLabel.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void CinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckoutButton.Enabled = true;

        // Removing Dresses selector
        PackagesGridView.SelectedIndex = -1;

    }
    protected void PackagesGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckoutButton.Enabled = true;

        // Removing Cinderella selector
        CinderellaGridView.SelectedIndex = -1;

        // Entering Dress information into the drops downs 
        DressSizeDropDown.SelectedValue = PackagesGridView.SelectedRow.Cells[3].Text.ToString();
        DressLengthDropDown.SelectedValue = PackagesGridView.SelectedRow.Cells[4].Text.ToString();
        DressColorDropDown.SelectedValue = PackagesGridView.SelectedRow.Cells[5].Text.ToString();

        // Resetting shoes to default values
        ShoeSizeDropDown.SelectedValue = "1";
        ShoeColorDropDown.SelectedValue = "1";

        // Clearing the checkboxes
        NecklaceCheckBox.Checked = false;
        RingCheckBox.Checked = false;
        HeadpieceCheckBox.Checked = false;
        EarringCheckBox.Checked = false;
        BraceletCheckBox.Checked = false;
        OtherCheckBox.Checked = false;

        NotesTextBox.Text = "";
    }
}