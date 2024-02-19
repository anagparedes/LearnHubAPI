using AutoMapper;
using LearnHub.Application.Qualifications.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Qualifications.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetQualification, Qualification>();
            CreateMap<Qualification, GetQualification>();

            CreateMap<CreateQualification, Qualification>();
            CreateMap<Qualification, CreateQualification>();
        }
    }
}
