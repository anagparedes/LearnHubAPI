using AutoMapper;
using LearnHub.Application.Administrators.Dtos;
using LearnHub.Domain.Entities;

namespace LearnHub.Application.Administrator.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateAdmin, Admin>();
            CreateMap<Admin, CreateAdmin>();

            CreateMap<GetAdmin, Admin>();
            CreateMap<Admin, GetAdmin>();

            CreateMap<UpdateAdmin, Admin>();
            CreateMap<Admin, UpdateAdmin>();
        }
    }
}
