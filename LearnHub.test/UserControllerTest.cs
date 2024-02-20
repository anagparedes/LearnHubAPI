using LearnHub.API.Controllers;
using LearnHub.Application.Users.Dtos;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LearnHub.test
{
    public class UserControllerTest
    {
        private readonly UserController _userController;
        private readonly Mock<IUserService> _userServiceMock = new();

        public UserControllerTest()
        {
            _userController = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsOkResult()
        {
            var expectedUsers = new List<GetUser>
            {
                new GetUser
                {
                     Id = 1,
                    RegistrationCode = "101864",
                    FullName = "John Suarez",
                    Email = "101864@admin.learnhub.edu.do",
                    Role = Roles.Admin,
                },

                new GetUser
                {
                    Id = 2,
                    RegistrationCode = "103764",
                    FullName = "Mario García",
                    Email = "103764@prof.learnhub.edu.do",
                    Role = Roles.Teacher,
                },
                 new GetUser
                {
                    Id = 3,
                    RegistrationCode = "102464",
                    FullName = "Ana Paredes",
                    Email = "102464@est.learnhub.edu.do",
                    Role = Roles.Student,
                },

            };

            _userServiceMock.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(expectedUsers);

            var result = await _userController.GetAllUsers();

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var users = Assert.IsAssignableFrom<List<GetUser>>(okObjectResult.Value);
            Assert.Equal(expectedUsers, users);
        }

        [Fact]
        public async Task GetUserById_ReturnsOkResult()
        {
            var userId = 1;
            var expectedUser = new GetUser
            {
                Id = 1,
                RegistrationCode = "101864",
                FullName = "John Suarez",
                Email = "101864@admin.learnhub.edu.do",
                Role = Roles.Admin,
            };

            _userServiceMock.Setup(x => x.GetUserByIdAsync(userId)).ReturnsAsync(expectedUser);

            var result = await _userController.GetUserById(userId);

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var user = Assert.IsAssignableFrom<GetUser>(okObjectResult.Value);
            Assert.Equal(expectedUser, user);
        }

        [Fact]
        public async Task GetUserByCode_ReturnsOkResult()
        {
            var registrationCode = "103764";
            var expectedUser = new GetUser
            {
                Id = 2,
                RegistrationCode = "103764",
                FullName = "Mario García",
                Email = "103764@prof.learnhub.edu.do",
                Role = Roles.Teacher,
            };

            _userServiceMock.Setup(x => x.GetUserByCodeAsync(registrationCode)).ReturnsAsync(expectedUser);

            var result = await _userController.GetUserByCode(registrationCode);

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var user = Assert.IsAssignableFrom<GetUser>(okObjectResult.Value);
            Assert.Equal(expectedUser, user);
        }
    }
}
