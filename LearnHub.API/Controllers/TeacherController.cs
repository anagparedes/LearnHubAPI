using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Teachers.Dtos;
using LearnHub.Application.Teachers.Interfaces;
using LearnHub.Application.Users.Exceptions;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(ITeacherService teacherService, IUserService userService) : ControllerBase
    {
        private readonly ITeacherService _teacherService = teacherService;
        private readonly IUserService _userService = userService;

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("/GetAllTeachers")]
        public async Task<ActionResult<List<GetTeacher>>> GetAllTeachers()
        {
            try
            {
                return Ok(await _userService.GetAllTeachersAsync());
            }
            catch (UserEmptyListException ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<GetTeacher>();
            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetTeacherCourses")]
        public async Task<ActionResult<GetTeacherWithCourse>> GetTeacherWithCourse(string registrationCode)
        {
            try
            {
                return Ok(await _teacherService.GetTeacherWithCourse(registrationCode));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetTeacherAssignments")]
        public async Task<ActionResult<GetStudent>> GetTeacherAssignments(string registrationCode)
        {
            try
            {
                return Ok(await _teacherService.GetTeacherWithAssignment(registrationCode));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");
            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetTeacherQualifications")]
        public async Task<ActionResult<GetStudent>> GetTeacherQualification(string registrationCode)
        {
            try
            {
                return Ok(await _teacherService.GetTeacherWithQualification(registrationCode));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddTeacher")]
        public async Task<ActionResult<GetTeacher>> AddTeacherAsync(CreateTeacher newTeacher)
        {
            try
            {
                
                return Ok(await _userService.AddTeacherAsync(newTeacher));
            }
            catch (InvalidUserException ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("/GetTeacherById")]
        public async Task<ActionResult<GetTeacher>> GetTeacherById(int id)
        {
            try
            {
                return Ok(await _userService.GetTeacherByIdAsync(id));
            }
            catch (UserNotFoundException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("/GetTeacherByCode")]
        public async Task<ActionResult<GetTeacher>> GetTeacherByCode(string registrationCode)
        {
            try
            {
                return Ok(await _userService.GetTeacherByCodeAsync(registrationCode));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("/UpdateTeacherByCode")]
        public async Task<ActionResult<UpdateTeacher>> UpdateTeacherByCode(string registrationCode, UpdateTeacher teacher)
        {
            try
            {
                return Ok(await _userService.UpdateTeacherAsync(registrationCode, teacher));
            }
            catch (UserNotFoundException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("/DeleteTeacherByCode")]
        public async Task<ActionResult<List<GetTeacher>>> DeleteTeacherByCode(string registrationCode)
        {
            try
            {
                return Ok(await _userService.DeleteTeacherAsync(registrationCode));
            }
            catch (UserNotFoundException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }
    }
}
