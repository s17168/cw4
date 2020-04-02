using Cw3WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3WebApplication.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService() 
        {
            _students = new List<Student>
            { 
                new Student{IdStudent = 1, FirstName = "Jan", LastName = "Kowalski" },
                new Student{IdStudent = 2, FirstName = "Anna", LastName = "Modela" },
                new Student{IdStudent = 3, FirstName = "Andy", LastName = "Andes" },

            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
