using AutoMapper;
using LearnHub.Application.Authentication.Dtos;
using LearnHub.Application.Authentication.Interfaces;
using LearnHub.Application.Users.Dtos;
using LearnHub.Application.Users.Exceptions;
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
            try
            {
                var register = _authenticationService.Register(request);
                return Ok(_mapper.Map<GetUser>(register));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            try
            {
                var user = await _authenticationService.Login(request);
                return Ok(user);

            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}

