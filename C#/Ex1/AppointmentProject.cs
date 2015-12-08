﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex1
{
    class AppointmentProject
    {

        void Status(string stat)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(stat);
        }
        void ExceptionOccur(string ExOccur)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + ExOccur);
            Console.ResetColor();
        }
        void AddingAppointment()
        {
            Console.WriteLine("Enter Appointment Date:- \t(YYYY-MM-DD)");
            string Apdate = Console.ReadLine();
            DateTime db = Convert.ToDateTime(Apdate);
            Console.WriteLine("AutoCorrect:- "+"{0}-{1}-{2}", db.Year, db.Month, db.Day);

            Console.WriteLine("\nEnter Name of Person to Meet:- ");
            string Apname = Console.ReadLine();
            Console.WriteLine("\nEnter Time:- \t(Hour-Minute Am or PM)");
            string Aptime = Console.ReadLine();
            Console.WriteLine("\nEnter Note:- ");
            string ApNote = Console.ReadLine();

            if (ApNote != null)
            {
                DirectoryInfo dir = new DirectoryInfo("C:\\ProjectData");
                dir.Create();
                FileStream fs = new FileStream("C:\\ProjectData\\" + Apdate + ".dtp", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write("Appointment Date:- " + Apdate + Environment.NewLine);
                sw.Write("Name of Person to Meet:- " + Apname + Environment.NewLine);
                sw.Write("Time is:- " + Aptime + Environment.NewLine);
                sw.Write("Note:- " + ApNote);
                sw.Flush();
                sw.Close();
                fs.Close();
                Status("\n\nFile Added...Successfully");
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo("C:\\ProjectData");
                dir.Create();
                FileStream fs = new FileStream("C:\\ProjectData\\" + Apdate + ".dtp", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write("Appointment Date:- " + Apdate + Environment.NewLine);
                sw.Write("Name of Person to Meet:- " + Apname + Environment.NewLine);
                sw.Write("Time is:- " + Aptime + Environment.NewLine);
                sw.Write("Note:- None");
                sw.Flush();
                sw.Close();
                fs.Close();
                Status("\n\nFile Added...Successfully");
            }
        }
        void GettingFilesNames()
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\ProjectData");
            Status("Getting Files from Directory...Please Press Enter");
            FileInfo[] finfo = dir.GetFiles("*.dtp");
            foreach (FileInfo fname in finfo)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("FileName:- " + fname.Name);
            }
            if (finfo.Length == 0)
            {
                Console.WriteLine("\t\tNo File Exist\n");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Status("Getting files Completed");
                Console.ReadLine();
                Main();
            }
        }
        void ViewAppointment()
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\ProjectData");
            dir.Create();
            FileInfo[] finfo = dir.GetFiles("*.dtp");
            Status("Getting Files From Directory...\n");
            if (finfo.Length == 0)
            {
                ExceptionOccur("\tFile Not Found\n");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Status("Getting Files Completed");
                Console.ReadLine();
                Main();
            }
            else
            {
            
            foreach (FileInfo fname in finfo)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("FileName:- "+fname.Name);
            }
            
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nEnter File Name:  Without Extension");
                string filename = Console.ReadLine();
                FileStream fs = new FileStream("C:\\ProjectData\\" + filename+".dtp", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                Console.WriteLine("\n\n-----------------------------------------------------------------\n\t\t\t\tRead\n");
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                string text=sr.ReadLine();
                while (text != null)
                {
                    Console.WriteLine("{0}",text);
                    text=sr.ReadLine();
                }
                sr.Close();
                fs.Close();
                Console.WriteLine("\n\nDo You Want To View Again:- (Press Yes for \'y\' Or No for \'N\')");
                string s = Console.ReadLine().ToUpper();
                if (s == "Y")
                {
                    Console.Clear();
                    ViewAppointment();
                }
                else
                {
                    Main();
                }
            }
        }

        void Search()
        {
            Console.WriteLine("Enter FileName search by Year ");
           
            DirectoryInfo dir = new DirectoryInfo("C:\\ProjectData");
            dir.Create();
            Console.WriteLine("\nEnter Year:- ");
            string partialName = Console.ReadLine();
            FileInfo[] finfo = dir.GetFiles(partialName + "*.dtp");
            if (finfo.Length == 0)
            {
                ExceptionOccur("No File Exist");
                Console.ReadLine();
                Main();
            }
            else
            {
                Console.WriteLine("\n-----------------------------------------------------------------");
                Console.WriteLine("\t\t\t\tFile Found...\n");

                foreach (FileInfo f in finfo)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(f.Name);
                }
                Console.ReadLine();
            }
        }
        void ClearFiles()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo("C:\\ProjectData");
                FileInfo[] finfo = dir.GetFiles();
                Console.WriteLine("Press Enter To Delete File:- Or Press N for no");
                string s = Console.ReadLine().ToUpper();
                if (s == "N")
                {
                    Main();
                }
                else
                {
                    if (finfo.Length == 0)
                    {
                        Console.WriteLine("File Not Found");
                        Console.ReadLine();
                        Main();
                    }
                    else
                    {
                        foreach (FileInfo f in finfo)
                        {
                            Console.WriteLine("File Deleted:- " + f.Name);
                            f.Delete();
                        }
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionOccur("Files Not Exist");
                Console.ReadLine();
                Main();
            }
        }
        void DeleteFiles()
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\ProjectData");
            dir.Create();
            FileInfo[] finfo = dir.GetFiles("*.dtp");
            Status("Getting Files From Directory...");
            if (finfo.Length == 0)
            {
                ExceptionOccur("\tFile Not Found.\n");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Status("\nGetting Files Completed");
                Console.ReadLine();
                Main();
            }
            else
            {
                foreach (FileInfo fi in finfo)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("FileName:- " + fi.Name);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nGetting Files Completed");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nEnter FileName Which You want to delete:- (Without Extension)");
                string filename = Console.ReadLine();
                FileInfo fi1 = new FileInfo("C:\\ProjectData\\" + filename + ".dtp");
                fi1.Delete();
                Status("\nFile Deleted...Successfully.");
                Console.ReadLine();
                Main();
            }

        }
        void DeletingDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\ProjectData");
            dir.Create();
            Console.WriteLine("Did You Want to Delete All Directory (Press 'y' to YES Or Press 'n' for NO)");
            string Decision = Console.ReadLine().ToUpper();
            if (Decision == "Y")
            {
                DirectoryInfo dir1 = new DirectoryInfo("C:\\ProjectData");
                FileInfo[] finfo = dir1.GetFiles();
                Console.WriteLine("\n");
                foreach (FileInfo f in finfo)
                {
                    Console.WriteLine("FileName:- "+ f.Name + " Deleted");
                    f.Delete();
                }
                dir1.Delete();
                Console.WriteLine("\n\nDirectory Deleted. Press Enter To Return to Dashboard");
                Console.ReadLine();
                Main();
            }
            else
            {
                Main();
            }
        }
        static void Main()
        {
            string tab="\t";

            AppointmentProject TeamProject = new AppointmentProject();
                        
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(tab + tab + tab + "Welcome to Appointment Application\n\n");
            Console.WriteLine("\nDashboard:-");
            Console.WriteLine(tab + "1.Add Appointment.");
            Console.WriteLine(tab + "2.View Appointment.");
            Console.WriteLine(tab + "3.Search");
            Console.WriteLine(tab + "4.ClearFiles");
            Console.WriteLine(tab + "5.Delete Files");
            Console.WriteLine(tab + "6.Exit");
            Console.WriteLine(tab + "7.Delete Directories");
            Console.WriteLine(tab + "8.About");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Enter Your Operation Below By Pressing Command 1,2,3... etc:-");
            int i = Convert.ToInt32(Console.ReadLine());

            switch (i)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(tab + tab + tab + tab + "Adding Appointment\n\n");
                    TeamProject.AddingAppointment();
                    Console.Clear();
                    Main();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine(tab + tab + tab + tab + "View Appointment\n\n");
                    TeamProject.ViewAppointment();
                    Console.Clear();
                    Main();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine(tab + tab + tab + tab + "Search\n\n");
                    TeamProject.Search();
                    Console.Clear();
                    Main();
                    break;
                case 4:
                    Console.Clear();
                    Console.BackgroundColor=ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine(tab + tab + tab + tab + "Clearing Wizard\n\n");
                    TeamProject.ClearFiles();
                    Main();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine(tab + tab + tab + tab + "Deleting Files\n\n");
                    TeamProject.DeleteFiles();
                    Console.ReadLine();
                    Main();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                case 7:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine(tab + tab + tab + tab + "Deleting Directory\n\n");
                    TeamProject.DeletingDirectory();
                    Console.ReadLine();
                    Main();
                    break;
                case 8:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(tab + tab + tab + tab +tab+ "About\n\n");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(tab + "Programmed By:- AnmolLimje");
                    Console.WriteLine(tab + "Email:- softwaredev31@gmail.com");
                    Console.WriteLine(tab + "Version:- 1.0.0.0");
                    Console.ReadLine();
                    Console.Clear();
                    Main();
                    break;
                default:
                    Console.WriteLine("Invalid Choice...");
                    Main();
                    break;
            }
            Console.ReadLine();
        }
    }
}
