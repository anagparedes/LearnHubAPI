using LearnHub.Application.Assignments.Dtos;
using LearnHub.Domain.Enums;

namespace LearnHub.Application.Courses.Dtos
{
    public class GetCourseWithAssignment
    {
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public int Period { get; set; }
        public int Year { get; set; }
        public CourseTypes CourseTypes { get; set; }
        public List<GetAssignment>? Assignments { get; set; }
    }
}
