using LearnHub.Domain.Enums;

namespace LearnHub.Application.Students.Dtos
{
    public class UpdateStudent
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Career { get; set; }
        public StudentStatus Status { get; set; }

    }
}
