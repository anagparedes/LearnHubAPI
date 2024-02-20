using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.Exceptions
{
    public class InvalidAssignmentException : Exception
    {
        public override string Message { get; }
        public InvalidAssignmentException() : base()
        {
            Message = "Invalid input for Assignment";
        }
    }
}
