﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystem.Domain;

[Table("Dues", Schema = "dbo")]
public class Dues : BaseEntity
{
    public string Month { get; set; }
    public int Year { get; set; }
    public decimal Amount { get; set; }
    public int DuesPaymentStatus { get; set; }

    public int ApartmentId { get; set; }
    public Apartment Apartment { get; set; }
    public int? PaymentId { get; set; }
    public Payment? Payment { get; set; }
}

public enum DuesPaymentStatus
{
    Unpaid = 0,
    Paid = 1,
}