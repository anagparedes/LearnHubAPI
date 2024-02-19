using LearnHub.Domain.Enums;
using LearnHub.Domain.Interfaces;
using LearnHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LearnHub.Domain.Entities
{
    public class User: Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? RegistrationCode { get; set; }
        public string? PasswordHash { get; set; }

        public Roles Role { get; set; }

    }
}
