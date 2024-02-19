using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.Dtos
{
    public  class GetAssignmentWithTeacher
    {
        public string? AssignmentCode { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Teacher? CreatedTeacher { get; set; }

    }
}
