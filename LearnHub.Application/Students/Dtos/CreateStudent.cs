using LearnHub.Domain.Enums;

namespace LearnHub.Application.Students.Dtos
{
    public class CreateStudent
    {
        public string? IdentificationCard { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        public string? Career { get; set; }
        public string? Telephone { get; set; }
        public string? PasswordHash { get; set; }

    }
}
