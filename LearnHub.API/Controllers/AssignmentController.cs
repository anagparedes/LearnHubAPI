using LearnHub.Application.Assignments.Interfaces;
using LearnHub.Application.Assignments.Dtos;
using LearnHub.Application.Assignments.Services;
using LearnHub.Application.Users.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LearnHub.Application.Courses.Dtos;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController(IAssignmentService assignmentService) : ControllerBase
    {
        private readonly IAssignmentService _assignmentService = assignmentService;

        [HttpGet("/GetAllAssignments")]
        public async Task<ActionResult<List<GetAssignment>>> GetAllAssignments()
        {
            try
            {
                return Ok(await _assignmentService.GetAllAssignmentAsync());
            }
            catch (UserEmptyListException ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<GetAssignment>();
            }

        }

        [HttpGet("/GetAssignmentByCode")]
        public async Task<ActionResult<GetAssignment>> GetAssignmentByCode(string assignmentCode)
        {
            try
            {
                return Ok(await _assignmentService.GetAssignmentByCodeAsync(assignmentCode));
            }
            catch (UserEmptyListException ex)
            {

                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [HttpGet("/GetAssignmentWithStudents")]
        public async Task<ActionResult<GetAssignmentWithStudent>> GetAssignmentWithStudents(string assignmentCode)
        {
            try
            {
                return Ok(await _assignmentService.GetAssignmentWithStudentAsync(assignmentCode));
            }
            catch (UserEmptyListException ex)
            {

                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [HttpPost("/AddAssignment")]
        public async Task<ActionResult<GetAssignment>> AddAssignmentAsync(CreateAssignment createAssignment)
        {
            try
            {
                return Ok(await _assignmentService.AddAssignmentAsync(createAssignment));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("/AddCourseToAssignment")]
        public async Task<ActionResult<GetAssignmentWithCourse>> AddCourseToAssignmentAsync(string assignmentCode, string courseCode)
        {
            try
            {
                return Ok(await _assignmentService.AddCourseToAssignment(assignmentCode, courseCode));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("/AddStudentToAssignment")]
        public async Task<ActionResult<GetAssignmentWithStudent>> AddStudentToAssignmentAsync(string assignmentCode, string studentCode)
        {
            try
            {
                return Ok(await _assignmentService.AddStudentsToAssignment(assignmentCode, studentCode));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost("/AddTeacherToAssignment")]
        public async Task<ActionResult<GetAssignmentWithTeacher>> AddTeacherToAssignmentAsync(string assignmentCode, string teacherCode)
        {
            try
            {
                return Ok(await _assignmentService.AddTeacherToAssignment(assignmentCode, teacherCode));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPut("/UpdateAssignment")]
        public async Task<ActionResult<GetAssignment>> UpdateAssignmentAsync(int id, CreateAssignment createAssignment)
        {
            try
            {
                return Ok(await _assignmentService.UpdateAssignmentAsync(id, createAssignment));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("/UpdateAssignmentWithStudentResponse")]
        public async Task<ActionResult<GetAssignment>> UpdateAssignmentWithStudentResponseAsync(int id, UpdateAssignmentWithStudentResponse updateAssignment)
        {
            try
            {
                return Ok(await _assignmentService.UpdateWithStudentResponseAsync(id, updateAssignment));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("/DeleteAssignmentByCode")]
        public async Task<ActionResult<List<GetAssignment>>> DeleteAssignmentByCode(string assignmentCode)
        {
            try
            {
                return Ok(await _assignmentService.DeleteAssignmentAsync(assignmentCode));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }
    }
}
