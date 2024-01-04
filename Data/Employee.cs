using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Data;

public partial class Employee
{
    public int IdEmployees { get; set; }

    public string Name { get; set; } = null!;

    public int Identitynumber { get; set; }

    public int Employeenumber { get; set; }

    public int Gender { get; set; }
    [ForeignKey("Jop")]
    public int JopType { get; set; }
    [ForeignKey("Rank")]
    public int RankId { get; set; }

    public virtual ICollection<ECourse> ECourses { get; set; } = new List<ECourse>();

    public virtual ICollection<EJob> EJobs { get; set; } = new List<EJob>();

    public virtual ICollection<EMedel> EMedels { get; set; } = new List<EMedel>();

    public virtual ICollection<ETransfer> ETransfers { get; set; } = new List<ETransfer>();

    public virtual Jop JopTypeNavigation { get; set; } 

    public virtual Rank Rank { get; set; } 
}
