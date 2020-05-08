using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3WebApplication.DTOs.Requests
{
    public class EnrollStudentRequest
    {
        [Required] //adnotacja
        [MaxLength(100)]
        [RegularExpression("^s[0-9]+$")]
        public string IndexNumber { get; set; }

        [Required(ErrorMessage = "Musisz podać imię!")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Studies { get; set; } //it is "StudyName" id DB
    }
}
