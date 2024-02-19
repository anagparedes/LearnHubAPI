using LearnHub.Application.Courses.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Interfaces
{
    public interface ICourseService
    {
        Task<List<GetCourse>> GetAllCoursesAsync();
        Task<GetCourse?> GetCourseByCodeAsync(string courseCode);
        Task<GetCourseWithStudent?> GetCourseWithStudentAsync(string courseCode);
        Task<GetCourse?> UpdateCourseAsync(int id, CreateCourse course);
        Task<List<GetCourse>?> DeleteCourseAsync(string courseCode);

        Task<GetCourse> AddInPersonCourseAsync(CreateCourse newCourse);
        Task<GetCourse> AddOnlineCourseAsync(CreateCourse newCourse);
        Task<GetCourseWithTeacher?> AddTeacherToCourse(string courseCode, string teacherCode);
        Task<GetCourseWithStudent?> AddStudentsToCourse(string courseCode, string studentCode);
        Task<GetCourseWithAssignment?> AddAssignmentsToCourse(string courseCode, string assignmentCode);
    }
}
