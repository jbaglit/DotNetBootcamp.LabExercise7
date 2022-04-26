using System;
using System.Collections.Generic;
using CSharp.LabExercise7.Models;

namespace CSharp.LabExercise7.Services
{
    public class GetStudentFromRecordService
    {
        public static Student GetStudentByID(HashSet<Student> students, string id)
        {
            foreach (var student in students)
            {
                if (student.ID == id)
                {
                    return student;
                }
            }

            return null;
        }

        public static List<string> GetStudentByName(HashSet<Student> students, string nameSearch)
        {
            List<string> searchedIdResults = new List<string>();
            //int searchCount = 0;
            string searchValues = "";
            foreach (var student in students)
            {
                if (student.FirstName.ToLower().Contains(nameSearch.ToLower()))
                {
                    searchValues = searchValues + $"[{student.ID}] - Name: {student.FirstName} {student.LastName}, Grade Level: {student.GradeLevel}, Section: {student.Section}\n";
                    //searchCount++;
                    searchedIdResults.Add(student.ID);
                }
            }

            if (searchedIdResults.Count > 0)
            {
                Console.WriteLine($"\n{searchedIdResults.Count} Record/s Found!");
                Console.WriteLine(searchValues);
            }
            else
            {
                Console.WriteLine("\n0 Records Found! Try Again!");
            }

            return searchedIdResults;
        }
    }
}
