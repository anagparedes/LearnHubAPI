using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Students.Dtos
{
    public class UpdateStudent
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Career { get; set; }
        public StudentStatus Status { get; set; }

    }
}
