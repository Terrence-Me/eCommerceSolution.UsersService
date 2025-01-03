using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;
public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address format");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(x => x.PersonName).NotEmpty().WithMessage("PersonName is required").Length(1, 50).WithMessage("Person Name should be between 1 and 50 characters long");
        RuleFor(x => x.Gender).IsInEnum().WithMessage("Invalid gender option");
    }
}
