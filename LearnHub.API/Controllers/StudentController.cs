using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Students.Interfaces;
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
    public class StudentController(IUserService userService, IStudentService studentService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IStudentService _studentService = studentService;

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("/GetAllStudents")]
        public async Task<ActionResult<List<GetStudent>>> GetAllStudents()
        {
            try
            {
                return Ok(await _userService.GetAllStudentsAsync());
            }
            catch (UserEmptyListException ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<GetStudent>();
            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddStudent")]
        public async Task<ActionResult<GetStudent>> AddStudentAsync(CreateStudent newStudent)
        {
            try
            {
               
                return Ok(await _userService.AddStudentAsync(newStudent));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("/GetStudentById")]
        public async Task<ActionResult<GetStudent>> GetStudentById(int id)
        {
            try
            {
                return Ok(await _userService.GetStudentByIdAsync(id));
            }
            catch (UserEmptyListException ex)
            {
                return StatusCode(404, $"An error occurred: {ex.Message}");
            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("/GetStudentByCode")]
        public async Task<ActionResult<GetStudent>> GetStudentByCode(string registrationCode)
        {
            try
            {
                return Ok(await _userService.GetStudentByCodeAsync(registrationCode));
            }
            catch (UserEmptyListException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("/GetStudentCourses")]
        public async Task<ActionResult<GetStudent>> GetStudentCourses(string registrationCode)
        {
            try
            {
                return Ok(await _studentService.GetStudentWithCourse(registrationCode));
            }
            catch (UserEmptyListException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetStudentWithAssignments")]
        public async Task<ActionResult<GetStudent>> GetStudentWithAssignments(string registrationCode)
        {
            try
            {
                return Ok(await _studentService.GetStudentWithAssignment(registrationCode));
            }
            catch (UserEmptyListException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");
            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetStudentWithQualification")]
        public async Task<ActionResult<GetStudent>> GetStudentWithQualification(string registrationCode)
        {
            try
            {
                return Ok(await _studentService.GetStudentWithQualification(registrationCode));
            }
            catch (UserEmptyListException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("/UpdateStudentByCode")]
        public async Task<ActionResult<UpdateStudent>> UpdateStudentByCode(string registrationCode, UpdateStudent student)
        {
            try
            {
                return Ok(await _userService.UpdateStudentAsync(registrationCode, student));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("/DeleteStudentByCode")]
        public async Task<ActionResult<List<GetStudent>>> DeleteStudentByCode(string registrationCode)
        {
            try
            {
                return Ok(await _userService.DeleteStudentAsync(registrationCode));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }
    }
}
