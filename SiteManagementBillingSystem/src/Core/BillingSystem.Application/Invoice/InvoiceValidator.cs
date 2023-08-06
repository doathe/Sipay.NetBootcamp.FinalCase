using BillingSystem.Schema;
using FluentValidation;
using System.Globalization;

namespace BillingSystem.Application;

public class InvoiceValidator : AbstractValidator<InvoiceRequest>
{
    public InvoiceValidator()
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
        RuleFor(x => x.Amounth)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .GreaterThan(0).WithMessage("Please ensure you have entered your {PropertyName} greater than 0");

        // InvoiceType Required and it's length must greater than 0.
        RuleFor(x => x.InvoiceType)
                .NotNull().NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}")
                .Must(BeAValidInvoiceType).WithMessage("Please ensure you have entered a valid invoice type: water, electric, or gas"); ;
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
    private bool BeAValidInvoiceType(string invoiceType)
    {
        if (string.IsNullOrEmpty(invoiceType))
            return true;

        string[] validTypes = { "Water", "Electric", "Gas" };

        return validTypes.Contains(invoiceType);
    }
}