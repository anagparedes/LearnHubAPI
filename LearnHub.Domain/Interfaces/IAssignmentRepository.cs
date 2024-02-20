using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAllAsync();
        Task<Assignment?> GetbyCodeAsync(string assignmentCode);
        Task<Assignment?> GetAssignmentWithStudentAsync(string assignmentCode);
        Task<Assignment?> GetAssignmentWithTeacherAsync(string assignmentCode);
        Task<Assignment?> GetAssignmentWithCourseAsync(string assignmentCode);
        Task<Assignment?> UpdateAsync(int id, Assignment newAssignment);
        Task<Assignment?> UpdateWithStudentResponseAsync(int id, Assignment newAssignment);
        Task<List<Assignment>?> DeleteAsync(string assignmentCode);

        Task<Assignment> AddAsync(Assignment newAssignment);
        Task<Assignment?> AddCourseToAssignment(string assignmentCode, string courseCode);
        Task<Assignment?> AddTeacherToAssignment(string assignmentCode, string teacherCode);
        Task<Assignment?> AddStudentsToAssignment(string assignmentCode, string studentCode);
        Task<Assignment?> AddQualificationToAssignment(string assignmentCode, string qualificationCode);

        string GenerateUniqueAssignmentCode();
    }
}
