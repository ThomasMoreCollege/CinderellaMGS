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
using System.Windows.Forms.DataVisualization.Charting;

namespace CinderellaLauncher
{
    /*
     * Statistics.cs
     * 
     * -Shows different data results from the event
     * 
     * -Input:None
     * 
     * -Ouput:
     *      -Graph results
     * 
     * -Precondition: None
     *      
     * -Postcondition: None
     * 
     */ 
    public partial class Statistics : Form
    {
        static SQL_Queries query = new SQL_Queries();
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

        private DataTable statusChartDataTable;
        private SqlDataAdapter statusChartDataAdapter;

        private DataTable volunteerCountChartDataTable;
        private SqlDataAdapter volunteerCountChartDataAdapter; 

        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            string statusQuery = "SELECT currentStatus, COUNT(*) AS num FROM Cinderellas WHERE currentStatus IN ('1','2','3','4','5','6','7','8') GROUP BY currentStatus"; 
            statusChartDataTable = new DataTable();
            statusChartDataAdapter = new SqlDataAdapter(statusQuery, connection);
            statusChartDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            statusChartDataAdapter.Fill(statusChartDataTable);
            statusCountChart.DataSource = statusChartDataTable;
            statusCountChart.DataBind();

            string volunteerCountQuery = "SELECT shiftID, roleID, COUNT(*) AS num FROM ShiftWorkers WHERE roleID IN ('3','4','5','6') GROUP BY shiftID, roleID";
            volunteerCountChartDataTable = new DataTable();
            volunteerCountChartDataAdapter = new SqlDataAdapter(volunteerCountQuery, connection);
            volunteerCountChartDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            volunteerCountChartDataAdapter.Fill(volunteerCountChartDataTable);
            volunteerCountChart.DataSource = volunteerCountChartDataTable;
            volunteerCountChart.DataBind();

     

        }
    }
}
