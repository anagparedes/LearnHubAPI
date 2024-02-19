using LearnHub.Application.Courses.Dtos;
using LearnHub.Application.Students.Dtos;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Infrastructure.Repositories.Assignments
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly LearnHubDbContext _context;
        public AssignmentRepository(LearnHubDbContext context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAllAsync()
        {
            return await _context.Set<Assignment>().ToListAsync();
        }

        public async Task<Assignment?> GetbyCodeAsync(string assignmentCode)
        {
            var assignment = await _context.Set<Assignment>().FirstOrDefaultAsync(s => s.AssignmentCode == assignmentCode);
            if (assignment == null)
                return null;
            return assignment;
        }

        public async Task<Assignment> AddAsync(Assignment newAssignment)
        {
            newAssignment.AssignmentCode = GenerateUniqueAssignmentCode();

            while (await _context.Set<Assignment>().AnyAsync(e => e.AssignmentCode == newAssignment.AssignmentCode))
            {
                newAssignment.AssignmentCode = GenerateUniqueAssignmentCode();
            }

            _context.Set<Assignment>().Add(newAssignment);
            await _context.SaveChangesAsync();
            return newAssignment;
        }

        public async Task<Assignment?> AddCourseToAssignment(string assignmentCode, string courseCode)
        {
            var assignment = await _context.Set<Assignment>().Include(a => a.Course).FirstOrDefaultAsync(a => a.AssignmentCode == assignmentCode);
            var course = await _context.Set<Course>().Include(c => c.Assignments).FirstOrDefaultAsync(c => c.CourseCode == courseCode);
            if (assignment == null || course == null)
            {
                return null;
            }

            assignment.Course = course;
            course.Assignments?.Add(assignment);
            await _context.SaveChangesAsync();

            return assignment;
        }

        public async Task<Assignment?> AddQualificationToAssignment(string assignmentCode, string qualificationCode)
        {
            var assignment = await _context.Set<Assignment>().Include(a => a.Qualifications).FirstOrDefaultAsync(a => a.AssignmentCode == assignmentCode);
            var qualification = await _context.Set<Qualification>().Include(q => q.Assignment).FirstOrDefaultAsync(q => q.QualificationCode == qualificationCode);
            if (assignment == null || qualification  == null)
            {
                return null;
            }

            assignment.Qualifications?.Add(qualification);
            qualification.Assignment = assignment;
            await _context.SaveChangesAsync();

            return assignment;
        }

        public async Task<Assignment?> AddStudentsToAssignment(string assignmentCode, string studentCode)
        {
            var assignment = await _context.Set<Assignment>().Include(c => c.AssignedStudents).FirstOrDefaultAsync(a => a.AssignmentCode == assignmentCode);
            var student = await _context.Set<Student>().Include(s => s.AssignedAssignments).FirstOrDefaultAsync(c => c.RegistrationCode == studentCode);
            if (assignment == null || student == null)
            {
                return null;
            }

            assignment.AssignedStudents?.Add(student);
            student.AssignedAssignments?.Add(assignment);
            await _context.SaveChangesAsync();

            return assignment;
        }

        public async Task<Assignment?> AddTeacherToAssignment(string assignmentCode, string teacherCode)
        {
            var assignment = await _context.Set<Assignment>().Include(c => c.CreatedTeacher).FirstOrDefaultAsync(a => a.AssignmentCode == assignmentCode);
            var teacher = await _context.Set<Teacher>().Include(c => c.CreatedAssignments).FirstOrDefaultAsync(c => c.RegistrationCode == teacherCode);
            if (assignment == null || teacher == null)
            {
                return null;
            }

            assignment.CreatedTeacher = teacher;
            teacher.CreatedAssignments?.Add(assignment);
            await _context.SaveChangesAsync();

            return assignment;
        }

        public async Task<Assignment?> UpdateAsync(int id, Assignment newAssignment)
        {
            var assignment = await _context.Set<Assignment>().FindAsync(id);

            if (assignment == null)
                return null;

            assignment.Title = newAssignment.Title;
            assignment.Description = newAssignment.Description;
            if (assignment.AssignmentCode is null)
            {
                assignment.AssignmentCode = GenerateUniqueAssignmentCode();
                // Verify the unicity of CourseCode
                while (await _context.Set<Assignment>().AnyAsync(e => e.AssignmentCode == assignment.AssignmentCode))
                {
                    assignment.AssignmentCode = GenerateUniqueAssignmentCode();
                }
            }
            await _context.SaveChangesAsync();

            return assignment;
        }

        public async Task<List<Assignment>?> DeleteAsync(string assignmentCode)
        {
            var assignment = await _context.Set<Assignment>().FirstOrDefaultAsync(s => s.AssignmentCode == assignmentCode);
            if (assignment == null)
                return null;

            _context.Set<Assignment>().Remove(assignment);
            await _context.SaveChangesAsync();

            return await _context.Set<Assignment>().ToListAsync();
        }

        public async Task<Assignment?> UpdateWithStudentResponseAsync(int id, Assignment newAssignment)
        {
            var assignment = await _context.Set<Assignment>().FindAsync(id);

            if (assignment == null)
                return null;

            assignment.StudentResponse = newAssignment.StudentResponse;

            await _context.SaveChangesAsync();

            return assignment;
        }
        public string GenerateUniqueAssignmentCode()
        {
            string prefix = "Assignment-";
            string uniqueCode = Guid.NewGuid().ToString("N").Substring(0, 7).ToUpper();
            return prefix + uniqueCode;
        }
    }
}
