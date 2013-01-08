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
    public partial class DispDataset : Form
    {
        public DispDataset(DataSet dataToDisplay)
        {
            InitializeComponent();

            // Convert DataSet to DataTable by getting DataTable at first zero-based index of DataTableCollection
            DataTable myDataTable = dataToDisplay.Tables[0];

            dataGridView.DataSource = myDataTable;

        }
    }
}
