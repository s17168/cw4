using System;
using Cw3WebApplication.Models;
using Cw3WebApplication.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Cw3WebApplication.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService service)
        {
            _dbService = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2) {
                return Ok("Malewski");
            }

            return NotFound("Nie znaleziono podanego studenta");
        }

        [HttpGet]
        public IActionResult GetStudents([FromQuery] string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 10000)}";
            _dbService.AddStudent(student);
            return Ok(student);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Student student, string id)
        {
            var studentId = student.IndexNumber;
            // update student

            return Ok("Akutalizacja dokonczona dla studenta " + studentId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            // check if student exists

            return Ok("Usuwanie ukonczone dla studenta id = " + id);
        }

        [HttpGet]
        [Route("{idStudent}/enrollment")]
        public IActionResult GetEnrollment(string idStudent)
        {
            return Ok(_dbService.GetEnrollment(idStudent));
        }

    }

}