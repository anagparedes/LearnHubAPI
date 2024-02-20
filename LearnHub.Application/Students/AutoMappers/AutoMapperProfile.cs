using AutoMapper;
using LearnHub.Application.Courses.Dtos;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Users.Dtos;
using LearnHub.Domain.Entities;

namespace LearnHub.Application.Students.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateStudent, Student>();
            CreateMap<Student, CreateStudent>();

            CreateMap<GetStudent, Student>();
            CreateMap<Student, GetStudent>();

            CreateMap<UpdateStudent, Student>();
            CreateMap<Student, UpdateStudent>();

            CreateMap<GetStudentWithCourse, Student>();
            CreateMap<Student, GetStudentWithCourse>();

            CreateMap<Student, GetStudentWithCourse>()
             .ForMember(dest => dest.EnrolledCourses, opt => opt.MapFrom(src => src.Enrollments!.Select(e => e.Course)));
            CreateMap<GetStudentWithCourse, Student>();

        }

    }
}
