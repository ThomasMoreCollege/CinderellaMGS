using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            // Creating a variable to hold a string of the Cinderella's ID
            string SelectedCinderellaID = CinderellaGridView.SelectedValue.ToString();

            // Variables to hold information of dress/shoes/jewelry
            string DressSize = DressSizeDropDown.SelectedValue;
            string DressLength = DressLengthDropDown.SelectedValue;
            string DressColor = DressColorDropDown.SelectedValue;
            string ShoeSize = ShoeSizeDropDown.SelectedValue;
            string ShoeColor = ShoeColorDropDown.SelectedValue;
            string Notes = NotesTextBox.Text;
            if (NecklaceCheckBox.Checked == true)
            {
                string Necklace = "Y";
            }
            if (HeadpieceCheckBox.Checked == true)
            {
                string HeadPiece = "Y";
            }
            if (BraceletCheckBox.Checked == true)
            {
                string Bracelet = "Y";
            }
            if (RingCheckBox.Checked == true)
            {
                string Ring = "Y";
            }
            if (EarringCheckBox.Checked == true)
            {
                string Earring = "Y";
            }
            if (OtherCheckBox.Checked == true)
            {
                string Other = "Y";
            }
        }
        // SQL code to add appropriate information into Package entity
    }
}