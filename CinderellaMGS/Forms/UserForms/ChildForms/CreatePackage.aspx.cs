﻿using System;
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
            string sql = "INSERT INTO Package (Cinderella_ID, DressSize, DressColor, DressLength, ShoeSize, ShoeColor, Necklace, Ring, Bracelet, HeadPiece, Earrings, Other, CheckoutNotes, WhenAvailable, InPackaging)"
                            + " VALUES ('" + SelectedCinderellaID + "', '"
                                            + DressSize + "', '" + DressColor + "', '" + DressLength + "', '"
                                            + ShoeSize + "', '" + ShoeColor + "', '"
                                            + Necklace + "', '" + Ring + "', '" + Bracelet + "', '" + HeadPiece + "', '" + Earring + "', '" + Other + "', '"
                                            + Notes + "', '" + today + "', 'Y')";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

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
        // SQL for updating the Package of a Cinderella whose Dress is in alterations and already in incomplete Package
        else if (DressesInAlterationsGridView.SelectedRow != null)
        {
            // Creating variables to hold a string of the Cinderella's ID and the Godmother's ID
            SelectedCinderellaID = DressesInAlterationsGridView.SelectedValue.ToString();

            // SQL string to UPDATE package information with rest of articles
            string sql = "UPDATE Package (ShoeSize, ShoeColor, Necklace, Ring, Bracelet, HeadPiece, Earrings, Other, CheckoutNotes, WhenAvailable, InPackaging)"
                            + " VALUES ('" + ShoeSize + "', '" + ShoeColor + "', '"
                                            + Necklace + "', '" + Ring + "', '" + Bracelet + "', '" + HeadPiece + "', '" + Earring + "', '" + Other + "', '"
                                            + Notes + "', '" + today + "', 'Y')"
                            + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";
        }

        // Overlapping SQL to update Cinderella's Volunteer's information
        // Only occurs if a selection is present in a GridView
        if (CinderellaGridView.SelectedRow != null || DressesInAlterationsGridView.SelectedRow != null)
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
        }
        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();

        // Rebind the data to refresh the Grid
        CinderellaGridView.DataBind();
        CinderellaGridView.SelectedIndex = -1;
        CheckoutButton.Enabled = false;
    }
    protected void CinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckoutButton.Enabled = true;

        // Enabling Dress information drop-downs and removing Dresses selector
        DressesInAlterationsGridView.SelectedIndex = -1;
        DressSizeDropDown.Enabled = true;
        DressColorDropDown.Enabled = true;
        DressLengthDropDown.Enabled = true;
    }
    protected void DressesInAlterationsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckoutButton.Enabled = true;

        // Disabling Dress information drop-downs and removing Cinderella selector
        CinderellaGridView.SelectedIndex = -1;
        DressSizeDropDown.Enabled = false;
        DressColorDropDown.Enabled = false;
        DressLengthDropDown.Enabled = false;


        // Entering Dress information into the drops downs 
        DressSizeDropDown.SelectedValue = DressesInAlterationsGridView.SelectedRow.Cells[3].Text.ToString();
        DressLengthDropDown.SelectedValue = DressesInAlterationsGridView.SelectedRow.Cells[4].Text.ToString();
        DressColorDropDown.SelectedValue = DressesInAlterationsGridView.SelectedRow.Cells[5].Text.ToString();
    }
}