using Cw3WebApplication.DTOs.Requests;
using Cw3WebApplication.DTOs.Responses;

namespace Wyklad5.Services
{
    public interface IStudentsDbService
    {
        EnrollStudentResponse EnrollStudent(EnrollStudentRequest request);
        void PromoteStudents(int semester, string studies);
    }
}
