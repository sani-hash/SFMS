using System;
using System.Collections.Generic;

namespace FMS.Models;

public partial class Transactiondetail
{
    public int Transactionid { get; set; }

    public int? Incomeid { get; set; }

    public int? Expenseid { get; set; }

    public virtual Expense? Expense { get; set; }

    public virtual Income? Income { get; set; }

    public virtual Transaction Transaction { get; set; } = null!;
}
