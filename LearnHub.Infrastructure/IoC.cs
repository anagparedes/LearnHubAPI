using LearnHub.Application.Users.Interfaces;
using LearnHub.Domain.Interfaces;
using LearnHub.Infrastructure.Repositories.Administrators;
using LearnHub.Infrastructure.Repositories.Assignments;
using LearnHub.Infrastructure.Repositories.Authentication;
using LearnHub.Infrastructure.Repositories.Courses;
using LearnHub.Infrastructure.Repositories.Qualifications;
using LearnHub.Infrastructure.Repositories.Students;
using LearnHub.Infrastructure.Repositories.Teachers;
using LearnHub.Infrastructure.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LearnHub.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service) 
        {
            return service
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IAuthenticationRepository, AuthenticationRepository>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<IAdministratorRepository, AdministratorRepository>()
                .AddScoped<ITeacherRepository, TeacherRepository>()
                .AddScoped<ICourseRepository, CourseRepository>()
                .AddScoped<IAssignmentRepository, AssignmentRepository>()
                .AddScoped<IQualificationRepository, QualificationRepository>();
                
        
        }

    }
}
