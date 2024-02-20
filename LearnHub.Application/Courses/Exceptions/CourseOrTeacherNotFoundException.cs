using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Exceptions
{
    public class CourseOrTeacherNotFoundException : Exception
    {
        public override string Message { get;}
        public CourseOrTeacherNotFoundException() : base() 
        { 
            Message = "Course or Teacher not found"; 
        }
    }
}
