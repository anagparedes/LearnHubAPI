using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Infrastructure.Repositories.Authentication
{
    public class AuthenticationRepository(LearnHubDbContext context) : IAuthenticationRepository
    {
        private readonly LearnHubDbContext _context = context;


        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(s => s.Email == email);
            if (user == null)
                return null;
            return user;
        }


    }
}
