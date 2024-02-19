using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.Dtos
{
    public class GetAssignment
    {
        public int Id { get; set; }
        public string? AssignmentCode { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
