using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class PaymentInfo
{
    public int Id { get; set; }

    public int Type { get; set; }

    public string Name { get; set; } = null!;

    public string? CardHolderName { get; set; }

    public string? CardNumber { get; set; }

    public string? ExpiryDate { get; set; }

    public string? SecurityCode { get; set; }

    public string? PaypalTrackingId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
