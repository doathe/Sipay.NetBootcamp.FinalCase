using BillingSystem.Schema;
using FluentValidation;

namespace BillingSystem.Application;

public class ApartmentValidator : AbstractValidator<ApartmentRequest>
{
    public ApartmentValidator()
    {
        // Block Required and it's length must be between 3 and 50 characters.
        RuleFor(user => user.Block)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Length(1, 50).WithMessage("Please ensure you have entered your {PropertyName} between 1 and 50 characters");

        // Floor Required and it's length must greater than 0.
        RuleFor(user => user.Floor)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .GreaterThan(0).WithMessage("Please ensure you have entered your {PropertyName} greater than 0");

        // Number Required and it's length must greater than 0.
        RuleFor(user => user.Number)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .GreaterThan(0).WithMessage("Please ensure you have entered your {PropertyName} greater than 0");

        // Type Required and it's length must be between 3 and 50 characters.
        RuleFor(user => user.Type)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Length(3, 50).WithMessage("Please ensure you have entered your {PropertyName} between 3 and 50 characters.");

        // Resident Required and it's length must be between 3 and 50 characters.
        RuleFor(user => user.Resident)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Must((user, resident) => resident == "Owner" || resident == "Tenant").WithMessage("Please select either 'Owner' or 'Tenant' for {PropertyName}");

        // Status Required and it's length must be between 3 and 50 characters.
        RuleFor(user => user.Status)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Must(status => status == "Empty" || status == "Full").WithMessage("Please select either 'Empty' or 'Full' for {PropertyName}");
    }
}
