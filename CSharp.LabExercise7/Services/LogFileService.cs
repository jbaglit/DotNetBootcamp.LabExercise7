using System;
using System.IO;

namespace CSharp.LabExercise7.Services
{
    public class LogFileService
    {
        private static void WriteToApplicationLogFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Application Log Timestamp: {DateTime.Now.ToLongTimeString()}");
            }
        }

        public static void CreateApplicationLogFile()
        {
            string logPath = Directory.GetCurrentDirectory() + $"/LogFiles";
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string filePath = $"{logPath}/{DateTime.Now:MMddyyyy}.log";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            WriteToApplicationLogFile(filePath);
        }
    }
}
