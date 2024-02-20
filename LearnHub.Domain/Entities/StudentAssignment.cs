using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Entities
{
    public class StudentAssignment
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int AssignmentId { get; set; }
        public Assignment? Assignment { get; set; }

    }
}
