using BillingSystem.Schema;
using FluentValidation;
using System.Globalization;

namespace BillingSystem.Application;

public class DuesValidator : AbstractValidator<DuesRequest>
{
    public DuesValidator()
    {
        // Month Required and it must a month.
        RuleFor(x => x.Month)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Must(BeAValidMonth).WithMessage("Please ensure you have entered a valid month name.");

        // Year Required and it's length must 4 lenght.
        RuleFor(x => x.Year)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Must(BeAValidYear).WithMessage("Please ensure you have entered a valid 4-digit year");

        // Amounth Required and it's length must greater than 0.
        RuleFor(x => x.Amount)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .GreaterThan(0).WithMessage("Please ensure you have entered your {PropertyName} greater than 0");
    }

    private bool BeAValidMonth(string month)
    {
        if (string.IsNullOrEmpty(month))
            return true;

        return DateTime.TryParseExact(month, "MMMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }
    private bool BeAValidYear(int year)
    {
        return year.ToString().Length == 4;
    }
}