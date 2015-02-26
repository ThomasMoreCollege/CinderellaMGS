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
        // Checking if a session is running
        if ((Session["CurrentUser"] == null) || (Session["CurrentUser"].ToString()) != "Admin")
        {
            // Sets admin menu to not visible
            (this.Master as MasterPage).RevealAdmin(false);
        }
        else if ((Session["CurrentUser"].ToString()) == "Admin")
        {
            // Sets admin menu links to visible for admin access
            (this.Master as MasterPage).RevealAdmin(true);
        }
    }
    protected void CheckoutButton_Click(object sender, EventArgs e)
    {
        // Input validation to guarantee a Cinderella is selected
        if (CinderellaGridView.SelectedRow == null)
        {
            CinderellaValidator.Visible = true;
        }
        else
        {
            CinderellaValidator.Visible = false;

            // Creating variables to hold a string of the Cinderella's ID and the Godmother's ID
            string SelectedCinderellaID = CinderellaGridView.SelectedValue.ToString();

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

            // SQL string to INSERT package information
            string sql = "INSERT INTO Package (Cinderella_ID, DressSize, DressColor, DressLength, ShoeSize, ShoeColor, Necklace, Ring, Bracelet, HeadPiece, Earrings, Other, CheckoutNotes, WhenAvailable, InPackaging)"
                            + " VALUES ('" + SelectedCinderellaID + "', '" 
                                            + DressSize + "', '" + DressColor + "', '" + DressLength + "', '" 
                                            + ShoeSize + "', '" + ShoeColor + "', '" 
                                            + Necklace + "', '" + Ring + "', '" + Bracelet + "', '" + HeadPiece + "', '" + Earring + "', '" + Other + "', '" 
                                            + Notes +"', '" + today + "', 'Y')";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            // SQL string to UPDATE Cinderella status 
            sql = "UPDATE CinderellaStatusRecord SET EndTime = '" + now + "', IsCurrent = 'N' WHERE Cinderella_ID = '" + SelectedCinderellaID + "' AND IsCurrent = 'Y'";

            // Execute query
            SqlCommand comm2 = new SqlCommand(sql, conn);
            comm2.ExecuteNonQuery();

            // SQL string to INSERT Waiting status into StatusRecord
            sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + SelectedCinderellaID + "', '" + now + "', 'Waiting for Package', 'Y')";

            // Execute query
            SqlCommand comm3 = new SqlCommand(sql, conn);
            comm3.ExecuteNonQuery();
            
            // SQL string to SELECT volunteer ID from selected Cinderella and assign it to a varirable
            sql = "SELECT Volunteer_ID FROM Cinderella WHERE CinderellaID = '" + SelectedCinderellaID + "'";
            
            // Execute query
            SqlCommand comm4 = new SqlCommand(sql, conn);
            string GodmotherID = comm4.ExecuteScalar().ToString();

            // SQL string to UPDATE Godmother status 
            sql = "UPDATE VolunteerStatusRecord SET EndTime = '" + now + "', IsCurrent = 'N' WHERE Volunteer_ID = '" + GodmotherID + "' AND IsCurrent = 'Y'";
           

            // Execute query
            SqlCommand comm5 = new SqlCommand(sql, conn);
            comm5.ExecuteNonQuery();

            // SQL string to INSERT On Break status into StatusRecord
            sql = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + GodmotherID + "', '" + now + "', 'On Break', 'Y')";

            // Execute query
            SqlCommand comm6 = new SqlCommand(sql, conn);
            comm6.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();
        }
        // SQL code to add appropriate information into Package entity
    }
}