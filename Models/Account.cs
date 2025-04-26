using System;
using System.Collections.Generic;

namespace FMS.Models;

public partial class Account
{
    public int Accountid { get; set; }

    public string? Accountname { get; set; }

    public decimal? Balance { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
