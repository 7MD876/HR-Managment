using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class Unit
{
    public int UnitId { get; set; }

    public string UnitName { get; set; }

    public int UnitNumber { get; set; }

    public virtual ICollection<ETransfer> ETransferFromUnitNavigations { get; set; } = new List<ETransfer>();

    public virtual ICollection<ETransfer> ETransferToUnitNavigations { get; set; } = new List<ETransfer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
