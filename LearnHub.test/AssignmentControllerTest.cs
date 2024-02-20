using Moq;
using LearnHub.API.Controllers;
using LearnHub.Application.Assignments.Dtos;
using LearnHub.Application.Assignments.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.test
{
    public class AssignmentControllerTest
    {
        private readonly AssignmentController _assignmentController;
        private readonly Mock<IAssignmentService> _assignmentServiceMock = new();

        public AssignmentControllerTest()
        {
            _assignmentController = new AssignmentController(_assignmentServiceMock.Object);
        }

        [Fact]
        public async Task GetAllAssignments_ReturnsOkResult()
        {
            var expectedAssignments = new List<GetAssignment>
            {
                new() {

                    Id = 1,
                    AssignmentCode = "Assignment-DEF123",
                    Title = " Building a Todo List Application",
                    Description = "Design and implement a simple Todo List application " +
                    "using a technology stack of your choice. The application should allow " +
                    "users to create, edit, and delete tasks."

                }
               
            };

            _assignmentServiceMock.Setup(x => x.GetAllAssignmentAsync()).ReturnsAsync(expectedAssignments);

            var result = await _assignmentController.GetAllAssignments();

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var assignments = Assert.IsAssignableFrom<List<GetAssignment>>(okObjectResult.Value);
            Assert.Equal(expectedAssignments, assignments);
        }

        [Fact]
        public async Task GetAssignmentByCode_ReturnsOkResult()
        {

            var assignmentCode = "Assignment-F43GE";
            var expectedAssignment = new GetAssignment
            {

                Id = 1,
                AssignmentCode = "Assignment-F43GE",
                Title = "Research Paper on a Medical Breakthrough",
                Description = " Write a research paper that summarizes the discovery, its implications for healthcare."

            };

            _assignmentServiceMock.Setup(x => x.GetAssignmentByCodeAsync(assignmentCode)).ReturnsAsync(expectedAssignment);

            var result = await _assignmentController.GetAssignmentByCode(assignmentCode);

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var assignment = Assert.IsAssignableFrom<GetAssignment>(okObjectResult.Value);
            Assert.Equal(expectedAssignment, assignment);
        }
    }
}
