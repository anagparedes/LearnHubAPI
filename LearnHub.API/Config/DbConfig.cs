using LearnHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LearnHub.API.Config
{
    public static class DbConfig
    {
        public static IServiceCollection ConfigDbConnection(this IServiceCollection service, IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            service.AddDbContext<LearnHubDbContext>(options => options.UseSqlServer(connectionString));

            return service;
        }
    }
}
