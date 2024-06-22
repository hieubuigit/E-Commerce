using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public bool? SaveForLater { get; set; }

    public bool? IsCreatedOrder { get; set; }

    public DateTime? CreateOrderTime { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Account Account { get; set; } = null!;
}
