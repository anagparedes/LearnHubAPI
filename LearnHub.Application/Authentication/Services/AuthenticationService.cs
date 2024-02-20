using AutoMapper;
using LearnHub.Application.Authentication.Exceptions;
using LearnHub.Application.Authentication.Interfaces;
using LearnHub.Application.Users.Dtos;
using LearnHub.Application.Users.Exceptions;
using LearnHub.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearnHub.Application.Authentication.Services
{
    public class AuthenticationService(IConfiguration configuration, IMapper mapper) : IAuthenticationService
    {
        public readonly User user = new();
        private readonly IConfiguration _configuration = configuration;
        private readonly IMapper _mapper = mapper;

        public string CreateToken(User user)
        {
            List<Claim> claims =
            [
                new Claim(ClaimTypes.Name, user.FullName!)
            ];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string Login(LoginRequest request)
        {
            if (user.Email != request.Email)
            {
               UserNotFoundException ex = new();
                return ex.Message;
            }
            if (!BCrypt.Net.BCrypt.Verify(request.PasswordHash, user.PasswordHash))
            {
                WrongPasswordException ex = new();
                return ex.Message;
            }

            string token = CreateToken(user);
            return token;
        }

        public GetUser Register(LoginRequest request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);

            user.Email = request.Email;
            user.PasswordHash = passwordHash;

            return _mapper.Map<GetUser>(user);
        }
    }
}
