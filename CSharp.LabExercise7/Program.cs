using System;
using System.Collections.Generic;
using CSharp.LabExercise7.Models;
using CSharp.LabExercise7.Services;

namespace CSharp.LabExercise7
{
    class StudentDatabaseManagementSystem
    {
        static void Main(string[] args)
        {
            LogFileService.CreateApplicationLogFile();
            HashSet<Student> students = new HashSet<Student>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== STUDENT DATABASE MANAGEMENT SYSTEM =====\n");
                Console.WriteLine("[1] - Add\tRecords");
                Console.WriteLine("[2] - List\tRecords");
                Console.WriteLine("[3] - Modify\tRecords");
                Console.WriteLine("[4] - Delete\tRecords");
                Console.WriteLine("[5] - Exit\tProgram");
                Console.Write("\nSelect Your Choice:=> ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        AddStudentToRecordService.AddStudent(students);
                        break;
                    case "2":
                        Console.Clear();
                        StudentListRenderer.RenderStudentList(students);
                        break;
                    case "3":
                        Console.Clear();
                        ModifyStudentFromRecordService.ModifyStudent(students);
                        break;
                    case "4":
                        Console.Clear();
                        DeleteStudentFromRecordService.DeleteStudent(students);
                        break;
                    case "5":
                        StudentDBFileService.CreateStudentDBFile(students);
                        Console.WriteLine("\nApplication Terminated!");
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.Write("\nInvalid Selection! Press Any Key To Try Again! . . . ");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
