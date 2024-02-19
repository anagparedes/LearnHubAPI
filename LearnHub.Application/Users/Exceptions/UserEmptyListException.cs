using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Exceptions
{
    public class UserEmptyListException: Exception
    {
        public override string Message { get; }

        public UserEmptyListException() : base()
        {
            Message = "The list of Users is empty";
        }
    }
}
