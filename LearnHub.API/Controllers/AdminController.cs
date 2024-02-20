using LearnHub.Application.Administrators.Dtos;
using LearnHub.Application.Users.Exceptions;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("/GetAllAdmins")]
        public async Task<ActionResult<List<GetAdmin>>> GetAllAdmins()
        {
            try
            {
                return Ok(await _userService.GetAllAdminsAsync());
            }
            catch (UserEmptyListException ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<GetAdmin>();
            }

        }

        [HttpPost("/AddAdmin")]
        public async Task<ActionResult<GetAdmin>> AddAdminAsync(CreateAdmin newAdmin)
        {
            try
            {
                
                return Ok(await _userService.AddAdminAsync(newAdmin));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("/GetAdminById")]
        public async Task<ActionResult<GetAdmin>> GetAdminById(int id)
        {
            try
            {
                return Ok(await _userService.GetAdminByIdAsync(id));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

        [HttpGet("/GetAdminByCode")]
        public async Task<ActionResult<GetAdmin>> GetAdminByCode(string registrationCode)
        {
            try
            {
                return Ok(await _userService.GetAdminByCodeAsync(registrationCode));
            }
            catch (UserEmptyListException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");
                //return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

        [HttpPut("/UpdateAdminByCode")]
        public async Task<ActionResult<GetAdmin>> UpdateAdminByCode(string registrationCode, UpdateAdmin admin)
        {
            try
            {
                return Ok(await _userService.UpdateAdminAsync(registrationCode, admin));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

        [HttpDelete("/DeleteAdminByCode")]
        public async Task<ActionResult<List<GetAdmin>>> DeleteAdminByCode(string registrationCode)
        {
            try
            {
                return Ok(await _userService.DeleteAdminAsync(registrationCode));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }
    }
}
