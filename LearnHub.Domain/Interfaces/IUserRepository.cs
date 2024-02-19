using LearnHub.Domain.Entities;
using LearnHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetbyIdAsync(int id);
        Task<User?> GetbyCodeAsync(string code);
        string GenerateUniqueCode();
    }
}
