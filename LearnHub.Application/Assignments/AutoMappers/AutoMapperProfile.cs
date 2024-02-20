using AutoMapper;
using LearnHub.Application.Assignments.Dtos;
using LearnHub.Application.Students.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateAssignment, Assignment>();
            CreateMap<Assignment, CreateAssignment>();

            CreateMap<GetAssignment, Assignment>();
            CreateMap<Assignment, GetAssignment>();

            CreateMap<GetAssignmentWithStudentResponse, Assignment>();
            CreateMap<Assignment, GetAssignmentWithStudentResponse>();

            CreateMap<GetAssignmentWithCourse, Assignment>();
            CreateMap<Assignment, GetAssignmentWithCourse>();

            CreateMap<GetAssignmentWithTeacher, Assignment>();
            CreateMap<Assignment, GetAssignmentWithTeacher>();

            CreateMap<Assignment, GetAssignmentWithStudent>()
             .ForMember(dest => dest.AssignedStudents, opt => opt.MapFrom(src => src.AssignedStudents.Select(e => e.Student)));
            CreateMap<GetAssignmentWithStudent, Assignment>();
        }
        
    }
}
