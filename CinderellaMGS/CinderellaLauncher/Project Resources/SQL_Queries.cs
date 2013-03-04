using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
//using System.Windows.Forms;

/// <summary>
/// 
/// </summary>
namespace CinderellaLauncher
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
    public class SQL_Queries
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
 /*       public void endShift()//Sets all godmothers to a pending status
        {
            string sql = "INSERT INTO [FairyGodmotherTimestamp]([fairyGodmotherID], [timestamp], [status]) Select CONVERT(VARCHAR(50),FairyGodmotherTimestamp.fairyGodmotherID) , GetDate(), 'Pending' 
                          From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmother) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a 
                          Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.status <> 'Pending' Order By transID";
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
        */
        
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
        /// Retrieves a dataset of those who are currently shopping.
        /// </summary>
        /// <returns>DataSet of currently shopping</returns>
        public DataSet getCurrentlyShopping()
        {
            string sql = "SELECT     Cinderellas.firstName AS 'CindFirstName', Cinderellas.lastName AS 'CindLastName', FairyGodmothers.firstName AS 'FGFirstName', FairyGodmothers.lastName AS 'FGLastName' FROM FairyGodmothers INNER JOIN Cinderellas ON FairyGodmothers.id = Cinderellas.fairyGodmotherID AND FairyGodmothers.id = Cinderellas.fairyGodmotherID WHERE (Cinderellas.currentStatus = 4)";
            return database.getDataSet(sql, "tableName");
        }/*
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
               
        //Information from here is also used in the CheckOut.cs Quick Search Bar.
        *//// <summary>
        /// This method houses all of the basic "Select" statements.
        /// </summary>
        /// <param name="keyword">Keyword identifying the select statment in the switch.</param>
        /// <returns>A DataSet of the </returns>
        public DataSet sqlSelect(string keyword)
        {
            string query = "";
            switch (keyword)
            {

                //select all godmother ids and names
                case "getGodmothers":
                    query = "SELECT ID,lastname + ', ' + firstname AS Name FROM FairyGodmothers";
                    break;
                //select all cinderella ids and names
                case "getCinderellas":
                    query = "SELECT ID,lastname + ', ' + firstname AS Name From Cinderellas";
                    break;
                case "getRandomGodmotherList":
                    query = "SELECT FairyGodmotherTimestamp.fairyGodmotherID From FairyGodmotherTimestamp, (Select ID, lastname + ', ' + firstname AS Name FROM FairyGodmothers) n, (Select fairyGodmotherID, max(timestamp) as TimeStamp FROM FairyGodmotherTimestamp Group BY fairyGodmotherID) a Where a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID and a.timestamp= FairyGodmotherTimestamp.timestamp and n.ID= fairyGodmotherTimestamp.fairyGodmotherID and FairyGodmotherTimestamp.statusid=1 Order By FairyGodmotherTimestamp.transID";
                    break;
                case "getWaitingFairyGodmothersID":
                    query = "SELECT FairyGodmotherTimestamp.fairyGodmotherID, n.name FROM FairyGodmotherTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM FairyGodmothers) n, (SELECT fairyGodmotherID, MAX(TIMESTAMP) AS TIMESTAMP FROM FairyGodmotherTimestamp GROUP BY fairyGodmotherID) a WHERE a.fairyGodmotherID= FairyGodmotherTimestamp.fairyGodmotherID AND a.timestamp= FairyGodmotherTimestamp.timestamp AND n.ID= FairyGodmotherTimestamp.fairyGodmotherID AND FairyGodmotherTimestamp.statusid=1";
                    break;
                case "getWaitingCinderellasID":
                    query = "SELECT CinderellaTimestamp.cinderellaID, n.name FROM CinderellaTimestamp, (SELECT ID, lastname + ', ' + firstname AS NAME FROM Cinderellas) n, (SELECT cinderellaID, MAX(TIMESTAMP) AS TIMESTAMP FROM CinderellaTimestamp GROUP BY cinderellaID) a WHERE a.cinderellaID= cinderellaTimestamp.cinderellaID AND a.timestamp= cinderellaTimestamp.timestamp AND n.ID= cinderellaTimestamp.cinderellaID AND cinderellaTimestamp.statusid=2";
                    break;
                //selects all the cinderella's statuses
                /* case "getCinderellaStatuses":
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
                    break; */
                case "getlastGodMotherID":
                    query = "SELECT MAX(id) FROM FairyGodmothers";
                    break;
                case "getCinderellaDetails":
                    query = "SELECT Cinderellas.firstName, Cinderellas.lastName, CinderellaTimestamp.statusID, Package.dressSize, Package.dressColor, Package.shoeSize, Package.shoeColor, Package.whenAvailable, Package.jewelry, Package.checkoutNotes FROM Cinderellas, Package, FairyGodmothers, CinderellaTimestamp WHERE	Cinderellas.ID = Package.cinderellaID AND  Cinderellas.ID = CinderellaTimestamp.cinderellaID AND FairyGodmothers.ID = Cinderellas.fairyGodmotherID AND (CinderellaTimestamp.statusID = 4 OR CinderellaTimestamp.statusID = 5 OR CinderellaTimestamp.statusID = 7 OR CinderellaTimestamp.statusID = 6)";
                    break;
                case "getFairyGodmotherDetails":
                    query = "SELECT FairyGodmothers.firstName, FairyGodmothers.lastName FROM Cinderellas, FairyGodmothers, CinderellaTimestamp WHERE Cinderellas.ID = CinderellaTimestamp.cinderellaID AND FairyGodmothers.ID = Cinderellas.fairyGodmotherID AND CinderellaTimestamp.statusid = 4";
                    break;
                case "exportData":
                    query = "SELECT * From Package";
                    break;
                //gets the maxID from the Cinderella Table
                case "getlastCinderellaID":
                    query = "SELECT MAX(ID) AS ID FROM CinderellaMGS.dbo.Cinderella";

                    break;
                case "getDate":
                    query = "SELECT GetDate() as 'Current Date'";
                    break;
            }
            //Do not touch the code below this!
            return database.getDataSet(query, "tableName");
        }
       
        public DataSet cinderellaCheckIn()
        {
            string query = "";

            //SELECT Cinderella firstname,last name, appointment date and time, organization, and notes.
            query = "SELECT Cinderellas.firstName, Cinderellas.lastName, Cinderellas.apptDate, Cinderellas.apptTime, Referrals.organization, Cinderellas.notes FROM Cinderellas, Referrals WHERE Cinderellas.approved = 1 AND Cinderellas.referralID = Referrals.id";

            return database.getDataSet(query, "tableName");
        }
        public string fairyGodmotherCheckIn()
        {
            string query = "";

            query = "SELECT FairyGodmothers.id, FairyGodmothers.firstName, FairyGodmothers.lastName, FairyGodmothers.emailAddress, FairyGodmothers.phoneNumber, FairyGodmothers.city, FairyGodmothers.state, FairyGodmothers.zip, FairyGodmothers.address " +
                    "FROM FairyGodmothers, FairyGodmotherTimestamp " +
                    "WHERE FairyGodmothers.id = FairyGodmotherTimestamp.fairyGodmotherID AND FairyGodmotherTimestamp.statusID = 1";

            return query;
        }

        

        


      

        

        /*public string checkOutList()
        {
            string query = "Select Cinderellas.id,Cinderellas.firstName AS 'First Name',Cinderellas.lastName AS 'Last Name', Referrals.organization AS 'Organization' " +
                        "FROM Cinderellas INNER JOIN CinderellaStatus ON Cinderellas.currentStatus = CinderellaStatus.statusID INNER JOIN Referrals ON Referrals.id = Cinderellas.referralID " +
                        "WHERE CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations'" +
                        "ORDER BY Cinderellas.apptDate, Cinderellas.apptTime ";

            return query;
        }*/

        
        
        // <-----------MIKE-ADDED QUERIES
        // Testin' some stuffs. Feel free to re-write, delete, whatever.


        
        //gets the cinderella that is matched to the passed god mother
        
        //sets a cinderella to be unpaired
        public void clearCinderellaFairyGodmotherID(int id)
        {
            string query = "UPDATE Cinderellas SET fairyGodmotherID = NULL WHERE id = " + id.ToString();
            database.ExecuteQuery(query);
        }
        
        

        

       

        public string getDressInfo(string id)
        {
            string query = "SELECT Package.dressColor, Package.dressSize " +
                           "FROM Package " +
                           "WHERE cinderellaID = " + id;
            return query;
        }


        

       


        // END MIKE ADDED QUERIES -------------------->

        public string fglistSearch(string fname, string lname)
        {
            string query = "SELECT id, firstName AS 'First Name', lastName AS 'Last Name', city AS 'City', state AS 'State' " +
                           "FROM FairyGodmothers WHERE FairyGodmothers.firstName LIKE '" + fname + "%' AND FairyGodmothers.lastName LIKE '" + lname + "%' AND FairyGodmothers.currentStatus = 1 ORDER BY lastName,firstName";
            /*           if (fname != null && fname != "")
                       {
                           if (lname != null && lname != "")
                           {
                               query += "WHERE FairyGodmothers.firstName LIKE '" + fname + "%' AND FairyGodmothers.lastName LIKE '" + lname + "%'";
                           }
                           else
                           {
                               query += "WHERE FairyGodmothers.firstName LIKE '" + fname + "%'";
                           }
                       }
                       else
                       {
                           if (lname != null && lname != "")
                           {
                               query += "WHERE FairyGodmothers.lastName LIKE '" + lname + "%'";
                           }
                           else
                           {
                                //Add nothing
                           }
                       }
             * query += " ORDER BY lastName,firstName";
           */
            return query;               
        }

       

        
        

        

        public string showFairyGodmothers(int shift, int status)
        {
            string query = "SELECT FairyGodmothers.firstName AS 'First Name', FairyGodmothers.lastName AS 'Last Name' " +
                           "FROM FairyGodmothers, Shifts, FairyGodmotherTimestamp " +
                           "WHERE FairyGodmothers.id = FairyGodmotherTimestamp.fairyGodmotherID AND Shifts.shiftID = " + shift + " AND FairyGodmotherTimestamp.statusID = "+status;
            return query;
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void checkOutUpdate(int cinderellaID, int dressSize, string dressColor)
        {
            string exQuery = "";
            string query = "UPDATE Package SET dressSize = " + dressSize + ", dressColor = '" + dressColor + "' WHERE Package.cinderellaID = " + cinderellaID;
            int x = database.ExecuteQuery(query);
            //MessageBox.Show(neck +" "+ rin+" " + head+" " + brace+ " " + ear + " " + x);
            if (x == 0)
            {
                exQuery = "INSERT INTO Package (dressSize, dressColor, cinderellaID,Necklace, Ring, Bracelet, Headpiece, Earrings) VALUES (" + dressSize + ",'" + dressColor + "'," + cinderellaID + ",0,0,0,0,0)";
                database.ExecuteQuery(exQuery);
            }
        }
        public string checkedOutCinderellas()
        {
            string query = "SELECT Cinderellas.firstName AS 'First Name', Cinderellas.lastName AS 'Last Name', Package.checkoutNotes AS 'Notes' FROM Package INNER JOIN Cinderellas ON Package.cinderellaID = Cinderellas.id WHERE (Cinderellas.currentStatus = 7)";
            return query;
        }
        public void addUser(string loginName, string password, string firstName, string lastName, int roleID)
        {
            string query = "INSERT INTO ApplicationLogin VALUES ('" + loginName + "','" + password + "','" + firstName + "','" + lastName + "',NULL," + roleID + ")";
            database.ExecuteQuery(query);
        }
        public int ShiftWorkerRole(int fgID, int shiftID)
        {
            string query = "select roleID FROM ShiftWorkers WHERE fairyGodmotherID = " + fgID + " AND shiftID = " + shiftID;
            return database.ReturnFirstCellInt(query);
        }
        //String used for the Quick search Bar. SHOULD Search for Fairy Godmothers and Cinderellas by any means neccesary. 
        public string FGQuickSearch(int fgID)
        {

            //used for when a Fairy Godmother is used a a search parameter to locate a particular Cinderella. 
            string query = "SELECT Cinderellas.firstName, Cinderella.lastName, Cinderellas.id, Referrals.organization, Cinderellas.currentStatus FROM Cinderellas WHERE id = "+fgID;
            return query;
        }

        public string CindyShoeSize(int fgID)
        {
            
            int ourCindy = getCindyIDFomFG(fgID);
            string query = "SELECT Package.shoeSize FROM Package, Cinderellas WHERE Cinderellas.fairyGodmotherID = "+fgID+" AND Package.cinderellaID = "+ourCindy;
            return database.ReturnFirstCellString(query);
        }


        public int CindyDressSize(int fgID)
        {
            int ourCindy = getCindyIDFomFG(fgID);
            string query = "SELECT Package.dressSize FROM Package, Cinderellas WHERE Cinderellas.fairyGodmotherID = "+fgID+" AND Package.cinderellaID = "+ourCindy;
            return database.ReturnFirstCellInt(query);
        }

        public string CindyDressColor(int fgID)
        {
            int ourCindy = getCindyIDFomFG(fgID);
            string query = "SELECT Package.dressColor FROM Package,Cinderellas WHERE Cinderellas.fairyGodmotherID = "+fgID+" AND Package.cinderellaID = "+ourCindy;
            return database.ReturnFirstCellString(query);
        }

        public string CindyShoeColor(int fgID)
        {
            int ourCindy = getCindyIDFomFG(fgID);
            string query = "SELECT Package.shoeColor FROM Package,Cinderellas WHERE Cinderellas.fairyGodmotherID = " + fgID + " AND Package.cinderellaID = " + ourCindy;
            return database.ReturnFirstCellString(query);
        }

        public int getCindyIDFomFG(int idFG)
        {
            string query = "SELECT Cinderellas.id FROM Cinderellas WHERE Cinderellas.fairyGodmotherID = "+idFG;

            return database.ReturnFirstCellInt(query);
        }

        public string CindyNecklace(int fgID)
        {
            int ourCindy = getCindyIDFomFG(fgID);
            string query = "SELECT Package.Necklace FROM Package,Cinderellas WHERE Cinderellas.fairyGodmotherID = " + fgID + " AND Package.cinderellaID = " + ourCindy;
            return database.ReturnFirstCellString(query);
        }

        public string CindyRing(int fgID)
        {
            int ourCindy = getCindyIDFomFG(fgID);
            string query = "SELECT Package.Ring FROM Package,Cinderellas WHERE Cinderellas.fairyGodmotherID = " + fgID + " AND Package.cinderellaID = " + ourCindy;
            return database.ReturnFirstCellString(query);
        }
        public string CindyBracelet(int fgID)
        {
            int ourCindy = getCindyIDFomFG(fgID);
            string query = "SELECT Package.Bracelet FROM Package,Cinderellas WHERE Cinderellas.fairyGodmotherID = " + fgID + " AND Package.cinderellaID = " + ourCindy;
            return database.ReturnFirstCellString(query);
        }

        public string CindyHeadpiece(int fgID)
        {
            int ourCindy = getCindyIDFomFG(fgID);
            string query = "SELECT Package.Headpiece FROM Package,Cinderellas WHERE Cinderellas.fairyGodmotherID = " + fgID + " AND Package.cinderellaID = " + ourCindy;
            return database.ReturnFirstCellString(query);
        }

        public string CindyEarrings(int fgID)
        {
            int ourCindy = getCindyIDFomFG(fgID);
            string query = "SELECT Package.Earrings FROM Package,Cinderellas WHERE Cinderellas.fairyGodmotherID = " + fgID + " AND Package.cinderellaID = " + ourCindy;
            return database.ReturnFirstCellString(query);
        }

       

        

        



        

        public void setSettingValue(string settingName, string settingValue)
        {
            string query = "UPDATE ConfigSettings SET propertyValue = " + settingValue + " WHERE appProperty = " + settingName;
            int x = database.ExecuteQuery(query);
            if (x == 0)
            {
                query = "INSERT INTO ConfigSettings Values (" + settingName + "," + settingValue + ",NULL)";
                database.ExecuteQuery(query);
            }
        }

        public void setDefaultSetting(string settingName, string defaultValue)
        {
            string query = "UPDATE ConfigSettings SET defaultPropertyValue = " + defaultValue + " WHERE appProperty = " + settingName;
            int x = database.ExecuteQuery(query);
            if (x == 0)
            {
                query = "INSERT INTO ConfigSettings Values (" + settingName + ",NULL," + defaultValue + ")";
                database.ExecuteQuery(query);
            }
        }

        public string getSetting(string settingName)
        {
            string query = "SELECT propertyValue FROM ConfigSettings WHERE appProperty = " + settingName;            
            string setting = database.ReturnFirstCellString(query);
            if (setting == null || setting == "")
            {
                query = "SELECT defaultPropertyValue FROM ConfigSettings WHERE appProperty = " + settingName;
                setting = database.ReturnFirstCellString(query);
            }

            return setting;
        }
        

        public void EndShift()
        {
            string query = "INSERT INTO FairyGodmotherTimestamp select id,GETDATE(),1 from FairyGodmothers WHERE currentStatus <> 1 UPDATE FairyGodmothers set currentStatus = 1 WHERE currentStatus <> 1 ";
            database.ExecuteQuery(query);
        }

        public string DressesNotFinished()
        {
            string query = "SELECT Cinderellas.firstName AS 'Cinderella First Name', Cinderellas.lastName AS 'Cinderellas Last Name', Package.dressColor AS 'Dress Color', Package.dressSize AS 'Dress Size', FairyGodmothers.firstName AS 'Seamstress First Name', FairyGodmothers.lastName AS 'Seamstress Last Name' FROM Alteration INNER JOIN FairyGodmothers ON Alteration.fairyGodmotherID = FairyGodmothers.id INNER JOIN Cinderellas ON Cinderellas.id = Alteration.cinderellaID INNER JOIN Package ON Alteration.cinderellaID = Package.cinderellaID WHERE Alteration.endAlterationTime IS NULL";
            return query;
        }

        

        

        public string CinderellaHistory(int cinID)
        {
            string query = "SELECT Cinderellas.firstName AS 'First Name', Cinderellas.lastName AS 'Last Name', CinderellaTimestamp.timestamp, CinderellaStatus.statusName "+
                           "FROM Cinderellas INNER JOIN CinderellaTimestamp ON Cinderellas.id = CinderellaTimestamp.cinderellaID INNER JOIN CinderellaStatus ON CinderellaStatus.statusID = CinderellaTimestamp.statusID "+
                           "WHERE Cinderellas.id = "+cinID;
            return query;
        }

        public string FairyGodmotherHistory(int fgID)
        {
            string query = "SELECT FairyGodmothers.firstName AS 'First Name', FairyGodmothers.lastName AS 'Last Name', FairyGodmotherTimestamp.timestamp, FairyGodmotherStatus.statusName " +
                           "FROM FairyGodmothers INNER JOIN FairyGodmotherTimestamp ON FairyGodmothers.id = FairyGodmotherTimestamp.fairygodmotherID INNER JOIN FairyGodmotherStatus ON FairyGodmotherStatus.statusID = FairyGodmotherTimestamp.statusID " +
                           "WHERE FairyGodmothers.id = " + fgID;
            return query;
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        /* START OF STATISTICS QUERIES */
        //////////////////////////////////////////////////////////
       /// <summary>
       /// USed to find the number of cinderellas that have been helped by a certain FG
       /// </summary>
       /// <returns>Query with FG's first name, last name, and number of cinderella's helped</returns>
        public string NumberOfCinderellasHelpedByFG()
        {
            string query = "SELECT FairyGodmothers.firstName, FairyGodmothers.lastName, A.[# of Cinderellas Helped] FROM FairyGodmothers INNER JOIN (SELECT Cinderellas.fairyGodmotherID, COUNT(Cinderellas.fairyGodmotherID) AS '# of Cinderellas Helped' FROM Cinderellas GROUP BY Cinderellas.fairyGodmotherID) AS A ON a.fairyGodmotherID = FairyGodmothers.id ORDER BY A.[# of Cinderellas Helped] DESC";
            return query;
        }
        /// <summary>
        /// Used to find the number of cinderellas that have gone through.  (based on the number that have been paired
        /// </summary>
        /// <returns>query with # of cinderellas</returns>
        public int NumberOfCinderellasHelped()
        {
            string query = "SELECT COUNT(*) FROM Cinderellas WHERE fairyGodmotherID IS NOT NULL ";
            return database.ReturnFirstCellInt(query);
        }
        /// <summary>
        /// Used to find the number of dresses a fairy godmother has altered
        /// </summary>
        /// <returns>query with FG's firstname, last name, and number of dresses altered</returns>
        public string NumberOfDressesAlteredByFG()
        {
            string query = "SELECT FairyGodmothers.firstName, FairyGodmothers.lastName, A.[Dresses Altered] FROM FairyGodmothers INNER JOIN (SELECT Alteration.fairyGodmotherID, COUNT(Alteration.fairyGodmotherID) AS 'Dresses Altered' FROM Alteration GROUP BY Alteration.fairyGodmotherID) AS A ON a.fairyGodmotherID = FairyGodmothers.id ORDER BY A.[Dresses Altered] DESC";
            return query;
        }
        /// <summary>
        /// USed to find the number of dresses that have been picked of a certain color
        /// </summary>
        /// <param name="color">The dress color</param>
        /// <returns>Query with number of dresses of a certain color</returns>
        public int NumberOfDressesTakenByColor(string color)
        {
            string query = "SELECT COUNT(*) FROM Package WHERE dressColor = '" + color + "'";
            return database.ReturnFirstCellInt(query);
        }
        /// <summary>
        /// USed to find the number of dresses that have been picked of a certain size
        /// </summary>
        /// <param name="size">The dress size</param>
        /// <returns>Query with number of dresses of a certain size</returns>
        public int NumberOfDressesTakenBySize(int size)
        {
            string query = "SELECT COUNT(*) FROM Package WHERE dressSize = " + size;
            return database.ReturnFirstCellInt(query);
        }
        /// <summary>
        /// USed to find the number of dresses that have been picked of a certain color and size
        /// </summary>
        /// <param name="color">The dress color</param>
        /// /// <param name="size">The dress size</param>
        /// <returns>Query with number of dresses of a certain color and size</returns>
        public int NumberOfDressesTakenByColorAndSize(string color, int size)
        {
            string query = "SELECT COUNT(*) FROM Package WHERE dressColor = '" + color + "' AND dressSize = " + size;
            return database.ReturnFirstCellInt(query);
        }
        /// <summary>
        /// Used to find the number of FG's that worked a certain shift
        /// </summary>
        /// <param name="shift">the shift #</param>
        /// <returns>Query with number of FG's that have worked the specified shift</returns>
        public int NumberOfFGsByShift(int shift)
        {
            string query = "SELECT DISTINCT COUNT(*) " +
                            "FROM Cinderellas INNER JOIN " +
                                "FairyGodmothers ON Cinderellas.fairyGodmotherID = FairyGodmothers.id INNER JOIN " +
                                "ShiftWorkers ON FairyGodmothers.id = ShiftWorkers.fairyGodmotherID " +
                            "WHERE ShiftWorkers.shiftID = " + shift;
            return database.ReturnFirstCellInt(query);
        }
        /// <summary>
        /// Used to find the number of FG's that worked a certain shift with a certain role
        /// </summary>
        /// <param name="shift">the shift #</param>
        /// <param name="role">the role number</param>
        /// <returns>query with number of FG's thathaveworked a specified shift and role</returns>
        public int NumberOfFGsByShiftAndRole(int shift, int role)
        {
            string query = "SELECT DISTINCT COUNT(*) " +
                            "FROM Cinderellas INNER JOIN " +
                                "FairyGodmothers ON Cinderellas.fairyGodmotherID = FairyGodmothers.id INNER JOIN " +
                                "ShiftWorkers ON FairyGodmothers.id = ShiftWorkers.fairyGodmotherID " +
                            "WHERE ShiftWorkers.shiftID = " + shift +" AND ShiftWorkers.roleID = " + role;
            return database.ReturnFirstCellInt(query);
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        /* MULTI-USE QUERIES */
        //////////////////////////////////////////////////////////
        /// <summary>
        /// Sets the status of a cinderella or godmother.
        /// </summary>
        /// <param name="ID">Id of the Cinderella or Godmother</param>
        /// <param name="status">Status that you would like to set.</param>
        /// <param name="cinderella">true-set the status of a cinderella :: false-set the status of a godmother</param>
        /// <param name="importRunning">true-if the import is currently running.</param>
        public void setCinderellaStatus(string ID, int status)
        {
            string query = "";

            //Set status of cinderella
            query = "INSERT INTO CinderellaTimestamp (statusID,timestamp,cinderellaID) VALUES (";
            query += status + ",'" + DateTime.Now.ToString() + "'," + ID + ")";

            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Used to update a cinderella's information. This is used if the Cinderella's information was incorrect and needed to be fixed, or if the appointment time and date needs to be changed
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <param name="firstName">Cinderella's First Name</param>
        /// <param name="lastName">Cinderella's Last Name</param>
        /// <param name="date">Cinderella's appointment date</param>
        /// <param name="time">Cinderella's appointment time</param>
        /// <returns>SQL query for updating a cinderella's information</returns>
        public string updateCinderella(int id, string firstName, string lastName, string date, string time)
        {

            string query = "UPDATE Cinderellas " +
                "SET firstName = '" + firstName +
                "',lastName = '" + lastName +
                "',apptDate = '" + date +
                "',apptTime = '" + time +
                "' WHERE Cinderellas.id = " + id;

            return query;
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
        /// Used to get a cinderella's status, along with their name and their FG's name
        /// </summary>
        /// <param name="statusID"></param>
        /// <returns>Query for Cinderella ID, first name, last name, and status name, along with FG's first and last name</returns>
        public string statusList(int statusID)
        {
            string query = "SELECT Cinderellas.id, Cinderellas.firstName AS 'First Name', Cinderellas.lastName AS 'Last Name', CinderellaStatus.statusName AS 'Status', FairyGodmothers.firstName AS 'Personal Shopper First Name', FairyGodmothers.lastName AS 'Personal Shopper Last Name' " +
                            "FROM Cinderellas INNER JOIN CinderellaStatus ON Cinderellas.currentStatus = CinderellaStatus.statusID INNER JOIN FairyGodmothers ON Cinderellas.fairyGodmotherID = FairyGodmothers.id " +
                            "WHERE CinderellaStatus.statusID = " + statusID +
                            " ORDER BY CinderellaStatus.statusName, Cinderellas.lastName, Cinderellas.firstName";
            return query;
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        /* CHECKOUT FORM */
        //////////////////////////////////////////////////////////
        /// <summary>
        /// Displays the list of Cinderellas that are ready for checkout.  (They are shopping or are in alterations).
        /// </summary>
        /// <param name="count">Specifies the number of cinderellas to be displayed.</param>
        /// <returns>List of Cinderellas ready for checkout, first name, last name, referrals</returns>
        public string checkOutList(int count)
        {
            string query = "Select TOP " + count + "Cinderellas.id,Cinderellas.firstName AS 'First Name',Cinderellas.lastName AS 'Last Name', Referrals.organization AS 'Organization' " +
                        "FROM Cinderellas INNER JOIN CinderellaStatus ON Cinderellas.currentStatus = CinderellaStatus.statusID INNER JOIN Referrals ON Referrals.id = Cinderellas.referralID " +
                        "WHERE CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations'" +
                        "ORDER BY Cinderellas.apptDate, Cinderellas.apptTime ";

            return query;
        }
        public string checkOutList()
        {
            string query = "Select Cinderellas.currentStatus AS 'Status',Cinderellas.id,Cinderellas.firstName AS 'First Name',Cinderellas.lastName AS 'Last Name', Referrals.organization AS 'Organization' " +
                        "FROM Cinderellas INNER JOIN CinderellaStatus ON Cinderellas.currentStatus = CinderellaStatus.statusID INNER JOIN Referrals ON Referrals.id = Cinderellas.referralID " +
                        "WHERE CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations'" +
                        "ORDER BY Cinderellas.apptDate, Cinderellas.apptTime ";

            return query;
        }
        /// <summary>
        /// Returns the data for the DGV for Cinderellas dresses that are done in Alterations.  
        /// </summary>
        /// <returns>Cinderella's first and last name, their dress color, and their dress size.</returns>
        public string dressesDone()
        {
            string query = "SELECT Cinderellas.id, Cinderellas.firstName AS 'First Name', Cinderellas.lastName AS 'Last Name', Package.dressColor AS 'Dress Color', Package.dressSize AS 'Dress Size'" +
                           "FROM Cinderellas INNER JOIN Alteration ON Cinderellas.id = Alteration.cinderellaID INNER JOIN " +
                           "Package ON Cinderellas.id = Package.cinderellaID " +
                           "WHERE Alteration.endAlterationTime IS NOT NULL AND Cinderellas.currentStatus = 6 AND Alteration.DressRetrieved = 0 " +
                           "ORDER BY Alteration.endAlterationTime ASC";
            return query;
        }
        /// <summary>
        /// Returns all data from Package table for a certain Cinderella
        /// </summary>
        /// <param name="id">Cinderella ID</param>
        /// <returns>Cinderella ID, dress size, dress color,shoe size, shoe color, datetime available (if applicable
        /// checkout notes, other accessories, and bool values for Necklaces, Rings, Bracelets, Headpieces, and Earrings</returns>
        public string getPackageInfo(string id)
        {
            string query = "SELECT * " +
                           "FROM Package " +
                           "WHERE cinderellaID = " + id;
            return query;
        }
        /// <summary>
        /// Updates a cinderella's package with all necesary information
        /// </summary>
        /// <param name="cinderellaID">Cinderella's ID</param>
        /// <param name="dressSize">Dress Size</param>
        /// <param name="dressColor">Dress Color</param>
        /// <param name="shoeSize">Shoe Size</param>
        /// <param name="shoeColor">Shoe Color</param>
        /// <param name="checkoutNotes">Checkout Notes (Can Be Null)</param>
        /// <param name="necklace">Necklace Bool</param>
        /// <param name="ring">Ring Bool</param>
        /// <param name="bracelet">Bracelet Bool</param>
        /// <param name="headpiece">Headpiece Bool</param>
        /// <param name="earrings">Earrings Bool</param>
        /// <param name="other">Other accessories (Can Be Null)</param>
        public void checkOutUpdate(int cinderellaID, int dressSize, string dressColor, double shoeSize, string shoeColor, string checkoutNotes, bool necklace, bool ring, bool bracelet, bool headpiece, bool earrings, string other)
        {
            string exQuery = "";
            int neck, rin, head, brace, ear;
            neck = Convert.ToInt32(necklace);
            rin = Convert.ToInt32(ring);
            head = Convert.ToInt32(headpiece);
            brace = Convert.ToInt32(bracelet);
            ear = Convert.ToInt32(earrings);
            string shoeColorstring = "";
            if (shoeColor == "" || shoeColor == null)
            {
                shoeColorstring = "NULL";
            }
            else
            {
                shoeColorstring = "'" + shoeColor + "'";
            }
            string shoeSizestring = shoeSize.ToString();
            if (shoeSize < 0)
            {
                shoeSizestring = "NULL";
            }

            string query = "UPDATE Package SET dressSize = " + dressSize + ", dressColor = '" + dressColor + "', shoeSize = " + shoeSizestring + ", shoeColor = " + shoeColorstring + ", checkoutNotes = '" + checkoutNotes + "', Necklace = " + neck + ", Ring = " + rin + ", Bracelet = " + brace + ", Headpiece = " + head + ", Earrings = " + ear + ", Other = '" + other + "' WHERE Package.cinderellaID = " + cinderellaID;
            int x = database.ExecuteQuery(query);
            //MessageBox.Show(neck +" "+ rin+" " + head+" " + brace+ " " + ear + " " + x);
            if (x == 0)
            {
                exQuery = "INSERT INTO Package (dressSize, dressColor, shoeSize, shoeColor, whenAvailable, checkoutNotes, Necklace, Ring, Bracelet, Headpiece, Earrings, Other, cinderellaID) VALUES (" + dressSize + ",'" + dressColor + "'," + shoeSize + ",'" + shoeColor + "',NULL,'" + checkoutNotes + "'," + neck + "," + rin + "," + brace + "," + head + "," + ear + ",'" + other + "'," + cinderellaID + ")";
                database.ExecuteQuery(exQuery);
            }
        }
        /// <summary>
        /// Search for Check Out Form. Used in populating the DGV according to search parameters
        /// </summary>
        /// <param name="fname">Cinderella First Name</param>
        /// <param name="lname">Cinderella Last Name</param>
        /// <param name="organization">Cinderella's Organization (pulled from Referral table in DB according to a Cinderella's referralID)</param>
        /// <returns>Returns a Cinderella's First Name, Last Name, and Organization and is ordered by their appointment date & time, and their name</returns>
        public string CheckOutSearch(string fname, string lname, string organization)
        {
            string query = "Select Cinderellas.id,Cinderellas.firstName AS 'First Name',Cinderellas.lastName AS 'Last Name', Referrals.organization AS 'Organization' " +
                        "FROM Cinderellas INNER JOIN " +
                                 "Referrals ON Cinderellas.referralID = Referrals.id INNER JOIN CinderellaStatus ON Cinderellas.currentStatus = CinderellaStatus.statusID ";
            if (fname != null || fname != "")
            {
                if (lname != null || lname != "")
                {
                    if (organization != null || organization != "")
                    {

                        query += "WHERE (Cinderellas.lastName LIKE '" + lname + "%') AND (Cinderellas.firstName LIKE '" + fname + "%') AND (Referrals.organization LIKE '" + organization + "%') AND (CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations') AND Cinderellas.approved = 1";
                    }
                    else
                    {
                        query += "WHERE (Cinderellas.lastName LIKE '" + lname + "%') AND (Cinderellas.firstName LIKE '" + fname + "%') AND (CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations') AND Cinderellas.approved = 1";
                    }
                }
                else
                {
                    if (organization != null || organization != "")
                    {
                        query += "WHERE (Cinderellas.firstName LIKE '" + fname + "%') AND (Referrals.organization LIKE '" + organization + "%') AND (CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations') AND Cinderellas.approved = 1";
                    }
                    else
                    {
                        query += "WHERE (Cinderellas.firstName LIKE '" + fname + "%') AND (CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations') AND Cinderellas.approved = 1";
                    }
                }
            }
            else
            {
                if (lname != null || lname != "")
                {
                    if (organization != null || organization != "")
                    {
                        query += "WHERE (Cinderellas.lastName LIKE '" + lname + "%') AND (Referrals.organization LIKE '" + organization + "%') AND (CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations') AND Cinderellas.approved = 1";
                    }
                    else
                    {
                        query += "WHERE (Cinderellas.lastName LIKE '" + lname + "%') AND (CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations') AND Cinderellas.approved = 1";
                    }
                }
                else
                {
                    if (organization != null || organization != "")
                    {
                        query += "WHERE (Referrals.organization LIKE '" + organization + "%') AND (CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations') AND Cinderellas.approved = 1";
                    }
                    else
                    {
                        query += "WHERE (CinderellaStatus.statusName = 'Shopping' OR CinderellaStatus.statusName = 'Alterations') AND Cinderellas.approved = 1";
                    }
                }
            }

            query += " ORDER BY Cinderellas.apptDate, Cinderellas.apptTime, Cinderellas.lastName, Cinderellas.firstName";
            return query;
        }
       /// <summary>
       /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
       /// </summary>
       /// <param name="id">Cinderella's ID#</param>
       /// <returns>Query for displaying a Cinderella's Dress Color</returns>
        public string dressColor(int id)
        {
            string query = "SELECT Package.dressColor FROM Package WHERE Package.cinderellaID = " + id;
            string color = database.ReturnFirstCellString(query);
            return color;
        }

       /// <summary>
       /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
       /// </summary>
       /// <param name="id">Cinderella's ID#</param>
       /// <returns>Query for displaying a Cinderella's Dress Size</returns>
        public int dressSize(int id)
        {
            string query = "SELECT Package.dressSize FROM Package WHERE Package.cinderellaID = " + id;
            int size = database.ReturnFirstCellInt(query);
            return size;
        }
        /// <summary>
        /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <returns>Query for displaying a Cinderella's Shoe Size</returns>
        public double PackageShoeSize(int id)
        {
            string query = "SELECT Package.shoeSize FROM Package WHERE Package.cinderellaID = " + id;
            string size = database.ReturnFirstCellString(query);
            return Convert.ToDouble(size);
        }
        /// <summary>
        /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <returns>Query for displaying a Cinderella's Shoe Color</returns>
        public string PackageShoeColor(int id)
        {
            string query = "SELECT Package.shoeColor FROM Package WHERE Package.cinderellaID = " + id;
            string color = database.ReturnFirstCellString(query);
            return color;
        }
        /// <summary>
        /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <returns>Query for displaying a Cinderella's Checkout notes</returns>
        public string PackageCheckOutNotes(int id)
        {
            string query = "SELECT Package.checkoutNotes FROM Package WHERE Package.cinderellaID = " + id;
            string notes = database.ReturnFirstCellString(query);
            return notes;
        }
        /// <summary>
        /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <returns>Query for displaying a Cinderella's Necklace Bool</returns>
        public bool PackageNecklace(int id)
        {
            string query = "SELECT Package.Necklace FROM Package WHERE Package.cinderellaID = " + id;
            int necklace = database.ReturnFirstCellInt(query);
            return Convert.ToBoolean(necklace);
        }
        /// <summary>
        /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <returns>Query for displaying a Cinderella's Ring Bool</returns>
        public bool PackageRing(int id)
        {
            string query = "SELECT Package.Ring FROM Package WHERE Package.cinderellaID = " + id;
            int ring = database.ReturnFirstCellInt(query);
            return Convert.ToBoolean(ring);
        }
        /// <summary>
        /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <returns>Query for displaying a Cinderella's Bracelet Bool</returns>
        public bool PackageBracelet(int id)
        {
            string query = "SELECT Package.Bracelet FROM Package WHERE Package.cinderellaID = " + id;
            int bracelet = database.ReturnFirstCellInt(query);
            return Convert.ToBoolean(bracelet);
        }
        /// <summary>
        /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <returns>Query for displaying a Cinderella's Headpiece Bool</returns>
        public bool PackageHeadpiece(int id)
        {
            string query = "SELECT Package.Headpiece FROM Package WHERE Package.cinderellaID = " + id;
            int headpiece = database.ReturnFirstCellInt(query);
            return Convert.ToBoolean(headpiece);
        }
        /// <summary>
        /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <returns>Query for displaying a Cinderella's Earrings Bool</returns>
        public bool PackageEarrings(int id)
        {
            string query = "SELECT Package.Earrings FROM Package WHERE Package.cinderellaID = " + id;
            int earrings = database.ReturnFirstCellInt(query);
            return Convert.ToBoolean(earrings);
        }
        /// <summary>
        /// Used when a Cinderella's checkout information is saved, but she is not set as 'Checked Out'
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <returns>Query for displaying a Cinderella's information in Package.other</returns>
        public string PackageOther(int id)
        {
            string query = "SELECT Package.dressColor FROM Package WHERE Package.cinderellaID = " + id;
            string other = database.ReturnFirstCellString(query);
            return other;
        }
        /// <summary>
        /// Views cinderellas that have been completely through alterations
        /// </summary>
        /// <returns>Query for Cinderellas' first name, last name, dress size, dress color, FG first and last name</returns>
        public string alterationCompleted()
        {
            string query = "SELECT     Cinderellas.firstName AS 'Cinderella First Name', Cinderellas.lastName AS 'Cinderella Last Name', Package.dressSize AS 'Dress Size', Package.dressColor AS 'Dress Color', FairyGodmothers.firstName AS 'Seamstress First Name', FairyGodmothers.lastName AS 'Seamstress Last Name' " +
                           "FROM         Cinderellas INNER JOIN " +
                                "Package ON Cinderellas.id = Package.cinderellaID INNER JOIN " +
                                "Alteration ON Package.cinderellaID = Alteration.cinderellaID INNER JOIN " +
                                "FairyGodmothers ON FairyGodmothers.id = Alteration.fairyGodmotherID " +
                                "WHERE Cinderellas.id = Package.cinderellaID AND Alteration.endAlterationTime IS NOT NULL AND Cinderellas.currentStatus = 6 " +
                                "ORDER BY Alteration.endAlterationTime ASC";
            return query;
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        /* CHECK-IN FORM */
        //////////////////////////////////////////////////////////
        /// <summary>
        /// Query for retrieving Cinderella's with a status of 'Pending' (Approved to come to Cinderella's Closet but not yet checked in)
        /// </summary>
        /// <returns>Cinderella id, first name, last name, appointment date, appointment time, and referral organization</returns>
        public string checkInList()
        {
            string query = "Select Cinderellas.id,Cinderellas.firstName AS 'First Name',Cinderellas.lastName AS 'Last Name',Cinderellas.apptDate AS 'Date',CONVERT(varchar,Cinderellas.apptTime,100) AS 'Time', Referrals.organization AS 'Organization' " +
                        "FROM Cinderellas INNER JOIN CinderellaStatus ON Cinderellas.currentStatus = CinderellaStatus.statusID INNER JOIN Referrals ON Referrals.id = Cinderellas.referralID " +
                        "WHERE CinderellaStatus.statusName = 'Pending'" +
                        "ORDER BY Cinderellas.apptDate, Cinderellas.apptTime, Cinderellas.lastName, Cinderellas.firstName ";

            return query;
        }
        /// <summary>
        /// Used with text box inputs to parse the data, returning results for the check-in list.
        /// </summary>
        /// <param name="fname">Cinderella's First Name</param>
        /// <param name="lname">Cinderella's Last Name</param>
        /// <param name="organization">Cinderella's Referrat Organization</param>
        /// <returns>Query used to search the Cinderellas table for required information</returns>
        public string CheckInSearch(string fname, string lname, string organization) //Always hits the first case. After realizing how it works, using the first case still makes everything work fine
        {
            string query = "Select Cinderellas.id,Cinderellas.firstName AS 'First Name',Cinderellas.lastName AS 'Last Name',Cinderellas.apptDate AS 'Date',CONVERT(varchar,Cinderellas.apptTime,100) AS 'Time', Referrals.organization AS 'Organization' " +
                        "FROM Cinderellas INNER JOIN " +
                                 "Referrals ON Cinderellas.referralID = Referrals.id INNER JOIN CinderellaStatus ON Cinderellas.currentStatus = CinderellaStatus.statusID ";
            if (fname != null || fname != "")
            {
                if (lname != null || lname != "")
                {
                    if (organization != null || organization != "")
                    {

                        query += "WHERE (Cinderellas.lastName LIKE '" + lname + "%') AND (Cinderellas.firstName LIKE '" + fname + "%') AND (Referrals.organization LIKE '" + organization + "%') AND (CinderellaStatus.statusName= 'Pending') AND (Cinderellas.approved = 1) AND (Cinderellas.currentStatus = 1)";
                    }
                    else
                    {
                        query += "WHERE (Cinderellas.lastName LIKE '" + lname + "%') AND (Cinderellas.firstName LIKE '" + fname + "%') AND (CinderellaStatus.statusName= 'Pending') AND (Cinderellas.approved = 1) AND (Cinderellas.currentStatus = 1)";
                    }
                }
                else
                {
                    if (organization != null || organization != "")
                    {
                        query += "WHERE (Cinderellas.firstName LIKE '" + fname + "%') AND (Referrals.organization LIKE '" + organization + "%') AND (CinderellaStatus.statusName= 'Pending') AND (Cinderellas.approved = 1) AND (Cinderellas.currentStatus = 1)";
                    }
                    else
                    {
                        query += "WHERE (Cinderellas.firstName LIKE '" + fname + "%') AND (CinderellaStatus.statusName= 'Pending') AND (Cinderellas.approved = 1) AND (Cinderellas.currentStatus = 1)";
                    }
                }
            }
            else
            {
                if (lname != null || lname != "")
                {
                    if (organization != null || organization != "")
                    {
                        query += "WHERE (Cinderellas.lastName LIKE '" + lname + "%') AND (Referrals.organization LIKE '" + organization + "%') AND (CinderellaStatus.statusName= 'Pending') AND (Cinderellas.approved = 1) AND (Cinderellas.currentStatus = 1)";
                    }
                    else
                    {
                        query += "WHERE (Cinderellas.lastName LIKE '" + lname + "%') AND (CinderellaStatus.statusName= 'Pending') AND (Cinderellas.approved = 1) AND (Cinderellas.currentStatus = 1)";
                    }
                }
                else
                {
                    if (organization != null || organization != "")
                    {
                        query += "WHERE (Referrals.organization LIKE '" + organization + "%') AND (CinderellaStatus.statusName= 'Pending') AND (Cinderellas.approved = 1) AND (Cinderellas.currentStatus = 1)";
                    }
                    else
                    {
                        query += "WHERE (CinderellaStatus.statusName= 'Pending') AND (Cinderellas.approved = 1) AND (Cinderellas.currentStatus = 1)";
                    }
                }
            }

            query += " ORDER BY Cinderellas.apptDate, Cinderellas.apptTime, Cinderellas.lastName, Cinderellas.firstName";
            return query;
        }
        /// <summary>
        /// Used to show cinderellas that are waiting or paired.  Used for when we have to undo the Cinderella's check-in because of accidental check-in
        /// </summary>
        /// <returns>Query that wil display Cinderella's first name, last name, status name, and organization where the Cinderella's have a status of 'Waiting' or 'Paired'</returns>
        public string CinderellasUndoList()
        {
            string query = "SELECT Cinderellas.id, firstName AS 'First Name', lastName AS 'Last Name', CinderellaStatus.statusName AS 'Status', Referrals.organization AS 'Organization' FROM Cinderellas INNER JOIN CinderellaStatus ON Cinderellas.currentStatus = CinderellaStatus.statusID INNER JOIN CinderellaTimestamp ON CinderellaTimestamp.cinderellaID = Cinderellas.id INNER JOIN Referrals ON Cinderellas.referralID = Referrals.id WHERE (currentStatus = 2 OR currentStatus = 3) AND CinderellaTimeStamp.statusID = currentStatus ORDER BY CinderellaTimestamp.timestamp";
            return query;
        }
        /// <summary>
        /// Used to change a cinderella's appointment time when a manually entered date and time are needed
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        /// <param name="date">Cinderella's new appt date</param>
        /// <param name="time">Cinderella's new appt time</param>
        public void updateCinderellaAppt(int id, string date, string time)
        {
            string query = "UPDATE Cinderellas SET apptDate = '" + date + "', apptTime = '" + time + "' WHERE Cinderellas.id = " + id;
            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Used to change a cinderella's appointment time when the current date and time button is clicked
        /// </summary>
        /// <param name="id">Cinderella's ID#</param>
        public void updateCinderellaAppt(int id)
        {
            string query = "UPDATE Cinderellas SET Cinderellas.apptDate = cast(GETDATE() as date), Cinderellas.apptTime = cast(GETDATE() AS time) WHERE Cinderellas.id = " + id;
            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Used to undo a FG's pairing with a cinderella
        /// </summary>
        /// <param name="fgID">Fairy Godmother's ID</param>
        public void undoCinderellaPairFromFGID(int fgID)
        {
            string query = "SELECT Cinderellas.id FROM FairyGodmothers INNER JOIN Cinderellas ON Cinderellas.FairyGodmotherID = FairyGodmothers.id WHERE FairyGodmothers.id = " + fgID + " AND Cinderellas.currentStatus = 3";
            int cinID = database.ReturnFirstCellInt(query);
            undoCinderellaStatus(cinID, 3);
        }
        /// <summary>
        /// Used to undo a Cinderella's pairing with a FG
        /// </summary>
        /// <param name="cinID">Cinderella's ID</param>
        public void undoFGPairFromCinderellaID(int cinID)
        {
            string query = "SELECT fairyGodmotherID FROM Cinderellas WHERE id = " + cinID;
            int fgID = database.ReturnFirstCellInt(query);
            undoFGStatus(fgID, 2);
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        /* FG SPECIFIC QUERIES */
        //////////////////////////////////////////////////////////
        /// <summary>
        /// Adds a new Godmother to the database. Since the godmother id's are automatically assigned this method will return their ID so that you can use that in the rest of the program logic like adding the godmother to shifts.
        /// </summary>
        /// <param name="fname">Godmothers First Name</param>
        /// <param name="lname">Godmothers Last Name</param>
        /// <returns>Godmothers ID Number</returns>
        public string NewGodMother(string fname, string lname, string address, string city, string emailAddress, string phoneNumber, string state, string zip)
        {
            if (zip == null || zip == "")
                zip = "NULL";
            if (phoneNumber == null || phoneNumber == "")
                phoneNumber = "NULL";
            if (city == null || city == "" || city == "NULL")
                city = "NULL";
            else
                city = "'" + city + "'";
            string tempSQLa = "INSERT INTO FairyGodmothers ([firstname], [lastname], [address], [city], [emailAddress], [phoneNumber], [state], [zip],[currentStatus]) ";
            string tempSQLb = "VALUES ('" + fname + "'" + ", " + "'" + lname + "'" + ", " + "'" + address + "'" + ", " + "" + city + "" + ", " + "'" + emailAddress + "'" + ", " + phoneNumber + ", " + "'" + state + "'" + ", " + zip + ", NULL)";
            string sql = tempSQLa + tempSQLb;
            database.ExecuteQuery(sql);

            //Now that we have added the godmother, what is their id?
            DataSet ds = sqlSelect("getlastGodMotherID");

            DataTable dt = ds.Tables["tableName"];
            //Return the freshly assigned id number.
            return dt.Rows[0][0].ToString();
        }
        /// <summary>
        /// Adds a godmother to a shift.
        /// </summary>
        /// <param name="shift">Shift ID</param>
        /// <param name="ID">Godmother ID</param>
        public void AddGodmotherShift(string fairyGodmotherID, string shiftID, string roleID)
        {
            string query = "UPDATE ShiftWorkers SET roleID = " + roleID + " WHERE ShiftWorkers.fairyGodmotherID = " + fairyGodmotherID + " AND ShiftWorkers.shiftID = " + shiftID;
            int x = database.ExecuteQuery(query);
            if (x == 0)
            {
                string tempSQLa = "INSERT INTO ShiftWorkers (fairyGodmotherID, shiftID, roleID) VALUES (" + fairyGodmotherID + ", " + shiftID + "," + roleID + ")";
                //string tempSQLb = "";

                string sql = tempSQLa;
                database.ExecuteQuery(sql);
            }
        }
        /// <summary>
        /// Used to set a FG to a certain status (Available, Unavailable, Paired, Shopping)
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="status"></param>
        public void setFGStatus(string ID, int status)
        {
            string query = "";
            //Set status of godmother
            query = "INSERT INTO FairyGodmotherTimestamp (fairyGodmotherID,timestamp,statusID) VALUES (";
            query += ID + ",'" + DateTime.Now.ToString() + "'," + status + ")";

            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Used tp find basic FG info
        /// </summary>
        /// <returns>Query for FG id, first name, last name, city, and state</returns>
        public string fgListShort()
        {
            string query = "SELECT id, firstName AS 'First Name', lastName AS 'Last Name', city AS 'City', state AS 'State' " +
                           "FROM FairyGodmothers";

            return query;
        }
        /// <summary>
        /// USed to find all info on FG's
        /// </summary>
        /// <returns>Query for FG id, first name, last name, email,phone, city, state, zip, and address</returns>
        public string fgList()
        {
            string query = "SELECT id, firstName AS 'First Name', lastName AS 'Last Name', emailAddress AS 'Email', phoneNumber AS 'Phone', " +
                                 "city AS 'City', state AS 'State', zip AS 'Zip', address AS 'Address' " +
                                 "FROM FairyGodmothers";

            return query;
        }

        /// <summary>
        /// Used to find info on all FG's according to their status
        /// </summary>
        /// <param name="status">status name</param>
        /// <returns>Query for FG's id, first name, last name, email, phone, city, state, zip, and address according to a certain status</returns>
        public string fgListStatus(string status)
        {
            string query = "SELECT id, firstName AS 'First Name', lastName AS 'Last Name', emailAddress AS 'Email', phoneNumber AS 'Phone', " +
                                 "city AS 'City', state AS 'State', zip AS 'Zip', address AS 'Address' " +
                                 "FROM FairyGodmothers WHERE currentStatus = " + status;

            return query;
        }
        /// <summary>
        /// used to find all info on FG's according to their status and shift
        /// </summary>
        /// <param name="status">status name</param>
        /// <param name="shift">shift name</param>
        /// <returns>Queryfor FG's id, first name, last name, email, phone, city, state, zip, and address according to their status and shift</returns>
        public string fgListStatus(string status, string shift)
        {
            string query = "SELECT id, firstName AS 'First Name', lastName AS 'Last Name', emailAddress AS 'Email', phoneNumber AS 'Phone', " +
                                 "city AS 'City', state AS 'State', zip AS 'Zip', address AS 'Address' " +
                                 "FROM FairyGodmothers WHERE currentStatus = " + status + " AND id IN (SELECT ShiftWorkers.fairyGodmotherID FROM ShiftWorkers WHERE ShiftWorkers.shiftID = " + shift + ")";

            return query;
        }
        
        /// <summary>
        /// Used to find FG's with a certain role
        /// </summary>
        /// <param name="roleID">Role ID</param>
        /// <returns></returns>
        public string fgListRole(string roleID)
        {
            string query = "SELECT FairyGodmothers.id, FairyGodmothers.firstName, FairyGodmothers.lastName " +
                            "FROM FairyGodmothers INNER JOIN ShiftWorkers ON FairyGodmothers.id = Shiftworkers.fairyGodmotherID " +
                            "WHERE ShiftWorkers.roleID = " + roleID;

            return query;
        }

        /// <summary>
        /// Used to find FG's that have a certain role and are 'Available'
        /// </summary>
        /// <param name="roleID">Role ID#</param>
        /// <returns></returns>
        public string fgListRoleCheckedIn(string roleID)
        {
            string query = "SELECT DISTINCT FairyGodmothers.id, FairyGodmothers.firstName, FairyGodmothers.lastName " +
                            "FROM FairyGodmothers " +
                            "WHERE FairyGodmothers.id IN (SELECT fairyGodmotherID FROM ShiftWorkers WHERE ShiftWorkers.roleID = " + roleID + ") AND FairyGodmothers.currentStatus = 4";

            return query;
        }

        /// <summary>
        /// Used to find FG & Cinderella's first and last names that are paired.
        /// </summary>
        /// <param name="roleID">Role ID#</param>
        /// <returns>Query for FG first and last name, and Cinderella's first and last name where the FG has a certain role</returns>
        public string fgListRoleManagement(string roleID)
        {
            string query = "SELECT FairyGodmothers.firstName AS 'Personal Shopper First Name', FairyGodmothers.lastName AS 'Personal Shopper Last Name', Cinderellas.firstName AS 'Cinderella First Name', Cinderellas.lastName AS 'Cinderella Last Name' " +
                            "FROM Cinderellas INNER JOIN " +
                                "FairyGodmothers ON Cinderellas.fairyGodmotherID = FairyGodmothers.id INNER JOIN" +
                                "ShiftWorkers ON FairyGodmothers.id = ShiftWorkers.fairyGodmotherID" +
                            "WHERE ShiftWorkers.roleID =" + roleID;


            return query;
        }
        /// <summary>
        /// USed to find a FG that has a certain role and status
        /// </summary>
        /// <param name="roleID">Role ID</param>
        /// <param name="currentStatus">Current Status</param>
        /// <returns>Query for FG first and last name, and Cinderellas first and last name where the FG has a certain role and status</returns>
        public string fgListRoleManagement(string roleID, int currentStatus)
        {
            string query = "SELECT DISTINCT FairyGodmothers.id, FairyGodmothers.firstName AS 'Personal Shopper First Name', FairyGodmothers.lastName AS 'Personal Shopper Last Name', Cinderellas.firstName AS 'Cinderella First Name', Cinderellas.lastName AS 'Cinderella Last Name' " +
                            "FROM Cinderellas INNER JOIN " +
                                "FairyGodmothers ON Cinderellas.fairyGodmotherID = FairyGodmothers.id INNER JOIN " +
                                "ShiftWorkers ON FairyGodmothers.id = ShiftWorkers.fairyGodmotherID " +
                            "WHERE ShiftWorkers.roleID = " + roleID + " AND FairyGodmothers.currentStatus = " + currentStatus;

            return query;
        }
        /// <summary>
        /// Used to find a FG that is paired with a Cinderella and has a certain role id
        /// </summary>
        /// <param name="roleID">Role id</param>
        /// <returns>Query for FG first and last name, and Cinderellas first and last name where the Cinderella and FG are both paired and the FG has a certain role</returns>
        public string fgListRoleManagement(int roleID)
        {
            string query = "SELECT DISTINCT FairyGodmothers.id, FairyGodmothers.firstName AS 'Personal Shopper First Name', FairyGodmothers.lastName AS 'Personal Shopper Last Name', Cinderellas.firstName AS 'Cinderella First Name', Cinderellas.lastName AS 'Cinderella Last Name' " +
                            "FROM Cinderellas INNER JOIN " +
                                "FairyGodmothers ON Cinderellas.fairyGodmotherID = FairyGodmothers.id INNER JOIN " +
                                "ShiftWorkers ON FairyGodmothers.id = ShiftWorkers.fairyGodmotherID " +
                            "WHERE ShiftWorkers.roleID = " + roleID + " AND FairyGodmothers.currentStatus = 2 AND Cinderellas.currentStatus = 3 ";


            return query;
        }
        /// <summary>
        /// USed to find FG's that are checked in
        /// </summary>
        /// <returns>Query for FG's id#, first name, last name, and status name where the FG is 'Available' or 'paired'</returns>
        public string fgListCheckedIn()
        {
            string query = "SELECT FairyGodmothers.id, FairyGodmothers.firstName, FairyGodmothers.lastName, FairyGodmotherStatus.statusName " +
                            "FROM FairyGodmothers INNER JOIN FairyGodmotherStatus ON FairyGodmothers.currentStatus = FairyGodmotherStatus.statusID WHERE currentStatus = 4 OR currentStatus = 2";

            return query;
        }
        /// <summary>
        /// Used to find the FG that is paired with a Cinderella
        /// </summary>
        /// <param name="id">Cinderella's ID</param>
        /// <returns>Query for the FG id that is paired to a certain Cinderella</returns>
        public string getFgPaired(int id)
        {
            string query = "SELECT fairyGodmotherID FROM Cinderellas WHERE id = " + id.ToString() + " AND fairyGodmotherID IS NOT NULL";
            return query;
        }
        /// <summary>
        /// Used to find what shift and role a FG has when they work
        /// </summary>
        /// <param name="fgID">FG ID#</param>
        /// <returns>Query for the shift ID and ROle ID of a certain FG</returns>
        public string getFGShiftInfo(string fgID)
        {
            string query = "select shiftID, roleID from ShiftWorkers where fairyGodmotherID = " + fgID;

            return query;

        }
        /// <summary>
        /// USed to search the FG list
        /// </summary>
        /// <param name="fname">FG's first name</param>
        /// <param name="lname">FG's last name</param>
        /// <param name="currentStatus">FG's current status</param>
        /// <returns>query for FG's id#, first name, last name, city, and state where these values are similar to the parameters</returns>
        public string fglistSearch(string fname, string lname, int currentStatus)
        {
            string query = "SELECT id, firstName AS 'First Name', lastName AS 'Last Name', city AS 'City', state AS 'State' " +
                           "FROM FairyGodmothers WHERE FairyGodmothers.firstName LIKE '" + fname + "%' AND FairyGodmothers.lastName LIKE '" + lname + "%' AND FairyGodmothers.currentStatus = " + currentStatus + " ORDER BY lastName,firstName";

            return query;
        }
        /// <summary>
        /// Updates FG's info
        /// </summary>
        /// <param name="fgID">FG ID#</param>
        /// <param name="firstName">FG First Name</param>
        /// <param name="lastName">FG Last Name</param>
        /// <param name="emailAddress">FG Email</param>
        /// <param name="phoneNumber">FG Phone#</param>
        /// <param name="city">FG's city</param>
        /// <param name="state">FG's state</param>
        /// <param name="zip">FG's zip</param>
        /// <param name="address">FG's Address</param>
        /// <returns>Query for updating an FG's info based on what the FG's id# is</returns>
        public string updateFairyGodmother(string fgID, string firstName, string lastName, string emailAddress, string phoneNumber, string city, string state, string zip, string address)
        {
            string query = "UPDATE FairyGodmothers SET firstName='" + firstName + "', lastName='" + lastName + "',emailAddress='" + emailAddress + "', phoneNumber=" + phoneNumber +
                            ",city='" + city + "', state='" + state + "', zip=" + zip + ", address='" + address + "' " +
                            "WHERE id=" + fgID;

            return query;
        }
        /// <summary>
        /// finds fairy godmother's ID# that are paired w/ a cinderella
        /// </summary>
        /// <param name="cinderellaID">cinderellas ID#</param>
        /// <returns>query for fairy godmother's ID# that are paired w/ a cinderella</returns>
        public string PairedPersonalShoppers(int cinderellaID)
        {
            string query = "SELECT * FROM FairyGodmothers WHERE ID IN (SELECT fairyGodmotherID FROM Cinderellas WHERE id = " + cinderellaID + ");";
            return query;
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        /* ADMINISTRATIVE QUERIES */
        //////////////////////////////////////////////////////////
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
        public string NewCinderella(string fname, string lname, string date, string time, int referralID)
        {
            string tempSQLa = "INSERT INTO Cinderellas ([firstName], [lastName], [apptDate], [apptTime], [referralID], [approved], [notes], [currentStatus]) ";
            string tempSQLb = "VALUES ('" + fname + "'" + ", " + "'" + lname + "'" + ", " + "'" + date + "'" + "," + "'" + time + "'" + "," + "'" + referralID + "'" + "," + "1" + "," + "NULL" + ", NULL)";
            string sql = tempSQLa + tempSQLb;

            database.ExecuteQuery(sql);

            //return the godmother id
            DataSet ds = sqlSelect("getlastCinderellaID");

            DataTable dt = ds.Tables["tableName"];
            return dt.Rows[0][0].ToString();
        }
        /// <summary>
        /// Used to search for anything needed in the program.
        /// </summary>
        /// <param name="cinFirstName">Cinderellas First Name</param>
        /// <param name="cinLastName">Cinderella's Last Name</param>
        /// <param name="cinOrganization">Cinderella's Organization</param>
        /// <param name="FGFirstName">FG's First Name</param>
        /// <param name="FGLastName">FG's last name</param>
        /// <param name="SeamstressID">ID# of a seamstress</param>
        /// <param name="hadAlterations">int for if a cinderella has had alterations</param>
        /// <param name="dressColor">Dress Color</param>
        /// <param name="maxDressSize">Maximum Dress Size (int)</param>
        /// <param name="minDressSize">minimum Dress Size (int)</param>
        /// <param name="hasShoes">If the cinderella wanted shoes or not</param>
        /// <param name="shoeColor">shoe color</param>
        /// <param name="maxShoeSize">Maximum Shoe Size (int)</param>
        /// <param name="minShoeSize">minimum Shoe Size (int)</param>
        /// <param name="ring">Ring int (for bool)</param>
        /// <param name="headpiece">headpiece int (for bool)</param>
        /// <param name="bracelet">bracelet int (for bool)</param>
        /// <param name="earring">earring int (for bool)</param>
        /// <param name="necklace">necklace int (for bool)</param>
        /// <returns></returns>
        public string MasterSearch(string cinFirstName, string cinLastName, string cinOrganization, string FGFirstName, string FGLastName, int SeamstressID, int hadAlterations, string[] dressColor, int maxDressSize, int minDressSize, bool hasShoes, string[] shoeColor, double maxShoeSize, double minShoeSize, int ring, int headpiece, int bracelet, int earring, int necklace)   //0 = False, 1 = True, Anything else = Unknown
        {
            string query = "SELECT Cinderellas.firstName AS 'Cinderella First Name', Cinderellas.lastName AS 'Cinderella Last Name', Referrals.organization AS 'Organization', PersonalShoppers.firstName AS 'Personal Shopper First Name', PersonalShoppers.lastName AS 'Personal Shopper Last Name', Package.dressColor AS 'Dress Color', Package.dressSize AS 'Dress Size', Package.shoeColor AS 'Shoe Color', Package.shoeSize AS 'Shoe Size', Alterators.firstName AS 'Seamstress First Name', Alterators.lastName AS 'Seamstress Last Name', Cinderellas.id AS 'CinderellaID', PersonalShoppers.id AS 'PersonalShopperID' " +
                           "FROM Cinderellas FULL OUTER JOIN FairyGodmothers AS PersonalShoppers ON Cinderellas.fairyGodmotherID = PersonalShoppers.id FULL OUTER JOIN Package ON Cinderellas.id = Package.cinderellaID FULL OUTER JOIN Alteration ON Cinderellas.id = Alteration.cinderellaID FULL OUTER JOIN FairyGodmothers AS Alterators ON Alteration.fairyGodmotherID = Alterators.id LEFT OUTER JOIN Referrals ON Referrals.id = Cinderellas.referralID " +
                           "WHERE (Cinderellas.firstName LIKE '" + cinFirstName + "%' ";
            if (cinFirstName == "" || cinFirstName == " ")      //Start handling textboxes
            {
                query += "OR Cinderellas.firstName IS NULL";
            }
            query += ") AND (Cinderellas.lastName LIKE '" + cinLastName + "%' ";

            if (cinLastName == "" || cinLastName == " ")
            {
                query += "OR Cinderellas.lastName IS NULL";
            }

            query += ") AND (Referrals.organization LIKE '" + cinOrganization + "%' ";
            if (cinOrganization == "" || cinOrganization == " ")
            {
                query += "OR Referrals.organization IS NULL";
            }
            query += ") AND (PersonalShoppers.firstName LIKE '" + FGFirstName + "%' ";
            if (FGFirstName == "" || FGFirstName == " ")
            {
                query += "OR PersonalShoppers.firstName IS NULL";
            }
            query += ") AND (PersonalShoppers.lastName LIKE '" + FGLastName + "%' ";
            if (FGLastName == "" || FGLastName == " ")
            {
                query += "OR PersonalShoppers.lastName IS NULL";
            }
            query += ") ";              //Handling textboxes is done.

            ////////////////////////////////     Need a break in all this confusing code            
            ////////////////////////////////
            int i = 0;

            if (dressColor.Length != 0)              //Handles the dress color(s)
            {
                query += " AND Package.dressColor IN (";

                string dresscolors = "";
                foreach (string color in dressColor)
                {
                    i++;
                    if (i == 1)
                        dresscolors += "'" + color + "'";        //Don't add the comma if its the first element.
                    else
                    {
                        dresscolors += ", '" + color + "'";
                    }
                }
                query += dresscolors + ") ";
            }

            i = 0;
            if (hasShoes)
            {
                if (shoeColor.Length != 0)          //Handles the shoe color(s)
                {
                    query += " AND Package.shoeColor IN (";
                    string shoecolors = "";
                    foreach (string color in shoeColor)
                    {
                        i++;
                        if (i == 1)
                            shoecolors += "'" + color + "'";        //Don't add the comma if its the first element.
                        else
                        {
                            shoecolors += ", '" + color + "'";
                        }
                    }
                    query += shoecolors + ") ";
                }
                query += " AND ((Package.shoeSize >= " + minShoeSize + " AND Package.shoeSize <= " + maxShoeSize + ") OR Package.shoeSize IS NULL) "; //handles shoe size
            }
            else
            {
                query += " AND Package.shoeColor IS NULL AND Package.shoeSize IS NULL";
            }
            ////////////////////////////    Another needed break
            ////////////////////////////

            query += " AND ((Package.dressSize >= " + minDressSize + " AND Package.dressSize <= " + maxDressSize + ") OR Package.dressSize IS NULL) ";          //Handles the range of dress size. If looking for a specific value, make max and min the same value.
            if (SeamstressID > 0 && hadAlterations != 0)
                query += " AND Alterators.id = " + SeamstressID;

            if (hadAlterations == 1)
                query += " AND Cinderellas.id IN (SELECT cinderellaID FROM Alteration) ";
            if (hadAlterations == 0)
                query += " AND Cinderellas.id NOT IN (SELECT cinderellaID FROM Alteration) ";

            if (ring == 0 || ring == 1)                 //0 = False, 1 = True, Anything else = Unknown
                query += " AND Package.Ring = " + ring;
            if (necklace == 0 || necklace == 1)
                query += " AND Package.Necklace = " + necklace;
            if (bracelet == 0 || bracelet == 1)
                query += " AND Package.Bracelet = " + bracelet;
            if (headpiece == 0 || headpiece == 1)
                query += " AND Package.Headpiece = " + headpiece;
            if (earring == 0 || earring == 1)
                query += " AND Package.Earrings = " + earring;

            return query;
        }
        /// <summary>
        /// Used to validate the login of a user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Query that checks if the username+password given exists</returns>
        public int validateLogin(string username, string password)
        {
            string query = "SELECT ApplicationLogin.roleID FROM ApplicationLogin WHERE loginName='" + username + "' AND password='" + password + "'";
            return database.ReturnFirstCellInt(query);
        }
        /// <summary>
        /// Used to manually pair a cinderella
        /// </summary>
        /// <param name="cinderellaID">Cinderella's ID#</param>
        /// <param name="fg_id">FG's ID#</param>
        public void pairCinderella(int cinderellaID, int fg_id)
        {
            string query = "UPDATE Cinderellas " +
                "SET Cinderellas.fairyGodmotherID = " + fg_id +
                "WHERE Cinderellas.id = " + cinderellaID;
            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Used to find a Cinderella's id that is paired with a certain FG
        /// </summary>
        /// <param name="id">FG's ID#</param>
        /// <returns>Query for cinderella's ID where fairyGodmotherID is the parameter given</returns>
        public string getCinderellaPaired(int id)
        {
            string query = "SELECT id FROM Cinderellas WHERE fairyGodmotherID = " + id.ToString();
            return query;
        }
        /// <summary>
        /// Used to retrieve the list of referrals
        /// </summary>
        /// <returns>query for referral ID, name, and organization</returns>
        public string getReferrals()
        {
            string query = "SELECT id, referralName, organization " +
                           "FROM Referrals ORDER BY organization";

            return query;
        }
        /// <summary>
        /// Soft reset of the Database
        /// </summary>
        public void resetDB()
        {
            string query = "DELETE FROM Alteration; " +
                            "DELETE FROM CinderellaTimestamp; " +
                            "DELETE FROM FairyGodmotherTimestamp; " +
                            "DELETE FROM Package; " +
                            "DELETE FROM ShiftWorkers; " +
                            "UPDATE Cinderellas SET currentStatus = 1; " +
                            "UPDATE Cinderellas SET fairyGodmotherID = NULL; " +
                            "UPDATE FairyGodmothers SET currentStatus = 1;";

            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Deletes everything from FG table
        /// </summary>
        public void deleteFGs()
        {
            string query = "DELETE FROM FairyGodmothers ";
            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Deletes everything from Cinderellas table
        /// </summary>
        public void deleteCinderellas()
        {
            string query = "DELETE FROM Cinderellas ";
            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Gives a cinderella's current status
        /// </summary>
        /// <param name="id">Cinderella's current ID#</param>
        /// <returns>query for a cinderella's current status</returns>
        public int CinderellaCurrentStatus(int id)
        {
            string query = "SELECT currentStatus FROM Cinderellas " +
                           "WHERE Cinderellas.id = " + id;
            return database.ReturnFirstCellInt(query);
        }
        /// <summary>
        /// Gives a FG's current status
        /// </summary>
        /// <param name="id">FG ID#</param>
        /// <returns>query for the current status of a FG</returns>
        public int FGCurrentStatus(int id)
        {
            string query = "SELECT currentStatus FROM FairyGodmothers " +
                           "WHERE FairyGodmothers.id = " + id;
            return database.ReturnFirstCellInt(query);
        }
        /// <summary>
        /// Finds Personal shoppers that have a currentStatus between two options
        /// </summary>
        /// <param name="currentStatus1">one status #</param>
        /// <param name="currentStatus2">the other status #</param>
        /// <returns>Query for FG's that have a current status of one or the other specified</returns>
        public string PersonalShoppers(int currentStatus1, int currentStatus2)
        {
            string query = "SELECT DISTINCT X.id, X.firstName AS 'First Name', X.lastName AS 'Last Name', FairyGodmotherStatus.statusName AS 'Status' FROM FairyGodmotherStatus INNER JOIN (SELECT DISTINCT id, firstName, lastName, currentStatus, timestamp FROM FairyGodmothers INNER JOIN ShiftWorkers ON FairyGodmothers.id = Shiftworkers.fairyGodmotherID INNER JOIN FairyGodmotherTimestamp ON FairyGodmothers.id = FairyGodmotherTimestamp.fairyGodmotherID WHERE (FairyGodmothers.currentStatus = " + currentStatus1 + " OR FairyGodmothers.currentStatus = " + currentStatus2 + ") AND ShiftWorkers.roleID = 4 AND FairyGodmotherTimestamp.statusID = FairyGodmothers.currentStatus ) AS X ON X.currentStatus = FairyGodmotherStatus.statusID";
            return query;
        }
        /// <summary>
        /// returns FG's that are personal shoppers and have the specified current status
        /// </summary>
        /// <param name="currentStatus">status #</param>
        /// <returns>Query for FG's that are personal shoppers and have the specified current status</returns>
        public string PersonalShoppers(int currentStatus)
        {
            string query = "SELECT DISTINCT X.id, X.firstName AS 'First Name*', X.lastName AS 'Last Name', state AS 'State' FROM (SELECT DISTINCT id, firstName, lastName, state, timestamp FROM FairyGodmothers INNER JOIN ShiftWorkers ON FairyGodmothers.id = Shiftworkers.fairyGodmotherID INNER JOIN FairyGodmotherTimestamp ON FairyGodmothers.id = FairyGodmotherTimestamp.fairyGodmotherID WHERE FairyGodmothers.currentStatus = " + currentStatus + " AND ShiftWorkers.roleID = 4 AND FairyGodmotherTimestamp.statusID = " + currentStatus + " ) AS X ";
            return query;
        }
        /// <summary>
        /// Returns a certain number of Personal Shoppers w/ a specified status
        /// </summary>
        /// <param name="count">number of Fg's to be shown</param>
        /// <param name="currentStatus">the desired status #</param>
        /// <returns>query for a certain number of Personal Shoppers w/ a specified status</returns>
        public string PersonalShoppersList(int count, int currentStatus)
        {
            string query = "SELECT TOP " + count + " X.id, X.firstName AS 'First Name*', X.lastName AS 'Last Name', CheckInTime FROM (SELECT DISTINCT id, firstName, lastName, MAX(timestamp) AS 'CheckInTime' FROM FairyGodmothers INNER JOIN ShiftWorkers ON FairyGodmothers.id = Shiftworkers.fairyGodmotherID INNER JOIN FairyGodmotherTimestamp ON FairyGodmothers.id = FairyGodmotherTimestamp.fairyGodmotherID WHERE FairyGodmothers.currentStatus = " + currentStatus + " AND ShiftWorkers.roleID = 4 AND FairyGodmotherTimestamp.statusID = FairyGodmothers.currentStatus GROUP BY id,firstName,lastName) AS X  ORDER BY CheckInTime";
            //string query = "SELECT TOP " + count + " X.id, X.firstName AS 'First Name*', X.lastName AS 'Last Name', state AS 'State', timestamp FROM (SELECT DISTINCT id, firstName, lastName, state FROM FairyGodmothers INNER JOIN ShiftWorkers ON FairyGodmothers.id = Shiftworkers.fairyGodmotherID INNER JOIN FairyGodmotherTimestamp ON FairyGodmothers.id = FairyGodmotherTimestamp.fairyGodmotherID WHERE FairyGodmothers.currentStatus = " + currentStatus + " AND ShiftWorkers.roleID = 4 AND FairyGodmotherTimestamp.statusID = " + currentStatus + " ) AS X";
            return query;
        }
        /// <summary>
        /// Finds Cinderellas that have a currentStatus between two options
        /// </summary>
        /// <param name="currentStatus1">one status #</param>
        /// <param name="currentStatus2">the other status #</param>
        /// <returns>Query for Cinderella's that have a current status of one or the other specified</returns>
        public string Cinderellas(int currentStatus1, int currentStatus2)
        {
            string query = "SELECT id, firstName AS 'First Name', lastName AS 'Last Name', CinderellaStatus.statusName AS 'Status' FROM Cinderellas INNER JOIN CinderellaStatus ON Cinderellas.currentStatus = CinderellaStatus.statusID WHERE currentStatus = " + currentStatus1 + " OR currentStatus = " + currentStatus2;
            return query;
        }


        /// <summary>
        /// Finds cinderellas with a certain status
        /// </summary>
        /// <param name="currentStatus">cinderella's current statud desired</param>
        /// <returns>Query for finding cinderella's with a certain status</returns>
        public string Cinderellas(int currentStatus)
        {
            string query = "SELECT * FROM Cinderellas INNER JOIN CinderellaTimestamp ON Cinderellas.id = CinderellaTimestamp.cinderellaID WHERE currentStatus = " + currentStatus + " AND CinderellaTimestamp.statusID = " + currentStatus + " ORDER BY Cinderellas.apptDate, Cinderellas.apptTime, CinderellaTimestamp.timestamp ";
            return query;
        }
        /// <summary>
        /// Finds cinderellas with a certain status and displays the top number of them
        /// </summary>
        /// <param name="count">number of cinderellas to display</param>
        /// <param name="currentStatus">cinderella's current status desired</param>
        /// <returns>Query for finding cinderella's with a certain status</returns>
        public string CinderellasList(int count, int currentStatus)
        {
            string query = "SELECT TOP " + count + " * FROM Cinderellas INNER JOIN CinderellaTimestamp ON Cinderellas.id = CinderellaTimestamp.cinderellaID WHERE currentStatus = " + currentStatus + " AND CinderellaTimestamp.statusID = " + currentStatus + " ORDER BY Cinderellas.apptDate, Cinderellas.apptTime, CinderellaTimestamp.timestamp ";
            //tring query = "SELECT TOP " + count + " * FROM Cinderellas WHERE currentStatus = '" + currentStatus + "' ORDER BY apptDate, apptTime, timestamp ";
            return query;
        }

        //run this for 'Add Cinderellas'  Checks if the referral exists first.  If they do, it will add a cinderella and referralID will be the referral specified.
        //If referral does not exist, will first add a new referral and then a new cinderella with a referral ID of the last referral (the new referral)
        /// <summary>
        /// Adds a Cinderella and new referral to respective tables
        /// </summary>
        /// <param name="refName">Referral Name</param>
        /// <param name="refOrg">Referral Organization</param>
        /// <param name="cindFirstName">Cinderella's First Name</param>
        /// <param name="cindLastName">Cinderella's Last Name</param>
        /// <param name="apptDate">Appointment Date</param>
        /// <param name="apptTime">Appointment Time</param>
        /// <param name="notes">any notes</param>
        public void addCinderellaAndReferral(string refName, string refOrg, string cindFirstName, string cindLastName, string apptDate, string apptTime, string notes)
        {
            if (notes == null)
                notes = "";
            string query = "IF EXISTS (SELECT Referrals.id FROM Referrals WHERE Referrals.referralName = '" + refName + "' AND Referrals.organization = '" + refOrg + "') BEGIN INSERT INTO Cinderellas (firstName, lastName, apptDate, apptTime, approved, notes, referralID) VALUES ('" + cindFirstName + "','" + cindLastName + "', '" + apptDate + "', '" + apptTime + "', 1, '" + notes + "' ,(SELECT Referrals.id FROM Referrals WHERE Referrals.referralName = '" + refName + "' AND Referrals.organization = '" + refOrg + "')) END ELSE BEGIN INSERT INTO Referrals (referralName, organization, phoneNumber) VALUES ('" + refName + "','" + refOrg + "',1) INSERT INTO Cinderellas (firstName, lastName, apptDate, apptTime, approved, notes, referralID) VALUES ('" + cindFirstName + "','" + cindLastName + "', '" + apptDate + "', '" + apptTime + "', 1, '" + notes + "',(SELECT Referrals.id FROM Referrals WHERE referralName = '" + refName + "' AND organization = '" + refOrg + "')) END";
            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Undos the status changes of the given status for the FairyGodmother fi that status is the last known status
        /// </summary>
        /// <param name="cinID">FairyGodmother given id</param>
        /// <param name="status">status to delete</param>
        /// <remarks>The FGDeleteStatusTrigger will update to the correct currentStatus</remarks>
        /// <returns>NULL</returns>
        public void undoFGStatus(int id, int status)
        {
            string query = "declare @transID int declare @statusID int " +
                           "select @transID = FairyGodmotherTimestamp.transID, @statusID = FairyGodmotherTimestamp.statusID from FairyGodmotherTimestamp where FairyGodmotherTimestamp.statusID = " + status + " and FairyGodmotherTimestamp.fairyGodmotherID = " + id + " ORDER BY FairyGodmotherTimestamp.timestamp " +
                           "if(@statusID = " + status + ") DELETE FROM FairyGodmotherTimestamp WHERE transID = @transID";
            database.ExecuteQuery(query);
        }

        /// <summary>
        /// Undos the status change of the given status for the Cinderella if that status is the last known status
        /// </summary>
        /// <param name="cinID">Cinderellas given id</param>
        /// <param name="status">status to delete</param>
        /// <remarks>The CinDeleteStatusTrigger will update to the correct currentStatus</remarks>
        /// <returns>NULL</returns>
        public void undoCinderellaStatus(int id, int status)
        {
            string query = "declare @transID int declare @statusID int " +
                "select @transID = CinderellaTimestamp.transID, @statusID = CinderellaTimestamp.statusID from CinderellaTimestamp where CinderellaTimestamp.statusID = " + status + " and CinderellaTimestamp.cinderellaID = " + id + " ORDER BY CinderellaTimestamp.timestamp " +
                "if(@statusID = " + status + ") DELETE FROM CinderellaTimestamp WHERE transID = @transID";
            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Used to add a FG to a shift
        /// </summary>
        /// <param name="firstName">FG first name</param>
        /// <param name="lastName">FG last name</param>
        /// <param name="shiftID">fg shift ID#</param>
        /// <param name="roleID">FG role ID#</param>
        public void newFGShiftWorker(string firstName, string lastName, int shiftID, int roleID)
        {
            string query = "declare @fgID int; " +
                           "select @fgID = id FROM FairyGodmothers WHERE firstName = '" + firstName + "' AND lastName = '" + lastName + "' " +
                           "INSERT INTO ShiftWorkers VALUES (@fgID," + shiftID + "," + roleID + ")";
            database.ExecuteQuery(query);
        }
        /// <summary>
        /// Undos the status changes until the given status for the FairyGodmother
        /// </summary>
        /// <param name="fgID">FairyGodmother given id</param>
        /// <param name="status">status to undo to</param>
        /// <remarks>The FGDeleteStatusTrigger will update to the correct currentStatus</remarks>
        /// <returns>NULL</returns>
        public void undoFGUntilThisStatus(int fgID, int status)
        {
            string query = "declare @transID int declare @statusID int " +
                           "select @transID = FairyGodmotherTimestamp.transID, @statusID = FairyGodmotherTimestamp.statusID from FairyGodmotherTimestamp " +
                           "where FairyGodmotherTimestamp.fairyGodmotherID = " + fgID + " " +
                           "ORDER BY FairyGodmotherTimestamp.timestamp " +
                           "select @statusID " +
                           "WHILE(@statusID <> " + status + ") " +
                           "BEGIN " +
                           "DELETE FROM FairyGodmotherTimestamp WHERE transID = @transID " +
                           "if(@statusID = 2) " +
                           "BEGIN " +
                           "declare @cinTransID int; " +
                           "select @cinTransID = transID from Cinderellas INNER JOIN CinderellaTimestamp ON Cinderellas.id = CinderellaTimestamp.cinderellaID WHERE Cinderellas.fairyGodmotherID = " + fgID + " AND Cinderellas.currentStatus = 3 AND Cinderellas.currentStatus = CinderellaTimestamp.statusID " +
                           "DELETE FROM CinderellaTimestamp WHERE transID = @cinTransID " +
                           "END " +
                           "select @transID = FairyGodmotherTimestamp.transID, @statusID = FairyGodmotherTimestamp.statusID from FairyGodmotherTimestamp " +
                           "where FairyGodmotherTimestamp.fairyGodmotherID = " + fgID + " " +
                           "ORDER BY FairyGodmotherTimestamp.timestamp " +
                           "if (select count(*) from FairyGodmotherTimestamp where FairyGodmotherTimestamp.fairyGodmotherID = " + fgID + " ) <= 1 " +
                           "BEGIN " +
                           "if (select FairyGodmotherTimestamp.statusID from FairyGodmotherTimestamp where FairyGodmotherTimestamp.fairyGodmotherID = " + fgID + " ) IS NULL " +
                           "BEGIN " +
                           "INSERT INTO FairyGodmotherTimestamp ([statusID],[timestamp],[fairyGodmotherID]) " +
                           "VALUES (1,GETDATE()," + fgID + ") " +
                           "BREAK END " +
                           "END " +
                           "END; ";
            database.ExecuteQuery(query);
        }

        /// <summary>
        /// Undos the status changes until the given status for the Cinderella
        /// </summary>
        /// <param name="cinID">Cinderellas given id</param>
        /// <param name="status">status to undo to</param>
        /// <remarks>The CinDeleteStatusTrigger will update to the correct currentStatus</remarks>
        /// <returns>NULL</returns>
        public void undoCinderellaUntilThisStatus(int cinID, int status)
        {
            string query = "declare @transID int declare @statusID int " +
                           "select @transID = CinderellaTimestamp.transID, @statusID = CinderellaTimestamp.statusID from CinderellaTimestamp " +
                           "where CinderellaTimestamp.cinderellaID = " + cinID + " " +
                           "ORDER BY CinderellaTimestamp.timestamp " +
                           "WHILE(@statusID <> " + status + ") " +
                           "BEGIN " +
                           "DELETE FROM CinderellaTimestamp WHERE transID = @transID " +
                           "if(@statusID = 3) " +
                           "BEGIN " +
                           "declare @fgTransID int; " +
                           "select @fgTransID = transID from Cinderellas INNER JOIN FairyGodmotherTimestamp ON Cinderellas.fairyGodmotherID = FairyGodmotherTimestamp.fairyGodmotherID INNER JOIN FairyGodmothers ON Cinderellas.fairyGodmotherID = FairyGodmothers.id WHERE Cinderellas.id = " + cinID + " AND FairyGodmothers.currentStatus = 2 AND FairyGodmotherTimestamp.statusID = 2 " +
                           "DELETE FROM FairyGodmotherTimestamp WHERE transID = @fgTransID " +
                           "END " +
                           "select @transID = CinderellaTimestamp.transID, @statusID = CinderellaTimestamp.statusID from CinderellaTimestamp " +
                           "where CinderellaTimestamp.cinderellaID = " + cinID + " " +
                           "ORDER BY CinderellaTimestamp.timestamp " +
                           "if(select COUNT(*) from CinderellaTimestamp where CinderellaTimestamp.cinderellaID = " + cinID + ") <= 1 " +
                           "BEGIN " +
                           "if (select CinderellaTimestamp.statusID from CinderellaTimestamp where CinderellaTimestamp.cinderellaID = " + cinID + ") IS NULL " +
                           "BEGIN " +
                           "INSERT INTO CinderellaTimestamp ([statusID],[timestamp],[cinderellaID]) " +
                           "VALUES (1,GETDATE()," + cinID + ") " +
                           "BREAK END " +
                           "END " +
                           "END; ";
            database.ExecuteQuery(query);

        }
        /// <summary>
        /// Sets the Cinderella's FairyGodmother to be unavailable if the Cinderella is the last known paired Cinderella for the FairyGodmother and the FairyGodmother is currently shopping
        /// </summary>
        /// <param name="cinID">Cinderellas given id</param>
        /// <returns>NULL</returns>
        public void FGLeavesCinderella(int cinID)
        {
            string query = "declare @cinID int; declare @fgstatus int; declare @fgid int; " +
                           "select @cinID = C2.id from Cinderellas AS C1 INNER JOIN FairyGodmothers ON C1.fairyGodmotherID = FairyGodmothers.id INNER JOIN " +
                           "Cinderellas AS C2 ON C2.fairyGodmotherID = FairyGodmothers.id INNER JOIN CinderellaTimestamp ON CinderellaTimestamp.cinderellaID = C2.id " +
                           "WHERE c1.id = " + cinID + " ORDER BY CinderellaTimestamp.timestamp " +
                           "select @fgstatus = FairyGodmothers.currentStatus, @fgid = FairyGodmothers.id from FairyGodmothers INNER JOIN Cinderellas ON Cinderellas.fairyGodmotherID = FairyGodmothers.id WHERE Cinderellas.id = @cinID " +
                           "IF(@cinID = " + cinID + " AND @fgstatus = 3) " +
                           "BEGIN " +
                           "INSERT INTO FairyGodmotherTimestamp VALUES (@fgid,GETDATE(),1) " +
                           "END";
            database.ExecuteQuery(query);
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        /* ALTERATION QUERIES */
        //////////////////////////////////////////////////////////
        /// <summary>
        /// Adds a Cinderella into Alterations
        /// </summary>
        /// <param name="cindID">Cinderella's ID#</param>
        public void addAlterations(string cindID)
        {

            string query = "INSERT INTO Alteration (cinderellaID,startAlterationTime, straps,darts,fixZipper,generalMending,generalTakeIn,bust,hem) VALUES (" + cindID + ",GETDATE(),0,0,0,0,0,0,0)";

            database.ExecuteQuery(query);

        }
        /// <summary>
        /// Used to give alterations to a Cinderella
        /// </summary>
        /// <param name="cindID">Cinderella's ID</param>
        /// <param name="notes">notes</param>
        /// <param name="straps">Straps (Int used for bool value in DB)</param>
        /// <param name="darts">darts (Int used for bool value in DB)</param>
        /// <param name="zipper">zipper (Int used for bool value in DB)</param>
        /// <param name="mending">mending (Int used for bool value in DB)</param>
        /// <param name="takeIn">takeIn (Int used for bool value in DB)</param>
        /// <param name="bust">bust (Int used for bool value in DB)</param>
        /// <param name="hem">hem (Int used for bool value in DB)</param>
        /// <param name="fgID">Seamstress ID#</param>
        public void updateAlterations(string cindID, string notes, int straps, int darts, int zipper, int mending, int takeIn, int bust, int hem, string fgID)
        {

            //string query = "INSERT INTO Alteration VALUES (" + cindID + ",'" + time + "','" + time + "','" + notes + "'," + straps + "," + darts + "," + zipper + "," + mending + "," + takeIn + "," + bust + "," + hem + "," + fgID + ")";
            string query = "UPDATE Alteration SET endAlterationTime= GETDATE(), notes= '" + notes + "', straps = " + straps + ", darts= " + darts + ", fixZipper= " + zipper + ", generalMending = " + mending + ", generalTakeIn = " + takeIn + ", bust= " + bust + ", hem= " + hem + ", fairyGodmotherID= " + fgID + " WHERE cinderellaID = " + cindID;

            database.ExecuteQuery(query);

        }
        /// <summary>
        /// used to give alterations to a Cinderella (This is used when their alterations will not be completed onsite)
        /// </summary>
        /// <param name="cindID">Cinderella's ID</param>
        /// <param name="notes">notes</param>
        /// <param name="straps">Straps (Int used for bool value in DB)</param>
        /// <param name="darts">darts (Int used for bool value in DB)</param>
        /// <param name="zipper">zipper (Int used for bool value in DB)</param>
        /// <param name="mending">mending (Int used for bool value in DB)</param>
        /// <param name="takeIn">takeIn (Int used for bool value in DB)</param>
        /// <param name="bust">bust (Int used for bool value in DB)</param>
        /// <param name="hem">hem (Int used for bool value in DB)</param>
        /// <param name="fgID">Seamstress ID#</param>
        public void updateAlterationsNotFinished(string cindID, string notes, int straps, int darts, int zipper, int mending, int takeIn, int bust, int hem, string fgID)
        {

            //string query = "INSERT INTO Alteration VALUES (" + cindID + ",'" + time + "','" + time + "','" + notes + "'," + straps + "," + darts + "," + zipper + "," + mending + "," + takeIn + "," + bust + "," + hem + "," + fgID + ")";
            string query = "UPDATE Alteration SET notes= '" + notes + "', straps = " + straps + ", darts= " + darts + ", fixZipper= " + zipper + ", generalMending = " + mending + ", generalTakeIn = " + takeIn + ", bust= " + bust + ", hem= " + hem + ", fairyGodmotherID= " + fgID + " WHERE cinderellaID = " + cindID;

            database.ExecuteQuery(query);

        }

        /// <summary>
        /// USed to check if a Cinderella is in Alterations
        /// </summary>
        /// <param name="id">Cinderella's ID</param>
        /// <returns>query for all alteratino info of a certain CInderella</returns>
        public string checkAlterations(string id)
        {
            string query = "select * FROM Alteration where cinderellaID = " + id;
            return query;
        }

        /// <summary>
        /// displays the cinderellas that are currently in alterations (status of 6) and their end time of their alterations is null, indicating that the dress has not been completed in alterations. (currently being worked on or if more time is needed.)
        /// </summary>
        /// <returns>Query for diaplaying the cinderellas that are currently in alterations (status of 6) and their end time of their alterations is null, indicating that the dress has not been completed in alterations. (currently being worked on or if more time is needed.)</returns>
        public string CinderellasInAlteration()
        {
            string query = "SELECT Cinderellas.id, Cinderellas.firstName AS 'First Name', Cinderellas.lastName AS 'Last Name', Package.dressColor AS 'Color', Package.dressSize AS 'Size' " +
                           "FROM Alteration INNER JOIN Package ON Alteration.cinderellaID = Package.cinderellaID INNER JOIN Cinderellas ON Cinderellas.id = Alteration.cinderellaID " +
                           "WHERE Alteration.endAlterationTime IS NULL AND Cinderellas.currentStatus = 6";
            return query;
        }
        /// <summary>
        /// Tells the DB that the cinderella got the dress back from alterations
        /// </summary>
        /// <param name="cinID">Cinderella's ID#</param>
        public void RetrievedDress(int cinID)
        {
            string query = "UPDATE Alteration SET DressRetrieved = 1 WHERE cinderellaID = " + cinID;
            database.ExecuteQuery(query);
        }





        public string getTime(int id)
        {

            SqlConnection sqlConnection = new SqlConnection("Server=db.cisdept.thomasmore.edu,50336;Database=cinderellaMGS2012; User Id=cinderellamgs; Password=cinderellamgs2012;");
            SqlCommand Test = new SqlCommand();
            Object returnValue;

            Test.CommandText = "SELECT Cinderellas.apptTime From Cinderellas WHERE Cinderellas.id = " + id;;
            Test.CommandType = CommandType.Text;
            Test.Connection = sqlConnection;

            sqlConnection.Open();

            returnValue = Test.ExecuteScalar();
            
            sqlConnection.Close();
            return returnValue.ToString();
        }





        /// <summary>
        /// Retrieves all FG's that are seamstresses
        /// </summary>
        /// <returns>Query for FG id#, first name, and last name that are seamstresses</returns>
        public string AllSeamstresses()
        {
            string query = "SELECT DISTINCT FairyGodmothers.id, FairyGodmothers.firstName, FairyGodmothers.lastName " +
                            "FROM FairyGodmothers " +
                            "WHERE FairyGodmothers.id IN (SELECT fairyGodmotherID FROM ShiftWorkers WHERE ShiftWorkers.roleID = 5)";
            return query;
        }
    }
}


