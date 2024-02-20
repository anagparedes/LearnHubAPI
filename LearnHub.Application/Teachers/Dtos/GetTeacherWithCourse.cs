using LearnHub.Domain.Entities;
using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Teachers.Dtos
{
    public class GetTeacherWithCourse
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public TeacherStatus Status { get; set; }
        public string? Career { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
