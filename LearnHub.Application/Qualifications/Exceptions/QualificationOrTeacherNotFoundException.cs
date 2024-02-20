using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Qualifications.Exceptions
{
    public class QualificationOrTeacherNotFoundException: Exception
    {
        public override string Message { get; }

        public QualificationOrTeacherNotFoundException() : base()
        {
            Message = "Qualification or Teacher not found";
        }
    }
}
