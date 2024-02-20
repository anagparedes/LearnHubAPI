using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Courses.Exceptions
{
    public class EmptyCourseListException: Exception
    {
        public override string Message { get; }

        public EmptyCourseListException() : base()
        {
            Message = "The list of Users is empty";
        }
    }
}
