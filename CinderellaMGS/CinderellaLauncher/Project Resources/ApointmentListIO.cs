using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using Microsoft.Office.Interop;
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
        [STAThread]
        public void readCinderellas()
        {
            int overallPercent = 0;
            int percentCounter = 0;
           // Console.WriteLine(Thread.CurrentThread.ToString());
            SQL_Queries yay = new SQL_Queries();
            //NOTE: for excel files row and column numbers start at 1 not zero.

            //creates excel object and gets the file ready to read

            //  string[,] valueSet;
            string[] errors = { "No Good" };
            OpenFileDialog fileToBeRead = new OpenFileDialog();
            ExcelReader.Application intermediary = new ExcelReader.Application();
            object[] particulars = new object[4];
            object what;
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
                if (System.IO.Path.GetExtension(fileToBeRead.FileName) != ".xls" ||System.IO.Path.GetExtension(fileToBeRead.FileName) != ".xlsx" ||System.IO.Path.GetExtension(fileToBeRead.FileName) != ".xlsb" ||System.IO.Path.GetExtension(fileToBeRead.FileName) != ".xlsm")
                {
                    MessageBox.Show("Error: Invalid file Type.");
                    return;
                }
                
                    ExcelReader.Workbook closetBook = intermediary.Workbooks.Open(fileToBeRead.FileName, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing, true);


                    ExcelReader.Worksheet closetSheet = closetBook.Worksheets.get_Item(1);
                    ExcelReader.Range closetTuples = closetSheet.UsedRange;



                    int index = 0;



                    for (int rows = 2; rows <= closetTuples.Rows.Count; rows++)
                    {
                        for (int columns = 1; columns < closetTuples.Columns.Count; columns++)
                        {
                            if (columns == 4)
                            {
                                //  continue;
                            }

                            what = closetSheet.Cells[rows, columns].Value;
                            // object whatme = cinderellaSheet.Cells[rows, columns];
                            if (what == null)
                            {
                                // Console.WriteLine("WHAT IS GOING ON");
                            }
                            else
                            {
                                int correctIndex;
                                if (columns == 8)
                                {

                                    particulars[index] = what.ToString().Trim();
                                    if (particulars[index].ToString().Contains("'"))
                                    {


                                        correctIndex = particulars[index].ToString().IndexOf("'");

                                        particulars[index] = particulars[index].ToString().Replace("'", "''");
                                        Console.WriteLine(particulars[index].ToString());
                                        closetSheet.Cells[rows, 8] = particulars[index];


                                    }

                                    index++;

                                }
                                else if (columns == 9)
                                {
                                    particulars[index] = what.ToString().Trim();

                                    if (particulars[index].ToString().Contains("'"))
                                    {


                                        correctIndex = particulars[index].ToString().IndexOf("'");

                                        particulars[index] = particulars[index].ToString().Replace("'", "''");
                                        Console.WriteLine(particulars[index].ToString());
                                        closetSheet.Cells[rows, 9] = particulars[index];


                                    }


                                    index++;

                                }
                                else if (columns == 10)
                                {
                                    particulars[index] = what.ToString().Trim();
                                    index++;

                                }
                                else if (columns == 11)
                                {
                                    particulars[index] = what.ToString().Trim();
                                    index++;

                                }
                                else if (columns == 12)
                                {
                                    particulars[index] = what.ToString().Trim();

                                }




                            }
                            index = 0;
                        }


                        DateTime converter = new DateTime();
                        DateTime timeConv = new DateTime();
                        try
                        {
                            converter = Convert.ToDateTime(closetSheet.Cells[rows, 3].Value.ToString() + " " + 2012);
                            timeConv = Convert.ToDateTime(closetSheet.Cells[rows, 5].Value.ToString());

                            if (closetSheet.Cells[rows, 6].Value.ToString() == "PM")
                            {
                                //   timeConv = timeConv.AddHours(12);
                                //   Console.WriteLine(timeConv.ToShortTimeString());
                                if (timeConv.ToShortTimeString() == "12:00 PM" || timeConv.ToShortTimeString() == "12:30 PM")
                                {
                                    //closetSheet.Cells[rows, 6].Value = "PM";
                                    //  timeConv = timeConv.AddHours(12);
                                }
                                else
                                {

                                    timeConv = timeConv.AddHours(12);
                                }


                            }
                        }
                        catch (FormatException bleh)
                        {

                            continue;
                        }
                        catch (RuntimeBinderException meh)
                        {
                            continue;
                        }
                        try
                        {


                            yay.addCinderellaAndReferral(closetSheet.Cells[rows, 11].Value.ToString() + closetSheet.Cells[rows, 12].Value.ToString(), closetSheet.Cells[rows, 10].Value.ToString(), closetSheet.Cells[rows, 8].Value.ToString(), closetSheet.Cells[rows, 9].Value.ToString(), converter.ToString(), timeConv.ToString(), "");

                            percentCounter++;
                            //closer to 4.76
                            if (percentCounter == 4)
                            {
                                CinderellaLauncher.AdminMenu.cinderellaProgess.Value += 1;
                                overallPercent = (int)(((double)CinderellaLauncher.AdminMenu.cinderellaProgess.Value / (double)CinderellaLauncher.AdminMenu.cinderellaProgess.Maximum) * 100);
                                CinderellaLauncher.AdminMenu.cinderellaProgess.Refresh();
                                CinderellaLauncher.AdminMenu.cinderellaProgess.CreateGraphics().DrawString(overallPercent.ToString() + "% Complete", new Font("System", (float)9.25, FontStyle.Regular), System.Drawing.Brushes.Black, new System.Drawing.PointF(CinderellaLauncher.AdminMenu.cinderellaProgess.Width / 2 - 10, CinderellaLauncher.AdminMenu.cinderellaProgess.Height / 2 - 7));
                                percentCounter = 0;

                            }
                            else
                            {

                            }

                        }
                        catch (Exception e)
                        {
                            continue;
                        }

                    }







                    // Console.ReadLine();
                    closetBook.Close();
                    intermediary.Quit();
                    Marshal.ReleaseComObject(intermediary);
                    Marshal.ReleaseComObject(closetBook);
                    Marshal.ReleaseComObject(closetSheet);
                    Marshal.ReleaseComObject(closetTuples);
                    GC.Collect();
                

            }



        }

        //readGodmothers
        //reads the excel file containing the godmother information into the db
        //Input: the excel file containg the godmother information
        //Output: godmother's have been added to the db
        //precondition: the godmother excel file is in the proper format and the db is connectable and is in a working state
        //postcondition: the godmother's have been correctly added to the db
        public void readGodmothers()
        {
            SQL_Queries yayAgain = new SQL_Queries();
            //NOTE: for excel files row and column numbers start at 1 not zero.

            //creates excel object and gets the file ready to read

            //  string[,] valueSet;
            string[] errors = { "No Good2" };
            OpenFileDialog fileToBeRead = new OpenFileDialog();
            ExcelReader.Application intermediary2 = new ExcelReader.Application();
            //  object[] particulars = new object[4];
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
                   // bool iKnow = false;
                    for (int rows = 5; rows <= closetTuples2.Rows.Count; rows++)
                    {
                        for (int columns = 1; columns < 11; columns++)
                        {
                            whatelement = closetSheet2.Cells[rows, columns].Value;
                            // object whatme = cinderellaSheet.Cells[rows, columns];
                            if (whatelement == null)
                            {
                                continue;
                                // Console.WriteLine("WHAT IS GOING ON");
                            }
                                if (whatelement.ToString().Trim().Contains('(') && whatelement.ToString().Trim().Contains(')') && whatelement.ToString().Trim().Contains('-'))
                                {
                                    //corrections
                                    whatelement = whatelement.ToString().Trim().Replace("(", "");
                                    whatelement = whatelement.ToString().Trim().Replace(")", "");
                                    whatelement = whatelement.ToString().Trim().Replace("-", "");
                                    whatelement = whatelement.ToString().Trim().Replace(" ", "");

                                    //   Console.WriteLine(whatelement.ToString().Trim());
                                    //     Console.WriteLine("Press any key to continue...");
                                    //      Console.ReadKey(true);

                                    closetSheet2.Cells[rows, 9] = whatelement.ToString().Trim();
                                  //  Console.WriteLine(closetSheet2.Cells[rows, 9].Value.ToString());
                                }
                               
                                if (whatelement.ToString().Trim().Contains("'"))
                                {
                                   


                                        whatelement = whatelement.ToString().Trim().Replace("'", "''");
                                        closetSheet2.Cells[rows, 3] = whatelement.ToString().Trim();
                                        Console.WriteLine(closetSheet2.Cells[rows, 3].Value.ToString());
                                       
                                    
                                }
                                //   Console.WriteLine(whatelement.ToString());
                                //   Console.WriteLine("Press any key to continue...");
                                //    Console.ReadKey(true);


                            }
                    
                        try
                        {

                             if (closetSheet2.Cells[rows, 6].Value == null && closetSheet2.Cells[rows,5].Value == null)
                            {
                               
                                
                                
                                yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(),"NULL", closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows,8].Value.ToString());
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
                                 //  Console.WriteLine("What the fuck");
                                 yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), "NULL", closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                                 continue;
                             }
                            else if (closetSheet2.Cells[rows, 5].Value == null)
                            {
                             //  Console.WriteLine(closetSheet2.Cells[rows,8].Value);
                                yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                                continue;
                            }
                            else if (closetSheet2.Cells[rows, 5].Value != null)
                            {
                                yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString() + closetSheet2.Cells[rows, 5].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                                continue;
                            }
                          /*  else
                            {
                                Console.WriteLine("MEH");
                                yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                            }*/
                          
                         /*   else if (closetSheet2.Cells[rows, 9].Value == null || closetSheet2.Cells[rows, 5] == null)
                            {
                                Console.WriteLine(closetSheet2.Cells[rows, 2].Value.ToString());
                                closetSheet2.Cells[rows, 9].Value = "";
                                
                                yayAgain.NewGodMother(closetSheet2.Cells[rows, 2].Value.ToString(), closetSheet2.Cells[rows, 3].Value.ToString(), closetSheet2.Cells[rows, 4].Value.ToString(), closetSheet2.Cells[rows, 6].Value.ToString(), closetSheet2.Cells[rows, 10].Value.ToString(), closetSheet2.Cells[rows, 9].Value.ToString(), closetSheet2.Cells[rows, 7].Value.ToString(), closetSheet2.Cells[rows, 8].Value.ToString());
                            }*/
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
                            if(columnSides > 3 && columnSides < 12) //was 12!
                            {
                                continue;
                            }
                           
                            //If a godmother's role changes when a time slot changes, that must be
                            //stored
                            shiftElement = closetSheet2.Cells[rightSideRows, columnSides].Value;
                           /*  if (columnSides == 11)
                            {
                                Console.WriteLine("test");
                                Console.WriteLine(shiftElement.ToString().Trim());
                            }*/
                            if (shiftElement == null)
                            {
                                continue;
                            }
                         /*   if (shiftElement.ToString().Trim().Contains("'"))
                            {
                                shiftElement = shiftElement.ToString().Trim().Replace("'", "''");
                                closetSheet2.Cells[rightSideRows, columnSides] = shiftElement.ToString().Trim();
                            }*/

                         //   Console.WriteLine(shiftElement.ToString().Trim());
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
