using LearnHub.Application.Students.Dtos;
using LearnHub.Domain.Enums;

namespace LearnHub.Application.Courses.Dtos
{
    public class GetCourseWithStudent
    {
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public CourseTypes CourseTypes { get; set; }
        public List<GetStudent>? EnrolledStudents { get; set; }
    }
}
