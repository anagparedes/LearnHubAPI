using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Qualifications.Exceptions
{
    public class QualificationOrStudentNotFoundException: Exception
    {
        public override string Message { get; }

        public QualificationOrStudentNotFoundException() : base()
        {
            Message = "Qualification or Student not found";
        }
    }
}
