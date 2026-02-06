using System;
using System.Collections.Generic;

namespace ITCompany.NewFolder;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public int IdRole { get; set; }

    public int IdExecutors { get; set; }

    public string Password { get; set; } = null!;

    public virtual Executor IdExecutorsNavigation { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
