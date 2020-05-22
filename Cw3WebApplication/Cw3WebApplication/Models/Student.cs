using System;

namespace Cw3WebApplication.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public int IdEnrollment { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }

        // additional info:
        public string Studies { get; set; } //it is "StudyName" id DB
        public int Semester { get; set; }

    }
}
