using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Authentication.Exceptions
{
    public class WrongPasswordException: Exception
    {
        public override string Message { get; }

        public WrongPasswordException() : base()
        {
            Message = "The User is not Found";
        }
    }
}
