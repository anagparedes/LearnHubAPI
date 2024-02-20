using AutoMapper;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Teachers.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Teachers.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateTeacher, Teacher>();
            CreateMap<Teacher, CreateTeacher>();

            CreateMap<GetTeacher, Teacher>();
            CreateMap<Teacher, GetTeacher>();

            CreateMap<UpdateTeacher, Teacher>();
            CreateMap<Teacher, UpdateTeacher>();

            CreateMap<Teacher, GetTeacherWithAssignment>()
             .ForMember(dest => dest.CreatedAssignments, opt => opt.MapFrom(src => src.CreatedAssignments));
            CreateMap<GetTeacherWithAssignment, Teacher>();

            CreateMap<Teacher, GetTeacherWithCourse>()
            .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses))
            .PreserveReferences();
            CreateMap<GetTeacherWithCourse, Teacher>()
                .PreserveReferences();

            CreateMap<Teacher, GetTeacherWithQualification>()
            .ForMember(dest => dest.Grades, opt => opt.MapFrom(src => src.Grades));
            CreateMap<GetTeacherWithQualification, Teacher>();
        }
    }
}
