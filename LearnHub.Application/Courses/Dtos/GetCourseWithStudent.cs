using LearnHub.Application.Students.Dtos;
using LearnHub.Domain.Entities;
using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Dtos
{
    public class GetCourseWithStudent
    {
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public CourseTypes CourseTypes { get; set; }
        public List<GetStudent>? EnrolledStudents { get; set; }
    }
}
