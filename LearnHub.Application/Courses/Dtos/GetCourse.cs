using LearnHub.Domain.Enums;

namespace LearnHub.Application.Courses.Dtos
{
    public class GetCourse
    {
        public int Id { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public int Period { get; set; }
        public int Year { get; set; }
        public CourseTypes CourseType { get; set; }
    }
}
