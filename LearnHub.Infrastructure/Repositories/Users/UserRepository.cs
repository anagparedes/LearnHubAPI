using Azure.Core;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using LearnHub.Domain.Interfaces.Repositories;
using LearnHub.Domain.Models;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Infrastructure.Repositories.Users
{
    public class UserRepository: IUserRepository
    {
        private readonly LearnHubDbContext _context;

        public UserRepository(LearnHubDbContext context)
        {
            _context = context;
        }
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
            var user = await _context.Set<User>().FirstOrDefaultAsync(s => s.RegistrationCode.Equals(code));
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 7).ToUpper();
        }
    }
}
