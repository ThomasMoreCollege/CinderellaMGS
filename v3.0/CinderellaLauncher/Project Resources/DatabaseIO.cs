using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml; //namespace to deal with XML documents 
using System.Xml.Linq; //namespace to deal with LINQ to XML classes 
using Microsoft.VisualBasic; //For my connectionString InputBox

namespace CinderellaLauncher
{
    ///-----------------------------------------------------------------
    ///   Namespace:      CinderellaMGS
    ///   Class:          DatabaseIO
    ///   Description:    Class to handle all database interaction.
    ///   Author:         Nathan Horn                    Date: January 1, 2011
    ///   Notes:          
    ///   Revision History:  Modified by Craig Everman 2012-02-15
    ///   Name:           Date:        Description:
    ///-----------------------------------------------------------------
    public class databaseType
    {
        public DataSet data { get; set; }
        public string errorMessage { get; set; }
    }
    public class DatabaseIO
    {
        public DatabaseIO()//Default Constructor
        {
        }
        SqlDataReader reader = null;
        SqlCommand cmd = null;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
     //   public string globConnectionString = string.Empty;
/*
        /// <summary>
        /// Checks for a valid connection string and tries to establish a connection to the database.  If the connection fails the user is given an opportunity to enter a new connection string.
        /// </summary>
        public void setupConnection()
        {
            if (checkConnection() == false)
            {
                DialogResult result = MessageBox.Show("A connection to the Database could not be established. Would you like to enter new connection settings?", "Database Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    RetrieveConnectionString();
                }

            }
        }
 */
        /// <summary>
        /// This method will check for a valid connection string and try opening a new connection.
        /// </summary>
        /// <returns>true if connection is successfull and false is unsuccessfull</returns>
        public bool checkConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                errorCheck(ex);
                return false;
            }
        }
        /// <summary>
        /// Creates the SQLConnection object "conn" which is used throughout the rest of the databaseIO methods.
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            checkConnection();
            return conn;           
        }
        /*
        /// <summary>
        /// Creates and returns a connection string key in the computers registry.
        /// </summary>
        /// <returns>Connection String value stored in the computers registry.</returns>
        public string createNewConnection()
        {
            string myString = string.Empty;
            ConnectionString connForm = new ConnectionString();
            if (connForm.ShowDialog() == DialogResult.OK)
                myString = connForm.StringReturnProperty;
            myRegistry.Write("CinderellaMGS", myString);
            string regConnString = myRegistry.Read("CinderellaMGS");
            return regConnString;
        }
        /// <summary>
        /// Attempts to read the connection string from the computers registry. If it doesn't exist a new key is created.
        /// </summary>
        /// <returns>Database connection string</returns>
        public string RetrieveConnectionString()
        {
            string myconnString = myRegistry.Read("CinderellaMGS");
            if (myconnString == null || myconnString == "")
            {
                return createNewConnection();
            }
            else//Create the file
            {
                return myconnString;
            }
        }
        */
        
        /// <summary>
        /// Method will execute a non query SQL statement and return the number of rows affected.
        /// </summary>
        /// <param name="sqlStatement">SQL Query to be executed.</param>
        /// <returns>Returns how many rows were affected.  -1 is returned if an error has occurred.</returns>
        public int ExecuteQuery(string sqlStatement)
        {
            try
            {
                //Close out previous connections
                CloseConnection();
                //Create our new connection
         //       conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                conn.Open();
                //Get the sql command
                cmd = new SqlCommand(sqlStatement, conn);
                cmd.CommandType = CommandType.Text;
                //Finally we will execute the command and return how many rows were affected
                int a = cmd.ExecuteNonQuery();
                conn.Close();
                return a;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Import Error :" + sqlStatement);
                MessageBox.Show(ex.ToString());
                return -1;
            }
        }

        public int ReturnFirstCellInt(string sqlStatement)
        {
            try
            {
                CloseConnection();
                conn.Open();
                cmd = new SqlCommand(sqlStatement, conn);
                cmd.CommandType = CommandType.Text;
                int a = Convert.ToInt32(cmd.ExecuteScalar().ToString()); 
                conn.Close();
                return Convert.ToInt32(a);
            }
            catch(NullReferenceException nre)
            {
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Import Error :" + sqlStatement);
                MessageBox.Show(ex.ToString());
                return -1;
            }
        }

        public string ReturnFirstCellString(string sqlStatement)
        {
            try
            {
                CloseConnection();
                conn.Open();
                cmd = new SqlCommand(sqlStatement, conn);
                cmd.CommandType = CommandType.Text;
                string a = cmd.ExecuteScalar().ToString();
                conn.Close();
                return a;
            }
            catch (NullReferenceException nre)
            {
                return "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Import Error :" + sqlStatement);
                MessageBox.Show(ex.ToString());
                return "-1";
            }
        }

        /// <summary>
        /// Method is used to help centralize and customize database error messages.
        /// </summary>
        /// <param name="errorMessage">errorMessage of type Exception</param>
        private void errorCheck(Exception errorMessage)
        {
            MessageBox.Show(errorMessage.ToString(), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// This method will allow you to retrieve a dataset containing the data from the executed query. 
        /// </summary>
        /// <param name="sqlComm">The SQL query you are using to retrieve the dataset</param>
        /// <param name="tableName">The specific table within the dataset.</param>
        /// <returns>DataSet containing the data from the executed query.</returns>
        public DataSet getDataSet(string sqlComm, string tableName)
        {
            try
            {
                CloseConnection();
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                conn.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(sqlComm, conn);
                DataSet ds = new DataSet();
                sqlda.Fill(ds, tableName);
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                errorCheck(ex);
                return null;
            }
        }
        /// <summary>
        /// Method used when executing an sql query that is retrieving aggregate data.
        /// </summary>
        /// <param name="sqlComm">SQL Aggregate Query</param>
        /// <param name="tableName">The specific table within the dataset.</param>
        /// <returns></returns>
        public string getAggDataString(string sqlComm, string tableName)
        {
            try
            {
                CloseConnection();
                conn.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(sqlComm, conn);
                DataSet ds = new DataSet();
                sqlda.Fill(ds, tableName);

                string dataString = ds.Tables[0].Rows[0][0].ToString();
                conn.Close();
                return dataString;
            }
            catch (Exception ex)
            {
                errorCheck(ex);
                return null;
            }
        }
        /// <summary>
        /// Closes the connection if it is open.
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                errorCheck(ex);
            }
        }
        /// <summary>
        /// This method allowed you to determine if an sql statement will return any rows.
        /// </summary>
        /// <param name="sqlStatement">SQL Query to use</param>
        /// <returns>True-if the query has at least one row and False-if the query returns no rows.</returns>
        public bool CheckForRows(string sqlStatement)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlStatement, conn);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception ex)
            {
                errorCheck(ex);
                return false;
            }
        }
        /// <summary>
        /// This method will allow you to determine how many rows will be returned from an sql query.
        /// </summary>
        /// <param name="sqlStatement">SQL Query to use</param>
        /// <returns>Number of rows in the query</returns>
        public int GetRows(string sqlStatement)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlStatement, conn);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                return Convert.ToInt32(reader[0].ToString());
            }
            catch (Exception ex)
            {
                errorCheck(ex);
                return -1;
            }
        }
    }
}
