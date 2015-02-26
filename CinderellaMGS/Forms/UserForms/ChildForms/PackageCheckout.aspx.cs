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

            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            // SQL string to UPDATE Pending status 
            string sql = "UPDATE Package SET InPackaging = 'N' WHERE Cinderella_ID = '" + SelectedPackageCinderellaID + "'";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            // Rebind the data to refresh the Grid
            CinderellaPackageGridView.DataBind();
            CinderellaPackageGridView.SelectedIndex = -1;
        }
    }
}