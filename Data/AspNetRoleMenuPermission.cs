using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class AspNetRoleMenuPermission
{
    public string RoleId { get; set; }

    public Guid NavigationMenuId { get; set; }

    public virtual AspNetNavigationMenu NavigationMenu { get; set; }
}
