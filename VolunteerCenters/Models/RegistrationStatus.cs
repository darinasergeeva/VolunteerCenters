using System;
using System.Collections.Generic;

namespace VolunteerCenters;

public partial class RegistrationStatus
{
    public int Id { get; set; }

    public string NameRegistrationStatus { get; set; } = null!;

    public virtual ICollection<VolunteerRegistration> VolunteerRegistrations { get; set; } = new List<VolunteerRegistration>();
}
