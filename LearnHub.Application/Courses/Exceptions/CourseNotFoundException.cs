using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Exceptions
{
    public class CourseNotFoundException: Exception
    {
        public override string Message { get; }

        public CourseNotFoundException() : base()
        {
            Message = "Course not found";
        }
    }
}
