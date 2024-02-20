using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Exceptions
{
    public class CourseOrAssignmentNotFoundException: Exception
    {
        public override string Message { get; }

        public CourseOrAssignmentNotFoundException() : base()
        {
            Message = "Course or Assignment not found";
        }

    }
}
