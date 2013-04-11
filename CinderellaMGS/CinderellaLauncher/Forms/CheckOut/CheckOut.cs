using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinderellaLauncher;
using System.Threading;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;



namespace CinderellaLauncher
{
    /*CheckOut.cs
     * 
     * -Checks the selected Cinderella out with her dress, jewelry, shoe, and any other information that are recorded
     * -Displays Cinderella's whose dresses are finished being altered and are ready to be delivered to the Cinderella
     * 
     * -Input:
     *      -Dress size
     *      -Dress color
     *      -Shoe size
     *      -Shoe color
     *      -Jewelry chosen
     *      -Notes(optional)
     * 
     * -Output: None
     * 
     * -Precondition:
     *      -Cinderelle must be selected from the grid view
     * 
     * -Postcondition:
     *      -Cinderella's status is changed to check-out in the database
     */

    public partial class CheckOut : Form
    {
        static SQL_Queries query = new SQL_Queries();
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

        private BindingSource searchDGVBindingSource = new BindingSource();
        private DataTable searchDGVDataTable;
        private SqlDataAdapter searchDGVDataAdapter;

        private BindingSource dressesDoneDGVBindingSource = new BindingSource();
        private DataTable dressesDoneDGVDataTable;
        private SqlDataAdapter dressesDoneDGVDataAdapter;

        private DataTable dressInfo;
        private SqlDataAdapter da;

        public CheckOut()
        {
            InitializeComponent();
          
            this.KeyPreview = true;
            this.KeyUp += new KeyEventHandler(search_KeyUp);

        }
        void search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                refreshButtonCheckOut.PerformClick();
            }
        }
        private void CheckOut_Load(object sender, System.EventArgs e)
        {
            // See CheckIn for explanation        
            Thread update = new Thread(() => updateDUI());
            update.Start();
           // dressesDoneDGV.AutoResizeColumns();
        }
        public void updateDUI()
        {
            try
            {
                //  while (true)
                //  {
                searchDGVDataTable = new DataTable();
                searchDGV.Invoke(new Action(delegate()
                    {
                        searchDGV.DataSource = searchDGVBindingSource;
                    }));
                searchDGVDataTable.Columns.Add("Status");
                searchDGVDataAdapter = new SqlDataAdapter(query.checkOutList(), connection);
                
                searchDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                searchDGVDataAdapter.Fill(searchDGVDataTable);
                
                searchDGV.Invoke(new Action(delegate()
                    {
                        searchDGVBindingSource.DataSource = searchDGVDataTable;
                        searchDGV.ClearSelection();
                    }));

                //  searchDGV.AutoResizeColumns();

                dressesDoneDGVDataTable = new DataTable();
                dressesDoneDGV.Invoke(new Action(delegate()
                    {
                        dressesDoneDGV.DataSource = dressesDoneDGVBindingSource;
                    }));
                dressesDoneDGVDataAdapter = new SqlDataAdapter(query.dressesDone(), connection);
                dressesDoneDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dressesDoneDGVDataAdapter.Fill(dressesDoneDGVDataTable);
                dressesDoneDGV.Invoke(new Action(delegate()
                    {
                        dressesDoneDGVBindingSource.DataSource = dressesDoneDGVDataTable;
                        dressesDoneDGV.ClearSelection();
                    }));

                // Thread.Sleep(5000);
                // }
                //searchDGVDataTable.Columns.Add("Status");
            }
            catch (Exception f)
            {
                //  Thread.CurrentThread.Abort();
            }
        }

        private void searchGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    // Clear out controls

                    dressSizeComboBox.ResetText();
                    dressColorComboBox.ResetText();
                    shoeSizeComboBox.ResetText();
                    shoeColorComboBox.ResetText();

                    braceletCheckBox.Checked = false;
                    ringsCheckBox.Checked = false;
                    earringsCheckBox.Checked = false;
                    headPieceCheckBox.Checked = false;
                    necklaceCheckBox.Checked = false;


                    notesTextBox.Clear();
                    otherCheckBox.Checked = false;
                    otherTextBox.Clear();

                    string customDressSize = "";
                    string customDressColor = "";
                    string customShoeSize = "";
                    string customShoeColor = "";
                    string customNotes = "";
                    string customOther = "";

                    bool customBracelet = false;
                    bool customRing = false;
                    bool customEarrings = false;
                    bool customNecklace = false;
                    bool customheadPiece = false;

                    string ID = searchDGV.Rows[e.RowIndex].Cells[1].Value.ToString();

                    // On cell click, change the name in the label.
                    cinderellaNameLabel.Text = searchDGV.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + searchDGV.Rows[e.RowIndex].Cells[2].Value.ToString();

                    //query.CinderellasInAlteration();
                    dressInfo = new DataTable();
                    da = new SqlDataAdapter(query.getPackageInfo(ID), connection);
                    da.Fill(dressInfo);

                    foreach (DataRow row in dressInfo.Rows)
                    {
                        customDressSize = row["dressSize"].ToString();
                        customDressColor = row["dressColor"].ToString();
                        customShoeSize = row["shoeSize"].ToString();
                        customShoeColor = row["shoeColor"].ToString();
                        customNotes = row["checkoutNotes"].ToString();

                        customOther = row["other"].ToString();
                        customBracelet = Convert.ToBoolean(row["Bracelet"]);
                        customNecklace = Convert.ToBoolean(row["Necklace"]);
                        customRing = Convert.ToBoolean(row["Ring"]);
                        customEarrings = Convert.ToBoolean(row["Earrings"]);
                        customheadPiece = Convert.ToBoolean(row["HeadPiece"]);
                    }

                    dressColorComboBox.SelectedValue = customDressColor;
                    dressColorComboBox.Text = customDressColor;

                    dressSizeComboBox.SelectedValue = customDressSize;
                    dressSizeComboBox.Text = customDressSize;

                    shoeSizeComboBox.SelectedValue = customShoeSize;
                    shoeSizeComboBox.Text = customShoeSize;

                    shoeColorComboBox.SelectedValue = customShoeSize;
                    shoeColorComboBox.Text = customShoeColor;

                    notesTextBox.Text = customNotes;

                    otherCheckBox.Checked = !(customOther == "" || customOther == null);
                    if (otherCheckBox.Checked)
                        otherTextBox.Text = customOther;

                    braceletCheckBox.Checked = customBracelet;
                    necklaceCheckBox.Checked = customNecklace;
                    ringsCheckBox.Checked = customRing;
                    earringsCheckBox.Checked = customEarrings;
                    headPieceCheckBox.Checked = customheadPiece;

                }
            }
            catch (InvalidOperationException error)
            {

            }
        }

        private void checkOutButton_Click(object sender, EventArgs e)
        {
            // INSERT a row into package that holds the cinderellas stuff
            // SET girls status to checked out.
            // SET shoppers status to whatever it should be
            if ((dressColorComboBox.Text == "") || (dressSizeComboBox.Text == ""))
            {
                MessageBox.Show("Please fill out all the dress and shoe information.");
                return;
            }
            try
            {
                int id = Convert.ToInt32(searchDGV.SelectedRows[0].Cells[1].Value.ToString());

                int dressSize = Convert.ToInt32(dressSizeComboBox.Text);
                string dressColor = dressColorComboBox.Text;

                double shoeSize;
                string shoeColor;

                if ((shoeColorComboBox.Text == "") || (shoeSizeComboBox.Text == ""))
                {
                    shoeSize = -1;
                    shoeColor = "";
                }
                else
                {
                    shoeSize = Convert.ToDouble(shoeSizeComboBox.Text);
                    shoeColor = shoeColorComboBox.Text;
                }

                bool necklace = necklaceCheckBox.Checked;
                bool bracelet = braceletCheckBox.Checked;
                bool earrings = earringsCheckBox.Checked;
                bool ring = ringsCheckBox.Checked;
                bool headPiece = headPieceCheckBox.Checked;




                string notes = notesTextBox.Text;
                if (notes.Count() > 50)
                {
                    MessageBox.Show("Notes must be fewer than 50 characters");
                    return;
                }

                string other = "";

                if (otherCheckBox.Checked)
                    other = otherTextBox.Text;

                if (other.Count() > 25)
                {
                    MessageBox.Show("Other must be fewer than 25 characters");
                    return;
                }

                //MessageBox.Show("ID: " + id + "\r\ndresssize: " + dressSize + "\r\nDresscolor: " + dressColor + "\r\nShoeSize: " + shoeSize + "\r\nShoeColor: " + shoeColor + necklace + bracelet + earrings + ring + headPiece + notes + other);
                query.checkOutUpdate(id, dressSize, dressColor, shoeSize, shoeColor, notes, necklace, ring, bracelet, headPiece, earrings, other);
                query.setCinderellaStatus(id.ToString(), 7);
                query.FGLeavesCinderella(id);
                query.RetrievedDress(id);

                // Reset the form
                dressSizeComboBox.ResetText();
                dressColorComboBox.ResetText();
                shoeSizeComboBox.ResetText();
                shoeColorComboBox.ResetText();
                necklaceCheckBox.Checked = false;
                braceletCheckBox.Checked = false;
                earringsCheckBox.Checked = false;
                ringsCheckBox.Checked = false;
                headPieceCheckBox.Checked = false;
                notesTextBox.ResetText();
                otherCheckBox.Checked = false;
                otherTextBox.ResetText();

                cinderellaNameLabel.ResetText();

                updateDUI();
            }
            catch (ArgumentOutOfRangeException noSelection)
            {
                MessageBox.Show("Please select a Cinderella");
            }
            catch (NullReferenceException error)
            {
                MessageBox.Show(error.ToString());
                //MessageBox.Show("Please Select the Size and Color of the Dress and of the Shoes");
            }
        }


        private void otherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            otherTextBox.Visible = !otherTextBox.Visible;
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            string q = query.MasterCheckOutSearchBox(QSearchTextBox.Text);
            searchDGVDataTable = new DataTable();
             searchDGV.DataSource = searchDGVBindingSource;
            searchDGVDataAdapter = new SqlDataAdapter(q, connection);
            searchDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            searchDGVDataAdapter.Fill(searchDGVDataTable);
            searchDGVBindingSource.DataSource = searchDGVDataTable;
            searchDGV.ClearSelection();
            /*if (QSearchTextBox.Text.Length > 0)
            {

                string neck = "";
                string ring = "";
                string bracelet = "";
                string headpiece = "";
                string earrings = "";

                dressSizeComboBox.Text = (query.CindyDressSize(Convert.ToInt32(QSearchTextBox.Text))).ToString();
                shoeSizeComboBox.Text = (query.CindyShoeSize(Convert.ToInt32(QSearchTextBox.Text)));
                dressColorComboBox.Text = (query.CindyDressColor(Convert.ToInt32(QSearchTextBox.Text))).ToString();
                shoeColorComboBox.Text = (query.CindyShoeColor(Convert.ToInt32(QSearchTextBox.Text))).ToString();
                neck = (query.CindyNecklace(Convert.ToInt32(QSearchTextBox.Text))).ToString();
                ring = (query.CindyRing(Convert.ToInt32(QSearchTextBox.Text))).ToString();
                bracelet = (query.CindyBracelet(Convert.ToInt32(QSearchTextBox.Text))).ToString();
                headpiece = (query.CindyHeadpiece(Convert.ToInt32(QSearchTextBox.Text))).ToString();
                earrings = (query.CindyEarrings(Convert.ToInt32(QSearchTextBox.Text))).ToString();


                if (neck.Equals("True"))
                {
                    necklaceCheckBox.Checked = true;
                }
                else
                {
                    necklaceCheckBox.Checked = false;
                }
                if (ring.Equals("True"))
                {
                    ringsCheckBox.Checked = true;
                }
                else
                {
                    ringsCheckBox.Checked = false;
                }
                if (bracelet.Equals("True"))
                {
                    braceletCheckBox.Checked = true;
                }
                else
                {
                    braceletCheckBox.Checked = false;
                }
                if (headpiece.Equals("True"))
                {
                    headPieceCheckBox.Checked = true;
                }
                else
                {
                    headPieceCheckBox.Checked = false;
                }
                if (earrings.Equals("True"))
                {
                    earringsCheckBox.Checked = true;
                }
                else
                {
                    earringsCheckBox.Checked = false;
                }
            }
            else
            {
                SqlCommand searchCommand = new SqlCommand(query.CheckOutSearch(firstNameBox.Text, lastNameBox.Text, organizationTextBox.Text));
                searchDGVBindingSource.EndEdit();
                searchDGVDataTable.Clear();

                searchDGVDataAdapter.SelectCommand = searchCommand;
                searchDGVDataAdapter.SelectCommand.Connection = connection;

                searchDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                searchDGVDataAdapter.Fill(searchDGVDataTable);

                searchDGV.Refresh();
                searchDGV.ClearSelection();
                //  searchDGV.AutoResizeColumns();
            }*/
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
           
            organizationTextBox.Text = "";

            SqlCommand searchCommand = new SqlCommand(query.CheckOutSearch("", "", ""));
            searchDGVBindingSource.EndEdit();
            searchDGVDataTable.Clear();

            searchDGVDataAdapter.SelectCommand = searchCommand;
            searchDGVDataAdapter.SelectCommand.Connection = connection;

            searchDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            searchDGVDataAdapter.Fill(searchDGVDataTable);

            searchDGV.Refresh();
            searchDGV.ClearSelection();
            //  searchDGV.AutoResizeColumns();
        }

        private void chatNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Thread> FormThreads = new List<Thread>();//keeps track of form threads for latter termination

            //this is where the threading of the online chat will prompt
            Thread cinderellaCheckOutChat = new Thread(() => Application.Run(new ClientApp()));
            cinderellaCheckOutChat.Name = "chat";
            bool found = false;
            foreach (Thread forms in FormThreads)
            {
                if (forms.Name == "chat")
                {
                    if (forms.IsAlive)
                    {
                        found = true;
                    }
                }
            }
            if (found)//prevents someone from having multiple copies of the same window open
            {
                MessageBox.Show("Chat window already open.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cinderellaCheckOutChat.Start();
                FormThreads.Add(cinderellaCheckOutChat);//adds the thread to the list
            }
        }

        private void refreshButtonCheckOut_Click(object sender, EventArgs e)
        {
            updateDUI();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(searchDGV.SelectedRows[0].Cells[0].Value.ToString());

            int dressSize = 0;
            if (dressSizeComboBox.SelectedItem != null)
                dressSize = Convert.ToInt32(dressSizeComboBox.SelectedItem);

            string dressColor = "";
            if (dressColorComboBox.SelectedItem != null)
                dressColor = dressColorComboBox.SelectedItem.ToString();

            double shoeSize = 0.0;
            if (shoeSizeComboBox.SelectedItem != null)
                shoeSize = Convert.ToDouble(shoeSizeComboBox.SelectedItem.ToString());

            string shoeColor = "";
            if (shoeColorComboBox.SelectedItem != null)
                shoeColor = shoeColorComboBox.SelectedItem.ToString();

            bool necklace = necklaceCheckBox.Checked;
            bool bracelet = braceletCheckBox.Checked;
            bool earrings = earringsCheckBox.Checked;
            bool ring = ringsCheckBox.Checked;
            bool headPiece = headPieceCheckBox.Checked;

            string notes = notesTextBox.Text;

            if (notes.Count() > 50)
            {
                MessageBox.Show("Notes must be fewer than 50 characters");
                return;
            }

            string other = "";

            if (otherCheckBox.Checked)
                other = otherTextBox.Text;


            if (other.Count() > 25)
            {
                MessageBox.Show("Other must be fewer than 25 characters");
                return;
            }


            query.checkOutUpdate(id, dressSize, dressColor, shoeSize, shoeColor, notes, necklace, ring, bracelet, headPiece, earrings, other);
            query.FGLeavesCinderella(id);
            MessageBox.Show(cinderellaNameLabel.Text + "'s " + "package has been saved.");

            dressSizeComboBox.ResetText();
            dressColorComboBox.ResetText();
            shoeSizeComboBox.ResetText();
            shoeColorComboBox.ResetText();
            necklaceCheckBox.Checked = false;
            braceletCheckBox.Checked = false;
            earringsCheckBox.Checked = false;
            ringsCheckBox.Checked = false;
            headPieceCheckBox.Checked = false;
            notesTextBox.ResetText();
            otherCheckBox.Checked = false;
            otherTextBox.ResetText();

            cinderellaNameLabel.ResetText();
        }

        private void dressRetrievedButton_Click(object sender, EventArgs e)
        {
            try
            {

                int id = Convert.ToInt32(dressesDoneDGV.SelectedRows[0].Cells[0].Value);

                query.RetrievedDress(id);

                updateDUI();
            }
            catch (ArgumentOutOfRangeException f)
            {
                MessageBox.Show("Please select a Cinderella");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread aboutThread = new Thread(() => Application.Run(new About()));
            aboutThread.Start();
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("C:\\CinderellaMGS\\cinderellamgs\\CinderellaMGS\\Documentation\\Help\\UserManual.pdf"))
            {
                Process.Start("C:\\CinderellaMGS\\cinderellamgs\\CinderellaMGS\\Documentation\\Help\\UserManual.pdf");
                return;
            }
            if (System.IO.File.Exists("..\\..\\..\\Documentation\\Help\\UserManual.pdf"))
            {
                Process.Start("..\\..\\..\\Documentation\\Help\\UserManual.pdf");
                return;
            }
            MessageBox.Show("File: C:\\CinderellaMGS\\cinderellamgs\\CinderellaMGS\\Documentation\\Help\\UserManual.pdf   Does Not Exist.");
        }

        private void CheckOutBarcodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // INSERT a row into package that holds the cinderellas stuff
                // SET girls status to checked out.
                // SET shoppers status to whatever it should be
                if ((dressColorComboBox.Text == "") || (dressSizeComboBox.Text == ""))
                {
                    MessageBox.Show("Please fill out all the dress and shoe information.");
                    return;
                }
              //  try
                {
                    


                    int id = Convert.ToInt32(CheckOutBarcodeTextBox.Text);
                    CheckOutBarcodeTextBox.Text = "";

                    int dressSize = Convert.ToInt32(dressSizeComboBox.Text);
                    string dressColor = dressColorComboBox.Text;

                    double shoeSize;
                    string shoeColor;

                    if ((shoeColorComboBox.Text == "") || (shoeSizeComboBox.Text == ""))
                    {
                        shoeSize = -1;
                        shoeColor = "";
                    }
                    else
                    {
                        shoeSize = Convert.ToDouble(shoeSizeComboBox.Text);
                        shoeColor = shoeColorComboBox.Text;
                    }

                    bool necklace = necklaceCheckBox.Checked;
                    bool bracelet = braceletCheckBox.Checked;
                    bool earrings = earringsCheckBox.Checked;
                    bool ring = ringsCheckBox.Checked;
                    bool headPiece = headPieceCheckBox.Checked;




                    string notes = notesTextBox.Text;
                    if (notes.Count() > 50)
                    {
                        MessageBox.Show("Notes must be fewer than 50 characters");
                        return;
                    }

                    string other = "";

                    if (otherCheckBox.Checked)
                        other = otherTextBox.Text;

                    if (other.Count() > 25)
                    {
                        MessageBox.Show("Other must be fewer than 25 characters");
                        return;
                    }

                    //MessageBox.Show("ID: " + id + "\r\ndresssize: " + dressSize + "\r\nDresscolor: " + dressColor + "\r\nShoeSize: " + shoeSize + "\r\nShoeColor: " + shoeColor + necklace + bracelet + earrings + ring + headPiece + notes + other);
                    query.checkOutUpdate(id, dressSize, dressColor, shoeSize, shoeColor, notes, necklace, ring, bracelet, headPiece, earrings, other);
                    query.setCinderellaStatus(id.ToString(), 7);
                    query.FGLeavesCinderella(id);
                    
                    
                    //Possibly use as a check
                    //commented out because it didn't work for the barcode reader
                    //query.RetrievedDress(id);

                    // Reset the form
                    dressSizeComboBox.ResetText();
                    dressColorComboBox.ResetText();
                    shoeSizeComboBox.ResetText();
                    shoeColorComboBox.ResetText();
                    necklaceCheckBox.Checked = false;
                    braceletCheckBox.Checked = false;
                    earringsCheckBox.Checked = false;
                    ringsCheckBox.Checked = false;
                    headPieceCheckBox.Checked = false;
                    notesTextBox.ResetText();
                    otherCheckBox.Checked = false;
                    otherTextBox.ResetText();
                    CheckOutBarcodeTextBox.ResetText();

                    cinderellaNameLabel.ResetText();

                    updateDUI();
                }
                //catch (ArgumentOutOfRangeException noSelection)
               // {
               //     MessageBox.Show("Please select a Cinderella");
               // }
              //  catch (NullReferenceException error)
                //{
                  //  MessageBox.Show(error.ToString());
                    //MessageBox.Show("Please Select the Size and Color of the Dress and of the Shoes");
                }
            }


        private void organizationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchLabel_Click(object sender, EventArgs e)
        {

        }
        }
    }

