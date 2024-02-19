using AutoMapper;
using LearnHub.Application.Assignments.Dtos;
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

            CreateMap<GetAssignmentWithStudent, Assignment>();
            CreateMap<Assignment, GetAssignmentWithStudent>();

            CreateMap<GetAssignmentWithTeacher, Assignment>();
            CreateMap<Assignment, GetAssignmentWithTeacher>();
        }
        
    }
}
