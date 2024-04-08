﻿using System;
using System.Collections.Generic;

namespace HRMSAPPLICATION.Models;

public partial class PaymJobStatus
{
    public int PnCompanyId { get; set; }

    public int BranchId { get; set; }

    public int PnJobStatusId { get; set; }

    public string VJobStatusName { get; set; } = null!;

    public string? Status { get; set; }

    public virtual PaymCompany PnCompany { get; set; } = null!;
}
