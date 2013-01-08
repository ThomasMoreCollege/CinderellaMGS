using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Office.Interop;



namespace CinderellaLauncher
{
    ///-----------------------------------------------------------------
    ///   Namespace:      CinderellaMGS
    ///   Class:          
    ///   Description:    Salts and Hashes a string
    ///   Author:         Erik Pratt                    Date: Februaury 4, 2012
    ///   Notes:          
    ///   Revision History:
    ///   Name:           Date:        Description:
    ///-----------------------------------------------------------------
    public class CinderellaUser
    {
      //  2012MasterAppointmentList.xlsx
        

        public string HashString(string ToHash)
        {
            ToHash += "Nathan";//adds a salt
            MD5 MD5Hash = MD5.Create();
            ToHash = Convert.ToBase64String(MD5Hash.ComputeHash(Encoding.UTF8.GetBytes(ToHash)));
            return ToHash;
        }
    }
}
