using BillingSystem.Schema;
using FluentValidation;

namespace BillingSystem.Application;

public class UserValidator : AbstractValidator<UserRequest>
{
    public UserValidator()
    {
        // FirstName Required and it's length must be between 3 and 50 characters.
        RuleFor(user => user.FirstName)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Length(3, 50).WithMessage("Please ensure you have entered your {PropertyName} between 3 and 50 characters.");

        // LastName Required and it's length must be between 3 and 50 characters.
        RuleFor(user => user.LastName)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Length(3, 50).WithMessage("Please ensure you have entered your {PropertyName} between 3 and 50 characters.");

        // Email Required and it must be in Email Format.
        RuleFor(user => user.Email)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .EmailAddress().WithMessage("Please ensure you have entered your {PropertyName} in the correct format.");

        // Phone Required and It must be in correct format.
        RuleFor(user => user.Phone)
            .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
            .Matches(@"^\d{3}\s\d{3}\s\d{4}$").WithMessage("Please ensure you have entered your {PropertyName} in the correct format.");

        // TCKN Required and It's length must 11.
        RuleFor(user => user.TCKNumber)
            .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
            .Length(11).WithMessage("Please ensure you have entered your {PropertyName}'s length 11");

        // CarPlateNumber Required and It must be correct format.
        RuleFor(user => user.CarPlateNumber)
            .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
            .Must(BeAValidPlateNumber).WithMessage("Please ensure you have entered a valid {PropertyName} in the correct format (e.g., 34 FA 567 or 34 A 4567)");

        // Role Required and IT must be User or Admin.
        RuleFor(user => user.Role)
            .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
            .Must(role => role == "User" || role == "Admin").WithMessage("Please ensure the {PropertyName} is either 'User' or 'Admin'.");

        // ApartmentId Required.
        RuleFor(user => user.ApartmentId)
            .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}");
    }

    private bool BeAValidPlateNumber(string plateNumber)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(plateNumber, @"^(34\s[A-Z]{2}\s\d{3})$|^(34\s[A]\s\d{4})$");
    }
}
