using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class AspNetRoleMenuPermission
{
    public string RoleId { get; set; } = null!;

    public Guid NavigationMenuId { get; set; }

    public virtual AspNetNavigationMenu NavigationMenu { get; set; } = null!;
}
