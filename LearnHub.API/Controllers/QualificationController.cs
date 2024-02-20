using LearnHub.Application.Qualifications.Dtos;
using LearnHub.Application.Qualifications.Exceptions;
using LearnHub.Application.Qualifications.Interfaces;
using LearnHub.Application.Users.Exceptions;
using LearnHub.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController(IQualificationService qualificationService) : ControllerBase
    {
        private readonly IQualificationService _qualificationService = qualificationService;

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetAllQualifications")]
        public async Task<ActionResult<List<GetQualification>>> GetAllQualifications()
        {
            try
            {
                return Ok(await _qualificationService.GetAllQualificationsAsync());
            }
            catch (EmptyQualificationListException ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<GetQualification>();
            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpGet("/GetQualificationByCode")]
        public async Task<ActionResult<GetQualification>> GetQualificationByCode(string qualificationCode)
        {
            try
            {
                return Ok(await _qualificationService.GetQualificationByCodeAsync(qualificationCode));
            }
            catch (QualificationNotFoundException ex)
            {

                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpPost("/AddQualificationAsync")]
        public async Task<ActionResult<GetQualification>> AddQualificationAsync(CreateQualification createQualification, string studentCode, string assignmentCode, string teacherCode)
        {
            try
            {
                return Ok(await _qualificationService.AddQualificationAsync(createQualification, studentCode, assignmentCode, teacherCode));
            }
            catch (InvalidQualificationException ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize(Roles = nameof(Roles.Teacher))]
        [HttpPut("/UpdateQualifiaction")]
        public async Task<ActionResult<GetQualification>> UpdateQualification(int id, CreateQualification updateQualification, string studentCode, string assignmentCode)
        {
            try
            {
                return Ok(await _qualificationService.UpdateQualificationAsync(id, updateQualification, studentCode, assignmentCode));
            }
            catch (QualificationNotFoundException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete("/DeleteQualificationByCode")]
        public async Task<ActionResult<List<GetQualification>>> DeleteQualificationByCode(string qualificationCode)
        {
            try
            {
                return Ok(await _qualificationService.DeleteQualificationAsync(qualificationCode));
            }
            catch (QualificationNotFoundException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }
    }
}
