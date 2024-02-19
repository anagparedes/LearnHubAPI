using LearnHub.Application.Courses.Dtos;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Infrastructure.Repositories.Qualifications
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly LearnHubDbContext _context;
        public QualificationRepository(LearnHubDbContext context)
        {
            _context = context;
        }

        public async Task<List<Qualification>> GetAllAsync()
        {
            return await _context.Set<Qualification>().ToListAsync();
        }

        public async Task<Qualification?> GetbyCodeAsync(string qualificationCode)
        {
            var qualification = await _context.Set<Qualification>().FirstOrDefaultAsync(s => s.QualificationCode.Equals(qualificationCode));
            if (qualification == null)
                return null;
            return qualification;
        }

        public async Task<Qualification?> AddAsync(Qualification newQualification, string studentCode, string assignmentCode, string teacherCode)
        {
            var student = await _context.Set<Student>().Include(s => s.Grades).FirstOrDefaultAsync(s => s.RegistrationCode == studentCode);
            var assignment = await _context.Set<Assignment>().Include(a => a.Qualifications).FirstOrDefaultAsync(a => a.AssignmentCode == assignmentCode);
            var teacher = await _context.Set<Teacher>().Include(t => t.Grades).FirstOrDefaultAsync(t => t.RegistrationCode == teacherCode);
            if (student == null || teacher == null || teacher == null)
            {
                return null;
            }
            newQualification.Student = student;
            newQualification.Assignment = assignment;
            newQualification.EvaluatedTeacher = teacher;
            newQualification.QualificationCode = GenerateUniqueQualificationCode();

            // Verify the unicity of QualificationCode
            while (await _context.Set<Qualification>().AnyAsync(e => e.QualificationCode == newQualification.QualificationCode))
            {
                newQualification.QualificationCode = GenerateUniqueQualificationCode();
            }


            _context.Set<Qualification>().Add(newQualification);
            student.Grades?.Add(newQualification);
            teacher.Grades?.Add(newQualification);
            assignment?.Qualifications?.Add(newQualification);
            await _context.SaveChangesAsync();
            return newQualification;
        }

        public async Task<Qualification?> UpdateAsync(int id, Qualification newQualification, string studentCode, string assignmentCode)
        {
            var qualification = await _context.Set<Qualification>().FindAsync(id);
            var student = await _context.Set<Student>().Include(s => s.Grades).FirstOrDefaultAsync(s => s.RegistrationCode == studentCode);
            var assignment = await _context.Set<Assignment>().Include(a => a.Qualifications).FirstOrDefaultAsync(a => a.AssignmentCode == assignmentCode);
            if (qualification == null || student == null || assignment == null)
                return null;

            qualification.Student = student;
            qualification.Assignment = assignment;
            qualification.Score = newQualification.Score;
          
            if (qualification.QualificationCode is null)
            {
                qualification.QualificationCode = GenerateUniqueQualificationCode();
                // Verify the unicity of QualificationCode
                while (await _context.Set<Qualification>().AnyAsync(e => e.QualificationCode == newQualification.QualificationCode))
                {
                    qualification.QualificationCode = GenerateUniqueQualificationCode();
                }
            }
            student.Grades?.Add(newQualification);
            assignment?.Qualifications?.Add(newQualification);
            await _context.SaveChangesAsync();

            return qualification;
        }

        public async Task<List<Qualification>?> DeleteAsync(string qualificationCode)
        {
            var qualification = await _context.Set<Qualification>().FirstOrDefaultAsync(s => s.QualificationCode.Equals(qualificationCode));
            if (qualification == null)
                return null;

            _context.Set<Qualification>().Remove(qualification);
            await _context.SaveChangesAsync();

            return await _context.Set<Qualification>().ToListAsync();
        }

        public string GenerateUniqueQualificationCode()
        {
            string prefix = "QUALIFICATION-";
            string uniqueCode = Guid.NewGuid().ToString("N").Substring(0, 7).ToUpper();
            return prefix + uniqueCode;
        }
    }
}
