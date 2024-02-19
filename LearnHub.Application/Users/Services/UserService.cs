using AutoMapper;
using LearnHub.Application.Administrators.Dtos;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Teachers.Dtos;
using LearnHub.Application.Users.Dtos;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LearnHub.Application.Users.Services
{
    public class UserService: IUserService
    {
        
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAdministratorRepository _administratorRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IStudentRepository studentRepository, IUserRepository userRepository, IAdministratorRepository administratorRepository,ITeacherRepository teacherRepository, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _administratorRepository = administratorRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUser>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => _mapper.Map<GetUser>(user)).ToList();  
        
        }

        public async Task<GetUser> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetbyIdAsync(id);
            return _mapper.Map<GetUser>(user);
        }

        public async Task<GetUser?> GetUserByCodeAsync(string registrationCode)
        {
            var user = await _userRepository.GetbyCodeAsync(registrationCode);
            return _mapper.Map<GetUser>(user);
        }

        public async Task<List<GetStudent>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(st => _mapper.Map<GetStudent>(st)).ToList();
        }

        public async Task<GetStudent> AddStudentAsync(CreateStudent createStudent)
        {
            var student = new Student
            {
                FirstName = createStudent.FirstName,
                LastName = createStudent.LastName,
                Career = createStudent.Career,
                Gender = createStudent.Gender,
                Telephone = createStudent.Telephone,
                IdentificationCard = createStudent.IdentificationCard,
                PasswordHash = createStudent.PasswordHash,
            };
            var newStudent = await _studentRepository.AddAsync(student);
            return _mapper.Map<GetStudent>(newStudent);
        }

        public async Task<GetStudent?> GetStudentByIdAsync(int id)
        {
            var user = await _studentRepository.GetbyIdAsync(id);
            return _mapper.Map<GetStudent>(user);
        }
        public async Task<GetStudent?> GetStudentByCodeAsync(string registrationCode)
        {
            var user = await _studentRepository.GetbyCodeAsync(registrationCode);
            return _mapper.Map<GetStudent>(user);
        }

        public async Task<GetStudentWithCourse?> GetStudentWithCourseAsync(string registrationCode)
        {
            var user = await _studentRepository.GetStudentWithCourse(registrationCode);
            return _mapper.Map<GetStudentWithCourse>(user);
        }

        public async Task<UpdateStudent?> UpdateStudentAsync(string registrationCode,  UpdateStudent updateStudent)
        {
            var student = new Student
            {
                FirstName = updateStudent.FirstName,
                LastName = updateStudent.LastName,
                Email = updateStudent.Email,
                Telephone = updateStudent.Telephone,
                Career = updateStudent.Career,
                Status = updateStudent.Status,
            };
            var newStudent = await _studentRepository.UpdateAsync(registrationCode, student);
            return _mapper.Map<UpdateStudent>(newStudent);
        }

        public async Task<List<GetStudent>?> DeleteStudentAsync(string registrationCode)
        {
            var user = await _studentRepository.DeleteAsync(registrationCode);
            return user?.Select(st => _mapper.Map<GetStudent>(st)).ToList();
        }

        public async Task<List<GetTeacher>> GetAllTeachersAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return teachers.Select(st => _mapper.Map<GetTeacher>(st)).ToList();
        }

        public async Task<GetTeacher> AddTeacherAsync(CreateTeacher createTeacher)
        {
            var teacher = new Teacher
            {
                FirstName = createTeacher.FirstName,
                LastName = createTeacher.LastName,
                Career = createTeacher.Career,
                careerArea = createTeacher.careerArea,
                Gender = createTeacher.Gender,
                Telephone = createTeacher.Telephone,
                IdentificationCard = createTeacher.IdentificationCard,
                PasswordHash = createTeacher.PasswordHash,
            };
            var newTeacher = await _teacherRepository.AddAsync(teacher);
            return _mapper.Map<GetTeacher>(newTeacher);
        }

        public async Task<GetTeacher?> GetTeacherByIdAsync(int id)
        {
            var teacher = await _teacherRepository.GetbyIdAsync(id);
            return _mapper.Map<GetTeacher>(teacher);
        }
        public async Task<GetTeacher?> GetTeacherByCodeAsync(string registrationCode)
        {
            var teacher = await _teacherRepository.GetbyCodeAsync(registrationCode);
            return _mapper.Map<GetTeacher>(teacher);
        }
        public async Task<UpdateTeacher?> UpdateTeacherAsync(string registrationCode, UpdateTeacher updateTeacher)
        {
            var teacher = new Teacher
            {
                FirstName = updateTeacher.FirstName,
                LastName = updateTeacher.LastName,
                Email = updateTeacher.Email,
                Telephone = updateTeacher.Telephone,
                Career = updateTeacher.Career,
                careerArea = updateTeacher.careerArea,
                Status = updateTeacher.Status,
            };
            var newTeacher = await _teacherRepository.UpdateAsync(registrationCode, teacher);
            return _mapper.Map<UpdateTeacher>(newTeacher);
        }

        public async Task<List<GetTeacher>?> DeleteTeacherAsync(string registrationCode)
        {
            var user = await _teacherRepository.DeleteAsync(registrationCode);
            return user?.Select(st => _mapper.Map<GetTeacher>(st)).ToList();
        }

        public async Task<List<GetAdmin>> GetAllAdminsAsync()
        {
            var admins = await _administratorRepository.GetAllAsync();
            return admins.Select(st => _mapper.Map<GetAdmin>(st)).ToList();
        }
        public async Task<GetAdmin> AddAdminAsync(CreateAdmin createAdmin)
        {
            var admin = new Admin
            {
                FirstName = createAdmin.FirstName,
                LastName = createAdmin.LastName,
                PasswordHash = createAdmin.PasswordHash,
            };
            var newAdmin = await _administratorRepository.AddAsync(admin);
            return _mapper.Map<GetAdmin>(newAdmin);
        }

        public async Task<GetAdmin?> GetAdminByIdAsync(int id)
        {
            var admin = await _administratorRepository.GetbyIdAsync(id);
            return _mapper.Map<GetAdmin>(admin);
        }
        public async Task<GetAdmin?> GetAdminByCodeAsync(string registrationCode)
        {
            var admin = await _administratorRepository.GetbyCodeAsync(registrationCode);
            return _mapper.Map<GetAdmin>(admin);
        }
        public async Task<GetAdmin?> UpdateAdminAsync(string registrationCode, UpdateAdmin updateAdmin)
        {
            var admin = new Admin
            {
                FirstName = updateAdmin.FirstName,
                LastName = updateAdmin.LastName,
                Email = updateAdmin.Email,
                PasswordHash = updateAdmin.PasswordHash,
            };
            var newAdmin = await _administratorRepository.UpdateAsync(registrationCode, admin);
            return _mapper.Map<GetAdmin>(newAdmin);
        }

        public async Task<List<GetAdmin>?> DeleteAdminAsync(string registrationCode)
        {
            var admin = await _administratorRepository.DeleteAsync(registrationCode);
            return admin?.Select(st => _mapper.Map<GetAdmin>(st)).ToList();
        }
    }
}
