using System;
using System.Collections.Generic;

namespace MethodistApplication;

public partial class User
{
    public int UserId { get; set; }

    public string LoginUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Surname { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public int? JobTitleId { get; set; }

    public virtual JobTitle? JobTitle { get; set; }
}
