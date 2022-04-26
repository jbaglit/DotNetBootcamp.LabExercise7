using System;
using CSharp.LabExercise7.Models;

namespace CSharp.LabExercise7.Services
{
    public class UserInputValidator
    {
        public static string ValidateUserInput()
        {
            string userGradeLevelInput;
            while (true)
            {
                Console.Write("Enter Student Grade Level: ");
                try
                {
                    userGradeLevelInput = Console.ReadLine();
                    if (userGradeLevelInput == null || "".Equals(userGradeLevelInput.Trim()))
                    {
                        Console.WriteLine($"Invalid input. Student Grade Level cannot be blank.");
                        continue;
                    }
                    if (!int.TryParse(userGradeLevelInput, out _))
                    {
                        Console.WriteLine($"Invalid Input. Student Grade Level should be a numeric value.");
                        continue;
                    }
                    if (Convert.ToInt32(userGradeLevelInput) < 1 || Convert.ToInt32(userGradeLevelInput) > 12)
                    {
                        Console.WriteLine($"Invalid Input. Student Grade Level should between 1 to 12.");
                        continue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            return userGradeLevelInput;
        }
        public static string ValidateUserInput(string inputType)
        {
            string userInput;
            while (true)
            {
                Console.Write($"Enter Student {inputType}: ");
                userInput = Console.ReadLine();
                try
                {
                    if (userInput == null || "".Equals(userInput.Trim()))
                    {
                        Console.WriteLine($"Invalid input. Student {inputType} cannot be blank.");
                        continue;
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return userInput;
        }
    }
}
