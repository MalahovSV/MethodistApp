using System;
using System.Collections.Generic;

namespace MethodistApplication;

public partial class Employeer
{
    public int EmployeersId { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public int? RankId { get; set; }

    public string? NumberPassport { get; set; }

    public string? SerialPassport { get; set; }

    public string? IssuidBy { get; set; }

    public DateTime? WhenIssued { get; set; }

    public string? RegistrationAddres { get; set; }

    public string? AccountNumber { get; set; }

    public string? NameBank { get; set; }

    public string? NumberSnils { get; set; }

    public DateTime? DateBirth { get; set; }

    public virtual Rank? Rank { get; set; }
}
