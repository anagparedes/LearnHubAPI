using LearnHub.Application.Qualifications.Dtos;

namespace LearnHub.Application.Students.Dtos
{
    public class GetStudentWithQualification
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Career { get; set; }
        public List<GetQualification>? Grades { get; set; }
    }
}
