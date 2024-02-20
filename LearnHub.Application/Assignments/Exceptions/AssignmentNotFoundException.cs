using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.Exceptions
{
    public class AssignmentNotFoundException: Exception
    {
        public override string Message { get; }

        public AssignmentNotFoundException() : base()
        {
            Message = "Assignment not found";
        }
    }
}
