using LearnHub.Application.Assignments.Interfaces;
using LearnHub.Application.Assignments.Dtos;
using LearnHub.Application.Users.Exceptions;
using Microsoft.AspNetCore.Mvc;
using LearnHub.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using LearnHub.Application.Assignments.Exceptions;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController(IAssignmentService assignmentService) : ControllerBase
    {
        private readonly IAssignmentService _assignmentService = assignmentService;

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetAllAssignments")]
        public async Task<ActionResult<List<GetAssignment>>> GetAllAssignments()
        {
            try
            {
                return Ok(await _assignmentService.GetAllAssignmentAsync());
            }
            catch (EmptyAssignmentListException ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<GetAssignment>();
            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetAssignmentByCode")]
        public async Task<ActionResult<GetAssignment>> GetAssignmentByCode(string assignmentCode)
        {
            try
            {
                return Ok(await _assignmentService.GetAssignmentByCodeAsync(assignmentCode));
            }
            catch (AssignmentNotFoundException ex)
            {

                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetAssignmentWithStudents")]
        public async Task<ActionResult<GetAssignmentWithStudent>> GetAssignmentWithStudents(string assignmentCode)
        {
            try
            {
                return Ok(await _assignmentService.GetAssignmentWithStudentAsync(assignmentCode));
            }
            catch (AssignmentNotFoundException ex)
            {

                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpPost("/AddAssignment")]
        public async Task<ActionResult<GetAssignment>> AddAssignmentAsync(CreateAssignment createAssignment)
        {
            try
            {
                return Ok(await _assignmentService.AddAssignmentAsync(createAssignment));
            }
            catch (InvalidAssignmentException ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddCourseToAssignment")]
        public async Task<ActionResult<GetAssignmentWithCourse>> AddCourseToAssignmentAsync(string assignmentCode, string courseCode)
        {
            try
            {
                return Ok(await _assignmentService.AddCourseToAssignment(assignmentCode, courseCode));

            }
            catch (AssignmentOrCourseNotFoundException ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddStudentToAssignment")]
        public async Task<ActionResult<GetAssignmentWithStudent>> AddStudentToAssignmentAsync(string assignmentCode, string studentCode)
        {
            try
            {
                return Ok(await _assignmentService.AddStudentsToAssignment(assignmentCode, studentCode));

            }
            catch (AssignmentOrStudentNotFoundException ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost("/AddTeacherToAssignment")]
        public async Task<ActionResult<GetAssignmentWithTeacher>> AddTeacherToAssignmentAsync(string assignmentCode, string teacherCode)
        {
            try
            {
                return Ok(await _assignmentService.AddTeacherToAssignment(assignmentCode, teacherCode));

            }
            catch (AssignmentOrTeacherNotFoundException ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpPut("/UpdateAssignment")]
        public async Task<ActionResult<GetAssignment>> UpdateAssignmentAsync(int id, CreateAssignment createAssignment)
        {
            try
            {
                return Ok(await _assignmentService.UpdateAssignmentAsync(id, createAssignment));

            }
            catch (AssignmentNotFoundException ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Student))]
        [HttpPut("/UpdateAssignmentWithStudentResponse")]
        public async Task<ActionResult<GetAssignment>> UpdateAssignmentWithStudentResponseAsync(int id, UpdateAssignmentWithStudentResponse updateAssignment)
        {
            try
            {
                return Ok(await _assignmentService.UpdateWithStudentResponseAsync(id, updateAssignment));

            }
            catch (AssignmentNotFoundException ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpDelete("/DeleteAssignmentByCode")]
        public async Task<ActionResult<List<GetAssignment>>> DeleteAssignmentByCode(string assignmentCode)
        {
            try
            {
                return Ok(await _assignmentService.DeleteAssignmentAsync(assignmentCode));
            }
            catch (AssignmentNotFoundException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }
    }
}
