using System;
using System.Collections.Generic;

namespace VolunteerCenters.Models;

public partial class VolunteerRegistration
{
    public int Id { get; set; }

    public int IdEvent { get; set; }

    public int IdUser { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public int IdRegistrationStatus { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual RegistrationStatus RegistrationStatus { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
}
