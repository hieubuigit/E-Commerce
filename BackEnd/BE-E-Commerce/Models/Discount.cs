using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Discount
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Value { get; set; }

    public int Type { get; set; }

    public DateTime StarDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
