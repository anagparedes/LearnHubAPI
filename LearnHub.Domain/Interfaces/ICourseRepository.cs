using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetbyCodeAsync(string courseCode);
        Task<Course?> GetCourseWithStudentAsync(string courseCode);
        Task<Course?> UpdateAsync(int id, Course course);
        Task<List<Course>?> DeleteAsync(string courseCode);

        Task<Course> AddInPersonCourseAsync(Course newCourse);
        Task<Course> AddOnlineCourseAsync(Course newCourse);
        Task<Course?> AddTeacherToCourse(string courseCode, string teacherCode);
        Task<Course?> AddStudentsToCourse (string courseCode, string studentCode);
        Task<Course?> AddAssignmentsToCourse(string courseCode, string assignmentCode);
        string GenerateUniqueCourseCode();
    }
}
