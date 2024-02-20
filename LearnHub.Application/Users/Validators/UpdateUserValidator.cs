using FluentValidation;
using LearnHub.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.FullName)
                .NotEmpty()
                .WithMessage("El nombre completo es obligatorio");

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Por favor, ingrese una dirección de correo electrónico válida");

            RuleFor(user => user.Role)
                .IsInEnum()
                .WithMessage("Rol no válido");
        }
    }
}
