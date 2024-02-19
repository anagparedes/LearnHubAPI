﻿using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Teachers.Dtos;
using LearnHub.Application.Users.Dtos;
using LearnHub.Application.Users.Exceptions;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
       
        [HttpGet("/GetAllUsers")]
        public async Task<ActionResult<List<GetUser>>> GetAllUsers()
        {
            try
            {
                return Ok(await _userService.GetAllUsersAsync());
            }
            catch (UserEmptyListException ex)
            {
                Console.WriteLine($"An error occurred while retrieving users: {ex.Message}");
                return new List<GetUser>();
            }

        }
       
        [HttpGet("/GetUserById")]
        public async Task<ActionResult<GetUser>> GetUserById(int id)
        {
            try
            {
                return Ok(await _userService.GetUserByIdAsync(id));
            }
            catch (UserEmptyListException ex)
            {

                return StatusCode(404, $"An error occurred: {ex.Message}");

            }

        }
       
        [HttpGet("/GetUserByCode")]
        public async Task<ActionResult<GetUser>> GetUserByCode(string registrationCode)
        {
            try
            {
                return Ok(await _userService.GetUserByCodeAsync(registrationCode));
            }
            catch (UserEmptyListException ex)
            {

                return NotFound($"An error occurred: {ex.Message}");

            }

        }
    }
}
