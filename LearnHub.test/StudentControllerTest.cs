using LearnHub.API.Controllers;
using LearnHub.Application.Students.Dtos;
using LearnHub.Application.Students.Interfaces;
using LearnHub.Application.Users.Interfaces;
using LearnHub.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LearnHub.test
{
    public class StudentControllerTest
    {
        private readonly StudentController _studentController;
        private readonly Mock<IUserService> _userServiceMock = new();
        private readonly Mock<IStudentService> _studentServiceMock = new();

        public StudentControllerTest()
        {
            _studentController = new StudentController(_userServiceMock.Object, _studentServiceMock.Object);
        }
        [Fact]
        public async Task GetAllStudents_ReturnsOkResult()
        {

            var expectedStudents = new List<GetStudent>
            {
                new() {
                    Id = 1,
                    RegistrationCode = "1024578",
                    IdentificationCard = "402-0042129-3",
                    FullName = "Ana Paredes",
                    Email = "1024578@learnhub.edu.do",
                    Career= "Software Engineering",
                    Gender= Gender.Female,
                    Telephone= "829-443-3032",
                    Status= StudentStatus.Active,
                },

                new() {
                    Id = 2,
                    RegistrationCode = "1024638",
                    IdentificationCard = "402-0042129-3",
                    FullName = "Manuel De Jesus Lopez",
                    Email = "1024638@learnhub.edu.do",
                    Career= "Medicine",
                    Gender= Gender.Male,
                    Telephone= "829-435-255",
                    Status= StudentStatus.Active,
                }

            };
        

            _userServiceMock.Setup(x => x.GetAllStudentsAsync()).ReturnsAsync(expectedStudents);

            var result = await _studentController.GetAllStudents();

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var students = Assert.IsAssignableFrom<List<GetStudent>>(okObjectResult.Value);
            Assert.Equal(expectedStudents, students);
        }

        [Fact]
        public async Task AddStudentAsync_ReturnsOkResult()
        {
            var newStudent = new CreateStudent 
            {
                IdentificationCard = "402-0042129-3",
                FirstName = "Laura",
                LastName = "Angeles",
                Gender = Gender.Female,
                Career = "Economy",
                Telephone = "829-443-3032",
                Password = "$student01",
            };
            var expectedStudent = new GetStudent 
            {
                Id = 3,
                RegistrationCode = "1022679",
                IdentificationCard = "402-0042129-3",
                FullName = "Laura Angeles",
                Email = "1022679@learnhub.edu.do",
                Career = "Economy",
                Gender = Gender.Female,
                Telephone = "829-443-3032",
                Status = StudentStatus.Active,
            };

            _userServiceMock.Setup(x => x.AddStudentAsync(newStudent)).ReturnsAsync(expectedStudent);

            var result = await _studentController.AddStudentAsync(newStudent);

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var student = Assert.IsAssignableFrom<GetStudent>(okObjectResult.Value);
            Assert.Equal(expectedStudent, student);
        }
    }
}
