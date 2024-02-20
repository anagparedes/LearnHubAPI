using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Administrators.Dtos
{
    public class GetAdmin
    {
        public int Id { get; set; }
        public string? RegistrationCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
