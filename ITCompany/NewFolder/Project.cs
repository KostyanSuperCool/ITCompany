using System;
using System.Collections.Generic;

namespace ITCompany.NewFolder;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public virtual ICollection<AssignmentToProject> AssignmentToProjects { get; set; } = new List<AssignmentToProject>();

    public virtual ICollection<Fulproject> Fulprojects { get; set; } = new List<Fulproject>();
}
