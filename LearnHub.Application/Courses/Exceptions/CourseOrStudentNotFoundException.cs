using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Exceptions
{
    public class CourseOrStudentNotFoundException: Exception
    {
        public override string Message { get; }
        public CourseOrStudentNotFoundException() : base()
        {
            Message = "Course or Student not found";
        }
    }
}
