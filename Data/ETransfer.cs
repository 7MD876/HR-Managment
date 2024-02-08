using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class ETransfer
{
    public int IdTransfer { get; set; }

    public int TransferId { get; set; }

    public int IdEmployees { get; set; }

    public string TransferDate { get; set; }

    public int? FromUnit { get; set; }

    public int? ToUnit { get; set; }

    public virtual Unit FromUnitNavigation { get; set; }

    public virtual Employee IdEmployeesNavigation { get; set; }

    public virtual Unit ToUnitNavigation { get; set; }

    public virtual Tranfer Transfer { get; set; }
}
