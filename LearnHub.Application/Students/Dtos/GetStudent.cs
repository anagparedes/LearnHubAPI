using LearnHub.Domain.Enums;

namespace LearnHub.Application.Students.Dtos
{
    public class GetStudent
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? IdentificationCard { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Career { get; set; }
        public Gender Gender {  get; set; }
        public string? Telephone { get; set; }
        public StudentStatus Status {  get; set; }
    }
}
