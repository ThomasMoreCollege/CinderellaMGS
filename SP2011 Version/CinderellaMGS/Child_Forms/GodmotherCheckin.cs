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
    public partial class GodmotherCheckin : Form
    {
        SQL_Queries sqlQuery = new SQL_Queries();
        string statusToGet = "";
        string orderByGet = "";
        string selectedShift = "";

        public GodmotherCheckin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="order"></param>
        /// <param name="shift"></param>
        public void populate(string status, string order, string shift)
        {
            DataSet dsA = sqlQuery.getGodmotherStatusByShift(status, order, shift);

            this.checkInListBox.DisplayMember = "Name";
            this.checkInListBox.ValueMember = "FairyGodmotherTimestamp.fairyGodmotherID";
            this.checkInListBox.DataSource = dsA.Tables["tableName"];

            //Only Godmothers that have a current status of "Pending" Should be able to be checked in
            if (status != "Pending")
            {
                checkInButton.Enabled = false;
            }
            else
            {
                checkInButton.Enabled = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void getStatuses()
        {
            DataSet dsB = sqlQuery.sqlSelect("getGodmotherStatuses");

            this.filterComboBox.DisplayMember = "statusTxt";
            this.filterComboBox.ValueMember = "statusName";
            this.filterComboBox.DataSource = dsB.Tables["tableName"];

        }
        /// <summary>
        /// 
        /// </summary>
        public void getShifts()
        {
            DataSet dsC = sqlQuery.sqlSelect("getShifts");

            this.shiftCB.DisplayMember = "shiftTime";
            this.shiftCB.ValueMember = "shiftID";
            this.shiftCB.DataSource = dsC.Tables["tableName"];
        }
        /// <summary>
        /// 
        /// </summary>
        public void setFormStyle()
        {
            filterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            shiftCB.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BackColor = GlobalVar.FormBackColor;
            checkInButton.BackColor = GlobalVar.ButtonBackColor;
            sortByNameButton.BackColor = GlobalVar.ButtonBackColor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GodmotherCheckin_Load(object sender, EventArgs e)
        {
            selectedShift = "1";
            orderByGet = "transID";
            statusToGet = "Pending";

            getStatuses();
            getShifts();

            populate(statusToGet, orderByGet, selectedShift);

            setFormStyle();

            //Set the defaults
            this.filterComboBox.SelectedValue = "Pending";
            this.shiftCB.SelectedValue = selectedShift; 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            statusToGet = filterComboBox.SelectedValue.ToString();
            populate(statusToGet, orderByGet, selectedShift);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkInButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = checkInListBox.SelectedValue.ToString();
                string status = "Unavailable";
                //Now set the status
                sqlQuery.setStatus(id, status, false, false);
            }
            catch
            {
                MessageBox.Show("Please Select Cinderella to be Checked-In, if there are no Cinderella's then please add one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Refresh the controls
            populate(statusToGet, orderByGet, selectedShift);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shiftCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShift = shiftCB.SelectedValue.ToString();
            populate(statusToGet, orderByGet, selectedShift);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addGodmotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Godmother addForm = new Add_Godmother();
            //this.Hide();
            this.Enabled = false;
            addForm.ShowDialog();
            this.Enabled = true;

            //REFRESH!
            populate(statusToGet, orderByGet, selectedShift);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortByNameButton_Click(object sender, EventArgs e)
        {
            //Not clean but it will do for now :(
            populate(statusToGet, "Name", selectedShift);
            //orderByGet = 'Name';
            //populate()
        }
    }
}
