using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Partner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Type { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Shipper> Shippers { get; set; } = new List<Shipper>();
}
