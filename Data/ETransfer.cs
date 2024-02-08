using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class ETransfer
{
    public int IdTransfer { get; set; }

    public int TransferId { get; set; }

    public int IdEmployees { get; set; }

    public DateTime TransferDate { get; set; }

    public virtual Employee IdEmployeesNavigation { get; set; }

    
}
