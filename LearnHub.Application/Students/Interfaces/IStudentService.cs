using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Teachers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Students.Interfaces
{
    public interface IStudentService
    {
        Task<GetStudentWithAssignment> GetStudentWithAssignment(string registrationCode);
        Task<GetStudentWithCourse?> GetStudentWithCourse(string registrationCode);
        Task<GetStudentWithQualification> GetStudentWithQualification(string registrationCode);
    }
}
