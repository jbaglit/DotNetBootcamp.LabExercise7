using System;
using System.Collections.Generic;
using CSharp.LabExercise7.Models;

namespace CSharp.LabExercise7.Services
{
    public class DeleteStudentFromRecordService
    {
        private static void ProcessDeletion(HashSet<Student> students)
        {
            Console.Write("Enter ID: ");
            string inputID = Console.ReadLine();
            Student searchedStudent = GetStudentFromRecordService.GetStudentByID(students, inputID);

            if (searchedStudent != null)
            {
                Console.WriteLine($"\nSearch Result:\nID: {searchedStudent.ID}, Firstname: {searchedStudent.FirstName}, Lastname: {searchedStudent.LastName}, Grade Level: {searchedStudent.GradeLevel}, Section: {searchedStudent.Section}\n");

                Console.Write("Enter [y] to confirm deletion: ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    students.Remove(searchedStudent);
                    Console.WriteLine($"\nStudent with id ({searchedStudent.ID}) is successfully deleted!");
                }
                else
                {
                    Console.WriteLine("Deletion Cancelled!");
                }
            }
            else
            {
                Console.WriteLine($"\nStudent with id ({inputID}) doesn't exist! Deletion Cancelled");
            }
        }
        public static void DeleteStudent(HashSet<Student> students)
        {
            string tryAgain = "y";

            while (tryAgain.Trim().ToLower().Equals("y"))
            {
                Console.Clear();
                Console.WriteLine("===== DELETE STUDENT RECORD =====\n");
                Console.WriteLine("[1] - Search by ID");
                Console.WriteLine("[2] - Search by Name");
                Console.Write("\nEnter Selection: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("===== SEARCH RECORD BY ID (DELETE) =====\n");
                        ProcessDeletion(students);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("===== SEARCH RECORD BY NAME (DELETE) =====\n");
                        Console.Write("Enter Student Name: ");
                        string nameSearch = Console.ReadLine();

                        List<string> searchedStudentsID = GetStudentFromRecordService.GetStudentByName(students, nameSearch);
                        if (searchedStudentsID.Count > 0)
                        {
                            ProcessDeletion(students);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Selection! Deletion Cancelled!");
                        break;

                }

                Console.Write("\nDo you want to Delete another Student? (y/n): ");
                tryAgain = Console.ReadLine();
            }

            Console.Write("\nPress any key to return to main menu . . . ");
            Console.ReadKey();
        }
    }
}
