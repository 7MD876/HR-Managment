using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class Medel
{
    public int Idmedels { get; set; }

    public string MedelsName { get; set; }

    public virtual ICollection<EMedel> EMedels { get; set; } = new List<EMedel>();
}
