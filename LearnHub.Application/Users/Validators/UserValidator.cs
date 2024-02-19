using FluentValidation;
using LearnHub.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnHub.Application.Users.Validators
{
    public class UserValidator: AbstractValidator<CreateUser>
    {
        public UserValidator()
        {
            RuleFor(u => u.FullName)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("The Name cannot be too short")
                .MaximumLength(50)
                .WithMessage("The Name cannot be too large");

            RuleFor(u => u.Email)
               .NotEmpty()
               .EmailAddress()
               .WithMessage("The Email cannot be empty");

            RuleFor(u => u.Password)
               .NotEmpty()
               .WithMessage("The Password cannot be empty");
        }

    }
}
