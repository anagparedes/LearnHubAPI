using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Teachers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Teachers.Interfaces
{
    public interface ITeacherService
    {
        Task<GetTeacherWithAssignment> GetTeacherWithAssignment(string registrationCode);
        Task<GetTeacherWithCourse> GetTeacherWithCourse(string registrationCode);
        Task<GetTeacherWithQualification> GetTeacherWithQualification(string registrationCode);
    }
}
