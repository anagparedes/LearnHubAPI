using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Qualifications.Exceptions
{
    public class QualificationNotFoundException: Exception
    {
        public override string Message { get; }

        public QualificationNotFoundException() : base()
        {
            Message = "Qualification not found";
        }
    }
}
