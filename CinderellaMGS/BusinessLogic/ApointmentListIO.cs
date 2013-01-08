using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using Microsoft.Office.Interop;
using Microsoft.CSharp.RuntimeBinder;
using ExcelReader = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;


namespace BusinessLogic
{
   public class ApointmentListIO
    {
public Array readFromExcel()

                {
    
            //NOTE: for excel files row and column numbers start at 1 not zero.

            //creates excel object and gets the file ready to read
                    //This is the classPath that I had in for 2012 file
                    //   "C:\\Users\\crmill01\\Documents\\Cinderella Project\\cinderellamgs\\CinderellaMGS\\CinderellaLauncher\\bin\\Debug\\Copy_of_2012MasterAppointmentList.xlsx"
                    //C:\Users\crmill01\Documents\Cinderella Project\cinderellamgs\CinderellaMGS\CinderellaLauncher\bin\Debug\Copy_of_2012 Volunteer Registration NKY.xls
                    //"C:\Copy of 2012MasterAppointmentList.xlsx"
            ExcelReader.Application intermediary = new ExcelReader.Application();
            if (!(System.IO.File.Exists("C:\\Copy of 2012MasterAppointmentList_1.xlsx")))
            {
                string error = "2.4";
                return error.ToArray();
            }
            ExcelReader.Workbook cinderellaBook = intermediary.Workbooks.Open("C:\\Copy of 2012MasterAppointmentList_1.xlsx", Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, true);
            ExcelReader.Worksheet cinderellaSheet = cinderellaBook.Worksheets.get_Item(1);
            ExcelReader.Range cinderellaTuples = cinderellaSheet.UsedRange;
            Console.WriteLine(cinderellaTuples.Rows.Count);
            Console.WriteLine(cinderellaTuples.Columns.Count);

            string[,] valueSet = new string[cinderellaTuples.Count, cinderellaTuples.Count];
           
           
          
        for(int rows = 2; rows <= cinderellaTuples.Rows.Count; rows++)
        {
           for(int columns = 1; columns < cinderellaTuples.Columns.Count; columns++)
           {
               if (columns == 4)
               {
                   
               }
               object what = cinderellaTuples.Cells[rows, columns].Value;
             // object whatme = cinderellaSheet.Cells[rows, columns];
               if (what == null)
               {
                  // Console.WriteLine("WHAT IS GOING ON");
               }
               else
               {
                   valueSet[rows, columns] = what.ToString().Trim();
                   Console.WriteLine(valueSet[rows, columns]);
                 
               }
           }
        }
for (int xrows = 1; xrows < cinderellaTuples.Rows.Count; xrows++)            {
                //TODO: check to make sure that line 1 is not the field discraiptor line
                //cinderellaSheet.Cells[index,1].value gets value in collumn 1 row == index
                //TODO: grab each collumn like above and send to DB
            }


           // Console.ReadLine();
            cinderellaBook.Close();
            return valueSet;
        }
    }
}
