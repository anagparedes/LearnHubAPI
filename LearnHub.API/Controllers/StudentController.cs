using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Users.Exceptions;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUserService _userService;

        public StudentController(IUserService userService)
        {
            _userService = userService;
        }

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
                //return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

        [HttpGet("/GetStudentCourses")]
        public async Task<ActionResult<GetStudent>> GetStudentCourses(string registrationCode)
        {
            try
            {
                return Ok(await _userService.GetStudentWithCourseAsync(registrationCode));
            }
            catch (UserEmptyListException ex)
            {
                return NotFound($"An error occurred: {ex.Message}");
                //return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

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
