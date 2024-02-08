using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class Tranfer
{
    public int TransferId { get; set; }

    public string TransferName { get; set; }

    public virtual ICollection<ETransfer> ETransfers { get; set; } = new List<ETransfer>();
}
