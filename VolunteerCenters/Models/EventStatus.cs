using System;
using System.Collections.Generic;

namespace VolunteerCenters.Models;

public partial class EventStatus
{
    public int Id { get; set; }

    public string NameEventStatus { get; set; } = null!;

    public virtual ICollection<Doing> Doings { get; set; } = new List<Doing>();
}
