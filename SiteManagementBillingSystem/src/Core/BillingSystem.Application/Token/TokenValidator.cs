using BillingSystem.Schema;
using FluentValidation;

namespace BillingSystem.Application.Token;

public class TokenValidator : AbstractValidator<TokenRequest>
{
    public TokenValidator() 
    {
        // Email Required and it must be in Email Format.
        RuleFor(user => user.Email)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .EmailAddress().WithMessage("Please ensure you have entered your {PropertyName} in the correct format.");

        // Password Required
        RuleFor(user => user.Password)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}");
    }
}
