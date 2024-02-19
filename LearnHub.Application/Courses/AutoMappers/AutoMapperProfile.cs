using AutoMapper;
using LearnHub.Application.Courses.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCourse, Course>();
            CreateMap<Course, CreateCourse>();

            CreateMap<GetCourse, Course>();
            CreateMap<Course, GetCourse>();

            CreateMap<GetCourseWithTeacher, Course>();
            CreateMap<Course, GetCourseWithTeacher>();

            //CreateMap<Course, GetCourseWithStudent>();
            //CreateMap<GetCourseWithStudent, Course>();

            CreateMap<GetCourseWithAssignment, Course>();
            CreateMap<Course, GetCourseWithAssignment>();

            CreateMap<Course, GetCourseWithStudent>()
            .ForMember(dest => dest.EnrolledStudents, opt => opt.MapFrom(src => src.Enrollments.Select(e => e.Student)));
            CreateMap<GetCourseWithStudent, Course>();
               
        }
    }
}
