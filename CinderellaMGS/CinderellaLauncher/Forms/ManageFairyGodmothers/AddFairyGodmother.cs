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
using System.Drawing.Printing;

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


        private Font lclFont;
        private Font lclFont2;

        //This is the text that will be printed from the printing event handler
        private string TextToPrint;
        private string TextToPrint2;
        private string TextToPrint3;
        string x = "";
        //int Text = 0;
        int rows = 0;
        int columns = 0;
        int count4 = 0;

        //Vertical postion on page of bar code
        float yPos = 60;
        //Hotizontal position on the page of the bar code
        float xPos = 125;
        //Vertical postion on page of bar code
        float yPos2 = 60;
        //Hotizontal position on the page of the bar code
        float xPos2 = 10;

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


            string name = firstName + " " + lastName +"     ";
            string barcode = query.FGMaxID();

            PrintBarCode("IDAutomationHC39M", barcode, 9, "Times New Roman", name, 9);
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
            rows = FGCheckIn.rows;
            columns=FGCheckIn.columns;
            
            //Set the left margin of the page
            float leftMargin = ev.MarginBounds.Left;
            //set the top margin of the page.
            float topMargin = ev.MarginBounds.Top;
            TextToPrint2 = query.PrintFGName(TextToPrint) + "            ";
            if (rows == 1 && columns == 1)
            {
                TextToPrint3 = "*" + TextToPrint + "*";
                ev.Graphics.DrawString(TextToPrint3, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
                ev.Graphics.DrawString(TextToPrint2, lclFont2, Brushes.Black, xPos2, yPos2, new StringFormat());
                FGCheckIn.addColumns();
            }

            else
                {
                    TextToPrint2 = query.PrintFGName(TextToPrint) + "            ";
                    TextToPrint3 = "*" + TextToPrint + "*";
                    xPos += 280;
                    xPos2 += 280;

                    ev.Graphics.DrawString(TextToPrint3, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
                    ev.Graphics.DrawString(TextToPrint2, lclFont2, Brushes.Black, xPos2, yPos2, new StringFormat());
                    FGCheckIn.addColumns();
                }
            }

            /*int count2 = 2;
            while (count2 != 0)
            {
                ++count4;
                TextToPrint2 = query.PrintFGName(TextToPrint) + "            ";
                TextToPrint3 = "*" + TextToPrint + "*";
                xPos += 280;
                xPos2 += 280;

                ev.Graphics.DrawString(TextToPrint3, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
                ev.Graphics.DrawString(TextToPrint2, lclFont2, Brushes.Black, xPos2, yPos2, new StringFormat());
                count2--;
            }*/
            //set the y pos to include the height of the text
            //yPos = yPos + lclFont.GetHeight(ev.Graphics);
            //yPos2 = yPos2 + lclFont2.GetHeight(ev.Graphics);
            //set the x pos to include the left margin of the page
            //xPos = xPos + leftMargin;
            //xPos2 = xPos2 + leftMargin;

            //send the string to the printer

            /*int count = 2;
            int count1 = 9;
            int count5 = Convert.ToInt32(query.FGcount());
            count5 = count5 - 1;
            int count3 = count5 - 1;
            max = Convert.ToInt32(query.FGMaxID());
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
                TextToPrint2 = query.PrintFGName(TextToPrint[count4]) + "             ";

                TextToPrint3 = "*" + TextToPrint[count4] + "*";
                ev.Graphics.DrawString(TextToPrint3, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
                ev.Graphics.DrawString(TextToPrint2, lclFont2, Brushes.Black, xPos2, yPos2, new StringFormat());

                count = 2;

                if (count4 >= count5)
                {
                    ev.HasMorePages = false;
                    count3 = 0;
                    count1 = 0;
                    count = 0;
                }
                while (count != 0)
                {
                    ++count4;
                    TextToPrint2 = query.PrintFGName(TextToPrint[count4]) + "             ";

                    TextToPrint3 = "*" + TextToPrint[count4] + "*";
                    xPos += 280;
                    xPos2 += 280;

                    ev.Graphics.DrawString(TextToPrint3, lclFont, Brushes.Black, xPos, yPos, new StringFormat());
                    ev.Graphics.DrawString(TextToPrint2, lclFont2, Brushes.Black, xPos2, yPos2, new StringFormat());

                    count--;
                }// end horizontal


                --count1;
                --count3;
                if (count4 >= count5)
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
            */
            //[count4]
            //}// end total 
        }
    }
