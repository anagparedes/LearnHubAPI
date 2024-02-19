using AutoMapper;
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

        }
    }
}
