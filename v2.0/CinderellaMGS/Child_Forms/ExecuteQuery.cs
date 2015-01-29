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
    public partial class ExecuteQuery : Form
    {
        DatabaseIO database = new DatabaseIO();

        public ExecuteQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Grabs the query from the textbox and determines whether it is a select, insert, or update.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void executeBT_Click(object sender, EventArgs e)
        {
            string mode = "";
            output.Text = "";
            int result = -1;

            //Get the query
            string sql = queryTB.Text;

            //Check for an empty query
            if (sql != "")
            {
                //Determine the type of query
                string firstChar = "";
                firstChar = sql.Substring(0, 1);

                switch (firstChar)
                {
                    case "S":
                        mode = "Select";
                        break;
                    case "D":
                        mode = "Delete";
                        break;
                    case "I":
                        mode = "Insert";
                        break;
                    case "U":
                        mode = "Update";
                        break;

                }
                //Execute the query

                if (mode == "Select")
                {
                    DataSet tempDataSet = database.getDataSet(sql, "tableName");

                    if (tempDataSet != null)
                    {
                        DispDataset dataForm = new DispDataset(tempDataSet);
                        this.Hide();
                        dataForm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        output.Text = "Query not succesfull.";
                    }

                }
                else if (mode == "Delete" || mode == "Insert" || mode == "Update")
                {

                    //int result = 
                    result = database.ExecuteQuery(sql);

                    //output the result
                    if (result != -1)
                    {//Executed Succesful
                        output.Text = "Query succesfull.";
                    }
                    else
                    {
                        output.Text = "Query not succesfull.";
                    }
                }
            }
        }
        /// <summary>
        /// Resets the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBT_Click(object sender, EventArgs e)
        {
            output.Text = "";
            queryTB.Clear();
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
        /// Displays a list of tables in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            string sql = " SELECT name FROM sysobjects WHERE type = 'U'";
            DataSet tempDataSet = database.getDataSet(sql, "tableName");
            DispDataset dataForm = new DispDataset(tempDataSet);
            this.Hide();
            dataForm.ShowDialog();
            this.Show();
        }
    }

}
