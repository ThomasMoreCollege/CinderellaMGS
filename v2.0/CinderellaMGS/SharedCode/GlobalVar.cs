using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace CinderellaMGS
{
    ///-----------------------------------------------------------------
    ///   Namespace:      CinderellaMGS
    ///   Class:          GlobalVar
    ///   Description:    Class to maintain global application settings.
    ///   Author:         Nathan Horn                    Date: January 1, 2011
    ///   Notes:          
    ///   Revision History:
    ///   Name:           Date:        Description:
    ///-----------------------------------------------------------------
    public static class GlobalVar
    {
        public static Color FormBackColor = Color.LightPink;
        public static Color ButtonBackColor = Color.LightGreen;
        public static Font LabelFont = new Font("Arial", 10, FontStyle.Regular);
        public static int timerInterval = 10000;
        public static bool masterPairSwitch = true;
      /// <summary>
      /// Will return the current date and time from the sql server so that you do not have to use the date and time on the client computers.
      /// </summary>
      /// <returns>The current date and time form the sql server.</returns>
        static public string getDate()
        {
            SQL_Queries sqlQuery = new SQL_Queries();
            //return '3/18/2011 3:30:00 PM'; //Shift 1
            //return "3/19/2011 7:01:00 AM"; //Shift 2 
            //return '3/19/2011 1:00:00 PM'; //Shift 3
           
            return sqlQuery.getDate();
        }
    }
}
