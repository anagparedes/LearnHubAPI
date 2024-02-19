using Azure.Core;
using LearnHub.Application.Courses.Dtos;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Users.Dtos;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using LearnHub.Domain.Interfaces.Repositories;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Infrastructure.Repositories.Students
{
    public class StudentRepository: IStudentRepository
    {
        private readonly LearnHubDbContext _context;
        public StudentRepository(LearnHubDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddAsync(Student newStudent)
        {
            newStudent.Role = Domain.Enums.Roles.Student;
            newStudent.Status = Domain.Enums.StudentStatus.Active;
            newStudent.RegistrationCode = GenerateUniqueNumericCode();

            // Verify the unicity of RegistrationCode
            while (await _context.Set<Student>().AnyAsync(e => e.RegistrationCode == newStudent.RegistrationCode))
            {
                newStudent.RegistrationCode = GenerateUniqueNumericCode();
            }
            newStudent.FullName = $"{newStudent.FirstName} {newStudent.LastName}";
            newStudent.Email = $"{newStudent.RegistrationCode}@est.learnhub.edu.do";

            _context.Set<Student>().Add(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Set<Student>().ToListAsync();
        }

        public async Task<Student?> GetbyIdAsync(int id)
        {
            var student = await _context.Set<Student>().FindAsync(id);
            if (student == null)
                return null;
            return student;
        }

        public async Task<Student?> GetbyCodeAsync(string code)
        {
            var student = await _context.Set<Student>().FirstOrDefaultAsync(s => s.RegistrationCode.Equals(code));
            if (student == null)
                return null;
            return student;
        }

        public async Task<Student?> UpdateAsync(string registrationCode, Student entity)
        {
            var student = await _context.Set<Student>().FirstOrDefaultAsync(s => s.RegistrationCode.Equals(registrationCode));

            if (student == null)
                return null;

            student.FirstName = entity.FirstName;
            student.LastName = entity.LastName;
            student.FullName = $"{entity.FirstName} {entity.LastName}";
            student.Email = entity.Email;
            student.Telephone = entity.Telephone;
            student.Career = entity.Career;
            student.Status = entity.Status;
            if (student.RegistrationCode is null)
            {
                student.RegistrationCode = GenerateUniqueNumericCode();
                // Verify the unicity of RegistrationCode
                while (await _context.Set<Student>().AnyAsync(e => e.RegistrationCode == entity.RegistrationCode))
                {
                    student.RegistrationCode = GenerateUniqueNumericCode();
                }
            }
            
            student.Telephone = entity.Telephone;

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<List<Student>?> DeleteAsync(string registrationCode)
        {
            var student = await _context.Set<Student>().FirstOrDefaultAsync(s => s.RegistrationCode.Equals(registrationCode));
            if (student == null)
                return null;

            _context.Set<Student>().Remove(student);
            await _context.SaveChangesAsync();

            return await _context.Set<Student>().ToListAsync();
        }
        public string GenerateUniqueNumericCode()
        {
            const string prefix = "102";
            string randomPart = new string(Guid.NewGuid().ToString("N").Where(char.IsDigit).Take(4).ToArray());
            string uniqueCode = prefix + randomPart.PadRight(7 - prefix.Length, '0');
            return uniqueCode;
        }

        public async Task<Student?> GetStudentWithCourse(string code)
        {
            var student = await _context.Set<Student>().Include(c => c.Enrollments).ThenInclude(e => e.Course).FirstOrDefaultAsync(s => s.RegistrationCode == code);
            if (student == null)
                return null;

            return student;
        }
    }
}
