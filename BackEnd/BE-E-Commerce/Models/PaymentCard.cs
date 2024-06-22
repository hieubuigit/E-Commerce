using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class PaymentCard
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string CardNumber { get; set; } = null!;

    public string CardHolderName { get; set; } = null!;

    public string ExpiryDate { get; set; } = null!;

    public int? SecurityCode { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
