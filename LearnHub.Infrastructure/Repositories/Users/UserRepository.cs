using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Infrastructure.Repositories.Users
{
    public class UserRepository(LearnHubDbContext context) : IUserRepository
    {
        private readonly LearnHubDbContext _context = context;

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Set<User>().ToListAsync();
        }

        public async Task<User?> GetbyIdAsync(int id)
        {
            var user = await _context.Set<User>().FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<User?> GetbyCodeAsync(string code)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(s => s.RegistrationCode == code);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString("N")[..7].ToUpper();
        }
    }
}
