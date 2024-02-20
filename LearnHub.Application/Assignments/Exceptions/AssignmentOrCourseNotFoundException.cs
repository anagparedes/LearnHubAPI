using LearnHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LearnHub.Application.Assignments.Exceptions
{
    public class AssignmentOrCourseNotFoundException: Exception
    {
        public override string Message { get; }

        public AssignmentOrCourseNotFoundException() : base()
        {
            Message = "Assignment or Course not found";
        }
    }
}
