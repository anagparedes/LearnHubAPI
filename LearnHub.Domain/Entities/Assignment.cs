using LearnHub.Domain.Interfaces;
using LearnHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Entities
{
    public class Assignment: Entity
    {
        public string? AssignmentCode { get; set; }
        public Course? Course { get; set; }
        public int? CourseId { get; set; }
        public Teacher? CreatedTeacher { get; set; }
        public int? TeacherId { get; set; }
        public List<StudentAssignment>? AssignedStudents { get; set; }
        public List<Qualification>? Qualifications { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? StudentResponse { get; set; }
        //public DateTime? DateToExpire { get; set; }
    }
}
