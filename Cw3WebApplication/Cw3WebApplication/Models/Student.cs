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

        // additional info:
        public string Studies { get; set; } //it is "StudyName" id DB
        public int Semester { get; set; }

        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public string Refreshtoken { get; set; }

    }
}
