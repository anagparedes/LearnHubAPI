using LearnHub.Application.Qualifications.Dtos;
using LearnHub.Application.Qualifications.Interfaces;
using LearnHub.Application.Users.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService _qualificationService;
        public QualificationController(IQualificationService qualificationService)
        {
            _qualificationService = qualificationService;
        }

        [HttpGet("/GetAllQualifications")]
        public async Task<ActionResult<List<GetQualification>>> GetAllQualifications()
        {
            try
            {
                return Ok(await _qualificationService.GetAllQualificationsAsync());
            }
            catch (UserEmptyListException ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<GetQualification>();
            }

        }

        [HttpGet("/GetQualificationByCode")]
        public async Task<ActionResult<GetQualification>> GetQualificationByCode(string qualificationCode)
        {
            try
            {
                return Ok(await _qualificationService.GetQualificationByCodeAsync(qualificationCode));
            }
            catch (UserEmptyListException ex)
            {

                return NotFound($"An error occurred: {ex.Message}");

            }

        }

        [HttpPost("/AddQualificationAsync")]
        public async Task<ActionResult<GetQualification>> AddQualificationAsync(CreateQualification createQualification, string studentCode, string assignmentCode, string teacherCode)
        {
            try
            {
                return Ok(await _qualificationService.AddQualificationAsync(createQualification, studentCode, assignmentCode, teacherCode));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("/UpdateQualifiaction")]
        public async Task<ActionResult<GetQualification>> UpdateQualification(int id, CreateQualification updateQualification, string studentCode, string assignmentCode)
        {
            try
            {
                return Ok(await _qualificationService.UpdateQualificationAsync(id, updateQualification, studentCode, assignmentCode));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }
        [HttpDelete("/DeleteQualificationByCode")]
        public async Task<ActionResult<List<GetQualification>>> DeleteQualificationByCode(string qualificationCode)
        {
            try
            {
                return Ok(await _qualificationService.DeleteQualificationAsync(qualificationCode));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }
    }
}
