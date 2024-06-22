using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Shipper
{
    public int Id { get; set; }

    public int PartnerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string AvatarUrl { get; set; } = null!;

    public string CccdCmnd { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<BillOfLanding> BillOfLandings { get; set; } = new List<BillOfLanding>();

    public virtual Partner Partner { get; set; } = null!;
}
