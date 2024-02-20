using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.Exceptions
{
    public class AssignmentOrTeacherNotFoundException: Exception
    {
        public override string Message { get; }

        public AssignmentOrTeacherNotFoundException() : base()
        {
            Message = "Assignment or Teacher not found";
        }
    }
}
