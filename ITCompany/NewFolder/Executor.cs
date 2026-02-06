using System;
using System.Collections.Generic;

namespace ITCompany.NewFolder;

public partial class Executor
{
    public int Id { get; set; }

    public string NameExecutor { get; set; } = null!;

    public virtual ICollection<AssignmentToProject> AssignmentToProjects { get; set; } = new List<AssignmentToProject>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
