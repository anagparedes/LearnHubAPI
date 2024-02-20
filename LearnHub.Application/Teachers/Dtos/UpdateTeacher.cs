using LearnHub.Domain.Enums;

namespace LearnHub.Application.Teachers.Dtos
{
    public class UpdateTeacher
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public TeacherStatus Status { get; set; }
        public string? Telephone { get; set; }
        public string? Career { get; set; }
        public CareerArea CareerArea { get; set; }
    }
}
