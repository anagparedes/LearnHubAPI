using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student?> GetbyCodeAsync(string code);
        Task<Student?> GetStudentWithAssignment(string code);
        Task<Student?> GetStudentWithCourse(string code);
        Task<Student?> GetStudentWithQualification(string code);
        string GenerateUniqueNumericCode();

    }
}
