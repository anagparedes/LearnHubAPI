using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Qualifications.Exceptions
{
    public  class EmptyQualificationListException : Exception
    {
        public override string Message { get; }

        public EmptyQualificationListException() : base()
        {
            Message = "The list of Qualifications is empty";
        }
    }
}
