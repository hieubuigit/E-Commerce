using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Order
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public int PaymentInfoId { get; set; }

    public int DiscountId { get; set; }

    public int ShippingAddressId { get; set; }

    public int PaymentCardId { get; set; }

    public decimal TotalAmount { get; set; }

    public int Status { get; set; }

    public string ReceiverName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Note { get; set; }

    public decimal ShippingFee { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<BillOfLanding> BillOfLandings { get; set; } = new List<BillOfLanding>();

    public virtual Discount Discount { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual PaymentCard PaymentCard { get; set; } = null!;

    public virtual PaymentInfo PaymentInfo { get; set; } = null!;
}
