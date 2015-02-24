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

public partial class Forms_AdminForms_ManualPairing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MatchButton_Click(object sender, EventArgs e)
    {
        if (CinderellaGridView.SelectedRow == null)
        {
            // Outputs error message if no Cinderella is selected
            String errorVar = "Please select a Cinderella";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else if (GodmotherGridView.SelectedRow == null)
        {
            // Outputs error message if no Godmother is selected
            String errorVar = "Please select a Godmother";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else
        {
            // Creating variables to hold a string of the Cinderella's and Gomother's ID
            string SelectedCinderellaID = CinderellaGridView.SelectedValue.ToString();
            string SelectedGodmotherID = GodmotherGridView.SelectedValue.ToString();

            /*
            //Initialize database connection with "DefaultConnection" setup in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            //Open the connection 
            conn.Open();

            string sql = "UPDATE Cinderella SET Volunteer_ID = '" + SelectedGodmotherID + "'WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";

            // Execute query
            SqlCommand comm1 = new SqlCommand(sql, conn);
            comm1.ExecuteNonQuery();

            //REMEMBER TO CLOSE CONNECTION!!
            conn.Close();

            // Rebind the data to refresh the Grid
            CinderellaGridView.DataBind();
            CinderellaGridView.SelectedIndex = -1;

            GodmotherGridView.DataBind();
            GodmotherGridView.SelectedIndex = -1;
             * */
        }
    }
}