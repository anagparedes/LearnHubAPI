using FluentValidation;
using LearnHub.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Authentication.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(request => request.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Por favor, ingrese una dirección de correo electrónico válida");

            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage("La contraseña es obligatoria");
        }
    }
}
