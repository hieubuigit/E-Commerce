using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class Common
{
    public int Id { get; set; }

    public int Category { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
