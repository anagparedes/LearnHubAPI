using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Interfaces.Repositories
{
    public class RepositoryUser
    {
        private readonly DbContext _context;
        public RepositoryUser(DbContext context)
        {
            _context = context;
        }

    }
}
