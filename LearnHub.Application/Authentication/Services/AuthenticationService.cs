using AutoMapper;
using LearnHub.Application.Authentication.Dtos;
using LearnHub.Application.Authentication.Exceptions;
using LearnHub.Application.Authentication.Interfaces;
using LearnHub.Application.Users.Dtos;
using LearnHub.Application.Users.Exceptions;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Enums;
using LearnHub.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearnHub.Application.Authentication.Services
{
    public class AuthenticationService(IAuthenticationRepository authenticationRepository, IConfiguration configuration, IMapper mapper) : IAuthenticationService
    {
        public readonly User user = new();
        private readonly IConfiguration _configuration = configuration;
        private readonly IAuthenticationRepository _authenticationRepository = authenticationRepository;
        private readonly IMapper _mapper = mapper;

        public string CreateToken(User user)
        {
            string? emailDomain = user.Email?.Split('@').LastOrDefault()?.ToLower();
            Roles userRole = GetUserRoleFromEmailDomain(emailDomain!);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.FullName!)
            };

            if (userRole != Roles.Unknown)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.ToString()));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _authenticationRepository.GetUserByEmail(request.Email!) ?? throw new UserNotFoundException();
            string token = CreateToken(user);
            user.Token = token;

            return _mapper.Map<LoginResponse>(user);
        }


        public GetUser Register(LoginRequest request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Email = request.Email;
            user.Password = passwordHash;

            return _mapper.Map<GetUser>(user);
        }

        private static Roles GetUserRoleFromEmailDomain(string emailDomain)
        {
            return emailDomain switch
            {
                "est.learnhub.edu.do" => Roles.Student,
                "prof.learnhub.edu.do" => Roles.Teacher,
                "admin.learnhub.edu.do" => Roles.Admin,
                _ => Roles.Unknown,
            };
        }
    }
}
