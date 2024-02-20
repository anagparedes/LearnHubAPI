using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Exceptions
{
    public class InvalidUserException: Exception
    {
        public override string Message { get; }

        public InvalidUserException() : base()
        {
            Message = "Invalid input for User";
        }
    }
}
