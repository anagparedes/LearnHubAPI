using AutoMapper;
using LearnHub.API.Controllers;
using LearnHub.Application.Authentication.Interfaces;
using Moq;
using Microsoft.AspNetCore.Mvc;
using LearnHub.Application.Users.Dtos;
using LearnHub.Domain.Enums;
using LearnHub.Domain.Entities;

namespace LearnHub.test
{
    public class AuthenticationTest
    {
        private readonly AuthenticationController _authenticationController;
        private readonly Mock<IAuthenticationService> _authenticationServiceMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public AuthenticationTest()
        {
            _authenticationController = new AuthenticationController(_authenticationServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void Register_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                Email = "1024573@admin.learnhub.edu.do",
                PasswordHash = "$hashedPassword"
            };
            var expectedUser = new GetUser
            {
                Id = 1,
                RegistrationCode = "1014573",
                FullName = "John Guzman",
                Email = "1024573@admin.learnhub.edu.do",
                Role = Roles.Admin 
            };

            _authenticationServiceMock.Setup(x => x.Register(loginRequest)).Returns(expectedUser);
            _mapperMock.Setup(x => x.Map<GetUser>(It.IsAny<object>())).Returns(expectedUser);

            // Act
            var actionResult = _authenticationController.Register(loginRequest);
            var result = actionResult as ActionResult<GetUser>;

            // Assert
            Assert.NotNull(result);

            var okObjectResult = result.Result as OkObjectResult;

            Assert.NotNull(okObjectResult);
            Assert.Equal(expectedUser, okObjectResult.Value);
        }

        [Fact]
        public void Login_ValidRequest_ReturnsOkResult()
        {

            var loginRequest = new LoginRequest
            {
                Email = "1024573@admin.learnhub.edu.do",
                PasswordHash = "$hashedPassword"
            };
            var expectedToken = "adminToken";

            _authenticationServiceMock.Setup(x => x.Login(loginRequest)).Returns(expectedToken);


            var actionResult = _authenticationController.Login(loginRequest);
            var result = actionResult as ActionResult<User>;


            Assert.NotNull(result);

            var okObjectResult = result.Result as OkObjectResult;

            Assert.NotNull(okObjectResult);
            Assert.Equal(expectedToken, okObjectResult.Value);
        }
    }
}
