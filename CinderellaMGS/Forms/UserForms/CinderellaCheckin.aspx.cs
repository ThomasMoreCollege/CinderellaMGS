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

public partial class Forms_CinderellaCheckin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }

    protected void CheckInButton_Click(object sender, EventArgs e)
    {
        // Checking to make sure a Cinderella is selected
        if (CinderellaGridView.SelectedRow == null)
        {
            // Outputs error message if no Cinderella is selected
            String errorVar = "Please select a Cinderella";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorVar + "');", true);
        }
        else
        {
            try
            {
                // Creating a variable to hold a string of the Cinderella's ID
                string SelectedCinderellaID = CinderellaGridView.SelectedValue.ToString();

                // Creating a variable to hold the current time
                string now = DateTime.Now.ToString();

                //Initialize database connection with "DefaultConnection" setup in the web.config
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                //Open the connection 
                conn.Open();

                // SQL string to UPDATE Pending status 
                string sql = "UPDATE CinderellaStatusRecord "
                            + "SET EndTime = '" + now + "', IsCurrent = 'N' "
                            + "WHERE Cinderella_ID = '" + SelectedCinderellaID + "' AND IsCurrent = 'Y'";

                // Execute query
                SqlCommand comm1 = new SqlCommand(sql, conn);
                comm1.ExecuteNonQuery();

                // SQL string to INSERT Waiting status into StatusRecord
                sql = "INSERT INTO CinderellaStatusRecord (Cinderella_ID, StartTime, Status_Name, IsCurrent) "
                        + "VALUES ('" + SelectedCinderellaID + "', '" + now + "', 'Waiting for Godmother', 'Y')";

                // Execute query
                SqlCommand comm2 = new SqlCommand(sql, conn);
                comm2.ExecuteNonQuery();

                //REMEMBER TO CLOSE CONNECTION!!
                conn.Close();

                GridViewRow currentRow = CinderellaGridView.SelectedRow;

                string notification = "" + currentRow.Cells[2].Text + " " + currentRow.Cells[1].Text + " has been successfully checked in!";
                SuccessLabel.Text = notification;
                SuccessLabel.Visible = true;

                // Rebind the data to refresh the Grid
                CinderellaGridView.DataBind();
                CinderellaGridView.SelectedIndex = -1;

            }
            catch
            {

            }
        }
    }
    protected void CinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        SuccessLabel.Visible = false;
    }
}