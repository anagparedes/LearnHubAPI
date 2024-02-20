using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Students.Dtos
{
    public class GetStudentWithQualification
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Career { get; set; }
        public List<Qualification>? Grades { get; set; }
    }
}
