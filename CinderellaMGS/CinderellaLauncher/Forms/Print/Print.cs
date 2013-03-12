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
using CinderellaLauncher;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace CinderellaLauncher.Forms
{
    public partial class Print : Form
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
        
        SQL_Queries query = new SQL_Queries();
        clsBarCode PrintLabel = new clsBarCode();
        private DataTable PG;
        private BindingSource PGBindingSource = new BindingSource();

        private SqlCommand updateCommand;
        private SqlDataAdapter PrintGridAdapter;
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {
            //PrintGrid.DataBindings = query.PrintIDGrid();

            PG = new DataTable();

            // Give the DGV a datasource
            PrintGrid.Invoke(new Action(delegate()
            {
                PrintGrid.DataSource = PGBindingSource;

            }));

            // Give the dataAdapter a select query and connection string
            PrintGridAdapter = new SqlDataAdapter(query.PrintIDGrid(), connection);


            // Not sure yet ...
            PG.Locale = System.Globalization.CultureInfo.InvariantCulture;

            // Fill the dataTable from the dataAdapter
            PrintGridAdapter.Fill(PG);
            //  searchDGV.Columns[0].Visible = false;


            // Make the datasource for the binding data source the data table
            PrintGrid.Invoke(new Action(delegate()
            {
                PGBindingSource.DataSource = PG;

                PrintGrid.ClearSelection();
            }));

        }

        private void button1_Click(object sender, EventArgs e)
        {
                int i = Convert.ToInt32(query.count());

                string[] barcode;
                barcode = new string[i];
                int p = 0;
                int z = 0;

                while (i != 0)
                {
                    if (p == Convert.ToInt32(query.count()))
                    {
                        i = 0;
                    }
                    else
                    {
                        barcode[p] = PrintGrid.Rows[z].Cells[0].Value.ToString();
                        z++;
                        p++;
                        --i;

                    }

                }

                string q = query.PrintCinderellaName(barcode[0]) + "     ";
                //string q1 = query.PrintCinderellaName(PrintBox.Text) + "     ";
                //string barcode1 = PrintBox.Text;
                PrintLabel.PrintBarCode("IDAutomationHC39M", barcode, 9, "Times New Roman", q, 11);
            }
        }
    }
