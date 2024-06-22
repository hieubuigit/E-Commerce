using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Review
{
    public long Id { get; set; }

    public int ProductId { get; set; }

    public int AccountId { get; set; }

    public int? ParentId { get; set; }

    public double? Rating { get; set; }

    public string? Comment { get; set; }

    public bool? IsHide { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<ReviewFile> ReviewFiles { get; set; } = new List<ReviewFile>();
}
