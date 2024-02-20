using LearnHub.Application.Courses.Dtos;
using LearnHub.Domain.Enums;

namespace LearnHub.Application.Teachers.Dtos
{
    public class GetTeacherWithCourse
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public TeacherStatus Status { get; set; }
        public string? Career { get; set; }
        public List<GetCourse>? Courses { get; set; }
    }
}
