using LearnHub.Application.Assignments.Dtos;
using LearnHub.Domain.Enums;

namespace LearnHub.Application.Teachers.Dtos
{
    public class GetTeacherWithAssignment
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public TeacherStatus Status { get; set; }
        public string? Career { get; set; }
        public List<GetAssignment>? CreatedAssignments { get; set; }
    }
}
