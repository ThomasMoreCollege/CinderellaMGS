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
using System.Threading;

namespace CinderellaLauncher
{
    /* AddCinderella.cs
     * 
     * - Simply adds a new Cinderella into the database. 
     * - A new referral name and organization may be added with a Cinderella as well.
     * 
     * - Input:
     *      - Cinderella first and last name, arrival time, date, referral, notes
     *      - If an existing referral is not specified, the name and organization for a new referral may be entered. 
     * 
     * - Output: none
     * 
     * - Precondition:
     *      - Data non-existent 
     *      
     * - Postcondition:
     *      - New Cinderella added to database
     *      - Possibly new referral added to database
     * 
     */
    public partial class AddCinderella : Form
    {
        // Data Binding Components
        private SQL_Queries query = new SQL_Queries();
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        private BindingSource referralsBindingSource = new BindingSource();
        private DataTable referralsDataTable;
        private SqlDataAdapter referralsDataAdapter;

        // Input variables for Cinderella
        private string firstName = "";
        private string lastName = "";
        private string notes = "";


        // Temporary fix for error with entering a referral
        bool showerror = false;

        public AddCinderella()
        {
            InitializeComponent();
        }

        private void AddCinderella_Load(object sender, EventArgs e)
        {
            referralsDataTable = new DataTable();
            referralsComboBox.DataSource = referralsBindingSource;
            referralsDataAdapter = new SqlDataAdapter(query.getReferrals(), connection);
            referralsDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            referralsDataAdapter.Fill(referralsDataTable);
            referralsBindingSource.DataSource = referralsDataTable;

            // Make a new column in the table to allow the dropdownlist to show first and last name
            referralsDataTable.Columns.Add("NameAndOrg", typeof(string), "organization + ' --  ' + referralName");
            referralsComboBox.DisplayMember = "NameAndOrg";
            referralsComboBox.ValueMember = "id";
            showerror = true;

        }

        //Adds a new cinderella into the system
        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {

                firstName = firstNameBox.Text;
                lastName = lastNameBox.Text;

                if (!(firstNameBox.Text == "" || lastNameBox.Text == ""))
                {                   
                    if (existingReferralButton.Checked)
                    {
                        string date = datePicker.Value.ToString();
                        string time = timePicker.Value.ToString();

                        notes = notesTextBox.Text;

                        DataRow selectedDataRow = ((DataRowView)referralsComboBox.SelectedItem).Row;
                        int referralID = Convert.ToInt32(selectedDataRow["id"].ToString());

                        // Add the new Cinderella into the database
                        query.NewCinderella(firstName, lastName, date, time, referralID);

                        // Reset the form
                        referralsComboBox.ResetText();
                        firstNameBox.Text = "";
                        lastNameBox.Text = "";
                        notesTextBox.Text = "";
                        timePicker.ResetText();
                        datePicker.ResetText();
                        newReferralTextBox.ResetText();
                        newSchoolTextBox.ResetText();
                    }
                    else
                    {
                        // Get the information for a new referral
                        string refName = newReferralTextBox.Text;
                        string refOrg = newSchoolTextBox.Text;

                        string date = datePicker.Value.ToString();
                        string time = timePicker.Value.ToString();

                        notes = notesTextBox.Text;

                        // This will appropriately add both the Cinderella and new referral. 
                        query.addCinderellaAndReferral(refName, refOrg, firstName, lastName, date, time, notes);

                        referralsComboBox.ResetText();
                        firstNameBox.Text = "";
                        lastNameBox.Text = "";
                        notesTextBox.Text = "";
                        timePicker.ResetText();
                        datePicker.ResetText();
                        newReferralTextBox.ResetText();
                        newSchoolTextBox.ResetText();

                    }
                }
                else
                    MessageBox.Show("Please enter a name!");

            }
            catch (Exception error)
            {
                MessageBox.Show("An Error has occurred, please check your input." + System.Environment.NewLine + error.ToString());
            }
        }

        private void newReferralButton_CheckedChanged(object sender, EventArgs e)
        {
            // Disable the option to use an existing referral name and organization.
            referralLabel.Enabled = !referralLabel.Enabled;
            referralsComboBox.Enabled = !referralsComboBox.Enabled;

            // Enable the option to enter a new name and school.
            referralNameLabel.Enabled = !referralNameLabel.Enabled;
            schoolLabel.Enabled = !schoolLabel.Enabled;
            newReferralTextBox.Enabled = !newReferralTextBox.Enabled;
            newSchoolTextBox.Enabled = !newSchoolTextBox.Enabled;

        }


        // Temporary Fix for error
        private void referralsComboBox_TextUpdate(object sender, EventArgs e)
        {
            if (showerror)
            {
                MessageBox.Show("Do no type into the referral Textbox.");
                Thread.CurrentThread.Abort();
            }
        }

    }
}
