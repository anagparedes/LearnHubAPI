using LearnHub.Domain.Enums;
using LearnHub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Entities
{
    public class Student : User, IUser
    {
        public string? Career { get; set; }
        public Gender Gender { get; set; }
        public string? IdentificationCard { get; set; }
        public string? Telephone { get; set; }
        public StudentStatus Status { get; set; }
        public List<Assignment>? AssignedAssignments { get; set; }
        public List<Qualification>? Grades { get; set; }
        public List<StudentCourse> Enrollments { get; set; } = new List<StudentCourse>();

    }
}
