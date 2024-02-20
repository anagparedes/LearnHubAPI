using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Exceptions
{
    public class InvalidCourseException: Exception
    {
        public override string Message { get; }

        public InvalidCourseException() : base()
        {
            Message = "Invalid input for Course";
        }
    }
}
