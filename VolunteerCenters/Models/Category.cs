using System;
using System.Collections.Generic;

namespace VolunteerCenters.Models;

public partial class Category
{
    public int Id { get; set; }

    public string NameCategori { get; set; } = null!;

    public virtual ICollection<Doing> Doings { get; set; } = new List<Doing>();
}
