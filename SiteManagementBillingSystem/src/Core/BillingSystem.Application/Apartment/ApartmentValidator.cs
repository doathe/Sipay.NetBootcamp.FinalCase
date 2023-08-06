using BillingSystem.Schema;
using FluentValidation;

namespace BillingSystem.Application;

public class ApartmentValidator : AbstractValidator<ApartmentRequest>
{
    public ApartmentValidator()
    {
        // Block Required and it's length must be between 1 and 50 characters.
        RuleFor(x => x.Block)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Length(1, 50).WithMessage("Please ensure you have entered your {PropertyName} between 1 and 50 characters");

        // Floor Required and it's length must greater than 0.
        RuleFor(x => x.Floor)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .GreaterThan(0).WithMessage("Please ensure you have entered your {PropertyName} greater than 0");

        // Number Required and it's length must greater than 0.
        RuleFor(x => x.Number)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .GreaterThan(0).WithMessage("Please ensure you have entered your {PropertyName} greater than 0");

        // Type Required and it's length must be between 3 and 50 characters.
        RuleFor(x => x.Type)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Length(3, 50).WithMessage("Please ensure you have entered your {PropertyName} between 3 and 50 characters.");

        // Resident Required and it's value must Owner or Tenant.
        RuleFor(x => x.Resident)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Must((x, resident) => resident == "Owner" || resident == "Tenant").WithMessage("Please select either 'Owner' or 'Tenant' for {PropertyName}");

        // Status Required and it's value must Empty or Full.
        RuleFor(x => x.Status)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Must(status => status == "Empty" || status == "Full").WithMessage("Please select either 'Empty' or 'Full' for {PropertyName}");
    }
}
