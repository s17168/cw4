﻿using Cw3WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3WebApplication.DAL
{
    public interface IDbService
    {
        IEnumerable<Student> GetStudents();
        void AddStudent(Student student);

        Enrollment GetEnrollment(string idStudent);

    }
}
