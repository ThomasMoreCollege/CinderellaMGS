using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL
using System.Data; // Must be included if using data tables

public partial class Forms_UserForms_EditCinderella : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CinderellaGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Enable textboxes and save button
        FirstNameTextBox.Enabled = true;
        LastNameTextBox.Enabled = true;
        EmailTextBox.Enabled = true;
        PhoneTextBox.Enabled = true;

        //Enable buttons
        EditCinderellaFormButton.Enabled = true;
        CancelButton.Enabled = true;

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Store Query string
        string retrieveVolunteerInfoQuery = "SELECT FirstName, LastName, Email, Phone"
                                            + " FROM Cinderella "
                                            + " WHERE CinderellaID ='" + CinderellaGridView.SelectedValue.ToString() + "'";

        //Execute query 
        SqlCommand retrieveInfo = new SqlCommand(retrieveVolunteerInfoQuery, conn1);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(retrieveInfo);

        //Create a new dataset to hold the query results
        DataSet CinderellaDS = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(CinderellaDS);

        //Display appropiate info based on selected volunteer
        FirstNameLabel.Text = CinderellaDS.Tables[0].Rows[0]["FirstName"].ToString();
        LastNameLabel.Text = CinderellaDS.Tables[0].Rows[0]["LastName"].ToString();
        EmailLabel.Text = CinderellaDS.Tables[0].Rows[0]["Email"].ToString();
        PhoneLabel.Text = CinderellaDS.Tables[0].Rows[0]["Phone"].ToString();
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        //Disable buttons
        EditCinderellaFormButton.Enabled = false;
        CancelButton.Enabled = false;

        //Disable Textboxes
        FirstNameTextBox.Enabled = false;
        LastNameTextBox.Enabled = false;
        EmailTextBox.Enabled = false;
        PhoneTextBox.Enabled = false;

        //Empty labels
        FirstNameLabel.Text = "--";
        LastNameLabel.Text = "--";
        EmailLabel.Text = "--";
        PhoneLabel.Text = "--";

        //Set index to nothing for grid view
        CinderellaGridView.SelectedIndex = -1;

    }
    protected void EditCinderellaFormButton_Click(object sender, EventArgs e)
    {
        
    }
    protected void EditCinderellaFormButton_Click1(object sender, EventArgs e)
    {
        //Counts how many text boxes where left empty
        int emptyCounter = 0;

        string firstName = FirstNameTextBox.Text.Trim();
        if (firstName == string.Empty)
        {
            firstName = FirstNameLabel.Text;
            emptyCounter++;
        }

        string lastName = LastNameTextBox.Text.Trim();
        if (lastName == string.Empty)
        {
            lastName = LastNameLabel.Text;
            emptyCounter++;
        }

        string email = EmailTextBox.Text.Trim();
        if (email == string.Empty)
        {
            email = EmailLabel.Text;
            emptyCounter++;
        }

        string phone = PhoneTextBox.Text.Trim();
        if (phone == string.Empty)
        {
            phone = PhoneLabel.Text;
            emptyCounter++;
        }


        if (IsValid && emptyCounter < 4)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                //Open the connection 
                conn.Open();
                string editVolQuery = "UPDATE Cinderella SET FirstName = @Vfname, LastName = @Vlname, Phone = @Vphone, Email = @Vemail "
                                        + "WHERE CinderellaID = '" + CinderellaGridView.SelectedValue.ToString() + "'";
               
                SqlCommand editCinderella = new SqlCommand(editVolQuery, conn);

                //Add values to variables in the query
                editCinderella.Parameters.AddWithValue("@Vfname", firstName);
                editCinderella.Parameters.AddWithValue("@Vlname", lastName);
                editCinderella.Parameters.AddWithValue("@Vphone", phone);
                editCinderella.Parameters.AddWithValue("@Vemail", email);

                // Execute query
                editCinderella.ExecuteNonQuery();

                conn.Close();

                //Empty textboxes
                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                PhoneTextBox.Text = "";
                EmailTextBox.Text = "";

                //Disable buttons
                EditCinderellaFormButton.Enabled = false;
                CancelButton.Enabled = false;

                //Disable Textboxes
                FirstNameTextBox.Enabled = false;
                LastNameTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                PhoneTextBox.Enabled = false;


                //Empty labels
                FirstNameLabel.Text = "--";
                LastNameLabel.Text = "--";
                EmailLabel.Text = "--";
                PhoneLabel.Text = "--";


                //Display message
                SuccessLabel.Text = "Update Successful!";
                SuccessLabel.ForeColor = System.Drawing.Color.Green;
                SuccessLabel.Visible = true;


                //Resfresh grid 
                CinderellaGridView.DataSourceID = "CinderellaDS";
                CinderellaGridView.DataBind();

                //Unselect volunteer
                CinderellaGridView.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                SuccessLabel.Text = "An error has occur. Contact an administrator to resolve error.";
                SuccessLabel.ForeColor = System.Drawing.Color.Red;
                SuccessLabel.Visible = true;
            }
        }
        else
        {
            //Display message 
            SuccessLabel.Text = "No changes were saved.";
            SuccessLabel.ForeColor = System.Drawing.Color.Red;
            SuccessLabel.Visible = true;

            //Empty textboxes
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            PhoneTextBox.Text = "";
            EmailTextBox.Text = "";

            //Disable buttons
            EditCinderellaFormButton.Enabled = false;
            CancelButton.Enabled = false;

            //Disable Textboxes
            FirstNameTextBox.Enabled = false;
            LastNameTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
            PhoneTextBox.Enabled = false;

            //Empty labels
            FirstNameLabel.Text = "--";
            LastNameLabel.Text = "--";
            EmailLabel.Text = "--";
            PhoneLabel.Text = "--";

            //Resfresh grid 
            CinderellaGridView.DataSourceID = "CinderellaDS";
            CinderellaGridView.DataBind();

            //Unselect volunteer
            CinderellaGridView.SelectedIndex = -1;

        }
    }
}