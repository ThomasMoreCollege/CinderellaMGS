using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace CinderellaMGS
{
    public partial class Administration : Form
    {
        //Instantiate the sql class
        SQL_Queries sqlQuery = new SQL_Queries();
        UserAccounts Account = new UserAccounts();

        string myUsername = "";
        string permissionMessage = "You do not have permission to access this resource.";
        string permissionHeader = "Access Denied";

        public Administration(string username)
        {
            InitializeComponent();
            loadPictures();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            myUsername = username;
            userLabel.Text = "Username: " + username;
            this.BackColor = GlobalVar.FormBackColor;
        }
        /// <summary>
        /// Loads the pictures for the menu items.
        /// </summary>
        public void loadPictures()
        {
            Assembly myAssembly;
            Stream myStream;
            Bitmap bmp;

            //Query Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.application64.png");
            bmp = new Bitmap(myStream);
            queryPB.Image = bmp;

            //Import Cinderellas Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.import64.png");
            bmp = new Bitmap(myStream);
            importCPB.Image = bmp;

            //Import Godmothers Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.import64.png");
            bmp = new Bitmap(myStream);
            importGPB.Image = bmp;

            //Settings Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.configure64.png");
            bmp = new Bitmap(myStream);
            manualModePB.Image = bmp;

            //Reset DB Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.cancel64.png");
            bmp = new Bitmap(myStream);
            resetPB.Image = bmp;

            //Reports Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.chart64.png");
            bmp = new Bitmap(myStream);
            reportsPB.Image = bmp;

            //User Management Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.edit_female_user.png");
            bmp = new Bitmap(myStream);
            usersPB.Image = bmp;

            //Export Data Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.export64.png");
            bmp = new Bitmap(myStream);
            exportPB.Image = bmp;

            //Exit Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.back64.png");
            bmp = new Bitmap(myStream);
            exitPB.Image = bmp;
        }
        /// <summary>
        /// Loads the sql query form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryPB_Click(object sender, EventArgs e)
        {
            if (Account.userHasRole(myUsername, "Developer"))
            {
                ExecuteQuery execQuery = new ExecuteQuery();
                //this.Hide();
                this.Enabled = false;
                execQuery.ShowDialog();
                //this.Show();
                this.Enabled = true;
            }
            else
            {
                MessageBox.Show(permissionMessage, permissionHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        /// <summary>
        /// Allows the user to specify a Cinderella data file to be imported.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importCPB_Click(object sender, EventArgs e)
        {
            //try
            //{
                int counter = 0;
                //Create the file open dialogue
                OpenFileDialog fDialog = new OpenFileDialog();

                //set a few properties
                fDialog.Title = "Open CSV File";
                fDialog.CheckFileExists = true;
                fDialog.CheckPathExists = true;

                //Add a file type filter
                fDialog.Filter = "CSV Files|*.csv";

                //Set initial path
                fDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                //Has the user selected a file?
                string fileName = "";
                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = fDialog.FileName;
                    List<string[]> parsedData = parseCSV(fileName);

                    DataTable newTable = new DataTable();
                    foreach (string column in parsedData[0])
                    {
                        newTable.Columns.Add();
                    }

                    int numberOfRows = 0;
                    foreach (string[] row in parsedData)
                    {
                        newTable.Rows.Add(row);
                        numberOfRows++;
                    }

                    //Progress Bar Stats
                    progressBar.Minimum = 0;
                    progressBar.Maximum = numberOfRows;
                    progressBar.Value = 0;
                    progressBar.Visible = true;

                    foreach (DataRow dataRow in newTable.Rows)
                    {
                        //Increment the progress bar
                        progressBar.Value++;
                        counter++;
                        if (counter > 1)//Get rid of the first two rows of file
                        {
                            string field1 = dataRow[0].ToString();//Day --Discard Column
                            string field2 = dataRow[1].ToString();//Date
                            string field3 = dataRow[2].ToString();//Time
                            string field4 = dataRow[3].ToString();//AM/PM
                            string field5 = dataRow[4].ToString();//SequenceNumber --Discard Column
                            string field6 = dataRow[5].ToString();//ID
                            string field7 = dataRow[6].ToString();//Certificate Sent
                            string field8 = dataRow[7].ToString();//Name
                            string field9 = dataRow[8].ToString();//Agency/School
                            string field10 = dataRow[9].ToString();//Referral Name
                            string field11 = dataRow[10].ToString();//Notes

                            //Are we finished reading the file yet?

                            if (field1 != "" || field2 != "")//Is this a valid row to import??
                            {//Then we are gonna say this is a valid row

                                //Some Data cleanup
                                string ID = field6;

                                //<Name>
                                string tempName = field8;
                                string[] splitName = tempName.Split(new Char[] { ' ' });
                                string firstName = Convert.ToString(splitName[0]);
                                string lastName = Convert.ToString(splitName[1]);
                                //</Name>

                                //<Date>
                                string tempDate = field2;
                                tempDate = tempDate.Remove(tempDate.Length - 2, 2);
                                tempDate += ", " + System.DateTime.Now.Year.ToString();
                                DateTime tempDateTime = DateTime.Parse(tempDate);
                                //string apptDate = tempDateTime.ToShortDateString();
                                string apptDate = tempDateTime.ToString("yyyy-MM-dd");
                                //</Date>

                                //<Time>
                                string tempTime = field3 + " " + field4;
                                DateTime tempDateTime2 = DateTime.Parse(tempTime);
                                //string apptTime = tempDateTime2.ToShortTimeString();
                                string apptTime = tempDateTime2.ToString("HH:mm");
                                //</Time>

                                string referralName = field10;

                                //<certification sent>
                                //string tempCertificationSent = field7.Substring(0, 1).ToUpper();
                                string tempCertificationSent = field7;
                                string certificateSent = "";
                                if (tempCertificationSent == "x" || tempCertificationSent == "X")
                                {
                                    certificateSent = "0";//True or Yes
                                }
                                else
                                {
                                    certificateSent = "1";//False or No
                                }

                                //</certification sent>

                                string notes = field11;

                                //Build and execute the sql
                                string sql = "INSERT INTO [Cinderella]([ID], [firstName], [lastName], [apptDate], [apptTime], [referralName], [certificateSent], [notes]) VALUES(";
                                sql += ID + ", '" + firstName + "', '" + lastName + "', '" + apptDate + "', '" + apptTime + "', '" + referralName + "', '" + certificateSent + "', '" + notes + "')";

                                sqlQuery.sqlStatment(sql);
                                sqlQuery.setStatus(ID, "Added", true, true);
                                sqlQuery.setStatus(ID, "Pending", true, true);

                                //counter++;
                            }
                        }
                    }
                }

                MessageBox.Show((counter -1).ToString() + " files were succesfully imported.", "Import Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Visible = false;
        }
        public List<string[]> parseCSV(string path)
        {
            List<string[]> parsedData = new List<string[]>();

            try
            {
                using (StreamReader readFile = new StreamReader(path))
                {
                    string line;
                    string[] row;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        parsedData.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return parsedData;
        }
        /// <summary>
        /// Allows the user to specify a Godmother data file to be imported.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importGPB_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is currently under construction. Please check back at a later time.", "Feature Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
            int counter = 0;
            //Create the file open dialogue
            OpenFileDialog fDialog = new OpenFileDialog();

            //set a few properties
            fDialog.Title = "Open CSV File";
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;

            //Add a file type filter
            fDialog.Filter = "CSV Files|*.csv";

            //Set initial path
            fDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            //Has the user selected a file?
            string fileName = "";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = fDialog.FileName;
                List<string[]> parsedData = parseCSV(fileName);

                DataTable newTable = new DataTable();
                foreach (string column in parsedData[0])
                {
                    newTable.Columns.Add();
                }

                int numberOfRows = 0;
                foreach (string[] row in parsedData)
                {
                    newTable.Rows.Add(row);
                    numberOfRows++;
                }

                //Progress Bar Stats
                progressBar.Minimum = 0;
                progressBar.Maximum = numberOfRows;
                progressBar.Value = 0;
                progressBar.Visible = true;

                foreach (DataRow dataRow in newTable.Rows)
                {
                    //Increment the progress bar
                    progressBar.Value++;

                    counter++;
                    if (counter > 1)//Get rid of the first row of file
                    {
                        string field1 = dataRow[0].ToString();//ID Number
                        string field2 = dataRow[1].ToString();//First Name
                        string field3 = dataRow[2].ToString();//Last Name
                        string field4 = dataRow[3].ToString();//Address Line One
                        string field5 = dataRow[4].ToString();//Address Line Two
                        string field6 = dataRow[5].ToString();//City
                        string field7 = dataRow[6].ToString();//State
                        string field8 = dataRow[7].ToString();//Zip
                        string field9 = dataRow[8].ToString();//Phone
                        string field10 = dataRow[9].ToString();//Email Address
                        string field11 = dataRow[10].ToString();//Date
                        string field12 = dataRow[11].ToString();//ID...Again
                        string field13 = dataRow[12].ToString();//Friday PS
                        string field14 = dataRow[13].ToString();//Friday DO
                        string field15 = dataRow[14].ToString();//Friday Alt
                        string field16 = dataRow[15].ToString();//Saturday AM PS
                        string field17 = dataRow[16].ToString();//Saturday AM DO
                        string field18 = dataRow[17].ToString();//Saturday AM ALT
                        string field19 = dataRow[18].ToString();//Sat PM PS
                        string field20 = dataRow[19].ToString();//Sat PM Do
                        string field21 = dataRow[20].ToString();//Sat PM Alt
                        string field22 = dataRow[21].ToString();//BGC In
                        string field23 = dataRow[22].ToString();//BGC OK
                        string field24 = dataRow[23].ToString();//Comments

                        //Are we finished reading the file yet?
                        if (field1 != "" || field2 != "")//Is this a valid row to import??
                        {//Then we are gonna say this is a valid row
                            string firstName = field2;
                            string lastName = field3;
                            string newGodmotherID = sqlQuery.NewGodMother(firstName, lastName);

                            //Set account created status
                            string statusAdded = "Added";
                            sqlQuery.setStatus(newGodmotherID, statusAdded, false, true);

                            //Set their initial status to inactive
                            //string statusUnavailable = "Unavailable"; //Removed due to addition of godmother checkin procedure
                            string statusUnavailable = "Pending";
                            sqlQuery.setStatus(newGodmotherID, statusUnavailable, false, true);

                            //Add the shift information
                            //Caution...this is a nasty hard-coded section!!!!!
                            ///--Shift 1- 3/18/2011 3:30:00 PM
                            ///--Shift 2- 3/19/2011 9:00:00 AM
                            ///--Shift 2- 3/19/2011 1:00:00 PM
                            ///
                            //DAY ONE (shift 1)
                            if (field13 != "")
                            {//Then they are working
                                sqlQuery.AddGodmotherShift("1", newGodmotherID);
                            }

                            //DAY TWO AM  (shift 2)
                            if (field16 != "")
                            {//Then they are working
                                sqlQuery.AddGodmotherShift("2", newGodmotherID);
                            }

                            //DAY TWO PM  (shift 3)
                            if (field19 != "")
                            {//Then they are working
                                sqlQuery.AddGodmotherShift("3", newGodmotherID);
                            }

                            counter++;
                        }
                    }
                }
            }
                MessageBox.Show(counter.ToString() + " files were succesfully imported.", "Import Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Visible = false;
            }

            catch (Exception ex)
            {
            MessageBox.Show("An error has occured during the import process.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            progressBar.Visible = false;
            }
        }
        /// <summary>
        /// Loads the Godmode form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsPB_Click(object sender, EventArgs e)
        {
                GodMode godModeForm = new GodMode();
                this.Enabled = false;
                godModeForm.ShowDialog();
                this.Enabled = true;
        }
        /// <summary>
        /// Resets the database to a default state as specified in the resetDB stored procedure.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetPB_Click(object sender, EventArgs e)
        {
            if (Account.userHasRole(myUsername, "Developer"))
            {
                int status = 0;
                const string message = "Are you sure you would like to reset the database?";
                const string caption = "Database Reset";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    //Reset the database
                    string temp = "execute resetDB";
                    status = sqlQuery.sqlStatment(temp);

                    if (status != -1)
                    {
                        MessageBox.Show("The database has been reset and populated with default data.");
                    }
                    else
                    {
                        MessageBox.Show("The database has been reset and populated with default data.", "An error has occured.");
                    }
                }
            }
            else
            {
                MessageBox.Show(permissionMessage, permissionHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
        /// <summary>
        /// Displays a messagebox with the current system stats.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportsPB_Click(object sender, EventArgs e)
        {
            //Gather some current statistics
            MessageBox.Show(sqlQuery.getStats(), "Current Stats", MessageBoxButtons.OK);
        }
        /// <summary>
        /// Loads the User_Mngt form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usersPB_Click(object sender, EventArgs e)
        {
            User_Mngt userForm = new User_Mngt();
            //this.Hide();
            this.Enabled = false;
            userForm.ShowDialog();
            //this.Show();
            this.Enabled = true;
        }
        /// <summary>
        /// Closes the Adminsitration Menu Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Exports data to a csv file based on the query defined.
        /// This method works however there has not been a query defined for the export. The SQL Select Statement should be entered in the exportQuery variable on line 511.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportPB_Click(object sender, EventArgs e)
        {
            string exportQuery = "";
            DataSet ds = sqlQuery.sqlSelect(exportQuery);
            DataTable dt = ds.Tables["tableName"];

            //Create the file save dialogue
            SaveFileDialog sDialog = new SaveFileDialog();

            //set a few properties
            sDialog.Title = "Save CSV File";
            //sDialog.CheckFileExists = true;
            //sDialog.CheckPathExists = true;

            //Add a file type filter
            sDialog.Filter = "CSV Files|*.csv";

            //Set initial path
            sDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            bool importRunning;

            //Has the user selected a file?
            string filePath = "";
            if (sDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = sDialog.FileName;
                try
                {
                    CreateCSVFile(dt, filePath);
                   var result = MessageBox.Show("The data has been successfully exported." + "\r\n" + "\r\n" + "Would you like to open the file?", "Export Completed", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                   if (result == DialogResult.Yes)
                    {
                        Process.Start(filePath); 
                    }
                }
                catch
                {
                    MessageBox.Show("An error occured during the export process. Please try your request again.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          }
        /// <summary>
        /// Method is used by the exportPB method to construct the csv file.
        /// </summary>
        /// <param name="dt">Datatable containing the data to be exported.</param>
        /// <param name="strFilePath">Path for which the file should be saved.</param>
        public void CreateCSVFile(DataTable dt, string strFilePath)
        {
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(strFilePath, false);

                // First we will write the headers.
                //DataTable dt = m_dsProducts.Tables[0];
                int iColCount = dt.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                // Now write all the rows.
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
            }
        }
    }