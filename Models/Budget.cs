using System;
using System.Collections.Generic;

namespace FMS.Models;

public partial class Budget
{
    public int Budgetid { get; set; }

    public int? Year { get; set; }

    public string? Category { get; set; }

    public decimal? Allocatedamount { get; set; }
}
