using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Teachers.Dtos
{
    public class GetTeacher
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? IdentificationCard { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public TeacherStatus Status { get; set; }
        public string? Career { get; set; }
        public string? Telephone { get; set; }
    }
}
