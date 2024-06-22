using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class ShippingAddress
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Address { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public int CityId { get; set; }

    public int CountryId { get; set; }

    public string District { get; set; } = null!;

    public string Ward { get; set; } = null!;

    public bool? IsDefault { get; set; }

    public string? PostalCode { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Address City { get; set; } = null!;

    public virtual Address Country { get; set; } = null!;
}
