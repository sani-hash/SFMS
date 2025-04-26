using System;
using System.Collections.Generic;

namespace FMS.Models;

public partial class Transaction
{
    public int Transactionid { get; set; }

    public DateOnly? Date { get; set; }

    public int? Accountid { get; set; }

    public string? Type { get; set; }

    public decimal? Amount { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Transactiondetail? Transactiondetail { get; set; }
}
