using Moq;
using LearnHub.API.Controllers;
using LearnHub.Application.Teachers.Dtos;
using LearnHub.Application.Teachers.Interfaces;
using LearnHub.Application.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LearnHub.Domain.Enums;

namespace LearnHub.test
{
    public class TeacherControllerTest
    {
        private readonly TeacherController _teacherController;
        private readonly Mock<ITeacherService> _teacherServiceMock = new();
        private readonly Mock<IUserService> _userServiceMock = new();

        public TeacherControllerTest()
        {
            _teacherController = new TeacherController(_teacherServiceMock.Object, _userServiceMock.Object);
        }

        [Fact]
        public async Task GetAllTeachers_ReturnsOkResult()
        {
            var expectedTeachers = new List<GetTeacher>  {
                new() {
                    Id = 1,
                    RegistrationCode = "1034578",
                    IdentificationCard = "001-0834582-6",
                    FullName = "Ramón Martínez",
                    Email = "1024578@prof.learnhub.edu.do",
                    Career= "Software Engineering",
                    Telephone= "829-443-3032",
                    Status= TeacherStatus.Active,
                },

                new() {
                    Id = 2,
                    RegistrationCode = "1030121",
                    IdentificationCard = "001-0835422-2",
                    FullName = "María Lora",
                    Email = "1030121@prof.learnhub.edu.do",
                    Career= "Medicine",
                    Telephone= "829-439-336",
                    Status= TeacherStatus.Active,
                }

            };

            _userServiceMock.Setup(x => x.GetAllTeachersAsync()).ReturnsAsync(expectedTeachers);

            var result = await _teacherController.GetAllTeachers();

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var teachers = Assert.IsAssignableFrom<List<GetTeacher>>(okObjectResult.Value);
            Assert.Equal(expectedTeachers, teachers);
        }

        [Fact]
        public async Task GetTeacherWithCourse_ReturnsOkResult()
        {
            var registrationCode = "1030121";
            var expectedTeacherWithCourse = new GetTeacherWithCourse
            {
                Id = 2,
                RegistrationCode = "1030121",
                FullName = "María Lora",
                Email = "1030121@prof.learnhub.edu.do",
                Career = "Medicine",
                Status = TeacherStatus.Active,
                Courses = {},
            };

            _teacherServiceMock.Setup(x => x.GetTeacherWithCourse(registrationCode)).ReturnsAsync(expectedTeacherWithCourse);

            var result = await _teacherController.GetTeacherWithCourse(registrationCode);

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var teacherWithCourse = Assert.IsAssignableFrom<GetTeacherWithCourse>(okObjectResult.Value);
            Assert.Equal(expectedTeacherWithCourse, teacherWithCourse);
        }
    }
}
