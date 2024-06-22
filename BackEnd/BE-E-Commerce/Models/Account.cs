using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Account
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool? IsTwoAuth { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<AccountActionLog> AccountActionLogs { get; set; } = new List<AccountActionLog>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PaymentCard> PaymentCards { get; set; } = new List<PaymentCard>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; } = new List<ShippingAddress>();
}
