using LearnHub.Application.Assignments.Interfaces;
using LearnHub.Application.Assignments.Services;
using LearnHub.Application.Courses.Interfaces;
using LearnHub.Application.Courses.Services;
using LearnHub.Application.Qualifications.Interfaces;
using LearnHub.Application.Qualifications.Services;
using LearnHub.Application.Students.Interfaces;
using LearnHub.Application.Students.Services;
using LearnHub.Application.Teachers.Interfaces;
using LearnHub.Application.Teachers.Services;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Application.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearnHub.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            return service
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICourseService, CourseService>()
                .AddScoped<IAssignmentService, AssignmentService>()
                .AddScoped<IQualificationService, QualificationService>()
                .AddScoped<IStudentService, StudentService>()
                .AddScoped<ITeacherService, TeacherService>();
                //.AddScoped<IStudentService, StudentService>()
                //.AddScoped<ITeacherService, TeacherService>()
                //.AddScoped<IAdministratorService, AdminService>();
                
        }

    }
}
