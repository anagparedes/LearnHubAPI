using LearnHub.Domain.Entities;
using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Domain.Interfaces
{
    public interface IUser
    {
         string? RegistrationCode { get; set; }
         string? Career { get; set; }
        string? IdentificationCard { get; set; }
        string? Telephone { get; set; }
    }
}
