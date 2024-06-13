using System;
using System.Collections.Generic;

namespace MethodistApplication;

public partial class JobTitle
{
    public int JobTitleId { get; set; }

    public string? JobTitle1 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
