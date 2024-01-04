using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class Jop
{
    public int Idjops { get; set; }

    public string JopName { get; set; } = null!;

    public virtual ICollection<EJob> EJobs { get; set; } = new List<EJob>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
