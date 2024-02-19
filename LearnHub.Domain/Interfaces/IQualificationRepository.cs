using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Interfaces
{
    public interface IQualificationRepository
    {
        Task<List<Qualification>> GetAllAsync();
        Task<Qualification?> GetbyCodeAsync(string qualificationCode);
        Task<Qualification?> AddAsync(Qualification newQualification, string studentCode, string assignmentCode, string teacherCode);
        Task<Qualification?> UpdateAsync(int id, Qualification newQualification, string studentCode, string assignmentCode);
        Task<List<Qualification>?> DeleteAsync(string assignmentCode);

        //Task<Qualification?> AddCourseToQualification(string assignmentCode, string courseCode);
        //Task<Qualification?> AddTeacherToQualification(string assignmentCode, string teacherCode);
        //Task<Qualification?> AddStudentsToQualification(string assignmentCode, string studentCode);
        //Task<Qualification?> AddQualificationToQualification(string assignmentCode, string qualificationCode);

        string GenerateUniqueQualificationCode();
    }
}
