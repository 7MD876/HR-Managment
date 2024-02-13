using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class Rejection
{
    public int Id { get; set; }

    public string RejectReason { get; set; }

    public int IdEmployee { get; set; }

    public bool? IsActive { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; }
}
