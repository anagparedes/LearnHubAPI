using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Infrastructure.Repositories.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly LearnHubDbContext _context;

        public TeacherRepository(LearnHubDbContext context)
        {
            _context = context;
        }
        public async Task<Teacher> AddAsync(Teacher newTeacher)
        {
            newTeacher.Role = Domain.Enums.Roles.Teacher;
            newTeacher.Status = Domain.Enums.TeacherStatus.Active;
            newTeacher.RegistrationCode = GenerateUniqueNumericCode();

            while (await _context.Set<Teacher>().AnyAsync(e => e.RegistrationCode == newTeacher.RegistrationCode))
            {
                newTeacher.RegistrationCode = GenerateUniqueNumericCode();
            }
            newTeacher.FullName = $"{newTeacher.FirstName} {newTeacher.LastName}";
            newTeacher.Email = $"{newTeacher.RegistrationCode}@prof.learnhub.edu.do";
            _context.Set<Teacher>().Add(newTeacher);
            await _context.SaveChangesAsync();
            return newTeacher;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Set<Teacher>().ToListAsync();
        }

        public async Task<Teacher?> GetbyIdAsync(int id)
        {
            var teacher = await _context.Set<Teacher>().FindAsync(id);
            if (teacher == null)
                return null;
            return teacher;
        }

        public async Task<Teacher?> GetbyCodeAsync(string code)
        {
            var teacher = await _context.Set<Teacher>().FirstOrDefaultAsync(s => s.RegistrationCode == code);
            if (teacher == null)
                return null;
            return teacher;
        }
        public async Task<Teacher?> GetTeacherWithCourse(string code)
        {
            var teacher = await _context.Set<Teacher>().Include(t => t.Courses).FirstOrDefaultAsync(s => s.RegistrationCode == code);
            if (teacher == null)
                return null;

            return teacher;
        }
        public async Task<Teacher?> UpdateAsync(string registrationCode, Teacher entity)
        {
            var teacher = await _context.Set<Teacher>().FirstOrDefaultAsync(s => s.RegistrationCode == registrationCode);

            if (teacher == null)
                return null;

            teacher.FirstName = entity.FirstName;
            teacher.LastName = entity.LastName;
            teacher.FullName = $"{entity.FirstName} {entity.LastName}";
            teacher.Email = entity.Email;
            teacher.CareerArea = entity.CareerArea;
            teacher.Career = entity.Career;
            teacher.Status = entity.Status;
            if (teacher.RegistrationCode is null)
            {
                teacher.RegistrationCode = GenerateUniqueNumericCode();
                // Verify the unicity of RegistrationCode
                while (await _context.Set<Teacher>().AnyAsync(e => e.RegistrationCode == teacher.RegistrationCode))
                {
                    teacher.RegistrationCode = GenerateUniqueNumericCode();
                }
            }

            teacher.Telephone = entity.Telephone;

            await _context.SaveChangesAsync();

            return teacher;
        }

        public async Task<List<Teacher>?> DeleteAsync(string registrationCode)
        {
            var teacher = await _context.Set<Teacher>().FindAsync(registrationCode);
            if (teacher == null)
                return null;

            _context.Set<Teacher>().Remove(teacher);
            await _context.SaveChangesAsync();

            return await _context.Set<Teacher>().ToListAsync();
        }

        public string GenerateUniqueNumericCode()
        {
            const string prefix = "103";
            string randomPart = new(Guid.NewGuid().ToString("N").Where(char.IsDigit).Take(4).ToArray());
            string uniqueCode = prefix + randomPart.PadRight(7 - prefix.Length, '0');
            return uniqueCode;
        }

        public async Task<Teacher?> GetTeacherWithAssignment(string code)
        {
            var teacher = await _context.Set<Teacher>().Include(c => c.CreatedAssignments).FirstOrDefaultAsync(s => s.RegistrationCode == code);
            if (teacher == null)
                return null;

            return teacher;
        }

        public async Task<Teacher?> GetTeacherWithQualification(string code)
        {
            var teacher = await _context.Set<Teacher>().Include(c => c.Grades).FirstOrDefaultAsync(s => s.RegistrationCode == code);
            if (teacher == null)
                return null;

            return teacher;
        }
    }
}
