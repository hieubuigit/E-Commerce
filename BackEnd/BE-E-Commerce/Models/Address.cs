using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Address
{
    public int Id { get; set; }

    public int ParentId { get; set; }

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public string? ZipCode { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Customer> CustomerCities { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerCountries { get; set; } = new List<Customer>();

    public virtual ICollection<ShippingAddress> ShippingAddressCities { get; set; } = new List<ShippingAddress>();

    public virtual ICollection<ShippingAddress> ShippingAddressCountries { get; set; } = new List<ShippingAddress>();
}
