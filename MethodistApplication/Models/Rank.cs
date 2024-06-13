using System;
using System.Collections.Generic;

namespace MethodistApplication;

public partial class Rank
{
    public int RankId { get; set; }

    public string? NameRank { get; set; }

    public virtual ICollection<Employeer> Employeers { get; set; } = new List<Employeer>();
}
