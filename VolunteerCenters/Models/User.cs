using System;
using System.Collections.Generic;

namespace VolunteerCenters.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int IdRole { get; set; }

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Doing> Doings { get; set; } = new List<Doing>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<VolunteerRegistration> VolunteerRegistrations { get; set; } = new List<VolunteerRegistration>();
}
