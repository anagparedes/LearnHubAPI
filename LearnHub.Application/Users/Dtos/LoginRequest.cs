using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Dtos
{
    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
