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
using System.Drawing.Printing;

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

        string barcode;
        string q;
        private Font lclFont;
        private Font lclFont2;

        //This is the text that will be printed from the printing event handler
        private string TextToPrint;
        private string TextToPrint2;
        private string TextToPrint3;
        string x = "";
        //int Text = 0;
        int max = 0;
        int count4 = 0; 

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
            string name = firstName + " " + lastName + "     ";
            barcode = query.MaxID();
            PrintBarCode("IDAutomationHC39M", barcode, 9, "Times New Roman", name, 9);

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

        public void PrintBarCode(string TextFont, string EncodedText, float TextFontSize, string TextFont2, string EncodedText2, float TextFontSize2)
        {
            //Update the class variables
            lclFont = new Font(TextFont, TextFontSize);
            TextToPrint = EncodedText;

            lclFont2 = new Font(TextFont2, TextFontSize2);
            TextToPrint2 = EncodedText2;
            //create the document object that will be printed.
            PrintDocument PrintDoc = new PrintDocument();

            //Call the print page method of the Print Document.  This assigns the event handler
            //that is used for printing operations of this bar code
            PrintDoc.PrintPage += new PrintPageEventHandler(this.PrintDocHandler);
            //now print the bar code.  Control will go to the event handler for any additional 
            //instructions for the printer, such as printing additional lines and
            //the location of the bar code on the page.
            PrintDoc.Print();

            return;
        }

        //This is the event handler for printing bar codes
        private void PrintDocHandler(object sender, PrintPageEventArgs ev)
        {

            //Vertical postion on page of bar code
            float yPos = 60;
            //Hotizontal position on the page of the bar code
            float xPos = 125;
            //Vertical postion on page of bar code
            float yPos2 = 60;
            //Hotizontal position on the page of the bar code
            float xPos2 = 10;
            //Set the left margin of the page
            float leftMargin = ev.MarginBounds.Left;
            //set the top margin of the page.
            float topMargin = ev.MarginBounds.Top;
            TextToPrint2 = query.PrintCinderellaName(TextToPrint) + "            ";
            TextToPrint3 = "*" + TextToPrint + "*";
            ev.Graphics.DrawString(TextToPrint3, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
            ev.Graphics.DrawString(TextToPrint2, lclFont2, Brushes.Black, xPos2, yPos2, new StringFormat());
            int count2 = 2;
            while (count2 != 0)
            {
                xPos += 280;
                xPos2 += 280;

                ev.Graphics.DrawString(TextToPrint3, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
                ev.Graphics.DrawString(TextToPrint2, lclFont2, Brushes.Black, xPos2, yPos2, new StringFormat());
                count2--;
            }
            //set the y pos to include the height of the text
            //yPos = yPos + lclFont.GetHeight(ev.Graphics);
            //yPos2 = yPos2 + lclFont2.GetHeight(ev.Graphics);
            //set the x pos to include the left margin of the page
            //xPos = xPos + leftMargin;
            //xPos2 = xPos2 + leftMargin;

            //send the string to the printer

            /*int count = 2;
            int count1 = 9;
            int count5 = Convert.ToInt32(query.count());
            count5 = count5 - 1;
            int count3 = count5 - 1;
            max = Convert.ToInt32(query.MaxID());
            // if (ev.HasMorePages == true)
            // {

            //while (count3 != 0)
            //{

            //Vertical postion on page of bar code
            yPos = 60;
            //Hotizontal position on the page of the bar code
            xPos = 125;
            //Vertical postion on page of bar code
            yPos2 = 60;
            //Hotizontal position on the page of the bar code
            xPos2 = 10;


            while (count1 != 0)
            {
                if (count3 == 0)
                {
                    ev.HasMorePages = false;

                }
                else
                    ev.HasMorePages = true;

                // x = TextToPrint.ToString();
                // Text = Convert.ToInt32(x);
                ++Text;
                ++count4;


                yPos += 100;
                yPos2 += 100;
                xPos = 125;
                xPos2 = 10;
                TextToPrint2 = query.PrintCinderellaName(TextToPrint[count4]) + "             ";

                TextToPrint3 = "*" + TextToPrint[count4] + "*";
                ev.Graphics.DrawString(TextToPrint3, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
                ev.Graphics.DrawString(TextToPrint2, lclFont2, Brushes.Black, xPos2, yPos2, new StringFormat());

                count = 2;
                while (count != 0)
                {
                    xPos += 280;
                    xPos2 += 280;

                    ev.Graphics.DrawString(TextToPrint3, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
                    ev.Graphics.DrawString(TextToPrint2, lclFont2, Brushes.Black, xPos2, yPos2, new StringFormat());

                    count--;
                }// end horizontal


                --count1;
                --count3;
                if (count4 == count5)
                {
                    ev.HasMorePages = false;
                    count3 = 0;
                    count1 = 0;
                }
            }// end vertical
            //x = TextToPrint.ToString();
            //Text = Convert.ToInt32(x);
            ++Text;
            ++count4;

            //[count4]
            //}// end total */
        }

    }
}
