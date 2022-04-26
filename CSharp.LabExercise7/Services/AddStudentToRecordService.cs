using System;
using System.Collections.Generic;
using CSharp.LabExercise7.Models;

namespace CSharp.LabExercise7.Services
{
    public class AddStudentToRecordService
    {
        public static void AddStudent(HashSet<Student> students)
        {
            string tryAgain = "y";
            string id;
            string firstName;
            string lastName;
            string gradeLevel;
            string section;

            while (tryAgain.Trim().ToLower().Equals("y"))
            {
                Console.Clear();
                Console.WriteLine("===== ADD NEW STUDENT =====\n");

                id = UserInputValidator.ValidateUserInput("ID");
                firstName = UserInputValidator.ValidateUserInput("First Name");
                lastName = UserInputValidator.ValidateUserInput("Last Name");
                gradeLevel = UserInputValidator.ValidateUserInput();
                section = UserInputValidator.ValidateUserInput("Section");

                var newStudent = new Student
                {
                    ID = id,
                    FirstName = firstName,
                    LastName = lastName,
                    GradeLevel = gradeLevel,
                    Section = section
                };
                if (students.Add(newStudent))
                {
                    Console.WriteLine($"\n~~ New Student Added Successfully!");
                    Console.WriteLine($"ID: {newStudent.ID}\nFullname: {newStudent.FirstName} {newStudent.LastName}\nGrade Level: {newStudent.GradeLevel}\nSection: {newStudent.Section}");
                }
                else
                {
                    Console.WriteLine($"\n~~ Student ID ({id}) Already Exists! Please Try Again!");
                }


                Console.Write("\nDo you want to add another Student? (y/n): ");
                tryAgain = Console.ReadLine();
            }

            Console.Write("\nPress any key to return to main menu . . . ");
            Console.ReadKey();
        }
    }
}
