using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class ReviewFile
{
    public long Id { get; set; }

    public long ReviewId { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Review Review { get; set; } = null!;
}
