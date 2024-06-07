using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class Duration : Entity
{
    public int DurationTypeId { get; set; }

    public bool Concentration { get; set; }

    public bool Dismissable { get; set; }

    public virtual DurationType DurationType { get; set; } = null!;

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}
