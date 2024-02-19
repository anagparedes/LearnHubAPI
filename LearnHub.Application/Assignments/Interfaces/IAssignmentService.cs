using LearnHub.Application.Assignments.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.Interfaces
{
    public interface IAssignmentService
    {
        Task<List<GetAssignment>> GetAllAssignmentAsync();
        Task<GetAssignment?> GetAssignmentByCodeAsync(string assignmentCode);
        Task<GetAssignment> AddAssignmentAsync(CreateAssignment createAssignment);
        Task<GetAssignment?> UpdateAssignmentAsync(int id, CreateAssignment createAssignment);
        Task<List<GetAssignment>?> DeleteAssignmentAsync(string assignmentCode);

        Task<GetAssignmentWithStudentResponse?> UpdateWithStudentResponseAsync(int id, UpdateAssignmentWithStudentResponse updateAssignment);
        Task<GetAssignmentWithTeacher?> AddTeacherToAssignment(string assignmentCode, string teacherCode);
        Task<GetAssignmentWithStudent?> AddStudentsToAssignment(string assignmentCode, string studentCode);
        Task<GetAssignmentWithCourse?> AddCourseToAssignment(string assignmentCode, string courseCode);
    }
}
