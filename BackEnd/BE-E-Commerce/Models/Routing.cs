using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Routing
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string Link { get; set; } = null!;

    public int Type { get; set; }

    public bool? IsDisabled { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
