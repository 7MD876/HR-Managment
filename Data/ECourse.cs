using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class ECourse
{
    public int IdemployeesCourses { get; set; }

    public int Idemployees { get; set; }

    public int CourseId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Rating { get; set; }

    public virtual Course Course { get; set; }

    public virtual Employee IdemployeesNavigation { get; set; }
}
