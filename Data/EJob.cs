using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class EJob
{
    public int EJobsId { get; set; }

    public int EmployeeId { get; set; }

    public int JobId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Jop Job { get; set; } = null!;
}
