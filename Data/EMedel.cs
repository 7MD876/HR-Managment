using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class EMedel
{
    public int IdeMedals { get; set; }

    public int MedalsId { get; set; }

    public string DateMedals { get; set; }

    public int Idemployees { get; set; }

    public virtual Employee IdemployeesNavigation { get; set; }

    public virtual Medel Medals { get; set; }
}
