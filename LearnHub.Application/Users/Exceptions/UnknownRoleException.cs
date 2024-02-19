using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Exceptions
{
    public class UnknownRoleException: Exception
    {
        public override string Message { get; }

        public UnknownRoleException(): base()
        {
            Message = "The user does not has a role";
        }
    }
}
