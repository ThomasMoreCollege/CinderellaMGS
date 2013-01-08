using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinderellaMGS
{
    public partial class Delete_Godmother : Form
    {
        //Instantiate some Classes
        SQL_Queries sqlQuery = new SQL_Queries();
        public Delete_Godmother()
        {
            InitializeComponent();
            populateControls();
        }
        /// <summary>
        /// Populates the list box containing godmother names.
        /// </summary>
        public void populateControls()
        {
            DataSet ds = sqlQuery.sqlSelect("getGodmothers");

            this.godmotherLB.DisplayMember = "Name";
            this.godmotherLB.ValueMember = "ID";
            this.godmotherLB.DataSource = ds.Tables["tableName"];
        }
        /// <summary>
        /// Gets the selected godmother from the listbox and deletes them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Get the selected item
            string idString = godmotherLB.SelectedValue.ToString();

            //Now lets set the delete flag
            sqlQuery.DeleteGodMother(idString);

            //Set a final status to deleted
            //Set their initial status to Deleted
            string status = "Deleted";

            //Now set the status
            sqlQuery.setStatus(idString, status, false, false);

            //Refresh the control
            populateControls();
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
