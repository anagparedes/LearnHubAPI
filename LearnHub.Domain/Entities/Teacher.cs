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
    public class Teacher: User, IUser
    {
        public CareerArea CareerArea {  get; set; }
        public TeacherStatus Status { get; set; }
        public Gender Gender { get; set; }
        public string? Telephone { get; set; }
        public string? IdentificationCard {  get; set; }
        public string? Career {  get; set; }
        public List<Course>? Courses { get; set; }
        public List<Assignment>? CreatedAssignments { get; set; }
        public List<Qualification>? Grades { get; set; }
    }
}
