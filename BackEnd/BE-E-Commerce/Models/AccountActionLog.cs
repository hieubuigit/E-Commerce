using System;
using System.Collections.Generic;

namespace BE_E_Commerce.Models;

public partial class AccountActionLog
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Action { get; set; } = null!;

    public string? AdditionDetail { get; set; }

    public string IpAddress { get; set; } = null!;

    public string WebBrowserName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Account Account { get; set; } = null!;
}
