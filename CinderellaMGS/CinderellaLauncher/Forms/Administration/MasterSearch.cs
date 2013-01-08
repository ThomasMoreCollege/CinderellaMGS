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
    
    public partial class MasterSearch : Form
    {
        private bool DEBUGGING_ENABLED = false;

        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        private SQL_Queries query = new SQL_Queries();

        // Main results DGV 
        private BindingSource resultsDGVBindingSource = new BindingSource();
        private DataTable resultsDGVDataTable;
        private SqlDataAdapter resultsDGVDataAdapter;

        // Fairy Godmother DGV
        private BindingSource fgDGVBindingSource = new BindingSource();
        private DataTable fgDGVDataTable;
        private SqlDataAdapter fgDGVDataAdapter;

        // Cinderella DGV
        private BindingSource cindDGVBindingSource = new BindingSource();
        private DataTable cindDGVDataTable;
        private SqlDataAdapter cindDGVDataAdapter;

        // Seamstress dropdownlist
        private BindingSource seamstressBindingSource = new BindingSource();
        private DataTable seamstressDataTable;
        private SqlDataAdapter seamstressDataAdapter;


        // Cinderella
        private string cinFirstName;
        private string cinLastName;
        private string cinOrganization;

        // FG
        private string FGFirstName;
        private string FGLastName;

        // Alterations
        private int SeamstressID;
        // Will be 0,1,or 2 
        // SQL booleans translate to: 1 = true, 0 = false
        // 2 == UNKNOWN
        // 1 == HAS
        // 0 == DOES NOT HAVE   
        private int statusOfAlterations;

        // Dress
        private List<string> dcList; 
        private int maxDressSize;
        private int minDressSize;
        
        // Shoes
        private bool hasShoes;
        private List<string> scList;
        private double maxShoeSize;
        private double minShoeSize;

        // Will be 0,1,or 2 
        // SQL booleans translate to: 1 = true, 0 = false
        // 2 == UNKNOWN
        // 1 == HAS
        // 0 == DOES NOT HAVE      
        private int ring;
        private int headpiece;
        private int bracelet;
        private int earring;
        private int necklace;

        public MasterSearch()
        {
            InitializeComponent();
        }

        private void MasterSearch_Load(object sender, EventArgs e)
        {
            // Create the dress and shoe color Lists
            dcList = new List<string>();
            scList = new List<string>();

            // Set up the data binding for the seamstress drop down list
            seamstressDataTable = new DataTable();
            seamstressDropDown.DataSource = seamstressBindingSource;
            seamstressDataAdapter = new SqlDataAdapter(query.AllSeamstresses(), connection);      
            seamstressDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            seamstressDataAdapter.Fill(seamstressDataTable);
            seamstressBindingSource.DataSource = seamstressDataTable;
            // Make a new column in the table to allow the dropdownlist to show first and last name
            seamstressDataTable.Columns.Add("FullName", typeof(string), "firstName + ' ' + lastName");
            seamstressDropDown.DisplayMember = "FullName";
            seamstressDropDown.ValueMember = "id";
            // Add a row for unknown seamstress
            seamstressDataTable.Rows.Add(-1, "Unknown", "");

            // Set the form and its values to their initial states
            clearVals();
            clearUI();

            if (DEBUGGING_ENABLED) this.Text = "Master Search (Debug Mode)"; else this.Text = "Master Search";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearVals();
            clearUI();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Grab cinderella info
                cinFirstName = cindFname.Text;
                cinLastName = cindLname.Text;
                cinOrganization = cindOrg.Text;

                // Grab FG info
                FGFirstName = fgFname.Text;
                FGLastName = fgLname.Text;

                // Grab alterations/seamstress info
                DataRow selectedDataRow = ((DataRowView)seamstressDropDown.SelectedItem).Row;
                SeamstressID = Convert.ToInt32(selectedDataRow["id"]);

                // Grab Dress info
                // Need to clear the list and start over, so duplicates don't occur.
                dcList.Clear();
                foreach (object dc in dressColorCheckList.CheckedItems)
                {
                    dcList.Add(dc.ToString());
                }

                maxDressSize = Convert.ToInt32(dressSizeMaxUpDown.Value);
                minDressSize = Convert.ToInt32(dressSizeMinUpDown.Value);

                if (maxDressSize < minDressSize)
                    throw new ArgumentException("Invalid dress size range");

                // Grab Shoe Info
                // Need to clear the list and start over, so duplicates don't occur.
                scList.Clear();
                foreach (object sc in shoeColorCheckList.CheckedItems)
                {
                    scList.Add(sc.ToString());
                }

                maxShoeSize = Convert.ToDouble(shoeSizeMax.Value);
                minShoeSize = Convert.ToDouble(shoeSizeMin.Value);

                if (maxShoeSize < minShoeSize)
                    throw new ArgumentException("Invalid shoe size range");

                // QUERYIN' LIKE A BAWSS
                if (!DEBUGGING_ENABLED)
                {

                    string uberQuery = query.MasterSearch(cinFirstName, cinLastName, cinOrganization, FGFirstName, FGLastName, SeamstressID, statusOfAlterations, dcList.ToArray(), maxDressSize, minDressSize, hasShoes, scList.ToArray(), maxShoeSize, minShoeSize, ring, headpiece, bracelet, earring, necklace);

                    resultsDGVDataTable = new DataTable();
                    resultsDGV.DataSource = resultsDGVBindingSource;
                    resultsDGVDataAdapter = new SqlDataAdapter(uberQuery, connection);
                    resultsDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    resultsDGVDataAdapter.Fill(resultsDGVDataTable);
                    resultsDGVBindingSource.DataSource = resultsDGVDataTable;
                    resultsDGV.ClearSelection();


                    // Remember to change these to something else ... they obviously dont display the results of uberQuery.
                    /* fgDGVDataTable = new DataTable();
                     fgDGV.DataSource = fgDGVBindingSource;
                     fgDGVDataAdapter = new SqlDataAdapter(uberQuery, connection);
                     fgDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                     fgDGVDataAdapter.Fill(fgDGVDataTable);
                     fgDGVBindingSource.DataSource = fgDGVDataTable;
                     fgDGV.ClearSelection();

                     cindDGVDataTable = new DataTable();
                     cindDGV.DataSource = cindDGVBindingSource;
                     cindDGVDataAdapter = new SqlDataAdapter(uberQuery, connection);
                     cindDGVDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                     cindDGVDataAdapter.Fill(cindDGVDataTable);
                     cindDGVBindingSource.DataSource = cindDGVDataTable;
                     cindDGV.ClearSelection();*/
                }
                else if (DEBUGGING_ENABLED)
                {
                    MessageBox.Show(getVals());
                    MessageBox.Show(query.MasterSearch(cinFirstName, cinLastName, cinOrganization, FGFirstName, FGLastName, SeamstressID, statusOfAlterations, dcList.ToArray(), maxDressSize, minDressSize, hasShoes, scList.ToArray(), maxShoeSize, minShoeSize, ring, headpiece, bracelet, earring, necklace));
                }

            }
            catch (ArgumentException badArg)
            {
                MessageBox.Show(badArg.Message);
            }
        }

        private void incDressSizeButton_CheckedChanged(object sender, EventArgs e)
        {
            minDressLabel.Visible = !minDressLabel.Visible;
            dressSizeMinUpDown.Visible = !dressSizeMinUpDown.Visible;
            dressRangeButton.Visible = !dressRangeButton.Visible;
            dressRangeButton.Checked = false;
            maxDressLabel.Visible = false;
            dressSizeMaxUpDown.Visible = false;

            if (incDressSizeButton.Checked == false)
            {
                maxDressLabel.Visible = false;
                minDressLabel.Visible = false;

                dressSizeMaxUpDown.Visible = false;
                dressSizeMinUpDown.Visible = false;

                dressRangeButton.Visible = false;


                dressSizeMaxUpDown.Value = 40;
                dressSizeMinUpDown.Value = 0;
            }
            else
            {
                dressSizeMaxUpDown.Value = 8;
                dressSizeMinUpDown.Value = 8;
            }
        }

        private void incShoeSizeButton_CheckedChanged(object sender, EventArgs e)
        {
            minShoeLabel.Visible = !minShoeLabel.Visible;
            shoeSizeMin.Visible = !shoeSizeMin.Visible;
            shoeRangeButton.Visible = !shoeRangeButton.Visible;
            shoeRangeButton.Checked = false;
            maxShoeLabel.Visible = false;
            shoeSizeMax.Visible = false;

            if (incShoeSizeButton.Checked == false)
            {
                maxShoeLabel.Visible = false;
                minShoeLabel.Visible = false;

                shoeSizeMax.Visible = false;
                shoeSizeMin.Visible = false;

                shoeRangeButton.Visible = false;

                shoeSizeMax.Value = Convert.ToDecimal(15.0);
                shoeSizeMin.Value = Convert.ToDecimal(3.0);
            }
            else
            {
                shoeSizeMax.Value = Convert.ToDecimal(7.0);
                shoeSizeMin.Value = Convert.ToDecimal(7.0);
            }
        }

        private void dressRangeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dressRangeButton.Checked == false) 
                dressSizeMaxUpDown.Value = dressSizeMinUpDown.Value;
            if (dressRangeButton.Checked == true)
                dressSizeMaxUpDown.Value = 40;

            if (dressRangeButton.Checked)
            {
                minDressLabel.Text = "Min";

                maxDressLabel.Visible = true; 
                dressSizeMaxUpDown.Visible = true;
                
            }
            else
            {
                minDressLabel.Text = "Size";

                maxDressLabel.Visible = false;
                dressSizeMaxUpDown.Visible = false;
            }

        }

        private void shoeRangeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (shoeRangeButton.Checked == false) shoeSizeMax.Value = shoeSizeMin.Value;
            if (shoeRangeButton.Checked == true) shoeSizeMax.Value = 15;

            if (shoeRangeButton.Checked)
            {
                minShoeLabel.Text = "Min";

                maxShoeLabel.Visible = true;
                shoeSizeMax.Visible = true;

            }
            else
            {
                minShoeLabel.Text = "Size";

                maxShoeLabel.Visible = false;
                shoeSizeMax.Visible = false;
            }
        }

        private void dressSizeMin_ValueChanged(object sender, EventArgs e)
        {
            if (dressRangeButton.Checked == false && incDressSizeButton.Checked)
            {
                int minS = Convert.ToInt32(dressSizeMinUpDown.Value);
                dressSizeMaxUpDown.Value = minS;
            }
        }

        private void shoeSizeMin_ValueChanged(object sender, EventArgs e)
        {
            if (shoeRangeButton.Checked == false && incShoeSizeButton.Checked)
            {
                Decimal minS = shoeSizeMin.Value;
                shoeSizeMax.Value = minS;
            }
        }

        private void toggleDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult debugToggleMessage = MessageBox.Show("Toggle debugging state?\r\n\r\nThis will avoid running the query upon clicking search.\r\n" + 
                                                                "Instead, all parameters being given to the query will be displayed.", "Debugging", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (debugToggleMessage == DialogResult.Yes)
            {
                if (DEBUGGING_ENABLED)
                {
                    DEBUGGING_ENABLED = false;
                    MessageBox.Show("Debugging Disabled");
                    this.Text = "Master Search";
                }
                else if (!DEBUGGING_ENABLED)
                {
                    DEBUGGING_ENABLED = true;
                    MessageBox.Show("Debugging Enabled");
                    this.Text = "Master Search (Debug Mode)";
                }
            }
            else
            {
                
            }
        }

        // Clears class private variables, not the UI components.
        private void clearVals()
        {

            cinFirstName = "";
            cinLastName = "";
            cinOrganization = "";
            FGFirstName = "";
            FGLastName = "";
            SeamstressID = -1; // To Reflect unknown seamstress
            statusOfAlterations = 2;
            dcList.Clear();
            maxDressSize = 40;
            minDressSize = 0;
            hasShoes = true; // Defaulting to true for now.
            scList.Clear();
            maxShoeSize = 15.0;
            minShoeSize = 3.0;
            ring = 2;
            headpiece = 2;
            bracelet = 2;
            earring = 2;
            necklace = 2;
        }

        // Clears UI components, no the class private variables
        private void clearUI()
        {
            // Clear cinderella input boxes
            cindFname.Text = "";
            cindLname.Text = "";
            cindOrg.Text = "";
            
            // Clear fairy godmother input boxes
            fgFname.Text = "";
            fgLname.Text = "";

            // Reset dress controls
            dressColorCheckList.ClearSelected();
            dressRangeButton.Checked = false;
            incDressSizeButton.Checked = false;
            dressSizeMinUpDown.Value = 0;
            dressSizeMaxUpDown.Value = 40;
            dressSizeMinUpDown.Visible = false;
            dressSizeMaxUpDown.Visible = false;
            maxDressLabel.Visible = false;
            minDressLabel.Visible = false;
            dressRangeButton.Visible = false;

            // Reset shoe controls
            shoeColorCheckList.ClearSelected();
            shoeRangeButton.Checked = false;
            incShoeSizeButton.Checked = false;
            noShoesButton.Checked = false;
            shoeSizeMax.Value = Convert.ToDecimal(15.0);
            shoeSizeMin.Value = Convert.ToDecimal(3.0);
            shoeSizeMax.Visible = false;
            shoeSizeMin.Visible = false;
            shoeRangeButton.Visible = false;
            minShoeLabel.Visible = false;
            maxShoeLabel.Visible = false;

            // Reset alterations status drop down to default selection
            alterationsStatusComboBox.SelectedIndex = 0;
            int seamstressCount = seamstressDropDown.Items.Count;
            seamstressDropDown.SelectedIndex = (seamstressCount - 1);
            
            // Reset jewelry drop downs to default index
            braceletDropDown.SelectedIndex = 0;
            earringsDropDown.SelectedIndex = 0;
            necklaceDropDown.SelectedIndex = 0;
            ringDropDown.SelectedIndex = 0;
            headPieceDropDown.SelectedIndex = 0;

            for (int i = 0; i < dressColorCheckList.Items.Count; i++)
            {
                dressColorCheckList.SetItemCheckState(i, CheckState.Unchecked);
               
            }

            for (int i = 0; i < shoeColorCheckList.Items.Count; i++)
            {
                shoeColorCheckList.SetItemCheckState(i, CheckState.Unchecked);

            }
        }

        // NOTE: This reports the values that are stored in the class's private variables.
        // This does not DIRECTLY reflect the values display on the UI. The search button is clicked, the values
        // are retrieved from the controls and stored into the class's private variables, and this concatenates them
        // all into a string. 
        private string getVals()
        {
            // Strings to hold the values in dress colors and shoe colors lists
            string dcls = "";
            string shcls = "";

            foreach (string d in dcList)
            {
                dcls += (d + "\r\n");
            }

            foreach (string s in scList)
            {
                shcls += (s + "\r\n");
            }


            string vals =
                "cinFirstName= " + cinFirstName + "\r\n" +
                "cinLastName= " + cinLastName + "\r\n" +
                "cinOrganization= " + cinOrganization + "\r\n" +
                "FGFirstName= " + FGFirstName + "\r\n" +
                "FGLastName= " + FGLastName + "\r\n" +
                "SeamstressID= " + SeamstressID + "\r\n" +
                "statusOfAlterations= " + statusOfAlterations + "\r\n" +
                "maxDressSize= " + maxDressSize + "\r\n" +
                "minDressSize= " + minDressSize + "\r\n" +
                "hasShoes= " + hasShoes + "\r\n" +
                "maxShoeSize= " + maxShoeSize + "\r\n" +
                "minShoeSize= " + minShoeSize + "\r\n" +
                "ring= " + ring + "\r\n" +
                "headpiece= " + headpiece + "\r\n" +
                "bracelet= " + bracelet + "\r\n" +
                "earring= " + earring + "\r\n" +
                "necklace= " + necklace + "\r\n" +
                "\r\n\r\n" +
                "Dress colors: " + dcls +
                "\r\n\r\n" +
                "Shoe colors: " + shcls +
                "\r\n";


            return vals;
        }

        

        private void braceletDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = braceletDropDown.SelectedIndex;

            switch (val)
            {
                case 0:
                    bracelet = 2;
                    break;
                case 1:
                    bracelet = 1;
                    break;
                case 2:
                    bracelet = 0;
                    break;
                default:
                    bracelet = 2;
                    break;
            }
        }

        private void earringsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = earringsDropDown.SelectedIndex;

            switch (val)
            {
                case 0:
                    earring = 2;
                    break;
                case 1:
                    earring = 1;
                    break;
                case 2:
                    earring = 0;
                    break;
                default:
                    earring = 2;
                    break;
            }
        }

        private void necklaceDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = necklaceDropDown.SelectedIndex;

            switch (val)
            {
                case 0:
                    necklace = 2;
                    break;
                case 1:
                    necklace = 1;
                    break;
                case 2:
                    necklace = 0;
                    break;
                default:
                    necklace = 2;
                    break;
            }
        }

        private void ringDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = ringDropDown.SelectedIndex;

            switch (val)
            {
                case 0:
                    ring = 2;
                    break;
                case 1:
                    ring = 1;
                    break;
                case 2:
                    ring = 0;
                    break;
                default:
                    ring = 2;
                    break;
            }
        }

        private void headPieceDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = headPieceDropDown.SelectedIndex;

            switch (val)
            {
                case 0:
                    headpiece = 2;
                    break;
                case 1:
                    headpiece = 1;
                    break;
                case 2:
                    headpiece = 0;
                    break;
                default:
                    headpiece = 2;
                    break;
            }
        }

       

        private void alterationsStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val = alterationsStatusComboBox.SelectedIndex;

            switch (val)
            {
                case 0:
                    statusOfAlterations = 2;
                    seamstressDropDown.Enabled = true;
                    break;
                case 1:
                    statusOfAlterations = 1;
                    seamstressDropDown.Enabled = true;
                    break;
                case 2:
                    statusOfAlterations = 0;
                    seamstressDropDown.Enabled = false;
                    break;
                default:
                    statusOfAlterations = 2;
                    seamstressDropDown.Enabled = true;
                    break;
            }
        }

        private void noShoesButton_CheckedChanged(object sender, EventArgs e)
        {
            hasShoes = !hasShoes;
        }
    }
}