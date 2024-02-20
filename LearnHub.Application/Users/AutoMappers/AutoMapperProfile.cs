using AutoMapper;
using LearnHub.Application.Users.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetUser, User>();
            CreateMap<User, GetUser>();

            CreateMap<UpdateUser, User>();
            CreateMap<User, UpdateUser>();

        }
    }
}
