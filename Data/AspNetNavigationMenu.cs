using System;
using System.Collections.Generic;

namespace LearningManagementSystem.Data;

public partial class AspNetNavigationMenu
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? ParentMenuId { get; set; }

    public string Area { get; set; }

    public string ControllerName { get; set; }

    public string ActionName { get; set; }

    public bool IsExternal { get; set; }

    public string ExternalUrl { get; set; }

    public int DisplayOrder { get; set; }

    public bool Visible { get; set; }

    public virtual ICollection<AspNetRoleMenuPermission> AspNetRoleMenuPermissions { get; set; } = new List<AspNetRoleMenuPermission>();

    public virtual ICollection<AspNetNavigationMenu> InverseParentMenu { get; set; } = new List<AspNetNavigationMenu>();

    public virtual AspNetNavigationMenu ParentMenu { get; set; }
}
