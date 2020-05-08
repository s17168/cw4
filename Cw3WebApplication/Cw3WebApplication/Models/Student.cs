using System;

namespace Cw3WebApplication.Models
{
    public class Student
    {
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public int IdEnrollment { get; set; }
        public DateTime BirthDate { get; set; }

        // additional info:
        public string StudyName { get; set; }
        public int Semester { get; set; }

    }
}
