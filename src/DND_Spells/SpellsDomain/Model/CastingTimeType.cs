using System;
using System.Collections.Generic;

namespace SpellsDomain.Model;

public partial class CastingTimeType : Entity
{
    public byte CastingTimeTypeId { get; set; }

    public int Value { get; set; }

    public string Label { get; set; } = null!;

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}
