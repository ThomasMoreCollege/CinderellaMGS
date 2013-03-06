using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using IDAutomation_FontEncoder;

namespace CinderellaLauncher.Forms
{
    public partial class Print : Form
    {
        clsBarCode PrintLabel = new clsBarCode();
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string barcode = "*" + PrintBox.Text + "*";
            PrintLabel.PrintBarCode("IDAutomationHC39M", barcode, 12);

        }
    }
}
