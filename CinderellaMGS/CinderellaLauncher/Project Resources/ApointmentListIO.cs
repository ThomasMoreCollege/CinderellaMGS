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
        //reads the excel file containing the cinderella information into the database.
        //Input: the excel file containg the cinderella information.
        //Output: cinderellas' have been added to the database.
        //precondition: the cinderella excel file is in the proper format, the database can be connected to, and is in a working state.
        //postcondition: the cinderellas' have been correctly and successfully added to the database.

        //IMPORTANT NOTE: Excel rows and columns start at the value 1.

        [STAThread]
        public void readCinderellas()
        {
            //Values for the progress bar.
            //int overallPercent = 0;
            //int percentCounter = 0;

            //Creates a new array of objects called particulars where the values for a row are stored for analysis.
            object[] particulars_C = new object[7];

            //The following object Value_C will be defined later.
            object Value_C;

            //Creates a new query to move data into the database.
            SQL_Queries Cinderella_Add = new SQL_Queries();

            //Creates an array of strings for errors.
            string[] errors = { "No Good_C" };

            //Creates a new open file dialogue box called FileToBeRead.
            OpenFileDialog fileToBeRead_C = new OpenFileDialog();

            //Opens a new instance of Excel.
            ExcelReader.Application intermediary_C = new ExcelReader.Application();

            //Additional filtering for FileToBeRead.
            fileToBeRead_C.Filter = "Worksheets (*.xls;*.xlsx;*.xlsb;*.xlsm) | *.xls; *.xlsx; *.xlsb; *.xlsm";
            fileToBeRead_C.Multiselect = false;
            DialogResult selection = fileToBeRead_C.ShowDialog();

            //This loop checks that the selected file is an existing Excel file.
            if (selection == DialogResult.OK)
            {

                //Checks to make sure file exists.
                if (!(System.IO.File.Exists(fileToBeRead_C.FileName)))
                {
                    MessageBox.Show("Error: File Not Found.");
                    return;
                }

                //Places the path of the file into a string.
                string Name_of_File = fileToBeRead_C.FileName;

                //Places the extension of a file into a string.
                string Extension_of_File_C = Path.GetExtension(Name_of_File);

                //Checks to make sure that file selected is an Excel file.
                if (Extension_of_File_C == ".xls")
                {

                }

                else if (Extension_of_File_C == ".xlsb")
                {

                }

                else if (Extension_of_File_C == ".xlsm")
                {

                }

                else if (Extension_of_File_C == ".xlsx")
                {

                }

                else
                {
                    MessageBox.Show("Error: Invalid file Type.");
                    return;
                }

                //closetBook will refer to the entire workbook selected to be read.
                ExcelReader.Workbook closetBook_C = intermediary_C.Workbooks.Open(fileToBeRead_C.FileName, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, true);

                //closetSheet will refer to the data sheet where the Cinderellas's infomation is stored.
                ExcelReader.Worksheet closetSheet_C = closetBook_C.Worksheets.get_Item(1);

                //closetTuples refers to only the used range of cells in the Excel sheet.
                ExcelReader.Range closetTuples_C = closetSheet_C.UsedRange;

                //The integer index will refer to the number of a cell in a column that is currently being processd.
                int index = 0;

                //The following variables Date and Time will represent the Date and Time of an Appointment.
                DateTime Appointment_DateTime = new DateTime();
                string TestD;
                string TestT;

                //This loop begins reading values into the database.
                for (int rows = 2; rows <= 406; rows++)
                {

                    //This loop begins to read values for each specific column.
                    for (int columns = 1; columns <= closetTuples_C.Columns.Count; columns++)
                    {

                        //The object Value_C is now assigned to be the value of a certain cell in the closetSheet Excel sheet.
                        Value_C = closetSheet_C.Cells[rows, columns].Value;

                        //The integer correctIndex is assigned to a cell with a special character that needs to be replaced.
                        int correctIndex;

                        //Checks the first column for any cells with special characters and if it finds one, corrects it.
                        if (columns == 1)
                        {

                            particulars_C[index] = Value_C.ToString().Trim();
                            if (particulars_C[index].ToString().Contains("'"))
                            {
                                correctIndex = particulars_C[index].ToString().IndexOf("'");

                                particulars_C[index] = particulars_C[index].ToString().Replace("'", "''");
                                Console.WriteLine(particulars_C[index].ToString());
                                closetSheet_C.Cells[rows, 1] = particulars_C[index];
                            }
                            index++;
                        }

                        //Checks the second column for any cells with special characters and if it finds one, corrects it.
                        else if (columns == 2)
                        {
                            particulars_C[index] = Value_C.ToString().Trim();
                            if (particulars_C[index].ToString().Contains("'"))
                            {
                                correctIndex = particulars_C[index].ToString().IndexOf("'");

                                particulars_C[index] = particulars_C[index].ToString().Replace("'", "''");
                                Console.WriteLine(particulars_C[index].ToString());
                                closetSheet_C.Cells[rows, 2] = particulars_C[index];
                            }
                            index++;
                        }

                        //Checks the third column for any cells with special characters and if it finds one, corrects it.
                        else if (columns == 3)
                        {
                            particulars_C[index] = Value_C.ToString().Trim();
                            if (particulars_C[index].ToString().Contains("'"))
                            {
                                correctIndex = particulars_C[index].ToString().IndexOf("'");

                                particulars_C[index] = particulars_C[index].ToString().Replace("'", "''");
                                Console.WriteLine(particulars_C[index].ToString());
                                closetSheet_C.Cells[rows, 3] = particulars_C[index];
                            }
                            index++;
                        }

                        //Checks the fourth column for any cells with special characters and if it finds one, corrects it.
                        else if (columns == 4)
                        {
                            particulars_C[index] = Value_C.ToString().Trim();
                            if (particulars_C[index].ToString().Contains("'"))
                            {
                                correctIndex = particulars_C[index].ToString().IndexOf("'");

                                particulars_C[index] = particulars_C[index].ToString().Replace("'", "''");
                                Console.WriteLine(particulars_C[index].ToString());
                                closetSheet_C.Cells[rows, 4] = particulars_C[index];
                            }
                            index++;
                        }

                        //Checks the fifth column for any cells with special characters and if it finds one, corrects it.
                        else if (columns == 5)
                        {
                            particulars_C[index] = Value_C.ToString().Trim();
                            if (particulars_C[index].ToString().Contains("'"))
                            {
                                correctIndex = particulars_C[index].ToString().IndexOf("'");

                                particulars_C[index] = particulars_C[index].ToString().Replace("'", "''");
                                Console.WriteLine(particulars_C[index].ToString());
                                closetSheet_C.Cells[rows, 5] = particulars_C[index];
                            }
                            index++;
                        }

                        //Formats the sixth column into the Date and Time columns.
                        else if (columns == 6)
                        {
                            particulars_C[index] = Value_C.ToString().Trim();
                            Appointment_DateTime = Convert.ToDateTime(Value_C);

                            TestD = Appointment_DateTime.Date.ToString();
                            TestT = Appointment_DateTime.TimeOfDay.ToString();

                            //Potentially Obsolete Code
                            //The Value for particulars[index] is then split into two strings at the ' '.
                            //These two strings are then placed into an array of strings called DateandTime
                            //string[] DateandTime = particulars_C[index].ToString().Trim().Split(' ');

                            //Potentially Obsolete Code
                            //The string DateandTime[0], which contains the appointment date, is now placed in the correct spots.
                            //Appointment_DateTime = Convert.ToDateTime(Value_C);

                            //Potentially Obsolete Code
                            /*Console.WriteLine(particulars_C[index].ToString());
                            closetSheet_C.Cells[rows, 6] = particulars_C[index];
                            index++;*/

                            //Potentially Obsolete Code
                            //The string DateandTime[1], which contains the appointment time, is now placed in the correct spots.
                            //Appointment_Time = Convert.ToDateTime(DateandTime[1]);

                            //Potentially Obsolete Code
                            /*Console.WriteLine(particulars_C[index].ToString());
                            closetSheet_C.Cells[rows, 7] = particulars_C[index];
                            index++;*/
                        }

                    }
                    index = 0;
                    TestD = Appointment_DateTime.Date.ToString();
                    TestT = Appointment_DateTime.TimeOfDay.ToString();

                    //The query will finally begin to add the data from the Excel sheet to the database.
                    Cinderella_Add.addCinderellaAndReferral(closetSheet_C.Cells[rows, 3].Value.ToString() + " " + closetSheet_C.Cells[rows, 4].Value.ToString(), closetSheet_C.Cells[rows, 5].Value.ToString(), closetSheet_C.Cells[rows, 1].Value.ToString(), closetSheet_C.Cells[rows, 2].Value.ToString(), TestD, TestT, "");

                    //Code for progress bar.

                }

                //Closes out of Excel.
                closetBook_C.Close();
                intermediary_C.Quit();
                Marshal.ReleaseComObject(intermediary_C);
                Marshal.ReleaseComObject(closetBook_C);
                Marshal.ReleaseComObject(closetSheet_C);
                Marshal.ReleaseComObject(closetTuples_C);
                GC.Collect();
            }

        }

        //readGodmothers
        //reads the excel file containing the godmother information into the db
        //Input: the excel file containg the godmother information
        //Output: godmother's have been added to the db
        //precondition: the godmother excel file is in the proper format and the db is connectable and is in a working state
        //postcondition: the godmother's have been correctly added to the db

        //IMPORTANT NOTE: Excel rows and columns start at the value 1.

        public void readGodmothers()
        {
            //Values for the progress bar.
            //int overallPercent = 0;
            //int percentCounter = 0;

            //Creates a new array of objects called particulars_G where the values for a row are stored for analysis.
            object[] particulars_G = new object[8];

            //This string is specifically for the use of analysing the Fairy Godmother Roles for a shift.
            string particulars_Shift;

            //An integer that represents a shift.
            int shiftID = 0;

            //An integer that represents a role.
            int roleID = 0;

            //The following object Value_C will be defined later.
            object Value_G;

            //Creates a new query to move data into the database.
            SQL_Queries Godmother_Add = new SQL_Queries();

            //Creates an array of strings for errors.
            string[] errors = { "No Good_G" };

            //Creates a new open file dialogue box called FileToBeRead.
            OpenFileDialog fileToBeRead_G = new OpenFileDialog();

            //Opens a new instance of Excel.
            ExcelReader.Application intermediary_G = new ExcelReader.Application();

            //Additional filtering for FileToBeRead.
            fileToBeRead_G.Filter = "Worksheets (*.xls;*.xlsx;*.xlsb;*.xlsm) | *.xls; *.xlsx; *.xlsb; *.xlsm";
            fileToBeRead_G.Multiselect = false;
            DialogResult selection = fileToBeRead_G.ShowDialog();

            //This loop checks that the selected file is an existing Excel file.
            if (selection == DialogResult.OK)
            {

                //Checks to make sure file exists.
                if (!(System.IO.File.Exists(fileToBeRead_G.FileName)))
                {
                    MessageBox.Show("Error: File Not Found.");
                    return;
                }

                //Places the path of the file into a string.
                string Name_of_File = fileToBeRead_G.FileName;

                //Places the extension of a file into a string.
                string Extension_of_File_G = Path.GetExtension(Name_of_File);

                //Checks to make sure that file selected is an Excel file.
                if (Extension_of_File_G == ".xls")
                {

                }

                else if (Extension_of_File_G == ".xlsb")
                {

                }

                else if (Extension_of_File_G == ".xlsm")
                {

                }

                else if (Extension_of_File_G == ".xlsx")
                {

                }

                else
                {
                    MessageBox.Show("Error: Invalid file Type.");
                    return;
                }

                //closetBook will refer to the entire workbook selected to be read.
                ExcelReader.Workbook closetBook_G = intermediary_G.Workbooks.Open(fileToBeRead_G.FileName, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, true);

                //closetSheet will refer to the data sheet where the Cinderellas's infomation is stored.
                ExcelReader.Worksheet closetSheet_G = closetBook_G.Worksheets.get_Item(1);

                //closetTuples refers to only the used range of cells in the Excel sheet.
                ExcelReader.Range closetTuples_G = closetSheet_G.UsedRange;

                //The integer index will refer to the number of a cell in a column that is currently being processd.
                int index = 0;

                //This loop begins reading values into the database.
                for (int rows = 2; rows <= 272; rows++)
                {

                    //This loop begins to read values for each specific column.
                    //It stops at column 8 due to columns 9 through 11 being shift related.
                    for (int columns = 1; columns <= 8; columns++)
                    {

                        //The object Value_C is now assigned to be the value of a certain cell in the closetSheet Excel sheet.
                        Value_G = closetSheet_G.Cells[rows, columns].Value;

                        //The integer correctIndex is assigned to a cell with a special character that needs to be replaced.
                        int correctIndex;

                        //Checks the first column for any cells with special characters and if it finds one, corrects it.
                        if (columns == 1)
                        {
                            particulars_G[index] = Value_G.ToString().Trim();
                            if (particulars_G[index].ToString().Contains("'"))

                            {
                                correctIndex = particulars_G[index].ToString().IndexOf("'");

                                particulars_G[index] = particulars_G[index].ToString().Replace("'", "''");
                                Console.WriteLine(particulars_G[index].ToString());
                                closetSheet_G.Cells[rows, 1] = particulars_G[index];
                            }

                            index++;
                        }

                        //Checks the second column for any cells with special characters and if it finds one, corrects it.
                        else if (columns == 2)
                        {
                            particulars_G[index] = Value_G.ToString().Trim();
                            if (particulars_G[index].ToString().Contains("'"))
                            {
                                correctIndex = particulars_G[index].ToString().IndexOf("'");

                                particulars_G[index] = particulars_G[index].ToString().Replace("'", "''");
                                Console.WriteLine(particulars_G[index].ToString());
                                closetSheet_G.Cells[rows, 2] = particulars_G[index];
                            }
                            index++;
                        }

                        //Places the contents of third column in a string.
                        else if (columns == 3)
                        {
                            if (Value_G == null)
                            {

                            }
                            else
                            particulars_G[index] = Value_G.ToString().Trim();
                            index++;
                        }

                        //Places the contents of fourth column in a string.
                        else if (columns == 4)
                        {
                            if (Value_G == null)
                            {
                                Value_G = "NULL";
                                Console.WriteLine(Value_G.ToString());
                                closetSheet_G.Cells[rows, 4] = Value_G;
                            }

                            if (Value_G.ToString().Trim().Contains('(') || Value_G.ToString().Trim().Contains(')') || Value_G.ToString().Trim().Contains('-') || Value_G.ToString().Trim().Contains(' '))
                            {
                                Value_G = "NULL";
                                Console.WriteLine(Value_G.ToString());
                                closetSheet_G.Cells[rows, 4] = Value_G;
                            }

                            particulars_G[index] = Value_G.ToString().Trim();
                            index++;

                        }

                        //Places the contents of fifth column in a string.
                        else if (columns == 5)
                        {
                            if (Value_G == null)
                            {
                                Value_G = "NULL";
                                Console.WriteLine(Value_G.ToString());
                                closetSheet_G.Cells[rows, 5] = Value_G;
                            }

                            particulars_G[index] = Value_G.ToString().Trim();
                            index++;

                        }

                        //Places the contents of sixth column in a string.
                        else if (columns == 6)
                        {
                            if (Value_G == null)
                            {
                                Value_G = "NULL";
                                Console.WriteLine(Value_G.ToString());
                                closetSheet_G.Cells[rows, 6] = Value_G;
                            }

                            particulars_G[index] = Value_G.ToString().Trim();
                            index++;

                        }

                        //Places the contents of seventh column in a string.
                        else if (columns == 7)
                        {
                            if (Value_G == null)
                            {
                                Value_G = "NULL";
                                Console.WriteLine(Value_G.ToString());
                                closetSheet_G.Cells[rows, 7] = Value_G;
                            }

                            particulars_G[index] = Value_G.ToString().Trim();
                            index++;

                        }

                        //Places the contents of eigth column in a string.
                        else if (columns == 8)
                        {
                            if (Value_G == null)
                            {
                                Value_G = "NULL";
                                Console.WriteLine(Value_G.ToString());
                                closetSheet_G.Cells[rows, 8] = Value_G;
                            }

                            particulars_G[index] = Value_G.ToString().Trim();

                            string Value_to_Check = particulars_G[index].ToString();

                            string Value_to_Compare = "0";

                            if (Value_to_Check == Value_to_Compare)
                            {
                                Value_to_Check = "NULL";
                                particulars_G[index] = Value_to_Check;
                                Console.WriteLine(particulars_G[index].ToString());
                                closetSheet_G.Cells[rows, 8] = particulars_G[index];
                            }

                            index++;

                        }
                    }
                    index = 0;

                    //The query will finally begin to add the data from the Excel sheet to the database.
                    Godmother_Add.NewGodMother(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), closetSheet_G.Cells[rows, 5].Value.ToString(), closetSheet_G.Cells[rows, 6].Value.ToString(), closetSheet_G.Cells[rows, 3].Value.ToString(), closetSheet_G.Cells[rows, 4].Value.ToString(), closetSheet_G.Cells[rows, 7].Value.ToString(), closetSheet_G.Cells[rows, 8].Value.ToString());

                    //Code for progress bar.

                }



                //This loop begins reading values into the database for the Fairy Godmother shifts.
                for (int rows = 2; rows <= 272; rows++)
                {

                    //This loop begins to read values for each of the three shift columns.
                    //It begins at column 9 because the Shift information begins at column 9.
                    for (int columns = 9; columns <= closetTuples_G.Columns.Count; columns++)
                    {

                        //The object Value_G is now assigned to be the value of a certain cell in the closetSheet Excel sheet.
                        Value_G = closetSheet_G.Cells[rows, columns].Value;

                        //The integer correctIndex is assigned to a cell with a special character that needs to be replaced.
                        //int correctIndex;

                        //Places the contents of column 9 (the shift and role IDs) into the particulars_Shift object.
                        if (columns == 9)
                        {
                            shiftID = 1;
                            particulars_Shift = Value_G.ToString().Trim();
                            string CompareRoles = particulars_Shift;

                            //The following strings represent any possible value for the role columns.
                            string NotVolunteering = "Not Volunteering";
                            string NullString = "NULL";
                            string EmptyString = "";
                            string PersonalShopper = "Personal Shopper";
                            string Alterations = "Alterations";

                            if (CompareRoles == NotVolunteering || CompareRoles == NullString || CompareRoles == EmptyString || CompareRoles == null)
                            {
                                continue;
                            }

                            else if (CompareRoles == PersonalShopper)
                            {
                                roleID = 4;
                                Godmother_Add.newFGShiftWorker(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), shiftID, roleID);
                            }

                            else if (CompareRoles == Alterations)
                            {
                                roleID = 5;
                                Godmother_Add.newFGShiftWorker(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), shiftID, roleID);
                            }

                            else
                            {
                                roleID = 6;
                                Godmother_Add.newFGShiftWorker(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), shiftID, roleID);
                            }

                        }

                        //Places the contents of column 10 (the shift and role IDs) into the particulars_Shift object.
                        else if (columns == 10)
                        {
                            shiftID = 2;
                            particulars_Shift = Value_G.ToString().Trim();
                            string CompareRoles = particulars_Shift;

                            //The following strings represent any possible value for the role columns.
                            string NotVolunteering = "Not Volunteering";
                            string NullString = "NULL";
                            string EmptyString = "";
                            string PersonalShopper = "Personal Shopper";
                            string Alterations = "Alterations";

                            if (CompareRoles == NotVolunteering || CompareRoles == NullString || CompareRoles == EmptyString || CompareRoles == null)
                            {
                                continue;
                            }

                            else if (CompareRoles == PersonalShopper)
                            {
                                roleID = 4;
                                Godmother_Add.newFGShiftWorker(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), shiftID, roleID);
                            }

                            else if (CompareRoles == Alterations)
                            {
                                roleID = 5;
                                Godmother_Add.newFGShiftWorker(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), shiftID, roleID);
                            }

                            else
                            {
                                roleID = 6;
                                Godmother_Add.newFGShiftWorker(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), shiftID, roleID);
                            }

                        }

                        //Places the contents of column 9 (the shift and role IDs) into the particulars_Shift object.
                        else if (columns == 11)
                        {
                            shiftID = 3;
                            particulars_Shift = Value_G.ToString().Trim();
                            string CompareRoles = particulars_Shift;

                            //The following strings represent any possible value for the role columns.
                            string NotVolunteering = "Not Volunteering";
                            string NullString = "NULL";
                            string EmptyString = "";
                            string PersonalShopper = "Personal Shopper";
                            string Alterations = "Alterations";

                            if (CompareRoles == NotVolunteering || CompareRoles == NullString || CompareRoles == EmptyString || CompareRoles == null)
                            {
                                continue;
                            }

                            else if (CompareRoles == PersonalShopper)
                            {
                                roleID = 4;
                                Godmother_Add.newFGShiftWorker(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), shiftID, roleID);
                            }

                            else if (CompareRoles == Alterations)
                            {
                                roleID = 5;
                                Godmother_Add.newFGShiftWorker(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), shiftID, roleID);
                            }

                            else
                            {
                                roleID = 6;
                                Godmother_Add.newFGShiftWorker(closetSheet_G.Cells[rows, 1].Value.ToString(), closetSheet_G.Cells[rows, 2].Value.ToString(), shiftID, roleID);
                            }

                        }

                    }

                    //Code for progress bar.

                }

                closetBook_G.Close();
                intermediary_G.Quit();
                Marshal.ReleaseComObject(intermediary_G);
                Marshal.ReleaseComObject(closetBook_G);
                Marshal.ReleaseComObject(closetSheet_G);
                Marshal.ReleaseComObject(closetTuples_G);
                GC.Collect();


            }
        }
    }
}
