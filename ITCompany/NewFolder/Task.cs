using System;
using System.Collections.Generic;

namespace ITCompany.NewFolder;

public partial class Task
{
    public int Id { get; set; }

    public string NameTasks { get; set; } = null!;

    public int IdProjectName { get; set; }

    public int IdFullProject { get; set; }

    public DateOnly DateExecution { get; set; }

    public virtual Fulproject IdFullProjectNavigation { get; set; } = null!;

    public virtual AssignmentToProject IdProjectNameNavigation { get; set; } = null!;
}
