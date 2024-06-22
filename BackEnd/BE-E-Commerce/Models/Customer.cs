using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Customer
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? AvatarUrl { get; set; }

    public int Gender { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public string? District { get; set; }

    public string? Ward { get; set; }

    public string? Street { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Address? City { get; set; }

    public virtual Address? Country { get; set; }

    public virtual Account IdNavigation { get; set; } = null!;
}
