using LearnHub.Domain.Enums;
using LearnHub.Domain.Interfaces;
using LearnHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Entities
{
    public class Course: Entity
    {
        public string? CourseCode { get; set; }
        public string? CourseName { get; set; }
        public int Year { get; set; }
        public int Period { get; set; }
        public Teacher? AssignedTeacher { get; set; }
        public int? AssignedTeacherId { get; set; }
        public List<Assignment>? Assignments { get; set; }
        public List<StudentCourse>? Enrollments { get; set; }
        public CourseTypes CourseType {  get; set; }
    }
}
