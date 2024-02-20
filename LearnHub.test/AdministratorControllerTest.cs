using Xunit;
using Moq;
using LearnHub.API.Controllers;
using LearnHub.Application.Users.Dtos;
using LearnHub.Application.Users.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Application.Administrators.Dtos;
using Microsoft.AspNetCore.Mvc;
using LearnHub.Domain.Enums;

namespace LearnHub.test
{
    public class AdministratorTest
    {
        private readonly AdminController _adminController;
        private readonly Mock<IUserService> _userServiceMock = new();

        public AdministratorTest()
        {
            _adminController = new AdminController(_userServiceMock.Object);
        }
        [Fact]
        public async Task GetAllAdmins_ReturnsOkResult()
        {
            var expectedAdmins = new List<GetAdmin>
            {
               new() {
                    Id = 1,
                    RegistrationCode = "101864",
                    FullName = "John Suarez",
                    Email = "101864@admin.learnhub.edu.do"
                },
                new()
                {
                    Id = 2,
                    RegistrationCode = "103764",
                    FullName = "Mario García",
                    Email = "103764@admin.learnhub.edu.do",
               
                },

            };

            _userServiceMock.Setup(x => x.GetAllAdminsAsync()).ReturnsAsync(expectedAdmins);

            var result = await _adminController.GetAllAdmins();

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var admins = Assert.IsAssignableFrom<List<GetAdmin>>(okObjectResult.Value);
            Assert.Equal(expectedAdmins, admins);
        }

        [Fact]
        public async Task AddAdminAsync_ReturnsOkResult()
        {

            var newAdmin = new CreateAdmin 
            { 
                FirstName= "Mario",
                LastName="García",
                PasswordHash="@admin432"
            };
            var expectedAdmin = new GetAdmin
            {
                Id = 2,
                RegistrationCode = "103764",
                FullName = "Mario García",
                Email = "103764@admin.learnhub.edu.do",
            };

            _userServiceMock.Setup(x => x.AddAdminAsync(newAdmin)).ReturnsAsync(expectedAdmin);

            var result = await _adminController.AddAdminAsync(newAdmin);

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var admin = Assert.IsAssignableFrom<GetAdmin>(okObjectResult.Value);
            Assert.Equal(expectedAdmin, admin);
        }
    }
}
