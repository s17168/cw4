using Cw3WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3WebApplication.DAL
{
    public class MockDbService : IDbService
    {
        private static List<Student> _students;

        static MockDbService() 
        {
            _students = new List<Student>
            { 
                new Student{IndexNumber = "s1", FirstName = "Jan", LastName = "Kowalski" },
                new Student{IndexNumber = "s2", FirstName = "Anna", LastName = "Modela" },
                new Student{IndexNumber = "s3", FirstName = "Andy", LastName = "Andes" },

            };
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public Enrollment GetEnrollment(string idStudent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
