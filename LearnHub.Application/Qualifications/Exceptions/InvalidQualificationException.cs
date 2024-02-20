using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Qualifications.Exceptions
{
    public class InvalidQualificationException: Exception
    {
        public override string Message { get; }

        public InvalidQualificationException() : base()
        {
            Message = "Invalid input for Qualification";
        }
    }
}
