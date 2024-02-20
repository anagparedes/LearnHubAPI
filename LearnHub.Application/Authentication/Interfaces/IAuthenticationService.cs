using LearnHub.Application.Users.Dtos;
using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        GetUser Register(LoginRequest request);
        string Login(LoginRequest request);
        string CreateToken(User user);
    }
}
