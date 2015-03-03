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

            // SQL string to UPDATE Pending status 
            string sql = "UPDATE Package SET InPackaging = 'N' WHERE Cinderella_ID = '" + SelectedPackageCinderellaID + "'";

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
}