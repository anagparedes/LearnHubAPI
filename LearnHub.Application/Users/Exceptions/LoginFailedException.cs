using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Exceptions
{
    public class LoginFailedException: Exception
    {
        public override string Message { get; }

        public LoginFailedException() : base()
        {
            Message = "The User is not Found";
        }
    }
}
