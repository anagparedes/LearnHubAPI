using AutoMapper;
using LearnHub.Application.Authentication.Interfaces;
using LearnHub.Application.Users.Dtos;
using LearnHub.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService authenticationService, IMapper mapper) : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        private readonly IMapper _mapper = mapper;

        [HttpPost("register")]
        public ActionResult<GetUser> Register(LoginRequest request)
        {
            var register = _authenticationService.Register(request);

            return Ok(_mapper.Map<GetUser>(register));
        }

        [HttpPost("login")]
        public ActionResult<User> Login(LoginRequest request)
        {

            var token = _authenticationService.Login(request);
            return Ok(token);
        }
    }
}

