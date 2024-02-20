using FluentValidation;
using LearnHub.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Validators
{
    public class LoginResponseValidator : AbstractValidator<LoginResponse>
    {
        public LoginResponseValidator()
        {
            RuleFor(response => response.Message)
                .NotEmpty()
                .WithMessage("El mensaje es obligatorio");

            RuleFor(response => response.FullName)
                .NotEmpty()
                .WithMessage("El nombre completo es obligatorio");
        }
    }
}
