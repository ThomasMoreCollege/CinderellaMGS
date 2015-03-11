using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //Must be include if using SQL
using System.Configuration; //Must be include if using SQL
using System.Data; // Must be included if using data tables

public partial class Forms_AdminForms_ChildForms_EditVolunteer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }
    protected void VolunteerGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Disable succcess label
        SuccessLabel.Visible = false;

        //Enable textboxes and save button
        FirstNameTextBox.Enabled = true;
        LastNameTextBox.Enabled = true;
        EmailTextBox.Enabled = true;
        PhoneTextBox.Enabled = true;
        AddressTextBox.Enabled = true;
        CityTextBox.Enabled = true;
        StateTextBox.Enabled = true;
        ZipcodeTextBox.Enabled = true;

        //Enable buttons
        EditVolunterFormButton.Enabled = true;
        CancelButton.Enabled = true;

        //Initialize database connection with "DefaultConnection" setup in the web.config
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //Store Query string
        string retrieveVolunteerInfoQuery = "SELECT FirstName,LastName,Email,Phone,Address,City,State,Zipcode "
                                            + "FROM Volunteer "
                                            + "WHERE VolunteerID='" + VolunteerGridView.SelectedValue.ToString() + "'";

        //Execute query 
        SqlCommand retrieveInfo = new SqlCommand(retrieveVolunteerInfoQuery, conn1);

        //Create a new adapter
        SqlDataAdapter adapter = new SqlDataAdapter(retrieveInfo);

        //Create a new dataset to hold the query results
        DataSet dataSet = new DataSet();

        //Store the results in the adapter 
        adapter.Fill(dataSet);

        //Display appropiate info based on selected volunteer
        FirstNameLabel.Text = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
        LastNameLabel.Text = dataSet.Tables[0].Rows[0]["LastName"].ToString();
        EmailLabel.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
        PhoneLabel.Text = dataSet.Tables[0].Rows[0]["Phone"].ToString();
        AddressLabel.Text = dataSet.Tables[0].Rows[0]["Address"].ToString();
        CityLabel.Text = dataSet.Tables[0].Rows[0]["City"].ToString();
        StateLabel.Text = dataSet.Tables[0].Rows[0]["State"].ToString();
        ZipcodeLabel.Text = dataSet.Tables[0].Rows[0]["Zipcode"].ToString();
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        //Disable/empty everything

        //Disable buttons
        EditVolunterFormButton.Enabled = false;
        CancelButton.Enabled = false;

        //Disable Textboxes
        FirstNameTextBox.Enabled = false;
        LastNameTextBox.Enabled = false;
        EmailTextBox.Enabled = false;
        PhoneTextBox.Enabled = false;
        AddressTextBox.Enabled = false;
        CityTextBox.Enabled = false;
        StateTextBox.Enabled = false;
        ZipcodeTextBox.Enabled = false;

        //Empty labels
        FirstNameLabel.Text = "--";
        LastNameLabel.Text = "--";
        EmailLabel.Text = "--";
        PhoneLabel.Text = "--";
        AddressLabel.Text = "--";
        CityLabel.Text = "--";
        StateLabel.Text = "--";
        ZipcodeLabel.Text = "--";

        //Set index to nothing for grid view
        VolunteerGridView.SelectedIndex = -1;
    }
    protected void EditVolunterFormButton_Click(object sender, EventArgs e)
    {
        //Counts how many text boxes where left empty
        int emptyCounter = 0;

        string firstName = FirstNameTextBox.Text;
        if (firstName == string.Empty)
        {
            firstName = FirstNameLabel.Text;
            emptyCounter++;
        }

        string lastName = LastNameTextBox.Text;
        if (lastName == string.Empty)
        {
            lastName = LastNameLabel.Text;
            emptyCounter++;
        }

        string email = EmailTextBox.Text;
        if (email == string.Empty)
        {
            email = EmailLabel.Text;
            emptyCounter++;
        }

        string phone = PhoneTextBox.Text;
        if (phone == string.Empty)
        {
            phone = PhoneLabel.Text;
            emptyCounter++;
        }

        string address = AddressTextBox.Text;
        if (address == string.Empty)
        {
            address = AddressLabel.Text;
            emptyCounter++;
        }

        string city = CityTextBox.Text;
        if (city == string.Empty)
        {
            city = CityLabel.Text;
            emptyCounter++;
        }

        string state = StateTextBox.Text;
        if (state == string.Empty)
        {
            state = StateLabel.Text;
            emptyCounter++;
        }

        string zipCode = ZipcodeTextBox.Text;
        if (zipCode == string.Empty)
        {
            zipCode = ZipcodeLabel.Text;
            emptyCounter++;
        }

        if (IsValid && emptyCounter < 8)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                //Open the connection 
                conn.Open();
                string editVolQuery = "UPDATE Volunteer "
                                        + "SET FirstName=@Vfname,LastName=@Vlname, Address=@Vaddress, City=@Vcity, State=@Vstate, Zipcode=@Vzipcode, Phone=@Vphone, Email=@Vemail "
                                        + "WHERE VolunteerID='" + VolunteerGridView.SelectedValue.ToString() + "'";
                //string sql = "INSERT INTO Volunteer (FirstName, LastName, Address, City, State, Zipcode, Phone, Email) VALUES ( '" + firstName + "', '" + lastName + "', '" + address + "', '" + city + "', '" + state + "', '" + zipCode + "', '" + phone + "', '" + email + "')";


                SqlCommand editVolunteer = new SqlCommand(editVolQuery, conn);

                //Add values to variables in the query
                editVolunteer.Parameters.AddWithValue("@Vfname", firstName);
                editVolunteer.Parameters.AddWithValue("@Vlname", lastName);
                editVolunteer.Parameters.AddWithValue("@Vaddress", address);
                editVolunteer.Parameters.AddWithValue("@Vcity", city);
                editVolunteer.Parameters.AddWithValue("@Vstate", state);
                editVolunteer.Parameters.AddWithValue("@Vzipcode", zipCode);
                editVolunteer.Parameters.AddWithValue("@Vphone", phone);
                editVolunteer.Parameters.AddWithValue("@Vemail", email);

                // Execute query
                editVolunteer.ExecuteNonQuery();


                //string sqlTwo = "INSERT INTO VolunteerStatusRecord (Volunteer_ID, StartTime, Status_Name, IsCurrent) VALUES ('" + totalVolunteers + "', GetDate(), 'Pending', 'Y')";

                // Execute query
                //SqlCommand comm2 = new SqlCommand(sqlTwo, conn);
                // comm2.ExecuteNonQuery();

                conn.Close();

                //Empty textboxes
                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                AddressTextBox.Text = "";
                CityTextBox.Text = "";
                StateTextBox.Text = "";
                ZipcodeTextBox.Text = "";
                PhoneTextBox.Text = "";
                EmailTextBox.Text = "";

                //Disable buttons
                EditVolunterFormButton.Enabled = false;
                CancelButton.Enabled = false;

                //Disable Textboxes
                FirstNameTextBox.Enabled = false;
                LastNameTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                PhoneTextBox.Enabled = false;
                AddressTextBox.Enabled = false;
                CityTextBox.Enabled = false;
                StateTextBox.Enabled = false;
                ZipcodeTextBox.Enabled = false;

                //Empty labels
                FirstNameLabel.Text = "--";
                LastNameLabel.Text = "--";
                EmailLabel.Text = "--";
                PhoneLabel.Text = "--";
                AddressLabel.Text = "--";
                CityLabel.Text = "--";
                StateLabel.Text = "--";
                ZipcodeLabel.Text = "--";

                //Display message
                SuccessLabel.Text = "Update Successful!";
                SuccessLabel.ForeColor = System.Drawing.Color.Green;
                SuccessLabel.Visible = true;


                //Resfresh grid 
                VolunteerGridView.DataSourceID = "VolunteersToBeEdittedSqlDataSource";
                VolunteerGridView.DataBind();

                //Unselect volunteer
                VolunteerGridView.SelectedIndex = -1;
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
            AddressTextBox.Text = "";
            CityTextBox.Text = "";
            StateTextBox.Text = "";
            ZipcodeTextBox.Text = "";
            PhoneTextBox.Text = "";
            EmailTextBox.Text = "";

            //Disable buttons
            EditVolunterFormButton.Enabled = false;
            CancelButton.Enabled = false;

            //Disable Textboxes
            FirstNameTextBox.Enabled = false;
            LastNameTextBox.Enabled = false;
            EmailTextBox.Enabled = false;
            PhoneTextBox.Enabled = false;
            AddressTextBox.Enabled = false;
            CityTextBox.Enabled = false;
            StateTextBox.Enabled = false;
            ZipcodeTextBox.Enabled = false;

            //Empty labels
            FirstNameLabel.Text = "--";
            LastNameLabel.Text = "--";
            EmailLabel.Text = "--";
            PhoneLabel.Text = "--";
            AddressLabel.Text = "--";
            CityLabel.Text = "--";
            StateLabel.Text = "--";
            ZipcodeLabel.Text = "--";

            //Resfresh grid 
            VolunteerGridView.DataSourceID = "VolunteersToBeEdittedSqlDataSource";
            VolunteerGridView.DataBind();

            //Unselect volunteer
            VolunteerGridView.SelectedIndex = -1;
        }
    }
    protected void EmailTextBox_TextChanged(object sender, EventArgs e)
    {
        EmailRegularExpressionValidator.Enabled = true;
    }
    protected void PhoneTextBox_TextChanged(object sender, EventArgs e)
    {
        PhoneRegularExpressionValidator.Enabled = true;
    }
    protected void ZipcodeTextBox_TextChanged(object sender, EventArgs e)
    {
        ZipcodeRegularExpressionValidator.Enabled = true;
    }
}