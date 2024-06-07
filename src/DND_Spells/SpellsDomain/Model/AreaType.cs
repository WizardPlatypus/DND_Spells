using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class AreaType : Entity
{
    public int AreaTypeId { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
}
