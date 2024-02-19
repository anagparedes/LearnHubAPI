using LearnHub.Application.Courses.Dtos;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LearnHub.Application.Students.Dtos
{
    public class GetStudentWithCourse
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Career { get; set; }
        public string? Telephone { get; set; }
        public StudentStatus Status { get; set; }
        public List<GetCourse>? EnrolledCourses { get; set; }
    }
}
