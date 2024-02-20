using LearnHub.Domain.Interfaces;
using LearnHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Entities
{
    public class Qualification: Entity
    {
        public string? QualificationCode { get; set; }
        public Student? Student { get; set; }
        public int? StudentId { get; set; }
        public Assignment? Assignment { get; set; }
        public int? AssignmentId { get; set; }
        public Teacher? EvaluatedTeacher { get; set; }
        public int? TeacherId { get; set; }
        public int? Score { get; set; }

    }
}
