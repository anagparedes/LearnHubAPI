using LearnHub.Application.Courses.Dtos;
using LearnHub.Application.Courses.Interfaces;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Users.Dtos;
using LearnHub.Application.Users.Exceptions;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Application.Users.Services;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        private readonly ICourseService _courseService = courseService;

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("/GetAllCourses")]
        public async Task<ActionResult<List<GetCourse>>> GetAllCourses()
        {
            try
            {
                return Ok(await _courseService.GetAllCoursesAsync());
            }
            catch (UserEmptyListException ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<GetCourse>();
            }

        }
        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet("/GetCourseByCode")]
        public async Task<ActionResult<GetCourse>> GetCourseByCode(string courseCode)
        {
            try
            {
                return Ok(await _courseService.GetCourseByCodeAsync(courseCode));
            }
            catch (UserEmptyListException ex)
            {

                return NotFound($"An error occurred: {ex.Message}");

            }

        }
        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetCourseWithStudent")]
        public async Task<ActionResult<GetCourseWithStudent>> GetCourseWithStudent(string courseCode)
        {
            try
            {
                return Ok(await _courseService.GetCourseWithStudentAsync(courseCode));
            }
            catch (UserEmptyListException ex)
            {

                return NotFound($"An error occurred: {ex.Message}");

            }

        }
        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddInPersonCourse")]
        public async Task<ActionResult<GetCourse>> AddInPersonCourseAsync(CreateCourse newCourse)
        {
            try
            {
                return Ok(await _courseService.AddInPersonCourseAsync(newCourse));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddOnlineCourse")]
        public async Task<ActionResult<GetCourse>> AddOnlineCourseAsync(CreateCourse newCourse)
        {
            try
            {
               
                return Ok(await _courseService.AddOnlineCourseAsync(newCourse));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddStudentToCourse")]
        public async Task<ActionResult<GetCourseWithStudent>> AddStudentToCourseAsync(string courseCode, string studentCode)
        {
            try
            {
                return Ok(await _courseService.AddStudentsToCourse(courseCode,studentCode));
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddTeacherToCourse")]
        public async Task<ActionResult<GetCourseWithTeacher>> AddTeacherToCourseAsync(string courseCode, string teacherCode)
        {
            try
            {
                return Ok(await _courseService.AddTeacherToCourse(courseCode, teacherCode));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddAssignmentToCourse")]
        public async Task<ActionResult<GetCourseWithAssignment>> AddAssignmentToCourseAsync(string courseCode, string assignmentCode)
        {
            try
            {
                return Ok(await _courseService.AddTeacherToCourse(courseCode, assignmentCode));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut("/UpdateCourseById")]
        public async Task<ActionResult<GetCourse>> UpdateCourseById(int id, CreateCourse createCourse)
        {
            try
            {
                return Ok(await _courseService.UpdateCourseAsync(id, createCourse));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("/DeleteCourseByCode")]
        public async Task<ActionResult<List<GetCourse>>> DeleteCourseByCode(string courseCode)
        {
            try
            {
                return Ok(await _courseService.DeleteCourseAsync(courseCode));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

    }
}
