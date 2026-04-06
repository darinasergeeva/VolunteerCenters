using System;
using System.Collections.Generic;

namespace VolunteerCenters.Models;

public partial class Doing
{
    public int Id { get; set; }

    public int IdEvent { get; set; }

    public int IdCategori { get; set; }

    public DateOnly DateDoing { get; set; }

    public string Place { get; set; } = null!;

    public int VolunteersNeeded { get; set; }

    public int IdUser { get; set; }

    public int IdEventStatus { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;

    public virtual EventStatus EventStatus { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
