using System;
using Cw3WebApplication.DTOs.Requests;
using Cw3WebApplication.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Wyklad5.Services;

namespace Cw3WebApplication.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IStudentsDbService _studentsDbService;

        public EnrollmentsController(IStudentsDbService service)
        {
            _studentsDbService = service;
        }

        //adding new student and enrolls him to semester
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            var response = new EnrollStudentResponse();
            try
            {
                response = _studentsDbService.EnrollStudent(request);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        //promotes all students of given study name to given semester
        [HttpPost]
        [Route("promotions")]
        public IActionResult PromoteStudents(int semester, string studies) // params not in body but in query string! 
        {
            
            try
            {
                _studentsDbService.PromoteStudents(semester, studies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Successfully promoted all students to next semester");
        }

    }
}
