using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class Course
{
    public int CourseId { get; set; }

    public int CourseNumber { get; set; }

    public string CourseName { get; set; } = null!;

    public virtual ICollection<ECourse> ECourses { get; set; } = new List<ECourse>();
}
