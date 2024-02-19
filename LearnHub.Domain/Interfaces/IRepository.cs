using LearnHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetbyIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(string code, T entity);
        Task<List<T>?> DeleteAsync(string code);
    }
}
