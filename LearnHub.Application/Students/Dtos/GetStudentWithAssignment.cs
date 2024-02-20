using LearnHub.Domain.Entities;

namespace LearnHub.Application.Students.Dtos
{
    public class GetStudentWithAssignment
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Career { get; set; }
        public List<StudentAssignment>? AssignedAssignments { get; set; }
    }
}
