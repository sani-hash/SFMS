using System;
using System.Collections.Generic;

namespace FMS.Models;

public partial class Income
{
    public int Incomeid { get; set; }

    public DateOnly? Date { get; set; }

    public string? Type { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<Transactiondetail> Transactiondetails { get; set; } = new List<Transactiondetail>();
}
