using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.CSharp.RuntimeBinder;
using ExcelReader = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using CinderellaLauncher;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Drawing;

namespace BusinessLogic
{

    public class ApointmentListIO
    {
        //readCinderellas
        //reads the excel file containing the cinderella information into the db
        //Input: the excel file containg the cinderella information
        //Output: cinderella's have been added to the db
        //precondition: the cinderella excel file is in the proper format and the db is connectable and is in a working state
        //postcondition: the cinderella's have been correctly added to the db

        //IMPORTANT NOTE: Excel rows and columns start at the value 1.

        [STAThread]
        public void readCinderellas()
        {
            //Values for the progress bar.

            //Creates a new query to move data into the database.

            //Creates an array of strings for errors.

            //Creates a new open file dialogue box called FileToBeRead.

            //Opens a new instance of Excel.

            //Creates a new array of objects called particulars where the values for a row are stored for analysis.

            //The following object Value_C will be defined later.

            //Additional filtering for FileToBeRead.

            //Checks to make sure file exists.

            //Checks to make sure that file selected is an Excel file.

            //closetBook will refer to the entire workbook selected to be read.

            //closetSheet will refer to the data sheet where the Cinderellas's infomation is stored.

            //closetTuples refers to only the used range of cells in the Excel sheet.

            //The integer index will refer to the number of a cell in a column.

            //This loop begins reading values into the database.

            //This loop begins to read values for each specific column.

            //The object Value_C is now assigned to be the value of a certain cell in the closetSheet Excel sheet.

            //The integer correctIndex is assigned to a cell with a special character that needs to be replaced.

            //Checks the first column for any cells with special characters and if it finds one, corrects it.

            //Checks the second column for any cells with special characters and if it finds one, corrects it.

            //Formats the third column into DateTime format.

            //Formats the fourth column into DateTime format.

            //Places the contents of fifth column in a string.

            //Places the contents of sixth column in a string.

            //Places the contents of seventh column in a string.

            //The query will finally begin to add the data from the Excel sheet to the database.

            //Code for progress bar.

            //Closes out of Excel.

        }

        //readGodmothers
        //reads the excel file containing the godmother information into the db
        //Input: the excel file containg the godmother information
        //Output: godmother's have been added to the db
        //precondition: the godmother excel file is in the proper format and the db is connectable and is in a working state
        //postcondition: the godmother's have been correctly added to the db
        public void readGodmothers()
        {
            //Creates a new query for to move the data into the database.
            SQL_Queries yayAgain = new SQL_Queries();
            //NOTE: for excel files row and column numbers start at 1 not zero.

            //creates excel object and gets the file ready to read


            string[] errors = { "No Good2" };

            //Calls a new open file dialog to select Excel file to be read.
            OpenFileDialog fileToBeRead = new OpenFileDialog();

            ////Opens a new instance of Excel.
            ExcelReader.Application intermediary2 = new ExcelReader.Application();

            object whatelement;
            object shiftElement;
            int shiftID = 0;
            int roleID = 0;
            fileToBeRead.Filter = "Worksheets (*.xls;*.xlsx;*.xlsb;*.xlsm) | *.xls; *.xlsx; *.xlsb; *.xlsm";
            fileToBeRead.Multiselect = false;
            DialogResult selection = fileToBeRead.ShowDialog();

            if (selection == DialogResult.OK)
            {
                if (!(System.IO.File.Exists(fileToBeRead.FileName)))
                {
                    MessageBox.Show("Error: File Not Found.");
                    return;
                }
                //checks the extension
                if (System.IO.Path.GetExtension(fileToBeRead.FileName) != ".xls" || System.IO.Path.GetExtension(fileToBeRead.FileName) != ".xlsx" || System.IO.Path.GetExtension(fileToBeRead.FileName) != ".xlsb" || System.IO.Path.GetExtension(fileToBeRead.FileName) != ".xlsm")
                {
                    MessageBox.Show("Error: Invalid file Type.");
                    return;
                }
                ExcelReader.Workbook closetBook2 = intermediary2.Workbooks.Open(fileToBeRead.FileName, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, true);


                ExcelReader.Worksheet closetSheet2 = closetBook2.Worksheets.get_Item(3);
                ExcelReader.Range closetTuples2 = closetSheet2.UsedRange;

                for (int rows = 5; rows <= closetTuples2.Rows.Count; rows++)
                {
                    for (int columns = 1; columns < 11; columns++)
                    {
                        whatelement = closetSheet2.Cells[rows, columns].Value;

                        if (whatelement == null)
                        {
                            continue;
                        }
                        if (whatelement.ToString().Trim().Contains('(') && whatelement.ToString().Trim().Contains(')') && whatelement.ToString().Trim().Contains('-'))
                        {
                            //corrections
                            whatelement = whatelement.ToString().Trim().Replace("(", "");
                            whatelement = whatelement.ToString().Trim().Replace(")", "");
                            whatelement = whatelement.ToString().Trim().Replace("-", "");
                            whatelement = whatelement.ToString().Trim().Replace(" ", "");

                            closetSheet2.Cells[rows, 9] = whatelement.ToString().Trim();
                        }

                        if (whatelement.ToString().Trim().Contains("'"))
                        {



                            whatelement = whatelement.ToString().Trim().Replace("'", "''");
                            closetSheet2.Cells[rows, 3] = whatelement.ToString().Trim();
                            Console.WriteLine(closetSheet2.Cells[rows, 3].Value.ToString());


                        }
                    }

                    try
                    {

                        if (closetSheet2.Cells[rows, 6].Value == null && closetSheet2.Cells[rows, 5].Value == null)
                        {
                            yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), "NULL", closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                            continue;
                        }
                        else if (closetSheet2.Cells[rows, 5].Value == null && closetSheet2.Cells[rows, 10].Value == null)
                        {
                            yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), "NULL", closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                        }
                        else if (closetSheet2.Cells[rows, 5].Value == null && closetSheet2.Cells[rows, 8].Value == null)
                        {
                            yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), "NULL");
                            continue;
                        }
                        else if (closetSheet2.Cells[rows, 9].Value == null && closetSheet2.Cells[rows, 5].Value == null)
                        {
                            yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), "NULL", closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                            continue;
                        }
                        else if (closetSheet2.Cells[rows, 8].Value == null)
                        {
                            yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), "NULL");
                            continue;
                        }
                        else if (closetSheet2.Cells[rows, 9].Value == null)
                        {
                            yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), "NULL", closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                            continue;
                        }
                        else if (closetSheet2.Cells[rows, 5].Value == null)
                        {
                            yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                            continue;
                        }
                        else if (closetSheet2.Cells[rows, 5].Value != null)
                        {
                            yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString() + closetSheet2.Cells[rows, 5].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                            continue;
                        }

                    }
                    catch (RuntimeBinderException ohno)
                    {
                        // continue;
                    }
                }



                for (int rightSideRows = 5; rightSideRows < closetTuples2.Rows.Count; rightSideRows++)
                {
                    for (int columnSides = 2; columnSides < 20; columnSides++)
                    {
                        //First element will be fairyGodmotherID, then the rest is just sorting
                        //out the Role and Shift information!
                        if (columnSides > 3 && columnSides < 12) //was 12!
                        {
                            continue;
                        }

                        //If a godmother's role changes when a time slot changes, that must be
                        //stored
                        shiftElement = closetSheet2.Cells[rightSideRows, columnSides].Value;

                        if (shiftElement == null)
                        {
                            continue;
                        }

                        if (shiftElement.ToString().Trim() == "X")
                        {
                            if (roleID > 0 && shiftID > 0)
                            {
                                // continue;
                            }
                            switch (columnSides)
                            {
                                //Friday, PM time slot, Personal Shopper
                                case 12: roleID = 4; shiftID = 1;
                                    yayAgain.newFGShiftWorker(closetSheet2.Cells[rightSideRows, 2].Value.ToString(), closetSheet2.Cells[rightSideRows, 3].Value.ToString(), shiftID, roleID);
                                    break;
                                //Friday, PM time slot, Volunteer
                                case 13: roleID = 6; shiftID = 1;
                                    yayAgain.newFGShiftWorker(closetSheet2.Cells[rightSideRows, 2].Value.ToString(), closetSheet2.Cells[rightSideRows, 3].Value.ToString(), shiftID, roleID);
                                    break;
                                //Friday, PM time slot, Alterator 
                                case 14: roleID = 5; shiftID = 1;
                                    yayAgain.newFGShiftWorker(closetSheet2.Cells[rightSideRows, 2].Value.ToString(), closetSheet2.Cells[rightSideRows, 3].Value.ToString(), shiftID, roleID);
                                    break;
                                //Saturday, AM time slot, Personal Shopper
                                case 15: roleID = 4; shiftID = 2;
                                    yayAgain.newFGShiftWorker(closetSheet2.Cells[rightSideRows, 2].Value.ToString(), closetSheet2.Cells[rightSideRows, 3].Value.ToString(), shiftID, roleID);
                                    break;
                                //Saturday, AM time slot, Volunteer
                                case 16: roleID = 6; shiftID = 2;
                                    yayAgain.newFGShiftWorker(closetSheet2.Cells[rightSideRows, 2].Value.ToString(), closetSheet2.Cells[rightSideRows, 3].Value.ToString(), shiftID, roleID);
                                    break;
                                //Saturday, AM time slot, Alterator
                                case 17: roleID = 5; shiftID = 2;
                                    yayAgain.newFGShiftWorker(closetSheet2.Cells[rightSideRows, 2].Value.ToString(), closetSheet2.Cells[rightSideRows, 3].Value.ToString(), shiftID, roleID);
                                    break;
                                //Saturday, PM time slot, Personal Shopper
                                case 18: roleID = 4; shiftID = 3;
                                    yayAgain.newFGShiftWorker(closetSheet2.Cells[rightSideRows, 2].Value.ToString(), closetSheet2.Cells[rightSideRows, 3].Value.ToString(), shiftID, roleID);
                                    break;
                                //Saturday, PM time slot, Volunteer
                                case 19: roleID = 6; shiftID = 3;
                                    yayAgain.newFGShiftWorker(closetSheet2.Cells[rightSideRows, 2].Value.ToString(), closetSheet2.Cells[rightSideRows, 3].Value.ToString(), shiftID, roleID);
                                    break;
                                //Saturday, PM time slot, Alterator
                                case 20: roleID = 5; shiftID = 3;
                                    yayAgain.newFGShiftWorker(closetSheet2.Cells[rightSideRows, 2].Value.ToString(), closetSheet2.Cells[rightSideRows, 3].Value.ToString(), shiftID, roleID);
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                }
                closetBook2.Close();
                intermediary2.Quit();
                Marshal.ReleaseComObject(intermediary2);
                Marshal.ReleaseComObject(closetBook2);
                Marshal.ReleaseComObject(closetSheet2);
                Marshal.ReleaseComObject(closetTuples2);
                GC.Collect();


            }
        }
    }
}
