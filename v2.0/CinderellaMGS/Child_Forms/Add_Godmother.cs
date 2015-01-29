using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinderellaMGS
{
    public partial class Add_Godmother : Form
    {
        //Instantiate some Classes
        SQL_Queries sqlQuery = new SQL_Queries();

        public Add_Godmother()
        {
            InitializeComponent();
            fnameLabel.Font = GlobalVar.LabelFont;
            lnameLabel.Font = GlobalVar.LabelFont;
            this.BackColor = GlobalVar.FormBackColor;
            getShifts();
        }
        /// <summary>
        /// Retrieves first and last name and selected shifts from the form and adds the godmother to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            //Add the godmother to the table
            string lname = "";
            string fname = "";

            lname = lnameTB.Text;
            fname = fnameTB.Text;

            string addedID = sqlQuery.NewGodMother(fname, lname);

            //Add the selected shifts
            //List<String> shiftList = new List<String>();
            foreach (DataRowView objDataRowView in shiftLB.SelectedItems)
            {
                
                string tempString = objDataRowView["shiftID"].ToString();
                sqlQuery.AddGodmotherShift(tempString, addedID);
                //shiftList.Add(tempString);
            }

            //Set account created status
            string statusAdded = "Added";
            sqlQuery.setStatus(addedID, statusAdded, false, false);

            //Set their initial status to inactive
            string statusUnavailable = "Unavailable";
            sqlQuery.setStatus(addedID, statusUnavailable, false, false);

            //Clean Everything up
            resetForm();
        }
        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Calls the reset form method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetButton_Click(object sender, EventArgs e)
        {
            resetForm();
        }
        /// <summary>
        /// Resets all the textboxes, list box, and set the proper focus.
        /// </summary>
        private void resetForm()
        {
            //Reset all controls on the form
            fnameTB.Clear();
            lnameTB.Clear();
            shiftLB.SelectedIndex = -1;
            fnameTB.Focus();
        }
        /// <summary>
        /// Retrieves all the available shifts from the database.
        /// </summary>
        private void getShifts()
        {
            DataSet ds = sqlQuery.sqlSelect("getShifts");

            this.shiftLB.DisplayMember = "shiftTime";
            this.shiftLB.ValueMember = "shiftID";
            //this.shiftLB.ValueMember = "ID";
            this.shiftLB.DataSource = ds.Tables["tableName"];

            this.shiftLB.SelectedIndex = -1;
        }
        /// <summary>
        /// Displays the applications Global about box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AboutBox aboutBoxForm = new AboutBox();
            aboutBoxForm.ShowDialog();
            this.Enabled = true;
        }
    }
}
