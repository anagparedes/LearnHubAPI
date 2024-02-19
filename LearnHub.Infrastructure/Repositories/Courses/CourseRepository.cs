using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Infrastructure.Repositories.Courses
{
    public class CourseRepository: ICourseRepository
    {
        private readonly LearnHubDbContext _context;
        public CourseRepository(LearnHubDbContext context)
        {
            _context = context;
        }

        public async Task<Course> AddInPersonCourseAsync(Course newCourse)
        {
            newCourse.courseType = Domain.Enums.CourseTypes.InPerson;
            newCourse.CourseCode = GenerateUniqueCourseCode();

            // Verify the unicity of CourseCode
            while (await _context.Set<Course>().AnyAsync(e => e.CourseCode == newCourse.CourseCode))
            {
                newCourse.CourseCode = GenerateUniqueCourseCode();
            }
           

            _context.Set<Course>().Add(newCourse);
            await _context.SaveChangesAsync();
            return newCourse;
        }

        public async Task<Course> AddOnlineCourseAsync(Course newCourse)
        {
            newCourse.courseType = Domain.Enums.CourseTypes.Online;
            newCourse.CourseCode = GenerateUniqueCourseCode();

            // Verify the unicity of CourseCode
            while (await _context.Set<Course>().AnyAsync(e => e.CourseCode == newCourse.CourseCode))
            {
                newCourse.CourseCode = GenerateUniqueCourseCode();
            }


            _context.Set<Course>().Add(newCourse);
            await _context.SaveChangesAsync();
            return newCourse;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Set<Course>().ToListAsync();
        }

        public async Task<Course?> GetbyCodeAsync(string courseCode)
        {
            var course = await _context.Set<Course>().FirstOrDefaultAsync(s => s.CourseCode == courseCode);
            if (course == null)
                return null;
            return course;
        }

        public async Task<Course?> GetCourseWithStudentAsync(string courseCode)
        {
            var course = await _context.Set<Course>().Include(c => c.Enrollments).ThenInclude(e => e.Student).FirstOrDefaultAsync(s => s.CourseCode == courseCode);
            if (course == null)
                return null;
            return course;
        }

        public async Task<Course?> UpdateAsync(int id, Course newCourse)
        {
            var course = await _context.Set<Course>().FindAsync(id);

            if (course == null)
                return null;

            course.CourseName = newCourse.CourseName;
            course.Year = newCourse.Year;
            course.Period = newCourse.Period;
            if (course.CourseCode is null)
            {
                course.CourseCode = GenerateUniqueCourseCode();
                // Verify the unicity of CourseCode
                while (await _context.Set<Course>().AnyAsync(e => e.CourseCode == newCourse.CourseCode))
                {
                    course.CourseCode = GenerateUniqueCourseCode();
                }
            }
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<List<Course>?> DeleteAsync(string courseCode)
        {
            var course = await _context.Set<Course>().FirstOrDefaultAsync(s => s.CourseCode == courseCode);
            if (course == null)
                return null;

            _context.Set<Course>().Remove(course);
            await _context.SaveChangesAsync();

            return await _context.Set<Course>().ToListAsync();
        }

        public async Task<Course?> AddTeacherToCourse(string courseCode, string teacherCode)
        {
            var course = await _context.Set<Course>().Include(c => c.AssignedTeacher).FirstOrDefaultAsync(c => c.CourseCode == courseCode);
            var teacher = await _context.Set<Teacher>().Include(t => t.Courses).FirstOrDefaultAsync(t => t.RegistrationCode == teacherCode);
            if (course == null || teacher == null)
            {
                return null;
            }

            course.AssignedTeacher = teacher;
            teacher.Courses?.Add(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course?> AddStudentsToCourse(string courseCode, string studentCode)
        {
            var course = await _context.Set<Course>().FirstOrDefaultAsync(c => c.CourseCode == courseCode);
            var student = await _context.Set<Student>().FirstOrDefaultAsync(s => s.RegistrationCode == studentCode);
            if (course == null || student == null)
            {
                return null;
            }

            var enrollment = new StudentCourse { Student = student, Course = course };

            _context.StudentCourses.Add(enrollment);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course?> AddAssignmentsToCourse(string courseCode, string assignmentCode)
        {
            var course = await _context.Set<Course>().Include(c => c.Assignments).FirstOrDefaultAsync(c => c.CourseCode == courseCode);
            var assignment = await _context.Set<Assignment>().Include(a => a.Course).FirstOrDefaultAsync(a => a.AssignmentCode == assignmentCode);
            if (course == null || assignment == null)
            {
                return null;
            }

            course.Assignments?.Add(assignment);
            assignment.Course = course;
            await _context.SaveChangesAsync();

            return course;
        }

        public string GenerateUniqueCourseCode()
        {
            string prefix = "COURSE-";
            string uniqueCode = Guid.NewGuid().ToString("N").Substring(0, 7).ToUpper();
            return prefix + uniqueCode;
        }
    }
}
