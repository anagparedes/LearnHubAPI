using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Qualifications.Exceptions
{
    public class QualificationOrAssignmentNotFoundException: Exception
    {
        public override string Message { get; }

        public QualificationOrAssignmentNotFoundException() : base()
        {
            Message = "Qualification or Assignment not found";
        }
    }
}
