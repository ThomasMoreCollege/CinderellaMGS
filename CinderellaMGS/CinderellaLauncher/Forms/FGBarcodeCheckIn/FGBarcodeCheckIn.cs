using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinderellaLauncher
{
    public partial class FGCheckInBarcode : Form
    {
        public FGCheckInBarcode()
        {
            InitializeComponent();
        }

        private void FGCheckInBarcode_Load(object sender, EventArgs e)
        {

        }

        private void BarcodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                int id = Convert.ToInt16(BarcodeTextBox.Text);



            }

        }
    }
}
