using LearnHub.Domain.Entities;

namespace LearnHub.Application.Qualifications.Dtos
{
    public class GetQualification
    {
        public int Id { get; set; }
        public string? QualificationCode { get; set; }
        public Student? Student { get; set; }
        public Assignment? Assignment { get; set; }
        public Teacher? EvaluatedTeacher { get; set; }
        public int Score { get; set; }
    }
}
