using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class Rank
{
    public int Idrank { get; set; }

    public string Rankname { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
