using System;
using System.IO;
using System.Collections.Generic;
using CSharp.LabExercise7.Models;

namespace CSharp.LabExercise7.Services
{
    public class StudentDBFileService
    {
        public static void CreateStudentDBFile(HashSet<Student> students)
        {
            if (students.Count > 0)
            {
                string dbPath = Directory.GetCurrentDirectory() + $"/StudentDB";
                if (!Directory.Exists(dbPath))
                {
                    Directory.CreateDirectory(dbPath);
                }
                string filePath = $"{dbPath}/studentdb.{DateTime.Now:MMddyyyyHHmmss}.txt";
                File.Create(filePath).Dispose();

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    foreach (var student in students)
                    {
                        writer.WriteLine($"{student.ToString()}");
                    }
                }

                Console.WriteLine("\nStudents DB File Successfully Created!");
            }
            else
            {
                Console.WriteLine("\n0 Records Found. No File Created!");
            }
        }
    }
}
