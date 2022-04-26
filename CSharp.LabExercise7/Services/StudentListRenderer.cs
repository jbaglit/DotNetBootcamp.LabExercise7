using System;
using System.Collections.Generic;
using CSharp.LabExercise7.Models;

namespace CSharp.LabExercise7.Services
{
    public class StudentListRenderer
    {
        public static void RenderStudentList(HashSet<Student> students)
        {
            Console.Clear();
            Console.WriteLine("===== STUDENT LIST =====\n");

            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.ID}, Firstname: {student.FirstName}, Lastname: {student.LastName}, Grade Level: {student.GradeLevel}, Section: {student.Section}");
                }
            }
            else
            {
                Console.WriteLine($"No records found!");
            }

            Console.Write("\nPress any key to return to main menu . . . ");
            Console.ReadKey();
        }
    }
}
