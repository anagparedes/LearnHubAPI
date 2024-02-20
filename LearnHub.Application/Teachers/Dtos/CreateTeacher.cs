using LearnHub.Domain.Enums;

namespace LearnHub.Application.Teachers.Dtos
{
    public class CreateTeacher
    {
        public string? IdentificationCard { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        public string? Career { get; set; }
        public CareerArea CareerArea { get; set; }
        public string? Telephone { get; set; }
        public string? PasswordHash { get; set; }
    }
}
