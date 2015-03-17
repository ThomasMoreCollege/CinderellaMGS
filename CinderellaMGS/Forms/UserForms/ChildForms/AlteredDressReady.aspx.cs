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

public partial class Forms_UserForms_ChildForms_AlteredDressReady : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CinderellaDressAlterationsGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Marks the dress as ready for pickup
        MarkDressAsReadyButton.Enabled = true;
    }
    protected void MarkDressAsReadyButton_Click(object sender, EventArgs e)
    {
        string SelectedCinderellaID = CinderellaDressAlterationsGridView.SelectedValue.ToString();

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Open the connection 
        conn.Open();

        string sql = "UPDATE Alteration "
                        + "SET ReadyForPickup = 'Y' "
                        + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "'";
        // Execute query
        SqlCommand comm1 = new SqlCommand(sql, conn);
        comm1.ExecuteNonQuery();

        //REMEMBER TO CLOSE CONNECTION!!
        conn.Close();

        // Rebind the data to refresh the Grid
        CinderellaDressAlterationsGridView.DataBind();
        CinderellaDressAlterationsGridView.SelectedIndex = -1;
    }
}