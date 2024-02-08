using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class Employee
{
    public int IdEmployees { get; set; }

    public string Name { get; set; }

    public int Identitynumber { get; set; }

    public int Employeenumber { get; set; }

    public int Gender { get; set; }

    public int? JopType { get; set; }

    public int RankId { get; set; }

    public bool? Enterd { get; set; }

    public bool? Audited { get; set; }

    public bool? Approved { get; set; }

    public int? Category { get; set; }

    public int? UnitId { get; set; }

    public virtual ICollection<ECourse> ECourses { get; set; } = new List<ECourse>();

    public virtual ICollection<EJob> EJobs { get; set; } = new List<EJob>();

    public virtual ICollection<EMedel> EMedels { get; set; } = new List<EMedel>();

    public virtual ICollection<ETransfer> ETransfers { get; set; } = new List<ETransfer>();

    public virtual Jop JopTypeNavigation { get; set; }

    public virtual Rank Rank { get; set; }

    public virtual Unit Unit { get; set; }
}
