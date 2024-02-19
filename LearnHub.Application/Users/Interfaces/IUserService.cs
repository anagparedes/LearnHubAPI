using LearnHub.Application.Administrators.Dtos;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Teachers.Dtos;
using LearnHub.Application.Users.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<List<GetUser>> GetAllUsersAsync();
        Task<GetUser> GetUserByIdAsync(int id);
        Task<GetUser?> GetUserByCodeAsync(string registrationCode);

        Task<List<GetStudent>> GetAllStudentsAsync();
        Task<GetStudent> AddStudentAsync(CreateStudent newStudent);
        Task<GetStudent?> GetStudentByIdAsync(int id);
        Task<GetStudent?> GetStudentByCodeAsync(string registrationCode);
        Task<GetStudentWithCourse?> GetStudentWithCourseAsync(string registrationCode);
        Task<UpdateStudent?> UpdateStudentAsync(string registrationCode, UpdateStudent updateStudent);
        Task<List<GetStudent>?> DeleteStudentAsync(string registrationCode);

        Task<List<GetTeacher>> GetAllTeachersAsync();
        Task<GetTeacher> AddTeacherAsync(CreateTeacher newTeacher);
        Task<GetTeacher?> GetTeacherByIdAsync(int id);
        Task<GetTeacher?> GetTeacherByCodeAsync(string registrationCode);
        Task<UpdateTeacher?> UpdateTeacherAsync(string registrationCode, UpdateTeacher updateTeacher);
        Task<List<GetTeacher>?> DeleteTeacherAsync(string registrationCode);



        Task<List<GetAdmin>> GetAllAdminsAsync();
        Task<GetAdmin> AddAdminAsync(CreateAdmin newAdmin);
        Task<GetAdmin?> GetAdminByIdAsync(int id);
        Task<GetAdmin?> GetAdminByCodeAsync(string registrationCode);
        Task<GetAdmin?> UpdateAdminAsync(string registrationCode, UpdateAdmin updateAdmin);
        Task<List<GetAdmin>?> DeleteAdminAsync(string registrationCode);
        //Task ForgotPasswordAsync(string email);
    }

}
