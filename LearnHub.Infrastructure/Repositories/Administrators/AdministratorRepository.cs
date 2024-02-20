using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Infrastructure.Repositories.Administrators
{
    public class AdministratorRepository(LearnHubDbContext context) : IAdministratorRepository
    {
        private readonly LearnHubDbContext _context = context;

        public async Task<Admin> AddAsync(Admin newAdmin)
        {
            newAdmin.Role = Domain.Enums.Roles.Admin;
            newAdmin.RegistrationCode = GenerateUniqueNumericCode();
            // Verify the unicity of Code
            while (await _context.Set<Admin>().AnyAsync(e => e.RegistrationCode == newAdmin.RegistrationCode))
            {
                newAdmin.RegistrationCode = GenerateUniqueNumericCode();
            }
            newAdmin.FullName = $"{newAdmin.FirstName} {newAdmin.LastName}";
            newAdmin.Email = $"{newAdmin.RegistrationCode}@admin.learnhub.edu.do";
            _context.Set<Admin>().Add(newAdmin);
            await _context.SaveChangesAsync();
            return newAdmin;
           
        }

        public async Task<List<Admin>> GetAllAsync()
        {
            return await _context.Set<Admin>().ToListAsync();
        }

        public async Task<Admin?> GetbyIdAsync(int id)
        {
            var admin = await _context.Set<Admin>().FindAsync(id);
            if (admin == null)
                return null;
            return admin;
        }

        public async Task<Admin?> GetbyCodeAsync(string code)
        {
            var admin = await _context.Set<Admin>().FirstOrDefaultAsync(s => s.RegistrationCode == code);
            if (admin == null)
                return null;
            return admin;
        }

        public async Task<Admin?> UpdateAsync(string registrationCode, Admin entity)
        {
            var admin = await _context.Set<Admin>().FirstOrDefaultAsync(s => s.RegistrationCode == registrationCode);

            if (admin == null)
                return null;

            admin.FirstName = entity.FirstName;
            admin.LastName = entity.LastName;
            admin.FullName = $"{entity.FirstName} {entity.LastName}";
            admin.Email = entity.Email;
            admin.PasswordHash = entity.PasswordHash;
         
            if (admin.RegistrationCode is null)
            {
                admin.RegistrationCode = GenerateUniqueNumericCode();
                // Verify the unicity of RegistrationCode
                while (await _context.Set<Admin>().AnyAsync(e => e.RegistrationCode == entity.RegistrationCode))
                {
                    admin.RegistrationCode = GenerateUniqueNumericCode();
                }
            }

            await _context.SaveChangesAsync();

            return admin;
        }

        public async Task<List<Admin>?> DeleteAsync(string registrationCode)
        {
            var admin = await _context.Set<Admin>().FirstOrDefaultAsync(s => s.RegistrationCode == registrationCode);
            if (admin == null)
                return null;

            _context.Set<Admin>().Remove(admin);
            await _context.SaveChangesAsync();

            return await _context.Set<Admin>().ToListAsync();
        }
        public string GenerateUniqueNumericCode()
        {
            const string prefix = "101";
            string randomPart = new(Guid.NewGuid().ToString("N").Where(char.IsDigit).Take(4).ToArray());
            string uniqueCode = prefix + randomPart.PadRight(7 - prefix.Length, '0');
            return uniqueCode;
        }
    }
}
