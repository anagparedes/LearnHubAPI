using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Dtos
{
    public class UpdateUser
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? RegistrationCode { get; set; }
        public Roles Role { get; set; }

    }
}
