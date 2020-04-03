using Cw3WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3WebApplication.DAL
{
    public class MsqlDbService : IDbService
    {

        private static List<Student> _students;

        static MsqlDbService()
        {
            _students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s17168;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select * from Student";

                connection.Open();

                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr);
                    var student = new Student();
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastNAme"].ToString();
                    student.IndexNumber = dr["IndexNumber"].ToString();
                    student.BirthDate = dr["BirthDate"].ToString();
                    student.IdEnrollment = Int16.Parse(dr["IdEnrollment"].ToString());

                    _students.Add(student);
                }
            }
            return _students;
        }

    }
}
