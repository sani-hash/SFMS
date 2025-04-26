using System;
using System.Collections.Generic;

namespace FMS.Models;

public partial class Expense
{
    public int Expenseid { get; set; }

    public DateOnly? Date { get; set; }

    public string? Category { get; set; }

    public decimal? Amount { get; set; }

    public virtual ICollection<Transactiondetail> Transactiondetails { get; set; } = new List<Transactiondetail>();
}
