using System;
using System.Collections.Generic;

namespace ITCompany.NewFolder;

public partial class Status
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Fulproject> Fulprojects { get; set; } = new List<Fulproject>();
}
