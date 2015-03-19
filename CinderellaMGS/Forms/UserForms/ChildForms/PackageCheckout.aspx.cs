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

public partial class Forms_UserForms_ChildForms_PackageCheckout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();

        // Disabling Checkboxes and notes 
        NecklaceCheckBox.Enabled = false;
        RingCheckBox.Enabled = false;
        BraceletCheckBox.Enabled = false;
        HeadpieceCheckBox.Enabled = false;
        EarringCheckBox.Enabled = false;
        OtherCheckBox.Enabled = false;
        NotesTextBox.Enabled = false;
    }
    protected void CheckOutButton_Click(object sender, EventArgs e)
    {
        // Checking to make sure a Volunteer is selected
        if (CinderellaPackageGridView.SelectedRow == null)
        {
            SelectionValidationLabel.Visible = true;
        }
        else
        {
            // Hiding validator
            SelectionValidationLabel.Visible = false;

            // Creating a variable to hold a string of the Cinderella's ID
            string SelectedPackageCinderellaID = CinderellaPackageGridView.SelectedValue.ToString();

            // Creating a variable to hold the current time
            string now = DateTime.Now.ToString();

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            // SQL string to UPDATE Package InPackaging status 
            string sql = "UPDATE Package "
                            + "SET InPackaging = 'N' "
                            + "WHERE Cinderella_ID = '" + SelectedPackageCinderellaID + "'";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            // SQL string to UPDATE Cinderella 'Waiting' status to not current
            sql = "UPDATE CinderellaStatusRecord "
                    + "SET IsCurrent = 'N', EndTime = '" + now + "' "
                    + "WHERE Cinderella_ID = '" + SelectedPackageCinderellaID + "' AND IsCurrent = 'Y'";

            // Execute query
            SqlCommand comm2 = new SqlCommand(sql, conn);
            comm2.ExecuteNonQuery();

            // SQL string to INSERT Cinderella 'Checked Out' status to StatusRecord
            sql = "INSERT INTO CinderellaStatusRecord(Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                    + "VALUES ('" + SelectedPackageCinderellaID + "', '" + now + "', 'Checked Out', 'Y')";

            // Execute query
            SqlCommand comm3 = new SqlCommand(sql, conn);
            comm3.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            // Rebind the data to refresh the Grid
            CinderellaPackageGridView.DataBind();
            CinderellaPackageGridView.SelectedIndex = -1;
        }
    }
    protected void CinderellaPackageGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        string SelectedCinderellaID = CinderellaPackageGridView.SelectedValue.ToString();
        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn1.Open();

        // SQL query to SELECT Package data from Selected Cinderella
        string sql = "SELECT Cinderella_ID, DressSize, DressColor, DressLength, "
                                + "ShoeSize, ShoeColor, "
                                + "Necklace, Ring, Bracelet, Headpiece, Earrings, Other, CheckoutNotes "
                        + "FROM Package "
                        + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";

        //Execute query 
        SqlCommand comm1 = new SqlCommand(sql, conn1);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(comm1);

        //Create a new dataset to hold the query results
        DataSet dataSet = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(dataSet);

        // Setting the Dress and Shoe information
        DressSizeLabel.Text = dataSet.Tables[0].Rows[0]["DressSize"].ToString();
        DressColorLabel.Text = dataSet.Tables[0].Rows[0]["DressColor"].ToString();
        DressLengthLabel.Text = dataSet.Tables[0].Rows[0]["DressLength"].ToString();
        ShoeSizeLabel.Text = dataSet.Tables[0].Rows[0]["ShoeSize"].ToString();
        ShoeColorLabel.Text = dataSet.Tables[0].Rows[0]["ShoeColor"].ToString();

        // Setting the various Checkbox information
        if (dataSet.Tables[0].Rows[0]["Necklace"].ToString() == "Y") { NecklaceCheckBox.Checked = true; }
        else { NecklaceCheckBox.Checked = false; }

        if (dataSet.Tables[0].Rows[0]["Ring"].ToString() == "Y") { RingCheckBox.Checked = true; }
        else { RingCheckBox.Checked = false; }

        if (dataSet.Tables[0].Rows[0]["Bracelet"].ToString() == "Y") { BraceletCheckBox.Checked = true; }
        else { BraceletCheckBox.Checked = false; }

        if (dataSet.Tables[0].Rows[0]["Headpiece"].ToString() == "Y") { HeadpieceCheckBox.Checked = true; }
        else { HeadpieceCheckBox.Checked = false; }

        if (dataSet.Tables[0].Rows[0]["Earrings"].ToString() == "Y") { EarringCheckBox.Checked = true; }
        else { EarringCheckBox.Checked = false; }

        if (dataSet.Tables[0].Rows[0]["Other"].ToString() == "Y") { OtherCheckBox.Checked = true; }
        else { OtherCheckBox.Checked = false; }

        NotesTextBox.Text = dataSet.Tables[0].Rows[0]["CheckoutNotes"].ToString();

        // Disabling Checkboxes and notes 
        NecklaceCheckBox.Enabled = false;
        RingCheckBox.Enabled = false;
        BraceletCheckBox.Enabled = false;
        HeadpieceCheckBox.Enabled = false;
        EarringCheckBox.Enabled = false;
        OtherCheckBox.Enabled = false;
        NotesTextBox.Enabled = false;


        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();
    }
}