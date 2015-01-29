using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace CinderellaMGS
{
    ///-----------------------------------------------------------------
    ///   Namespace:      CinderellaMGS
    ///   Class:          GlobalVar
    ///   Description:    This class controls all methods pertaining to users, roles, and accounts.
    ///   Author:         Nathan Horn                    Date: January 1, 2011
    ///   Notes:          
    ///   Revision History:
    ///   Name:           Date:        Description:
    ///-----------------------------------------------------------------
    class UserAccounts
    {
        private DatabaseIO database;
        private SQL_Queries sqlQuery;
        public UserAccounts()//Default Constructor
        {
            //Instantiate the database class
            database = new DatabaseIO();
            sqlQuery = new SQL_Queries();
        }
        /// <summary>
        /// This method will take a password and return the salted hash version to be stored in the database.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string ProtectPassword(string password)
        {
            password += "Nathan";//Lets add some salt to the hash!
            byte[] input = Encoding.UTF8.GetBytes(password);
            byte[] output = MD5.Create().ComputeHash(input);
            string tempPassword = Convert.ToBase64String(output);
            return tempPassword;
        }
        /// <summary>
        /// Allows an account record to be updated.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="lname"></param>
        /// <param name="fname"></param>
        /// <param name="insert"></param>
        /// <returns></returns>
        public bool editAccount(string username, string password, string lname, string fname, bool insert)
        { 
            if (insert)
            {//Insert new record
                try
                {
                    //Hash the password
                    string passwordhash = ProtectPassword(password);

                    string sql = "INSERT INTO [ApplicationLogin]([loginName], [password], [firstName], [lastName], [lastLogin]) VALUES('" +
                        username + "', '" + passwordhash + "', '" + fname + "', '" + lname + "', " + "getDate())";

                    sqlQuery.sqlStatment(sql);
                    MessageBox.Show("The useraccount " + username + " has been successfully created.", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch
                {
                    MessageBox.Show("The useraccount " + username + " was not created. Please try your request again.", "Account Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {//Update existing record
                try
                {
                    //Some Password work
                    DataSet ds = getUserAccountRecord(username);
                    string passwordInDB = ds.Tables[0].Rows[0]["password"].ToString();
                    if (password != passwordInDB)
                    {
                        password = ProtectPassword(password);
                    }
                    //Hash the password
                    //password = ProtectPassword(password);

                    string sql = "UPDATE [ApplicationLogin] SET [password]='" +
                        password + "' , [firstName]='" + fname + "' , [lastName]='" + lname + "' WHERE [loginName]='" + username + "'";
                    sqlQuery.sqlStatment(sql);
                    MessageBox.Show("Changes have been successfully made to " + username + ".", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Changes have not been successfully made to " + username + ". Please try your request again.", "Account Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
        }
        /// <summary>
        /// Deletes a user account as well as all roles associated with it.
        /// </summary>
        /// <param name="username"></param>
        public void deleteUser(string username)
        {
            //Remove all roles
            add_delete_Roles(username, "", false);

            //Delete the account
            string sql = "DELETE FROM [ApplicationLogin] WHERE [loginName]='" + username + "'";
            database.ExecuteQuery(sql);

        }
        /// <summary>
        /// Checks to see if a user has a role.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="role">Role to check</param>
        /// <returns>True-username has role :: False-Username does not have the role</returns>
        public bool userHasRole(string username, string role)
        {
            bool foundRole = false;
            string sql = "Select loginRole From LoginRole Where loginName='" + username + "'";
            DataSet roleData = database.getDataSet(sql, "tableName");
            
            if (roleData.Tables["tableName"].Rows.Count == 0)
            {//User has no roles
                foundRole = false;
                return foundRole;
            }

            foreach (DataRow dr in roleData.Tables[0].Rows)
            {
                //string currentRole = roleData.Tables[0].Rows[0]["loginRole"].ToString();
                //if (roleData.Tables[0].Rows[0]["loginRole"].ToString() == role)
                if (dr["loginRole"].ToString() == role)
                {//The user has the role
                    foundRole = true;
                    return foundRole;
                }

            }
            //Override for the Administrator User Role
            if (roleData.Tables[0].Rows[0]["loginRole"].ToString() == "Administrator" && role != "Developer")
            {//The user has the role
                foundRole = true;
                return foundRole;
            }

            return foundRole;
        }
        /// <summary>
        /// Updates the last login timestamp for a specific username. 
        /// </summary>
        /// <param name="username"></param>
        public void loginTimestamp(string username)
        {
            string sql = "UPDATE [ApplicationLogin] SET [lastLogin]=GetDate() WHERE [loginName]='" + username + "'";
            database.ExecuteQuery(sql);
        }
        /// <summary>
        /// Retrieves all user accounts currently in the system.
        /// </summary>
        /// <returns>DataSet containing name and loginName</returns>
        public DataSet getUsers()
        {
            string sql = "Select lastName + ', ' + firstName as Name, loginName From ApplicationLogin";
            return database.getDataSet(sql, "tableName");
        }
        /// <summary>
        /// Retrieves all data associated with a specific user account.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>DataSet containing the specified users data</returns>
        public DataSet getUserAccountRecord(string username)
        {
            string sql = "Select lastName, firstName, loginName, password, lastLogin From ApplicationLogin where loginName = '" + username + "'";
            return database.getDataSet(sql, "tableName");
        }
        /// <summary>
        /// Retrieves all available roles in the database.
        /// </summary>
        /// <returns>DataSet containing all roles</returns>
        public DataSet getRoles()
        {
            string sql = "Select roleName as TXT, roleName as ID From Role";
            return database.getDataSet(sql, "tableName");
        }
        /// <summary>
        /// Retrieves all roles assigned to a username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>DataSet containing all of the users assigned roles</returns>
        public DataSet getUserAssignedRoles(string username)
        {
            string sql = "Select loginRole From LoginRole where loginName = '" + username + "'";
            return database.getDataSet(sql, "tableName");
        }
        /// <summary>
        /// Adds or removes roles from a user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="role">Role to add or delete</param>
        /// <param name="add">True-Add Role :: False-Remove Role</param>
        public void add_delete_Roles(string username, string role, bool add)
        {
            if (add)
            {//we are adding a role
                string sql = "INSERT INTO [LoginRole]([loginName], [loginRole]) VALUES('" + username + "', '" + role + "')";
              database.ExecuteQuery(sql);
            }
            else
            {//We are removing all the users roles
                string sql = "DELETE FROM [LoginRole] WHERE [loginName]='" + username + "'";
                database.ExecuteQuery(sql);
            }
        }
        /// <summary>
        /// Adds a user account record to the database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="lname"></param>
        /// <param name="fname"></param>
        /// <param name="password"></param>
        public void setUser(string username, string lname, string fname, string password)
        {
            string sql = "INSERT INTO [ApplicationLogin]([loginName], [password], [firstName], [lastName], [lastLogin]) VALUES('";
            sql += username + "', '" + password + "', '" + fname + "', '" + lname + "', getDate())";
            database.ExecuteQuery(sql);
        }        
    }
}
