using LearnHub.Application.Qualifications.Dtos;
using LearnHub.Domain.Enums;

namespace LearnHub.Application.Teachers.Dtos
{
    public class GetTeacherWithQualification
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public TeacherStatus Status { get; set; }
        public string? Career { get; set; }
        public List<GetQualification>? Grades { get; set; }
    }
}
