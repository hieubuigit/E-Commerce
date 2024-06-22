using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class ProductResource
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Url { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
