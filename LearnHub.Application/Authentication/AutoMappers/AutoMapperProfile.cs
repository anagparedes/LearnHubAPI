using AutoMapper;
using LearnHub.Application.Authentication.Dtos;
using LearnHub.Application.Users.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Authentication.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {

                CreateMap<LoginRequest,User> ();
                CreateMap<User, LoginRequest>();

                CreateMap<LoginResponse, User>();
                CreateMap<User, LoginResponse>();

        }
    }
}
