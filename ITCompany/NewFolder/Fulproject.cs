using System;
using System.Collections.Generic;

namespace ITCompany.NewFolder;

public partial class Fulproject
{
    public int Id { get; set; }

    public int IdProject { get; set; }

    public string Description { get; set; } = null!;

    public int IdStatus { get; set; }

    public DateOnly DataFirst { get; set; }

    public string ManagerProject { get; set; } = null!;

    public virtual Project IdProjectNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
