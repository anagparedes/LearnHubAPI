using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher?> GetbyCodeAsync(string code);
        Task<Teacher?> GetTeacherWithCourse(string code);
        Task<Teacher?> GetTeacherWithAssignment(string code);
        Task<Teacher?> GetTeacherWithQualification(string code);
        string GenerateUniqueNumericCode();
    }
}
