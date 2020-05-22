using System;
using Cw3WebApplication.DTOs.Requests;
using Cw3WebApplication.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wyklad5.Services;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Cw3WebApplication.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IStudentsDbService _studentsDbService;
        public IConfiguration Configuration { get; set; }


        public EnrollmentsController(IStudentsDbService service, IConfiguration configuration)
        {
            _studentsDbService = service;
            Configuration = configuration;
        }

        //adding new student and enrolls him to semester
        [HttpPost]
        [Authorize(Roles = "employee")]
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
        [Authorize(Roles = "employee")]
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

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDto request)
        {
            // TODO: Move all this logic to DBService
            var student = _studentsDbService.GetStudent(request.Login);

            if (student.Password.Equals(request.Password))
            {
                Console.WriteLine("Pass confirmed");
            }
            else {
                return BadRequest("Password dont match");
            }

            var claims = new[]
{
                new Claim(ClaimTypes.NameIdentifier, "1"),
                //new Claim(ClaimTypes.Name, "jan123"),
                //new Claim(ClaimTypes.Role, "admin"),
                new Claim(ClaimTypes.Role, "student")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "Gakko",
                audience: "Students",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds
            );

            //return Ok("success");
            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = Guid.NewGuid() // is unique and has no information 
            });
        }

    }
}
