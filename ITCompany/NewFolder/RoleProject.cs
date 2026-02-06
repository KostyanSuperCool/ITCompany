using System;
using System.Collections.Generic;

namespace ITCompany.NewFolder;

public partial class RoleProject
{
    public int Id { get; set; }

    public string NameProject { get; set; } = null!;

    public virtual ICollection<AssignmentToProject> AssignmentToProjects { get; set; } = new List<AssignmentToProject>();
}
