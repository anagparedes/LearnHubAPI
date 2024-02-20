using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.Exceptions
{
    public class AssignmentOrStudentNotFoundException : Exception
    {
        public override string Message { get; }

        public AssignmentOrStudentNotFoundException() : base()
        {
            Message = "Assignment or Student not found";
        }

    }

}
