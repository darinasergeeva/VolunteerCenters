using System;
using System.Collections.Generic;

namespace VolunteerCenters.Models;

public partial class Event
{
    public int Id { get; set; }

    public string NameEvent { get; set; } = null!;

    public virtual ICollection<Doing> Doings { get; set; } = new List<Doing>();

    public virtual ICollection<VolunteerRegistration> VolunteerRegistrations { get; set; } = new List<VolunteerRegistration>();
}
