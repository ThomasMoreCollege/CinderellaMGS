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
    public partial class ConnectionString : Form
    {
        private string _StringReturnProperty;

        public string StringReturnProperty
        {
            get { return _StringReturnProperty; }
        }
        public ConnectionString()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Formats the connection string to be returned.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button_Click(object sender, EventArgs e)
        {
            _StringReturnProperty = "Data Source=" + serverTB.Text + "," + portTB.Text + ";Initial Catalog=" + databaseTB.Text + ";User Id=" + usernameTB.Text + ";Password=" + passwordTB.Text + ";";
            this.DialogResult = DialogResult.OK; // You dont need this line if you set buttonOK's DialogResult to OK in the designer
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void portTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }
    }
}
