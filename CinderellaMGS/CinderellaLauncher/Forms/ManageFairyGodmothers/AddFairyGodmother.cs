using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CinderellaLauncher
{
    /*AddFairyGodmother.cs
     * 
     * -Adds a new Fairy Godmother into the database
     * 
     * -Input:
     *      -First name
     *      -Last name
     *      -Address
     *      -City
     *      -State
     *      -Zip code
     *      -Email
     *      -Phone
     * 
     * -Output: None
     * 
     * -Precondition:
     *      -Data non-existent
     * 
     * -Postcondition:
     *      -New Fairy Godmother added into the database
     * 
     */ 
    public partial class AddFairyGodmother : Form
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        SQL_Queries query = new SQL_Queries();

        private string firstName = "";
        private string lastName = "";
        private string address = "";
        private string state = "";
        private string city = "";
        private string zip = "";
        private string phone = "";
        private string email = "";

        public AddFairyGodmother()
        {
            InitializeComponent();
        }

        private void AddFairyGodmother_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            firstName = firstNameTextBox.Text;
            lastName = lastNameTextBox.Text;
            address = addressTextBox.Text;
            city = cityTextBox.Text;
            state = stateTextBox.Text;
            zip = zipTextBox.Text;
            phone = phoneTextBox.Text;
            email = emailTextBox.Text;

            if (state.Count() > 2)
            {
                MessageBox.Show("State must be only 2 characters.");
                return;
            }

            int numCheck = 0;
            if (!int.TryParse(zip, out numCheck))
            {
                MessageBox.Show("Please enter only numbers for zip");
                return;
            }

            long numCheck2 = 0;
            if (!long.TryParse(phone, out numCheck2))
            {
                MessageBox.Show("Please enter only numbers for phone");
                return;
            }

            if (phone.Count() > 10)
            {
                MessageBox.Show("Phone must be less than 10 digits");
                return;
            }


            try
            {
                query.NewGodMother(firstName, lastName, address, city, email, phone, state, zip);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.ToString());
            }

            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            addressTextBox.Clear();
            stateTextBox.Clear();
            cityTextBox.Clear();
            zipTextBox.Clear();
            phoneTextBox.Clear();
            emailTextBox.Clear(); 
        }
    }
}
