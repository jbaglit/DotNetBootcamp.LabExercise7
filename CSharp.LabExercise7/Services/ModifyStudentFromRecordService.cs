using System;
using System.Collections.Generic;
using CSharp.LabExercise7.Models;

namespace CSharp.LabExercise7.Services
{
    public class ModifyStudentFromRecordService
    {
        private static void ProcessModification(HashSet<Student> students)
        {
            Console.Write("Enter ID: ");

            string inputID = Console.ReadLine();
            Student searchedStudent = GetStudentFromRecordService.GetStudentByID(students, inputID);

            if (searchedStudent != null)
            {
                Console.WriteLine($"\nSearch Result:\nID: {searchedStudent.ID}, Firstname: {searchedStudent.FirstName}, Lastname: {searchedStudent.LastName}, Grade Level: {searchedStudent.GradeLevel}, Section: {searchedStudent.Section}\n");

                string firstName = UserInputValidator.ValidateUserInput("First Name");
                string lastName = UserInputValidator.ValidateUserInput("Last Name");
                string gradeLevel = UserInputValidator.ValidateUserInput();
                string section = UserInputValidator.ValidateUserInput("Section");

                var modifiedStudent = new Student
                {
                    ID = inputID,
                    FirstName = firstName,
                    LastName = lastName,
                    GradeLevel = gradeLevel,
                    Section = section
                };

                students.Remove(searchedStudent);
                students.Add(modifiedStudent);

                Console.WriteLine("\nStudent Successfully Updated!");
                Console.WriteLine($"FROM: ID: {searchedStudent.ID}, Firstname: {searchedStudent.FirstName}, Lastname: {searchedStudent.LastName}, Grade Level: {searchedStudent.GradeLevel}, Section: {searchedStudent.Section}");
                Console.WriteLine($"TO: ID: {modifiedStudent.ID}, Firstname: {modifiedStudent.FirstName}, Lastname: {modifiedStudent.LastName}, Grade Level: {modifiedStudent.GradeLevel}, Section: {modifiedStudent.Section}");
            }
            else
            {
                Console.WriteLine($"\nStudent with id ({inputID}) doesn't exist! Modification Cancelled!");
            }
        }


        private static void ProcessModification(HashSet<Student> students, List<String> searchedResultID)
        {
            Console.Write("Enter ID: ");
            string inputID = Console.ReadLine();

            bool foundFlag  = false;

            foreach (var searchedID in searchedResultID)
            {
                if (inputID == searchedID)
                {
                    foundFlag = true;
                }
            }

            if (foundFlag)
            {
                Student searchedStudent = GetStudentFromRecordService.GetStudentByID(students, inputID);

                if (searchedStudent != null)
                {
                    Console.WriteLine($"\nSearch Result:\nID: {searchedStudent.ID}, Firstname: {searchedStudent.FirstName}, Lastname: {searchedStudent.LastName}, Grade Level: {searchedStudent.GradeLevel}, Section: {searchedStudent.Section}\n");

                    string firstName = UserInputValidator.ValidateUserInput("First Name");
                    string lastName = UserInputValidator.ValidateUserInput("Last Name");
                    string gradeLevel = UserInputValidator.ValidateUserInput();
                    string section = UserInputValidator.ValidateUserInput("Section");

                    var modifiedStudent = new Student
                    {
                        ID = inputID,
                        FirstName = firstName,
                        LastName = lastName,
                        GradeLevel = gradeLevel,
                        Section = section
                    };

                    students.Remove(searchedStudent);
                    students.Add(modifiedStudent);

                    Console.WriteLine("\nStudent Successfully Updated!");
                    Console.WriteLine($"FROM: ID: {searchedStudent.ID}, Firstname: {searchedStudent.FirstName}, Lastname: {searchedStudent.LastName}, Grade Level: {searchedStudent.GradeLevel}, Section: {searchedStudent.Section}");
                    Console.WriteLine($"TO: ID: {modifiedStudent.ID}, Firstname: {modifiedStudent.FirstName}, Lastname: {modifiedStudent.LastName}, Grade Level: {modifiedStudent.GradeLevel}, Section: {modifiedStudent.Section}");
                }
                else
                {
                    Console.WriteLine($"\nStudent with id ({inputID}) doesn't exist! Modification Cancelled!");
                }
            }
            else
            {
                Console.WriteLine($"\nInputted ID is not included in Search Result!");
            }

        }

        public static void ModifyStudent(HashSet<Student> students)
        {
            string tryAgain = "y";

            while (tryAgain.Trim().ToLower().Equals("y"))
            {
                Console.Clear();
                Console.WriteLine("===== MODIFY STUDENT RECORD =====\n");
                Console.WriteLine("[1] - Search by ID");
                Console.WriteLine("[2] - Search by Name");
                Console.Write("\nEnter Selection: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("===== SEARCH RECORD BY ID (MODIFY) =====\n");
                        ProcessModification(students);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("===== SEARCH RECORD BY NAME (MODIFY) =====\n");
                        Console.Write("Enter Student Name: ");
                        string nameSearch = Console.ReadLine();

                        List<string> searchedStudentsID = GetStudentFromRecordService.GetStudentByName(students, nameSearch);
                        if (searchedStudentsID.Count > 0)
                        {
                            ProcessModification(students, searchedStudentsID);
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid Selection! Modify Cancelled!");
                        break;
                }
                Console.Write("\nDo you want to Modify another Student? (y/n): ");
                tryAgain = Console.ReadLine();
            }
            Console.Write("\nPress any key to return to main menu . . . ");
            Console.ReadKey();
        }
    }
}
