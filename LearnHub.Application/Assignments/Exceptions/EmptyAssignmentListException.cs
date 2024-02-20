using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Assignments.Exceptions
{
    public class EmptyAssignmentListException: Exception
    {

        public override string Message { get; }

        public EmptyAssignmentListException() : base()
        {
            Message = "The list of Assignments is empty";
        }
    }
}
