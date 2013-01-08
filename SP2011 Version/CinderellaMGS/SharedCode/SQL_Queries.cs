using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

/// <summary>
/// 
/// </summary>
namespace CinderellaMGS
{
    ///-----------------------------------------------------------------
    ///   Namespace:      CinderellaMGS
    ///   Class:          SQL_Queries
    ///   Description:    Class to handle all database interaction.
    ///   Author:         Nathan  Horn                    Date: January 1, 2011
    ///   Notes:  This class should be used to build all queries. The exectuion of the completed query should be
    ///           done by passing the completed query to the DatabaseIO Class.
    /// 
    ///           Insert and update statemtents should be written in the form of a method
    ///           Select statements go in the switch statement located in the sqlSelect method.
    ///           each select statement will be denoted by a keyword        
    ///   Revision History:
    ///   Name:           Date:        Description:
    ///-----------------------------------------------------------------
    class SQL_Queries
    {
        private DatabaseIO database;
        public SQL_Queries()//Default Constructor
        {
            //Instantiate the database class
            database = new DatabaseIO();
        }
        /// <summary>
        /// Will execute a non-query sql statment.
        /// </summary>
        /// <param name="mysql">SQL statement to be executed.</param>
        /// <returns>Number of rows affected</returns>
        public int sqlStatment(string mysql)
        {
            return (database.ExecuteQuery(mysql));
        }
        /// <summary>
        /// Resets all godmothers back to a status of pending.
        /// </summary>
        public void endShift()//Sets all godmothers to a pending status
        {
            string sql = "INSERT INTO [FairyGodmotherTimestamp]([fairyGodmotherID], [timestamp], [status]) Select CONVERT(VARCHAR(50),FairyGodmotherTimestamp.fairyGodmotherID) , GetDate(), 'Pending' From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status <> 'Pending' Order By transID";
            database.ExecuteQuery(sql);
        }
        /// <summary>
        /// Method is used to determine if a shift can be started or ended. If a shift is started it can be ended but not started again.
        /// 
        /// EXAMPLE USAGE:
        /// if (sqlQuery.getShiftStartEnd(true)) \\shiftend
        ///    {
        ///        randomizeStartToolStripMenuItem1.Enabled = true;
        ///    }
        ///   else
        ///    {
        ///        randomizeStartToolStripMenuItem1.Enabled = false;
        ///    }
        ///    
        /// if (sqlQuery.getShiftStartEnd(false))//aka shiftEnd
        ///    {
        ///        endShiftToolStripMenuItem.Enabled = true;
        ///    }
        ///    else
        ///    {
        ///           endShiftToolStripMenuItem.Enabled = false;
        ///    }
        ///
        ///   if (sqlQuery.getShiftStartEnd(true) && sqlQuery.getShiftStartEnd(false))
        ///    {
        ///        //This is an initial launch of the program and both fields are blank
        ///        randomizeStartToolStripMenuItem1.Enabled = true;
        ///        endShiftToolStripMenuItem.Enabled = false;
        ///    }
        /// 
        /// </summary>
        /// <param name="shiftStart">True-shift start : False-shift end</param>
        /// <returns>True if button should be enabled and False if button should be disabled.</returns>
        public bool getShiftStartEnd(bool shiftStart)  
        {
            string sql = "";
            if (shiftStart)
            {
                sql = "Select [PropertyValue] From [ConfigSettings] WHERE [appProperty]='shiftStart'";
            }
            else
            {
                sql = "Select [PropertyValue] From [ConfigSettings] WHERE [appProperty]='shiftEnd'";
            }

            DataSet ds = database.getDataSet(sql, "tableName");
            string propertyValue = ds.Tables["tableName"].Rows[0]["propertyValue"].ToString();

            if (propertyValue == "" || propertyValue == null)
            {//If true then option can be selected
                return true;
            }
            else//The option cannot be selected
            {
                return false;
            }
        }
        /// <summary>
        /// Updates the time of either a shift start or shift end in the ConfigSettings table.
        /// </summary>
        /// <param name="shiftStart">True-set the shift start time :: False-Set the shift end time.</param>
        /// <param name="clear">True-Clear the value :: False-Set the value with the current datetime</param>
        public void setShiftStartEnd(bool shiftStart, bool clear)
        {
            if (shiftStart)
            {
                if (clear)
                {
                    database.ExecuteQuery("UPDATE [CinderellaMGS].[dbo].[ConfigSettings] SET [PropertyValue]='' WHERE [appProperty]='shiftStart'");
                }

                else
                {
                    database.ExecuteQuery("UPDATE [CinderellaMGS].[dbo].[ConfigSettings] SET [PropertyValue]=CONVERT(VARCHAR, getDate(), 109) WHERE [appProperty]='shiftStart'");
                }
            }
            else//shiftEnd
            {
                if (clear)
                {
                    database.ExecuteQuery("UPDATE [CinderellaMGS].[dbo].[ConfigSettings] SET [PropertyValue]='' WHERE [appProperty]='shiftEnd'");
                }

                else
                {
                    database.ExecuteQuery("UPDATE [CinderellaMGS].[dbo].[ConfigSettings] SET [PropertyValue]=CONVERT(VARCHAR, getDate(), 109) WHERE [appProperty]='shiftEnd'");
                }
            }
            
        }
        /// <summary>
        /// Method will retrieve settings from the database in the ConfigSettings table.
        /// </summary>
        /// <param name="appProperty">the appProperty key of the setting you are retreiving from the database</param>
        /// <returns>string of either the propertyValue if defined or the defaultPropertyValue if propertyvalue is no defined in database.</returns>
        public string getGlobalizedSettings(string appProperty)
        {
            string sql = "Select appProperty, propertyValue, defaultPropertyValue From ConfigSettings Where appProperty = '" + appProperty + "'";
            
            DataSet ds = database.getDataSet(sql, "tableName");
            string propertyValue = ds.Tables["tableName"].Rows[0]["propertyValue"].ToString();
            string defaultPropertyValue = ds.Tables["tableName"].Rows[0]["defaultPropertyValue"].ToString();

            if (propertyValue != null)
            {
                return propertyValue;
            }
            else
            {
                return defaultPropertyValue;
            }

        }
        /// <summary>
        /// Adds a new Godmother to the database. Since the godmother id's are automatically assigned this method will return their ID so that you can use that in the rest of the program logic like adding the godmother to shifts.
        /// </summary>
        /// <param name="fname">Godmothers First Name</param>
        /// <param name="lname">Godmothers Last Name</param>
        /// <returns>Godmothers ID Number</returns>
        public string NewGodMother(string fname, string lname)
        {
            string tempSQLa = "INSERT INTO FairyGodmother ([firstname], [lastname], [deleted]) ";
            string tempSQLb = "VALUES ('" + fname + "'" + ", " + "'" + lname + "'" + ", " + "0" + ")";
            string sql = tempSQLa + tempSQLb;
            database.ExecuteQuery(sql);

            //Now that we have added the godmother, what is their id?
            DataSet ds = sqlSelect("getlastGodMotherID");

            DataTable dt = ds.Tables["tableName"];
            //Return the freshly assigned id number.
            return dt.Rows[0][0].ToString(); 
        }
        /// <summary>
        /// Retrieves the current date and time from the database server.
        /// </summary>
        /// <returns>Current Date and Time From Database server</returns>
        public string getDate()
        {
            DataSet ds = sqlSelect("getDate");
            DataTable dt = ds.Tables["tableName"];
            
            return dt.Rows[0][0].ToString(); 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getMaxCinderellaID()
        {
            DataSet ds = sqlSelect("getlastCinderellaID");

            DataTable dt = ds.Tables["tableName"];
            return dt.Rows[0][0].ToString(); 
        }
        /// <summary>
        /// Inserts into the Cinderella Table the new Cinderella to be added
        /// </summary>
        /// <param name="id">Cinderellas given iD</param>
        /// <param name="fname">Cinderellas First Name</param>
        /// <param name="lname">Cinderellas Last Name</param>
        /// <param name="date">Cinderellas Appt Date</param>
        /// <param name="time">Cinderellas Appt Time</param>
        /// <param name="referral">The person who referred the Cinderella to the Program</param>
        /// <returns>NULL</returns>
        public string NewCinderella(string id, string fname, string lname, string date, string time, string referral)
        {
            string tempSQLa = "INSERT INTO Cinderella ([ID], [firstName], [lastName], [apptDate], [apptTime], [referralName], [certificateSent], [notes]) ";
            string tempSQLb = "VALUES ('"+id +"'" + "," + "'" + fname + "'" + ", " + "'" + lname + "'" + ", " + "'"  + date + "'"  +"," + "'" + time + "'" + "," + "'" + referral+ "'" + "," + "NULL" + "," + "NULL" +  ")";
            string sql = tempSQLa + tempSQLb;

            database.ExecuteQuery(sql);

            //return the godmother id
            DataSet ds = sqlSelect("getlastCinderellaID");

            DataTable dt = ds.Tables["tableName"];
            return dt.Rows[0][0].ToString(); 
        }
        /// <summary>
        /// Deletes a Godmother from the system. Actually this method just sets the delete flag since we don't actually want to delete the godmother from the database.
        /// </summary>
        /// <param name="godmotherID">Godmother ID to delete</param>
        public void DeleteGodMother(string godmotherID)//Remove Godmother - Set the delete flag
        {
            string tempSQLa = "UPDATE FairyGodmother SET deleted=1 WHERE ID=";
            string tempSQLb = godmotherID;
            string sql = tempSQLa + tempSQLb;

            database.ExecuteQuery(sql);
        }
        /// <summary>
        /// Adds a godmother to a shift.
        /// </summary>
        /// <param name="shift">Shift ID</param>
        /// <param name="ID">Godmother ID</param>
        public void AddGodmotherShift(string shift, string ID)
        {
            string tempSQLa = "INSERT INTO [CinderellaMGS].[dbo].[FairyGodmotherShift]([fairyGodmotherID], [shiftID]) VALUES(" + ID + ", " + shift + ")";
            //string tempSQLb = "";

            string sql = tempSQLa;
            database.ExecuteQuery(sql);
        }
        /// <summary>
        /// Retrieves a dataset of those who are currently shopping.
        /// </summary>
        /// <returns>DataSet of currently shopping</returns>
        public DataSet getCurrentlyShopping()
        {
            string sql = "Select FairyGodmother.lastName + ', ' + FairyGodmother.firstName + ' :: ' + Cinderella.lastName + ', ' + Cinderella.firstName as PairName  From CinderellaFGPairing INNER JOIN FairyGodmother ON CinderellaFGPairing.fairyGodmotherID = FairyGodmother.ID INNER JOIN Cinderella ON CinderellaFGPairing.cinderellaID=Cinderella.ID Where fairyGodmotherID IN (Select FairyGodmotherTimestamp.fairyGodmotherID From FairyGodmotherTimestamp,(Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, shiftID From FairyGodmotherShift) b, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and b.fairyGodmotherID = FairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status = 'Shopping')";
            return database.getDataSet(sql, "tableName");
        }
        /// <summary>
        /// Returns godmothers working a specific shift with a specific status.
        /// </summary>
        /// <param name="statustocheck">Status that you are checking for (ie. shopping, pending, etc)</param>
        /// <param name="orderby">How the data should be ordered (ie. lname)</param>
        /// <param name="shiftID">Id of the shift you are checking</param>
        /// <returns></returns>
        public DataSet getGodmotherStatusByShift(string statustocheck, string orderby, string shiftID)
        {
            string sql = "Select transID, FairyGodmotherTimestamp.fairyGodmotherID, n.Name, FairyGodmotherTimestamp.timestamp, FairyGodmotherTimestamp.status, b.shiftID From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, shiftID From FairyGodmotherShift) b, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and b.fairyGodmotherID = FairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status = '";
            sql += statustocheck + "' and b.shiftID =" + shiftID + " Order By " + orderby;
            
            return database.getDataSet(sql, "tableName");
        }
        /// <summary>
        /// Retreives all godmothers of the status specified.
        /// </summary>
        /// <param name="statustocheck">Status that you are checking for (ie. shopping, pending, etc)</param>
        /// <param name="orderby">How the data should be ordered (ie. lname)</param>
        /// <param name="filterToday">True-Only those for the current day :: False-for everyone with the specific status.</param>
        /// <returns></returns>
        public DataSet getGodmotherStatus(string statustocheck, string orderby, bool filterToday)
        {
            if (filterToday)
            {
                //What is todays date?? any takers??
                string today = GlobalVar.getDate();
                string query = "Select transID, FairyGodmotherTimestamp.fairyGodmotherID, n.Name, FairyGodmotherTimestamp.timestamp, FairyGodmotherTimestamp.status From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status='";
                query += statustocheck + "'";
                query += "and fairyGodmotherTimestamp.fairyGodmotherID IN (";
                query += "Select FairyGodmotherShift.fairyGodmotherID  From FairyGodmotherShift INNER JOIN AvailableFGShift ON FairyGodmotherShift.shiftID = AvailableFGShift.shiftID Where (DATEDIFF(day, '" + today + "', AvailableFGShift.shiftStart)=0) and (DATEDIFF(hour, '" + today + "', AvailableFGShift.shiftStart) <2))";// and (DATEDIFF(day, '" + today + "', AvailableFGShift.shiftStart) >0))";

                query += " Order By " + orderby;//transID";

                return database.getDataSet(query, "tableName");
            }
            else
            {
                string query = "Select transID, FairyGodmotherTimestamp.fairyGodmotherID, n.Name, FairyGodmotherTimestamp.timestamp, FairyGodmotherTimestamp.status From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status='";
                query += statustocheck + "' Order By "+ orderby; //transID";

                return database.getDataSet(query, "tableName");
            }
        }
        /// <summary>
        /// Retrieves all cinderellas with the current specified status.
        /// </summary>
        /// <param name="statustocheck">Status that you are checking for (ie. shopping, pending, etc)</param>
        /// <param name="orderby">How the data should be ordered (ie. lname)</param>
        /// <returns>All Cinderellas that have the status given and ordered by the orderby variable</returns>
        public DataSet getCinderellaStatus(string statustocheck, string orderby)
        {
            string time = DateTime.Now.ToShortDateString();
            string query = "SELECT transID, CinderellaTimestamp.cinderellaID, n.Name, CinderellaTimestamp.timestamp, CinderellaTimestamp.status, n.apptDate, n.apptTime FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME, apptDate, apptTime FROM Cinderella) n, (SELECT cinderellaID, MAX(TIMESTAMP) AS TIMESTAMP FROM CinderellaTimestamp GROUP BY cinderellaID) a WHERE a.cinderellaID= cinderellaTimestamp.cinderellaID AND a.timestamp= cinderellaTimestamp.timestamp AND n.ID= cinderellaTimestamp.cinderellaID AND cinderellaTimestamp.status='";
            query += statustocheck + "' Order By " + orderby;

            return database.getDataSet(query, "tableName");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isShopping"></param>
        /// <param name="isDoneShopping"></param>
        /// <param name="isCheckedOut"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public DataSet getCinderellas(bool isShopping, bool isDoneShopping, bool isCheckedOut, string orderby)
        {
            //this is for checkout, so that i can pull data separately based on which statuses are desired            
            if (isShopping == false && isDoneShopping == false && isCheckedOut == false)
            {
                return null;
            }
            else
            {

                string query = "SELECT DISTINCT CinderellaTimestamp.transID, Cinderella.ID, Cinderella.firstName, Cinderella.lastName, CN.NAME, FairyGodmother.ID, FGM.fgID, FairyGodmother.firstName, FairyGodmother.lastName, FGLastN.fgLastName, FGFirstN.fgFirstName, CinderellaTimestamp.status, Package.cinderellaID, Package.shoeSize, Package.dressSize, Package.dressAltered, Package.whenAvailable FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM Cinderella) CN, (SELECT ID, lastName AS fgLastName FROM FairyGodmother) FGLastN, (SELECT ID, firstName AS fgFirstName FROM FairyGodmother) FGFirstN, (SELECT ID AS fgID FROM FairyGodmother) FGM, Cinderella JOIN CinderellaFGPairing ON Cinderella.ID=CinderellaFGPairing.cinderellaID JOIN FairyGodmother ON FairyGodmother.ID=CinderellaFGPairing.fairyGodmotherID LEFT OUTER JOIN Package ON CinderellaFGPairing.cinderellaID=Package.cinderellaID WHERE CN.ID=CinderellaTimestamp.cinderellaID AND FGFirstN.ID=FairyGodmother.ID AND FGLastN.ID=FairyGodmother.ID AND FGM.fgID =FairyGodmother.ID AND transID IN (SELECT MAX(transID) FROM CinderellaTimestamp WHERE CN.ID = CinderellaTimestamp.cinderellaID) AND Cinderella.ID=CinderellaTimestamp.cinderellaID AND (";
                
                if (isShopping == true)
                {
                    query += "cinderellaTimestamp.status='Shopping'";

                    if (isDoneShopping == false && isCheckedOut == false)
                    {
                        query += ")";
                    }
                }
                if (isDoneShopping == true)
                {
                    if (isShopping == false)
                    {
                        query += "cinderellaTimestamp.status='Done Shopping'";
                    }
                    else
                    {
                        query += " OR cinderellaTimestamp.status='Done Shopping'";
                    }
                    if (isCheckedOut == false)
                    {
                        query += ")";
                    }
                }
                if (isCheckedOut == true)
                {
                    if (isShopping == false && isDoneShopping == false)
                    {
                        query += "cinderellaTimestamp.status='Checked-Out')";
                    }
                    else
                    {
                        query += " OR cinderellaTimestamp.status='Checked-Out')";
                    }
                }
                
                query += " ORDER BY " + orderby;
                return database.getDataSet(query, "tableName");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isShopping"></param>
        /// <param name="isDoneShopping"></param>
        /// <param name="isCheckedOut"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public DataSet getNotes(bool isShopping, bool isDoneShopping, bool isCheckedOut, string orderby)
        {
            //this is for checkout, so that i can pull data separately based on which statuses are desired            
            if (isShopping == false && isDoneShopping == false && isCheckedOut == false)
            {
                return null;
            }
            else
            {

                string query = "SELECT Package.checkoutNotes FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM Cinderella) CN, (SELECT ID, lastName + ', ' + firstName AS fgname FROM FairyGodmother) FGN, Cinderella JOIN CinderellaFGPairing ON Cinderella.ID=CinderellaFGPairing.cinderellaID JOIN FairyGodmother ON FairyGodmother.ID=CinderellaFGPairing.fairyGodmotherID LEFT OUTER JOIN Package ON CinderellaFGPairing.cinderellaID=Package.cinderellaID WHERE CN.ID=CinderellaTimestamp.cinderellaID AND FGN.ID=FairyGodmother.ID AND transID IN (SELECT MAX(transID) FROM CinderellaTimestamp WHERE CN.ID = CinderellaTimestamp.cinderellaID) AND Cinderella.ID=CinderellaTimestamp.cinderellaID AND (";

                if (isShopping == true)
                {
                    query += "cinderellaTimestamp.status='Shopping'";

                    if (isDoneShopping == false && isCheckedOut == false)
                    {
                        query += ")";
                    }
                }
                if (isDoneShopping == true)
                {
                    if (isShopping == false)
                    {
                        query += "cinderellaTimestamp.status='Done Shopping'";
                    }
                    else
                    {
                        query += " OR cinderellaTimestamp.status='Done Shopping'";
                    }
                    if (isCheckedOut == false)
                    {
                        query += ")";
                    }
                }
                if (isCheckedOut == true)
                {
                    if (isShopping == false && isDoneShopping == false)
                    {
                        query += "cinderellaTimestamp.status='Checked-Out')";
                    }
                    else
                    {
                        query += " OR cinderellaTimestamp.status='Checked-Out')";
                    }
                }

                query += " ORDER BY " + orderby;
                return database.getDataSet(query, "tableName");
            }
        }
        /// <summary>
        /// Retrieves all of the current stats for the system.
        /// </summary>
        /// <returns>A string containing all of the current stats.</returns>
        public string getStats()//Gather and return some general stats
        {
            //Total Number of Godmothers
            string totalGodmothersSQL = "Select count(*) From FairyGodmother";
            string totalGodmothersData = database.getAggDataString(totalGodmothersSQL, "tableName");

            //Godmothers available
            string totalGodmothersAvailableSQL = "Select count(*) From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status='Available'";
            string totalGodmothersAvailableData = database.getAggDataString(totalGodmothersAvailableSQL, "tableName");

            //Godmothers pending
            string totalGodmothersPendingSQL = "Select count(*) From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status='Pending'";
            string totalGodmothersPendingData = database.getAggDataString(totalGodmothersPendingSQL, "tableName");

            //Godmothers paired
            string totalGodmothersPairedSQL = "Select count(*) From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status='Paired'";
            string totalGodmothersPairedData = database.getAggDataString(totalGodmothersPairedSQL, "tableName");

            //Godmothers shopping
            string totalGodmothersShoppingSQL = "Select count(*) From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status='Shopping'";
            string totalGodmothersShoppingData = database.getAggDataString(totalGodmothersShoppingSQL, "tableName");

            //Godmothers Unavailable
            string totalGodmothersUnavailableSQL = "Select count(*) From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status='Unavailable'";
            string totalGodmothersUnavailableData = database.getAggDataString(totalGodmothersUnavailableSQL, "tableName");

            //Total Number of Cinderellas
            string totalCinderellasSQL = "Select count(*) From Cinderella";
            string totalCinderellasData = database.getAggDataString(totalCinderellasSQL, "tableName");

            //Cinderellas pending
            string totalCinderellasPendingSQL = "SELECT count(*) FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM Cinderella) n, (SELECT cinderellaID, MAX(TIMESTAMP) AS TIMESTAMP FROM CinderellaTimestamp GROUP BY cinderellaID) a WHERE a.cinderellaID= cinderellaTimestamp.cinderellaID AND a.timestamp= cinderellaTimestamp.timestamp AND n.ID= cinderellaTimestamp.cinderellaID AND cinderellaTimestamp.status='Pending'";
            string totalCinderellasPendingData = database.getAggDataString(totalCinderellasPendingSQL, "tableName");
                
            //Cimderellas Waiting
            string totalCinderellasWaitingSQL = "SELECT count(*) FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM Cinderella) n, (SELECT cinderellaID, MAX(TIMESTAMP) AS TIMESTAMP FROM CinderellaTimestamp GROUP BY cinderellaID) a WHERE a.cinderellaID= cinderellaTimestamp.cinderellaID AND a.timestamp= cinderellaTimestamp.timestamp AND n.ID= cinderellaTimestamp.cinderellaID AND cinderellaTimestamp.status='Waiting'";
            string totalCinderellasWaitingData = database.getAggDataString(totalCinderellasWaitingSQL, "tableName");

            //Cinderellas Paired
            string totalCinderellasPairedSQL = "SELECT count(*) FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM Cinderella) n, (SELECT cinderellaID, MAX(TIMESTAMP) AS TIMESTAMP FROM CinderellaTimestamp GROUP BY cinderellaID) a WHERE a.cinderellaID= cinderellaTimestamp.cinderellaID AND a.timestamp= cinderellaTimestamp.timestamp AND n.ID= cinderellaTimestamp.cinderellaID AND cinderellaTimestamp.status='Paired'";
            string totalCinderellasPairedData = database.getAggDataString(totalCinderellasPairedSQL, "tableName");

            //Cinderellas Shopping
            string totalCinderellasShoppingSQL = "SELECT count(*) FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM Cinderella) n, (SELECT cinderellaID, MAX(TIMESTAMP) AS TIMESTAMP FROM CinderellaTimestamp GROUP BY cinderellaID) a WHERE a.cinderellaID= cinderellaTimestamp.cinderellaID AND a.timestamp= cinderellaTimestamp.timestamp AND n.ID= cinderellaTimestamp.cinderellaID AND cinderellaTimestamp.status='Shopping'";
            string totalCinderellasShoppingData = database.getAggDataString(totalCinderellasShoppingSQL, "tableName");

            //Cinderellas Checked-Out
            string totalCinderellasCheckoutSQL = "SELECT count(*) FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM Cinderella) n, (SELECT cinderellaID, MAX(TIMESTAMP) AS TIMESTAMP FROM CinderellaTimestamp GROUP BY cinderellaID) a WHERE a.cinderellaID= cinderellaTimestamp.cinderellaID AND a.timestamp= cinderellaTimestamp.timestamp AND n.ID= cinderellaTimestamp.cinderellaID AND cinderellaTimestamp.status='Checked-Out'";
            string totalCinderellasCheckoutData = database.getAggDataString(totalCinderellasCheckoutSQL, "tableName");

            //Cinderella Average Shopping Time
            string totalCinderellasAverageShoppingSQL = "";
            string totalCinderellasAverageShoppingData = "";//"Need to write this Query";//database.getAggDataString(totalCinderellasAverageShoppingSQL, "tableName");


            return DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToShortTimeString() + "      " + "\r\n" + "\r\n" + "\r\n" +
            "GODMOTHER'S" + "\r\n" +
            "Total: " + totalGodmothersData + "\r\n" +
            "Pending: " + totalGodmothersPendingData + "\r\n" + 
            "Available: " + totalGodmothersAvailableData + "\r\n" +
            "Paired: " + totalGodmothersPairedData + "\r\n" +
            "Shopping: " + totalGodmothersShoppingData + "\r\n" +
            "Unavailable: " + totalGodmothersUnavailableData + "\r\n" + "\r\n" +
            "CINDERELLA'S" + "\r\n" +
            "Total: " + totalCinderellasData + "\r\n" +
            "Pendng: " + totalCinderellasPendingData + "\r\n" +
            "Waiting: " + totalCinderellasWaitingData + "\r\n" +
            "Paired: " + totalCinderellasPairedData + "\r\n" +
            "Shopping: " + totalCinderellasShoppingData + "\r\n" + 
            "Checked Out: " + totalCinderellasCheckoutData + "\r\n" + "\r\n";// +
            //"Average Shopping Time: " + totalCinderellasAverageShoppingData;
        }
        /// <summary>
        /// Pairs a godmother and Cinderella.
        /// </summary>
        /// <param name="godmotherID">ID of the Godmother</param>
        /// <param name="cinderellaID">ID of the Cinderella</param>
        public void setPairing(string godmotherID, string cinderellaID)
        {
            string query = "INSERT INTO [CinderellaFGPairing]([cinderellaID], [fairyGodmotherID]) VALUES(";
            query += cinderellaID + "," + godmotherID + ")";

            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Sets the status of a cinderella or godmother.
        /// </summary>
        /// <param name="ID">Id of the Cinderella or Godmother</param>
        /// <param name="status">Status that you would like to set.</param>
        /// <param name="cinderella">true-set the status of a cinderella :: false-set the status of a godmother</param>
        /// <param name="importRunning">true-if the import is currently running.</param>
        public void setStatus(string ID, string status, bool cinderella, bool importRunning)
        {
            string query = "";

            if (cinderella)
            {//Set status of cinderella
                query = "INSERT INTO [CinderellaTimestamp]([cinderellaID], [timestamp], [status]) VALUES(";
            }
            else
            {//Set status of godmother
                query = "INSERT INTO [FairyGodmotherTimestamp]([fairyGodmotherID], [timestamp], [status]) VALUES(";
            }

            //Lets finish our statement!
            query += ID + ", GetDate(),'" + status + "')";

            //Execute our lovely query!
            database.ExecuteQuery(query);

            //check if this is an import if its an import wait untill it is finished to run this
            //NH: Matchmaker will only be run from a single form now
            /*if (importRunning == false)
            {
                //Run MatchMaker!
                MatchMakerProcess();
            }*/
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dressSize"></param>
        /// <param name="shoeSize"></param>
        /// <param name="altered"></param>
        /// <param name="notes"></param>
        /// <param name="time"></param>
        /// <param name="Fname"></param>
        /// <param name="Lname"></param>
        public void setCinderellaDetails(string ID, string dressSize, string shoeSize, int altered, string notes, string time, string Fname, string Lname)
        {
            string query, query1;
            query = "IF EXISTS (SELECT * FROM Package WHERE cinderellaID=" + ID + ") UPDATE Package SET dressSize=" + dressSize + ", shoeSize=" + shoeSize + ", dressAltered=" + altered + ", checkoutNotes='" + notes + "', whenAvailable='" + time + "' WHERE cinderellaID=" + ID + " ELSE INSERT INTO Package VALUES (" + ID + ", " + dressSize +", " + shoeSize + ", " + altered + ", '" + notes + "', '" + time + "')";
            query1 = "IF EXISTS (SELECT * FROM Cinderella WHERE ID=" + ID + ") UPDATE Cinderella SET firstName='" + Fname + "', lastName='" + Lname + "' WHERE ID=" + ID;
            database.ExecuteQuery(query);
            database.ExecuteQuery(query1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Fname"></param>
        /// <param name="Lname"></param>
        public void setGodmotherDetails(string ID, string Fname, string Lname)
        {
            string query;
            query = "IF EXISTS (SELECT * FROM FairyGodmother WHERE ID=" + ID + ") UPDATE FairyGodmother SET firstName='" + Fname + "', lastName='" + Lname + "' WHERE ID=" + ID;

            database.ExecuteQuery(query);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cinderellaID"></param>
        /// <param name="godmotherID"></param>
        public void insertPair(string cinderellaID, string godmotherID)
        {
            string query = "INSERT INTO [CinderellaFGPairing]([cinderellaID], [fairyGodmotherID]) VALUES(";
            query += cinderellaID + ", " + godmotherID + ")";

            database.ExecuteQuery(query);
        }
        /// <summary>
        /// This method houses all of the basic "Select" statements.
        /// </summary>
        /// <param name="keyword">Keyword identifying the select statment in the switch.</param>
        /// <returns>A DataSet of the </returns>
        public DataSet  sqlSelect(string keyword)
        {
            string query = "";
            switch (keyword)
            {
                    //select all godmother ids and names
                case "getGodmothers":
                    query = "Select ID,lastname + ', ' + firstname AS Name From FairyGodmother Where deleted =0";
                    break;
                    //select all cinderella ids and names
                case "getCinderellas":
                    query = "Select ID,lastname + ', ' + firstname AS Name From Cinderella";
                    break;
                case "getRandomGodmotherList":
                    query = "Select FairyGodmotherTimestamp.fairyGodmotherID From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status='Available' Order By FairyGodmotherTimestamp.transID";
                    break;
                case "getWaitingFairyGodmothersID":
                    query = "SELECT FairyGodmotherTimestamp.fairyGodmotherID, n.name FROM FairyGodmotherTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM FairyGodmother) n, (SELECT fairyGodmotherID, MAX(TIMESTAMP) AS TIMESTAMP FROM FairyGodmotherTimestamp GROUP BY fairyGodmotherID) a WHERE a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID AND a.timestamp= FairyGodmotherTimestamp.timestamp AND n.ID= FairyGodmotherTimestamp.fairyGodmotherID AND FairyGodmotherTimestamp.status='Available'";
                    break;
                case "getWaitingCinderellasID":
                    query = "SELECT CinderellaTimestamp.cinderellaID, n.name FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM Cinderella) n, (SELECT cinderellaID, MAX(TIMESTAMP) AS TIMESTAMP FROM CinderellaTimestamp GROUP BY cinderellaID) a WHERE a.cinderellaID= cinderellaTimestamp.cinderellaID AND a.timestamp= cinderellaTimestamp.timestamp AND n.ID= cinderellaTimestamp.cinderellaID AND cinderellaTimestamp.status='waiting'";
                    break;
                    //selects all the cinderella's statuses
                case "getCinderellaStatuses":
                    query = "Select statusName, statusTxt From CinderellaStatus";
                    break;
                case "getGodmotherStatuses":
                    query = "Select statusName, statusTxt From FairyGodmotherStatus";
                    break;
                case "getShifts":
                    query = "Select (CONVERT(varchar,shiftStart,100) + ' -' +  SUBSTRING(CONVERT(varchar, shiftEnd, 100), 13, 2) + ':' + SUBSTRING(CONVERT(varchar, shiftEnd, 100), 16, 2) + ''+ SUBSTRING(CONVERT(varchar, shiftEnd, 100), 18, 2)) as shiftTime, shiftID From AvailableFGShift";
                    //Need to only pull shift where date > than yesterday
                    //string where = "Where shiftDate > CAST(DateAdd(day, -1, getdate()) AS DATE";
                    //query += where;
                    break;
                case "getlastGodMotherID":
                    query = "Select MAX(ID) FROM FairyGodmother";
                    break;
                case "getCinderellaDetails":
                    query = "SELECT Cinderella.firstName, Cinderella.lastName, CinderellaTimestamp.status, Package.dressSize, Package.shoeSize, Package.dressAltered, Package.checkoutNotes FROM Cinderella, Package, FairyGodmother, CinderellaFGPairing, CinderellaTimestamp WHERE	Cinderella.ID = Package.cinderellaID AND Cinderella.ID = CinderellaFGPairing.cinderellaID AND Cinderella.ID = CinderellaTimestamp.cinderellaID AND FairyGodmother.ID = CinderellaFGPairing.fairyGodmotherID AND (CinderellaTimestamp.status = 'Shopping' OR CinderellaTimestamp.status = 'Done Shopping' OR CinderellaTimestamp.status = 'Checked-Out')";
                    break;
                case "getFairyGodmotherDetails":
                    query = "SELECT FairyGodmother.firstName, FairyGodmother.lastName FROM Cinderella, FairyGodmother, CinderellaFGPairing, CinderellaTimestamp WHERE Cinderella.ID = CinderellaFGPairing.cinderellaID AND Cinderella.ID = CinderellaTimestamp.cinderellaID AND FairyGodmother.ID = CinderellaFGPairing.fairyGodmotherID AND CinderellaTimestamp.status = 'Shopping'";
                    break;
                case "exportData":
                        query = "Select * From Package";
                        break;
                    //gets the maxID from the Cinderella Table
                case "getlastCinderellaID":
                        query = "SELECT MAX(ID) AS ID FROM CinderellaMGS.dbo.Cinderella";
                        
                        break;
                case "getDate":
                    query = "Select GetDate() as 'Current Date'";
                    break;
            }
            //Do not touch the code below this!
            return database.getDataSet(query, "tableName");
        }

        /// <summary>
        /// MatchMaker Process begins here!
        /// 
        /// This Process is what currently will match
        /// cinderellas and fairygodmothers and 
        /// also change ther statuses to the appropriate
        /// setting.
        /// 
        /// It is only called in the server form
        /// </summary>   
        public void MatchMakerProcess()
        {
            if (GlobalVar.masterPairSwitch == true)
            {
                //List for available godmothers
                List<int> gML = new List<int>();
                //List for Waiting Cinderellas
                List<int> cL = new List<int>();
                //
                //get godmother ids
                //Forms a dataset called gmds from the data from the sql statement getGodmotherStatus
                //It requires first a status then what its ordering by and finally a bool value 
                //to see if filtering by day
                DataSet gmds = getGodmotherStatus("Available", "transID", false);
                //a loop to loop through the rows of the dataset gmds
                foreach (DataRow dr in gmds.Tables[0].Rows)
                {
                    //This will add the fairyGodmotherID at the current row of the dataset gmds
                    //to the list gML
                    gML.Add(int.Parse(dr["fairyGodmotherID"].ToString()));
                }
                //get cinderella ids
                //Forms a dataset called cds from the data from the sql statement getCinderellaStatus
                //It requires first a status then what its ordering by 
                DataSet cds = getCinderellaStatus("Waiting", "transID");
                //a loop to loop through the rows of the dataset cds
                foreach (DataRow dr in cds.Tables[0].Rows)
                {
                    //This will add the cinderellaID at the current row of the dataset cds
                    //to the list cL
                    cL.Add(int.Parse(dr["cinderellaID"].ToString()));
                }
                //check match
                //create two int to track pairing of the two lists
                //gML and cL
                //tracks pairs through loop
                int numOfPairsCount = 0;
                //sets limit to smallest list
                int countBackPairs = 0;
                //find smalliest list between gML and cL
                //first look to see if cL is the shortest of the two lists
                if (gML.Count > cL.Count)
                {
                    //if cL is the shortest then set countBackPairs to its item count
                    countBackPairs = cL.Count;
                }
                else
                {
                    //if cL is not the shortest list then
                    //set countBackPairs equal to gML item count
                    countBackPairs = gML.Count;
                }
                //set pairings in db
                //This while loop will happen as long as gML and cL have counts greater then 0
                while (gML.Count > 0 && cL.Count > 0)
                {
                    //only enters this if statement when countBackPairs is greater then numOfPairsCount
                    if (countBackPairs > numOfPairsCount)
                    {
                        //temps
                        //holds the current gmID
                        string gmidTemp;
                        //holds the current cID
                        string cidTemp;
                        //takes the ID from list gML at pisition numOfPairsCount and adds to temp
                        gmidTemp = gML[numOfPairsCount].ToString();
                        //takes the ID from list cL at pisition numOfPairsCount and adds to temp
                        cidTemp = cL[numOfPairsCount].ToString();
                        //
                        //set paired status
                        //Uses the method setStatus to insert the updated status of
                        //godmother with the id in the gmidtemp
                        setStatus(gmidTemp, "Paired", false, true);
                        //Uses the method setStatus to insert the updated status of
                        //cinderella with the id in the cidtemp
                        setStatus(cidTemp, "Paired", true, true);
                        //add pairings to paired table 
                        setPairing(gmidTemp, cidTemp);
                        //increment count of pairs
                        numOfPairsCount++;
                    }
                    else
                    {
                        //when countBackPairs is no longer greater then numOfPairsCount then break the loop
                        break;
                    }
                }
            }//end match maker
        }
    }  
}
