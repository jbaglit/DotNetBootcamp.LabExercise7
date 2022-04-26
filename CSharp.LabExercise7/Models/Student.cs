using System;

namespace CSharp.LabExercise7.Models
{
    public class Student : IEquatable<Student>
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GradeLevel { get; set; }
        public string Section { get; set; }

        public bool Equals(Student other)
        {
            if (other == null)
            {
                throw new ArgumentException("Student object cannot be null");
            }

            return this.ID == other.ID;
        }

        public override string ToString()
        {
            return $"{ID},{FirstName},{LastName},{GradeLevel},{Section}";
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
