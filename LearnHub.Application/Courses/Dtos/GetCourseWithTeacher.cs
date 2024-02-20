using LearnHub.Domain.Entities;
using LearnHub.Domain.Enums;

namespace LearnHub.Application.Courses.Dtos
{
    public class GetCourseWithTeacher
    {
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public int Period { get; set; }
        public int Year { get; set; }
        public CourseTypes CourseTypes { get; set; }
        public Teacher? AssignedTeacher { get; set; }
    }
}
