using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class Tranfer
{
    public int TransferId { get; set; }

    public string TransferName { get; set; }

    public virtual ETransfer ETransfer { get; set; }
}
