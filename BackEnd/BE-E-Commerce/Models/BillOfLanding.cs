using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class BillOfLanding
{
    public int Id { get; set; }

    public string TrackingNumber { get; set; } = null!;

    public long OrderId { get; set; }

    public int ShipperId { get; set; }

    public DateTime ShippingDate { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public string? ShipFrom { get; set; }

    public string? ShipTo { get; set; }

    public int Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Shipper Shipper { get; set; } = null!;
}
