using LearnHub.API.Controllers;
using LearnHub.Application.Courses.Dtos;
using LearnHub.Application.Courses.Interfaces;
using LearnHub.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LearnHub.test
{
    public class CourseControllerTest
    {
        private readonly CourseController _courseController;
        private readonly Mock<ICourseService> _courseServiceMock = new();

        public CourseControllerTest()
        {
            _courseController = new CourseController(_courseServiceMock.Object);
        }

        [Fact]
        public async Task GetAllCourses_ReturnsOkResult()
        {
            var expectedCourses = new List<GetCourse> 
            {
                new() {
                    CourseCode = "COURSE-1021233",
                   CourseName= "Introducción a la Programación",
                       Period= 1,
                    Year= 2024,
                    CourseType = CourseTypes.Online,
                },
                new() {
                    CourseCode = "COURSE-102573",
                   CourseName= "Aseguramiento de la Calidad del Software",
                       Period= 2,
                    Year= 2024,
                    CourseType = CourseTypes.Online,
                }
            };

            _courseServiceMock.Setup(x => x.GetAllCoursesAsync()).ReturnsAsync(expectedCourses);

            var result = await _courseController.GetAllCourses();

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var courses = Assert.IsAssignableFrom<List<GetCourse>>(okObjectResult.Value);
            Assert.Equal(expectedCourses, courses);
        }

        [Fact]
        public async Task GetCourseByCode_ReturnsOkResult()
        {
            var courseCode = "COURSE-GDC123";
            var expectedCourse = new GetCourse
            {
                CourseCode = "COURSE-GDC123",
                CourseName = "Arquitectura De Software",
                Period = 2,
                Year = 2024,
                CourseType = CourseTypes.InPerson,
            };

            _courseServiceMock.Setup(x => x.GetCourseByCodeAsync(courseCode)).ReturnsAsync(expectedCourse);

            var result = await _courseController.GetCourseByCode(courseCode);

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var course = Assert.IsAssignableFrom<GetCourse>(okObjectResult.Value);
            Assert.Equal(expectedCourse, course);
        }
    }
}
