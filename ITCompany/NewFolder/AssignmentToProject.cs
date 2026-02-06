using System;
using System.Collections.Generic;

namespace ITCompany.NewFolder;

public partial class AssignmentToProject
{
    public int Id { get; set; }

    public int IdProject { get; set; }

    public int IdExecutors { get; set; }

    public int IdRoleProject { get; set; }

    public virtual Executor IdExecutorsNavigation { get; set; } = null!;

    public virtual Project IdProjectNavigation { get; set; } = null!;

    public virtual RoleProject IdRoleProjectNavigation { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
