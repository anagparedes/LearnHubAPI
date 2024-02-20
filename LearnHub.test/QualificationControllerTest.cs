using Moq;
using LearnHub.API.Controllers;
using LearnHub.Application.Qualifications.Dtos;
using LearnHub.Application.Qualifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LearnHub.Application.Courses.Dtos;
using LearnHub.Domain.Enums;

namespace LearnHub.test
{
    public class QualificationControllerTest
    {
        private readonly QualificationController _qualificationController;
        private readonly Mock<IQualificationService> _qualificationServiceMock = new();

        public QualificationControllerTest()
        {
            _qualificationController = new QualificationController(_qualificationServiceMock.Object);
        }

        [Fact]
        public async Task GetAllQualifications_ReturnsOkResult()
        {
            var expectedQualifications = new List<GetQualification> 
            {
                 new GetQualification
                {
                    QualificationCode = "QUALIFICATION-1021233",
                    Score= 10,
              
                },
                new GetQualification
                {
                    QualificationCode = "QUALIFICATION-102573",
                    Score= 10,
                }
            };

            _qualificationServiceMock.Setup(x => x.GetAllQualificationsAsync()).ReturnsAsync(expectedQualifications);

            var result = await _qualificationController.GetAllQualifications();

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var qualifications = Assert.IsAssignableFrom<List<GetQualification>>(okObjectResult.Value);
            Assert.Equal(expectedQualifications, qualifications);
        }

        [Fact]
        public async Task GetQualificationByCode_ReturnsOkResult()
        {
            var qualificationCode = "QUALIFICATION-DFE123";
            var expectedQualification = new GetQualification
            {
                QualificationCode = "QUALIFICATION-DFE123",
                Score = 8,
            };

            _qualificationServiceMock.Setup(x => x.GetQualificationByCodeAsync(qualificationCode)).ReturnsAsync(expectedQualification);

            var result = await _qualificationController.GetQualificationByCode(qualificationCode);

            Assert.NotNull(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var qualification = Assert.IsAssignableFrom<GetQualification>(okObjectResult.Value);
            Assert.Equal(expectedQualification, qualification);
        }

    }
}
