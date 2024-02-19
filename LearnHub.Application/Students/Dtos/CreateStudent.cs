using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Students.Dtos
{
    public class CreateStudent
    {
        public string? IdentificationCard { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        public string? Career { get; set; }
        public string? Telephone { get; set; }
        public string? PasswordHash { get; set; }

    }
}
