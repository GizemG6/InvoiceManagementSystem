using FluentValidation;
using InvoiceManagementSystem.Models.Entities;

namespace InvoiceManagementSystem.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
            .NotEmpty().WithMessage("İsim alanı zorunludur.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Soyisim alanı zorunludur.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Şifre alanı zorunludur.");

            RuleFor(user => user.TCNo)
                .NotEmpty().WithMessage("TC No alanı zorunludur.");
        }
    }
}
