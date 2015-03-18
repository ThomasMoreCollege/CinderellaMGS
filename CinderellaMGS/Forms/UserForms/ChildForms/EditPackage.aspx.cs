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

public partial class Forms_UserForms_ChildForms_EditPackage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();

        // Disabling the controls until a GridView value is selected
        EditPackageButton.Enabled = false;
        DressDeliveredButton.Enabled = false;
        NecklaceCheckBox.Enabled = false;
        BraceletCheckBox.Enabled = false;
        RingCheckBox.Enabled = false;
        HeadpieceCheckBox.Enabled = false;
        EarringCheckBox.Enabled = false;
        OtherCheckBox.Enabled = false;
        DressSizeDropDown.Enabled = false;
        DressColorDropDown.Enabled = false;
        DressLengthDropDown.Enabled = false;
        ShoeSizeDropDown.Enabled = false;
        ShoeColorDropDown.Enabled = false;
    }
   
    protected void DressDeliveredButton_Click(object sender, EventArgs e)
    {
        string SelectedCinderellaID = DressDeliveryGridView.SelectedValue.ToString();

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection.
        conn1.Open();

        string sql = "UPDATE Package "
                        + "SET InAlterations = 'N' "
                        + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";

        // Execute SQL
        SqlCommand comm1 = new SqlCommand(sql, conn1);
        comm1.ExecuteNonQuery();

        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();

        // Rebind the data to refresh the grid
        DressDeliveryGridView.DataBind();
        DressDeliveryGridView.SelectedIndex = -1;

        CinderellaPackageGridView.DataBind();
        CinderellaPackageGridView.SelectedIndex = -1;
    }
    protected void DressDeliveryGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        CinderellaPackageGridView.SelectedIndex = -1;

        // Enabling the dress delivered button
        DressDeliveredButton.Enabled = true;

        // Disabling the Package information area
        EditPackageButton.Enabled = false;
        NecklaceCheckBox.Enabled = false;
        BraceletCheckBox.Enabled = false;
        RingCheckBox.Enabled = false;
        HeadpieceCheckBox.Enabled = false;
        EarringCheckBox.Enabled = false;
        OtherCheckBox.Enabled = false;
        DressSizeDropDown.Enabled = false;
        DressColorDropDown.Enabled = false;
        DressLengthDropDown.Enabled = false;
        ShoeSizeDropDown.Enabled = false;
        ShoeColorDropDown.Enabled = false;
    }
    protected void CinderellaPackageGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        DressDeliveryGridView.SelectedIndex = -1;

        // Disabling the dress delivered button
        DressDeliveredButton.Enabled = false;

        // Enabling the Package information area
        EditPackageButton.Enabled = true;
        NecklaceCheckBox.Enabled = true;
        BraceletCheckBox.Enabled = true;
        RingCheckBox.Enabled = true;
        HeadpieceCheckBox.Enabled = true;
        EarringCheckBox.Enabled = true;
        OtherCheckBox.Enabled = true;
        DressSizeDropDown.Enabled = true;
        DressColorDropDown.Enabled = true;
        DressLengthDropDown.Enabled = true;
        ShoeSizeDropDown.Enabled = true;
        ShoeColorDropDown.Enabled = true;

        string SelectedCinderellaID = CinderellaPackageGridView.SelectedValue.ToString();

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection.
        conn1.Open();

        // SQL to retrieve selected Cinderella's Package information
        string sql = "SELECT DressSize, DressColor, DressLength, "
                        + "ShoeSize, ShoeColor, "
                        + "Necklace, Bracelet, Ring, Headpiece, Earrings, Other, "
                        + "CheckoutNotes "
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

        // Entereing in Package's Dress values
        DressSizeDropDown.SelectedValue = dataSet.Tables[0].Rows[0]["DressSize"].ToString();
        DressColorDropDown.SelectedValue = dataSet.Tables[0].Rows[0]["DressColor"].ToString();
        DressLengthDropDown.SelectedValue = dataSet.Tables[0].Rows[0]["DressLength"].ToString();

        // Entering in Package's Shoe values
        ShoeSizeDropDown.SelectedValue = dataSet.Tables[0].Rows[0]["ShoeSize"].ToString();
        ShoeColorDropDown.SelectedValue = dataSet.Tables[0].Rows[0]["ShoeColor"].ToString();

        // Entering in Package's Jewelry values
        if (dataSet.Tables[0].Rows[0]["Necklace"].ToString() == "Y") { NecklaceCheckBox.Checked = true; }
        else { NecklaceCheckBox.Checked = false; }
        if (dataSet.Tables[0].Rows[0]["Bracelet"].ToString() == "Y") { BraceletCheckBox.Checked = true; }
        else { BraceletCheckBox.Checked = false; }
        if (dataSet.Tables[0].Rows[0]["Ring"].ToString() == "Y") { RingCheckBox.Checked = true; }
        else { RingCheckBox.Checked = false; }
        if (dataSet.Tables[0].Rows[0]["Headpiece"].ToString() == "Y") { HeadpieceCheckBox.Checked = true; }
        else { HeadpieceCheckBox.Checked = false; }
        if (dataSet.Tables[0].Rows[0]["Earrings"].ToString() == "Y") { EarringCheckBox.Checked = true; }
        else { EarringCheckBox.Checked = false; }
        if (dataSet.Tables[0].Rows[0]["Other"].ToString() == "Y") { OtherCheckBox.Checked = true; }
        else { OtherCheckBox.Checked = false; }

        // Entering in the PackageNotes
        NotesTextBox.Text = dataSet.Tables[0].Rows[0]["CheckoutNotes"].ToString();

        //REMEMBER TO CLOSE CONNECTION!!
        conn1.Close();
    }
    protected void EditPackageButton_Click(object sender, EventArgs e)
    {
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
            // Variable to hold selected cinderella's ID
            string SelectedCinderellaID = CinderellaPackageGridView.SelectedValue.ToString();

            // Variables to hold chosen modules of checkboxes
            char packNecklace = 'N';
            char packRing = 'N';
            char packBracelet = 'N';
            char packHeadpiece = 'N';
            char packEarrings = 'N';
            char packOther = 'N';

            // Checking if the checkboxes are checked
            if (NecklaceCheckBox.Checked == true) { packNecklace = 'Y'; }
            if (RingCheckBox.Checked == true) { packRing = 'Y'; }
            if (BraceletCheckBox.Checked == true) { packBracelet = 'Y'; }
            if (HeadpieceCheckBox.Checked == true) { packHeadpiece = 'Y'; }
            if (EarringCheckBox.Checked == true) { packEarrings = 'Y'; }
            if (OtherCheckBox.Checked == true) { packOther = 'Y'; }

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection.
            conn1.Open();

            // SQL string to update Package with user entered information
            string sql = "UPDATE Package "
                            + "SET DressSize='" + DressSizeDropDown.SelectedValue
                                + "', DressColor ='" + DressColorDropDown.SelectedValue
                                + "', DressLength ='" + DressLengthDropDown.SelectedValue
                                + "', ShoeSize='" + ShoeSizeDropDown.SelectedValue
                                + "', ShoeColor='" + ShoeColorDropDown.SelectedValue
                                + "', Necklace='" + packNecklace
                                + "', Ring='" + packRing
                                + "', Bracelet='" + packBracelet
                                + "', Headpiece='" + packHeadpiece
                                + "', Earrings='" + packEarrings
                                + "', Other='" + packOther
                                + "', CheckoutNotes='" + NotesTextBox.Text + "'"
                            + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";

            // Execute SQL
            SqlCommand comm1 = new SqlCommand(sql, conn1);
            comm1.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn1.Close();

            // Rebind the data to refresh the grid
            DressDeliveryGridView.DataBind();
            DressDeliveryGridView.SelectedIndex = -1;

            CinderellaPackageGridView.DataBind();
            CinderellaPackageGridView.SelectedIndex = -1;
        }
        else
        {
            // Disabling the dress delivered button
            DressDeliveredButton.Enabled = false;

            // Enabling the Package information area
            EditPackageButton.Enabled = true;
            NecklaceCheckBox.Enabled = true;
            BraceletCheckBox.Enabled = true;
            RingCheckBox.Enabled = true;
            HeadpieceCheckBox.Enabled = true;
            EarringCheckBox.Enabled = true;
            OtherCheckBox.Enabled = true;
            DressSizeDropDown.Enabled = true;
            DressColorDropDown.Enabled = true;
            DressLengthDropDown.Enabled = true;
            ShoeSizeDropDown.Enabled = true;
            ShoeColorDropDown.Enabled = true;
        }
    }
}